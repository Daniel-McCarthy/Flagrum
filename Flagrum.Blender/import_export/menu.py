import json
import math
import os
from types import SimpleNamespace

import bpy
from bpy.props import StringProperty, FloatProperty, BoolProperty
from bpy.types import Operator, Menu
from bpy_extras.io_utils import ImportHelper, ExportHelper

from .export_context import ExportContext
from .generate_armature import generate_armature
from .generate_mesh import generate_mesh
from .import_context import ImportContext
from .interop import Interop
from .pack_mesh import pack_mesh
from .read_armature_data import import_armature_data
from ..entities import EnvironmentModelMetadata, Gpubin


class ImportOperator(Operator, ImportHelper):
    """Imports data from a Luminous Engine model"""
    bl_idname = "flagrum.gfxbin_import"
    bl_label = "Import FFXV Model (.gfxbin)"
    filename_ext = ".gfxbin"

    filter_glob: StringProperty(
        default="*.gfxbin",
        options={'HIDDEN'}
    )

    def execute(self, context):
        import_context = ImportContext(self.filepath)

        mesh_data = Interop.import_mesh(import_context.gfxbin_path)

        if len(mesh_data.BoneTable.__dict__) > 0:
            armature_data = import_armature_data(import_context)
            generate_armature(import_context, armature_data)

        for mesh in mesh_data.Meshes:
            generate_mesh(import_context,
                          collection=import_context.collection,
                          mesh_data=mesh,
                          bone_table=mesh_data.BoneTable.__dict__,
                          use_blue_normals=True)

        return {'FINISHED'}


class ExportOperator(Operator, ExportHelper):
    """Exports a mod data package for use with Flagrum"""
    bl_idname = "flagrum.gfxbin_export"
    bl_label = "Export to Flagrum"
    filename_ext = ".fmd"

    filter_glob: StringProperty(
        default="*.fmd",
        options={'HIDDEN'}
    )

    smooth_normals: BoolProperty(
        name="Smooth Normals on Doubles",
        description="When the exporter splits edges for compatibility with FFXV, this functionality will smooth "
                    "the seams caused by the edge-splitting",
        default=False
    )

    distance: FloatProperty(
        name="Distance",
        description="The maximum distance between doubles for which to merge normals",
        default=0.0001,
        min=0.0001,
        precision=4
    )

    def draw(self, context):
        layout = self.layout
        layout.label(text="FMD Export Options")
        layout.prop(self, property="smooth_normals")
        layout.prop(self, property="distance")

    def execute(self, context):
        export_context = ExportContext(self.smooth_normals, self.distance)
        data = pack_mesh(export_context)
        Interop.export_mesh(self.filepath, data)

        return {'FINISHED'}


class ImportEnvironmentOperator(Operator, ImportHelper):
    """Imports data from a Flagrum Environment Pack"""
    bl_idname = "flagrum.environment_import"
    bl_label = "Import Flagrum Environment (.fed)"
    filename_ext = ".fed"

    filter_glob: StringProperty(
        default="*.fed",
        options={'HIDDEN'}
    )

    def execute(self, context):
        environment_path = self.filepath
        directory = os.path.dirname(environment_path)
        filename_without_extension = environment_path.split("\\")[-1].replace(".fed", "")
        context = ImportContext(environment_path)

        import_file = open(environment_path, mode='r')
        import_data = import_file.read()

        data: list[EnvironmentModelMetadata] = json.loads(import_data, object_hook=lambda d: SimpleNamespace(**d))
        meshes = {}

        for model in data:
            if model.Index < 1:
                continue

            mesh_data = None
            if model.Index in meshes:
                if model.PrefabName not in bpy.context.scene.collection.children:
                    collection = bpy.data.collections.new(model.PrefabName)
                    bpy.context.scene.collection.children.link(collection)
                else:
                    collection = bpy.data.collections[model.PrefabName]

                for original_mesh in meshes[model.Index]:
                    mesh = original_mesh.copy()
                    collection.objects.link(mesh)
                    mesh["Model URI"] = model.Path
                    mesh.scale = [model.Scale, model.Scale, model.Scale]
                    mesh.rotation_euler = [math.radians(model.Rotation[0]), math.radians(abs(model.Rotation[2] * -1)),
                                           math.radians(model.Rotation[1])]
                    mesh.location = [model.Position[0], model.Position[2] * -1, model.Position[1]]
            else:
                try:
                    path = directory + "\\" + filename_without_extension + "_models\\" + str(model.Index) + ".json"
                    mesh_file = open(path, mode='r')
                    mesh_file_data = mesh_file.read()
                    mesh_data: Gpubin = json.loads(mesh_file_data, object_hook=lambda d: SimpleNamespace(**d))
                except:
                    print("Failed to load " + model.Path)

                if mesh_data is not None:
                    self.import_mesh(context, mesh_data, model, directory, meshes)

        for texture_slot in context.texture_slots:
            print(texture_slot)

        return {'FINISHED'}

    def import_mesh(self, context: ImportContext, mesh_data: Gpubin, model: EnvironmentModelMetadata, directory,
                    meshes):
        for mesh_metadata in mesh_data.Meshes:
            # Create or get the collection for this prefab
            if model.PrefabName not in bpy.context.scene.collection.children:
                collection = bpy.data.collections.new(model.PrefabName)
                bpy.context.scene.collection.children.link(collection)
            else:
                collection = bpy.data.collections[model.PrefabName]

            # Import the mesh and position it according to the level data
            mesh = generate_mesh(context, collection, mesh_metadata, [], use_blue_normals=False)
            mesh["Model URI"] = model.Path
            mesh.scale = [model.Scale, model.Scale, model.Scale]
            mesh.rotation_euler = [math.radians(model.Rotation[0]), math.radians(abs(model.Rotation[2] * -1)),
                                   math.radians(model.Rotation[1])]
            mesh.location = [model.Position[0], model.Position[2] * -1, model.Position[1]]

            if model.Index in meshes:
                meshes[model.Index].append(mesh)
            else:
                meshes[model.Index] = []
                meshes[model.Index].append(mesh)


class FlagrumImportMenu(Menu):
    bl_idname = "flagrum.import"
    bl_label = "Flagrum"

    def draw(self, context):
        layout = self.layout
        layout.operator(ImportOperator.bl_idname)
        layout.operator(ImportEnvironmentOperator.bl_idname)
