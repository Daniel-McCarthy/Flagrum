# -*- coding: utf-8 -*-
# Generated by the protocol buffer compiler.  DO NOT EDIT!
# source: google/protobuf/internal/any_test.proto
"""Generated protocol buffer code."""
from ....google.protobuf import descriptor as _descriptor
from ....google.protobuf import descriptor_pool as _descriptor_pool
from ....google.protobuf import symbol_database as _symbol_database
from ....google.protobuf.internal import builder as _builder

# @@protoc_insertion_point(imports)

_sym_db = _symbol_database.Default()

DESCRIPTOR = _descriptor_pool.Default().AddSerializedFile(
    b'\n\'google/protobuf/internal/any_test.proto\x12\x18google.protobuf.internal\x1a\x19google/protobuf/any.proto\"\xc0\x01\n\x07TestAny\x12#\n\x05value\x18\x01 \x01(\x0b\x32\x14.google.protobuf.Any\x12\x11\n\tint_value\x18\x02 \x01(\x05\x12\x42\n\tmap_value\x18\x03 \x03(\x0b\x32/.google.protobuf.internal.TestAny.MapValueEntry\x1a/\n\rMapValueEntry\x12\x0b\n\x03key\x18\x01 \x01(\t\x12\r\n\x05value\x18\x02 \x01(\x05:\x02\x38\x01*\x08\x08\n\x10\x80\x80\x80\x80\x02\"\x85\x01\n\x11TestAnyExtension1\x12\t\n\x01i\x18\x0f \x01(\x05\x32\x65\n\nextension1\x12!.google.protobuf.internal.TestAny\x18\xab\xff\xf6. \x01(\x0b\x32+.google.protobuf.internal.TestAnyExtension1')

_builder.BuildMessageAndEnumDescriptors(DESCRIPTOR, globals())
_builder.BuildTopDescriptorsAndMessages(DESCRIPTOR, 'google.protobuf.internal.any_test_pb2', globals())
if _descriptor._USE_C_DESCRIPTORS == False:
    TestAny.RegisterExtension(_TESTANYEXTENSION1.extensions_by_name['extension1'])

    DESCRIPTOR._options = None
    _TESTANY_MAPVALUEENTRY._options = None
    _TESTANY_MAPVALUEENTRY._serialized_options = b'8\001'
    _TESTANY._serialized_start = 97
    _TESTANY._serialized_end = 289
    _TESTANY_MAPVALUEENTRY._serialized_start = 232
    _TESTANY_MAPVALUEENTRY._serialized_end = 279
    _TESTANYEXTENSION1._serialized_start = 292
    _TESTANYEXTENSION1._serialized_end = 425
# @@protoc_insertion_point(module_scope)
