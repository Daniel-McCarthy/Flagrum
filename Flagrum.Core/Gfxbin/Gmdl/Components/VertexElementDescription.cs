﻿using System.Linq;
using Flagrum.Core.Utilities.Types;

namespace Flagrum.Core.Gfxbin.Gmdl.Components;

public enum VertexElementFormat
{
    Disable = 0x0,
    XYZW32_Float = 0x1,
    XYZW32_UintN = 0x2,
    XYZW32_Uint = 0x3,
    XYZW32_SintN = 0x4,
    XYZW32_Sint = 0x5,
    XYZW16_Float = 0x6,
    XYZW16_UintN = 0x7,
    XYZW16_Uint = 0x8,
    XYZW16_SintN = 0x9,
    XYZW16_Sint = 0xA,
    XYZW8_Float = 0xB,
    XYZW8_UintN = 0xC,
    XYZW8_Uint = 0xD,
    XYZW8_SintN = 0xE,
    XYZW8_Sint = 0xF,
    XYZ32_Float = 0x10,
    XYZ32_UintN = 0x11,
    XYZ32_Uint = 0x12,
    XYZ32_SintN = 0x13,
    XYZ32_Sint = 0x14,
    XY32_Float = 0x15,
    XY32_UintN = 0x16,
    XY32_Uint = 0x17,
    XY32_SintN = 0x18,
    XY32_Sint = 0x19,
    XY16_Float = 0x1A,
    XY16_UintN = 0x1B,
    XY16_Uint = 0x1C,
    XY16_SintN = 0x1D,
    XY16_Sint = 0x1E,
    X32_Float = 0x1F,
    X32_UintN = 0x20,
    X32_Uint = 0x21,
    X32_SintN = 0x22,
    X32_Sint = 0x23,
    X16_Float = 0x24,
    X16_UintN = 0x25,
    X16_Uint = 0x26,
    X16_SintN = 0x27,
    X16_Sint = 0x28,
    X8_Float = 0x29,
    X8_UintN = 0x2A,
    X8_Uint = 0x2B,
    X8_SintN = 0x2C,
    X8_Sint = 0x2D,
    Num = 0x2E
}

public class VertexElementSemantic : Enum<string>
{
    private VertexElementSemantic(string value) : base(value) { }

    public static VertexElementSemantic Position0 => new("POSITION0");
    public static VertexElementSemantic Normal0 => new("NORMAL0");
    public static VertexElementSemantic Color0 => new("COLOR0");
    public static VertexElementSemantic Color1 => new("COLOR1");
    public static VertexElementSemantic Color2 => new("COLOR2");
    public static VertexElementSemantic Color3 => new("COLOR3");
    public static VertexElementSemantic TexCoord0 => new("TEXCOORD0");
    public static VertexElementSemantic TexCoord1 => new("TEXCOORD1");
    public static VertexElementSemantic TexCoord2 => new("TEXCOORD2");
    public static VertexElementSemantic TexCoord3 => new("TEXCOORD3");
    public static VertexElementSemantic TexCoord4 => new("TEXCOORD4");
    public static VertexElementSemantic TexCoord5 => new("TEXCOORD5");
    public static VertexElementSemantic TexCoord6 => new("TEXCOORD6");
    public static VertexElementSemantic TexCoord7 => new("TEXCOORD7");
    public static VertexElementSemantic BlendWeight0 => new("BLENDWEIGHT0");
    public static VertexElementSemantic BlendWeight1 => new("BLENDWEIGHT1");
    public static VertexElementSemantic BlendIndices0 => new("BLENDINDICES0");
    public static VertexElementSemantic BlendIndices1 => new("BLENDINDICES1");
    public static VertexElementSemantic Tangent0 => new("TANGENT0");
    public static VertexElementSemantic Tangent1 => new("TANGENT1");
    public static VertexElementSemantic Binormal0 => new("BINORMAL0");
    public static VertexElementSemantic Binormal1 => new("BINORMAL1");
    public static VertexElementSemantic Normal2Factors => new("NORMAL2FACTORS0");
    public static VertexElementSemantic Normal4Factors => new("NORMAL4FACTORS0");
    public static VertexElementSemantic FogCoord0 => new("FOGCOORD0");
    public static VertexElementSemantic PSize0 => new("PSIZE0");

    public static explicit operator VertexElementSemantic(string name)
    {
        return GetAll<VertexElementSemantic>().First(e => e.Value == name);
    }
}

public class VertexElementDescription
{
    // Positions of each of the vertices in the mesh
    public const string Position0 = "POSITION0";

    // Per-vertex normals (stored as sbyte XYZW)
    public const string Normal0 = "NORMAL0";

    // Vertex colour layers for this mesh
    public const string Color0 = "COLOR0";
    public const string Color1 = "COLOR1";
    public const string Color2 = "COLOR2";
    public const string Color3 = "COLOR3";

    // UV maps for this mesh
    public const string TexCoord0 = "TEXCOORD0"; // map0
    public const string TexCoord1 = "TEXCOORD1"; // mapLM
    public const string TexCoord2 = "TEXCOORD2";
    public const string TexCoord3 = "TEXCOORD3";
    public const string TexCoord4 = "TEXCOORD4";
    public const string TexCoord5 = "TEXCOORD5";
    public const string TexCoord6 = "TEXCOORD6";
    public const string TexCoord7 = "TEXCOORD7";

    // Weight values for this mesh (4 per vertex per weight map)
    // Vertices with <4 weights have extras stored as 0 weights
    public const string BlendWeight0 = "BLENDWEIGHT0";
    public const string BlendWeight1 = "BLENDWEIGHT1";

    // Bone indices which the corresponding weights apply to (1 per weight value)
    public const string BlendIndices0 = "BLENDINDICES0";
    public const string BlendIndices1 = "BLENDINDICES1";

    // Tangents for this mesh, currently not using
    public const string Tangent0 = "TANGENT0";
    public const string Tangent1 = "TANGENT1";

    // All of these are somewhat unknown and often empty on game assets
    // More research needed to uncover their purpose
    // We suspect different asset types use these for specific purposes
    public const string Binormal0 = "BINORMAL0";
    public const string Binormal1 = "BINORMAL1";
    public const string Normal2Factors = "NORMAL2FACTORS0";
    public const string Normal4Factors = "NORMAL4FACTORS0";
    public const string FogCoord0 = "FOGCOORD0";
    public const string PSize0 = "PSIZE0";

    public uint Offset { get; set; }
    public string Semantic { get; set; }
    public VertexElementFormat Format { get; set; }
}