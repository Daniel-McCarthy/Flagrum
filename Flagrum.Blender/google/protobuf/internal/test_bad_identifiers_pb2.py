# -*- coding: utf-8 -*-
# Generated by the protocol buffer compiler.  DO NOT EDIT!
# source: google/protobuf/internal/test_bad_identifiers.proto
"""Generated protocol buffer code."""
from ....google.protobuf import descriptor as _descriptor
from ....google.protobuf import descriptor_pool as _descriptor_pool
from ....google.protobuf import symbol_database as _symbol_database
from ....google.protobuf.internal import builder as _builder

# @@protoc_insertion_point(imports)

_sym_db = _symbol_database.Default()

DESCRIPTOR = _descriptor_pool.Default().AddSerializedFile(
    b'\n3google/protobuf/internal/test_bad_identifiers.proto\x12\x11protobuf_unittest\"\x1e\n\x12TestBadIdentifiers*\x08\x08\x64\x10\x80\x80\x80\x80\x02\"\x10\n\x0e\x41notherMessage2\x10\n\x0e\x41notherService:;\n\x07message\x12%.protobuf_unittest.TestBadIdentifiers\x18\x64 \x01(\t:\x03\x66oo:>\n\ndescriptor\x12%.protobuf_unittest.TestBadIdentifiers\x18\x65 \x01(\t:\x03\x62\x61r:>\n\nreflection\x12%.protobuf_unittest.TestBadIdentifiers\x18\x66 \x01(\t:\x03\x62\x61z:;\n\x07service\x12%.protobuf_unittest.TestBadIdentifiers\x18g \x01(\t:\x03quxB\x03\x90\x01\x01')

_builder.BuildMessageAndEnumDescriptors(DESCRIPTOR, globals())
_builder.BuildTopDescriptorsAndMessages(DESCRIPTOR, 'google.protobuf.internal.test_bad_identifiers_pb2', globals())
if _descriptor._USE_C_DESCRIPTORS == False:
    TestBadIdentifiers.RegisterExtension(message)
    TestBadIdentifiers.RegisterExtension(descriptor)
    TestBadIdentifiers.RegisterExtension(reflection)
    TestBadIdentifiers.RegisterExtension(service)

    DESCRIPTOR._options = None
    DESCRIPTOR._serialized_options = b'\220\001\001'
    _TESTBADIDENTIFIERS._serialized_start = 74
    _TESTBADIDENTIFIERS._serialized_end = 104
    _ANOTHERMESSAGE._serialized_start = 106
    _ANOTHERMESSAGE._serialized_end = 122
    _ANOTHERSERVICE._serialized_start = 124
    _ANOTHERSERVICE._serialized_end = 140
_builder.BuildServices(DESCRIPTOR, 'google.protobuf.internal.test_bad_identifiers_pb2', globals())
# @@protoc_insertion_point(module_scope)
