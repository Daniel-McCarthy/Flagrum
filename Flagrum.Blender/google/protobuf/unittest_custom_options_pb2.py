# -*- coding: utf-8 -*-
# Generated by the protocol buffer compiler.  DO NOT EDIT!
# source: google/protobuf/unittest_custom_options.proto
"""Generated protocol buffer code."""
from ...google.protobuf import descriptor as _descriptor
from ...google.protobuf import descriptor_pool as _descriptor_pool
from ...google.protobuf import symbol_database as _symbol_database
from ...google.protobuf.internal import builder as _builder

# @@protoc_insertion_point(imports)

_sym_db = _symbol_database.Default()

from ...google.protobuf import descriptor_pb2 as google_dot_protobuf_dot_descriptor__pb2

DESCRIPTOR = _descriptor_pool.Default().AddSerializedFile(
    b'\n-google/protobuf/unittest_custom_options.proto\x12\x11protobuf_unittest\x1a\x19google/protobuf/any.proto\x1a google/protobuf/descriptor.proto\"\xd0\x02\n\x1cTestMessageWithCustomOptions\x12\x1e\n\x06\x66ield1\x18\x01 \x01(\tB\x0e\x08\x01\xc1\xe0\xc3\x1d-\xe1u\n\x02\x00\x00\x00\x12\x15\n\x0boneof_field\x18\x02 \x01(\x05H\x00\x12^\n\tmap_field\x18\x03 \x03(\x0b\x32=.protobuf_unittest.TestMessageWithCustomOptions.MapFieldEntryB\x0c\xc1\xe0\xc3\x1d\x39\x30\x00\x00\x00\x00\x00\x00\x1a/\n\rMapFieldEntry\x12\x0b\n\x03key\x18\x01 \x01(\t\x12\r\n\x05value\x18\x02 \x01(\t:\x02\x38\x01\";\n\x06\x41nEnum\x12\x0f\n\x0b\x41NENUM_VAL1\x10\x01\x12\x16\n\x0b\x41NENUM_VAL2\x10\x02\x1a\x05\xb0\x86\xfa\x05{\x1a\x08\xc5\xf6\xc9\x1d\xeb\xfc\xff\xff:\x10\x08\x00\xe0\xe9\xc2\x1d\xc8\xff\xff\xff\xff\xff\xff\xff\xff\x01\x42\x19\n\x07\x41nOneof\x12\x0e\xf8\xac\xc3\x1d\x9d\xff\xff\xff\xff\xff\xff\xff\xff\x01\"\x18\n\x16\x43ustomOptionFooRequest\"\x19\n\x17\x43ustomOptionFooResponse\"\x1e\n\x1c\x43ustomOptionFooClientMessage\"\x1e\n\x1c\x43ustomOptionFooServerMessage\"m\n\x1a\x44ummyMessageContainingEnum\"O\n\x0cTestEnumType\x12\x1a\n\x16TEST_OPTION_ENUM_TYPE1\x10\x16\x12#\n\x16TEST_OPTION_ENUM_TYPE2\x10\xe9\xff\xff\xff\xff\xff\xff\xff\xff\x01\"!\n\x1f\x44ummyMessageInvalidAsOptionType\"\x8a\x01\n\x1c\x43ustomOptionMinIntegerValues:j\xd0\xde\xb2\x1d\x00\xe8\xc6\xb2\x1d\x80\x80\x80\x80\xf8\xff\xff\xff\xff\x01\xb0\xbc\xb2\x1d\x80\x80\x80\x80\x80\x80\x80\x80\x80\x01\x80\x93\xb2\x1d\x00\xf8\xf5\xb0\x1d\x00\x80\xc4\xb0\x1d\xff\xff\xff\xff\x0f\xf8\x97\xb0\x1d\xff\xff\xff\xff\xff\xff\xff\xff\xff\x01\x9d\xf5\xaf\x1d\x00\x00\x00\x00\x91\xee\xaf\x1d\x00\x00\x00\x00\x00\x00\x00\x00\xad\x8d\xaf\x1d\x00\x00\x00\x80\x99\xd6\xa8\x1d\x00\x00\x00\x00\x00\x00\x00\x80\"\x91\x01\n\x1c\x43ustomOptionMaxIntegerValues:q\xd0\xde\xb2\x1d\x01\xe8\xc6\xb2\x1d\xff\xff\xff\xff\x07\xb0\xbc\xb2\x1d\xff\xff\xff\xff\xff\xff\xff\xff\x7f\x80\x93\xb2\x1d\xff\xff\xff\xff\x0f\xf8\xf5\xb0\x1d\xff\xff\xff\xff\xff\xff\xff\xff\xff\x01\x80\xc4\xb0\x1d\xfe\xff\xff\xff\x0f\xf8\x97\xb0\x1d\xfe\xff\xff\xff\xff\xff\xff\xff\xff\x01\x9d\xf5\xaf\x1d\xff\xff\xff\xff\x91\xee\xaf\x1d\xff\xff\xff\xff\xff\xff\xff\xff\xad\x8d\xaf\x1d\xff\xff\xff\x7f\x99\xd6\xa8\x1d\xff\xff\xff\xff\xff\xff\xff\x7f\"n\n\x17\x43ustomOptionOtherValues:S\xe8\xc6\xb2\x1d\x9c\xff\xff\xff\xff\xff\xff\xff\xff\x01\xf5\xdf\xa3\x1d\xe7\x87\x45\x41\xe9\xdc\xa2\x1d\xfbY\x8c\x42\xca\xc0\xf3?\xaa\xdc\xa2\x1d\x0eHello, \"World\"\xb2\xd9\xa2\x1d\x0bHello\x00World\x88\xd9\xa2\x1d\xe9\xff\xff\xff\xff\xff\xff\xff\xff\x01\"4\n\x1cSettingRealsFromPositiveInts:\x14\xf5\xdf\xa3\x1d\x00\x00@A\xe9\xdc\xa2\x1d\x00\x00\x00\x00\x00@c@\"4\n\x1cSettingRealsFromNegativeInts:\x14\xf5\xdf\xa3\x1d\x00\x00@\xc1\xe9\xdc\xa2\x1d\x00\x00\x00\x00\x00@c\xc0\"U\n\x12\x43omplexOptionType1\x12\x0b\n\x03\x66oo\x18\x01 \x01(\x05\x12\x0c\n\x04\x66oo2\x18\x02 \x01(\x05\x12\x0c\n\x04\x66oo3\x18\x03 \x01(\x05\x12\x0c\n\x04\x66oo4\x18\x04 \x03(\x05*\x08\x08\x64\x10\x80\x80\x80\x80\x02\"\x8b\x03\n\x12\x43omplexOptionType2\x12\x32\n\x03\x62\x61r\x18\x01 \x01(\x0b\x32%.protobuf_unittest.ComplexOptionType1\x12\x0b\n\x03\x62\x61z\x18\x02 \x01(\x05\x12\x46\n\x04\x66red\x18\x03 \x01(\x0b\x32\x38.protobuf_unittest.ComplexOptionType2.ComplexOptionType4\x12H\n\x06\x62\x61rney\x18\x04 \x03(\x0b\x32\x38.protobuf_unittest.ComplexOptionType2.ComplexOptionType4\x1a\x97\x01\n\x12\x43omplexOptionType4\x12\r\n\x05waldo\x18\x01 \x01(\x05\x32r\n\x0c\x63omplex_opt4\x12\x1f.google.protobuf.MessageOptions\x18\x8a\xf5\xd1\x03 \x01(\x0b\x32\x38.protobuf_unittest.ComplexOptionType2.ComplexOptionType4*\x08\x08\x64\x10\x80\x80\x80\x80\x02\"\x9c\x01\n\x12\x43omplexOptionType3\x12\x0b\n\x03moo\x18\x01 \x01(\x05\x12T\n\x12\x63omplexoptiontype5\x18\x02 \x01(\n28.protobuf_unittest.ComplexOptionType3.ComplexOptionType5\x1a#\n\x12\x43omplexOptionType5\x12\r\n\x05plugh\x18\x03 \x01(\x05\"\x1f\n\x0b\x43omplexOpt6\x12\x10\n\x05xyzzy\x18\xdf\xbf\xcf\x03 \x01(\x05\"\xf1\x01\n\x15VariousComplexOptions:\xd7\x01\xa2\xe2\x95\x1d\x02\x08*\xa2\xe2\x95\x1d\x06\xd8\x85\x9e\x1d\xc4\x02\xa2\xe2\x95\x1d\x08\x92\xf5\x9d\x1d\x03\x08\xec\x06\xa2\xe2\x95\x1d\x02 c\xa2\xe2\x95\x1d\x02 X\xaa\xfd\x90\x1d\x03\x10\xdb\x07\xaa\xfd\x90\x1d\x06\xf8\xe6\x97\x1d\x8e\x05\xaa\xfd\x90\x1d\x05\n\x03\x08\xe7\x05\xaa\xfd\x90\x1d\x08\n\x06\xd8\x85\x9e\x1d\xcf\x0f\xaa\xfd\x90\x1d\n\n\x08\x92\xf5\x9d\x1d\x03\x08\xd8\x0f\xaa\xfd\x90\x1d\x08\xc2\xac\x97\x1d\x03\x08\xe5\x05\xaa\xfd\x90\x1d\x0b\xc2\xac\x97\x1d\x06\xd8\x85\x9e\x1d\xce\x0f\xaa\xfd\x90\x1d\r\xc2\xac\x97\x1d\x08\x92\xf5\x9d\x1d\x03\x08\xc9\x10\xd2\xa8\x8f\x1d\x03\x08\xb3\x0f\xaa\xfd\x90\x1d\x05\x1a\x03\x08\xc1\x02\xaa\xfd\x90\x1d\x04\"\x02\x08\x65\xaa\xfd\x90\x1d\x05\"\x03\x08\xd4\x01\xfa\xde\x90\x1d\x02\x08\t\xfa\xde\x90\x1d\x04\x13\x18\x16\x14\xe3\xdc\xfc\x1c\xf8\xfd\xfb\x1c\x18\xe4\xdc\xfc\x1c\"#\n\x13\x41ggregateMessageSet*\x08\x08\x04\x10\xff\xff\xff\xff\x07:\x02\x08\x01\"\xa0\x01\n\x1a\x41ggregateMessageSetElement\x12\t\n\x01s\x18\x01 \x01(\t2w\n\x15message_set_extension\x12&.protobuf_unittest.AggregateMessageSet\x18\xf6\xeb\xae\x07 \x01(\x0b\x32-.protobuf_unittest.AggregateMessageSetElement\"\xa0\x02\n\tAggregate\x12\t\n\x01i\x18\x01 \x01(\x05\x12\t\n\x01s\x18\x02 \x01(\t\x12)\n\x03sub\x18\x03 \x01(\x0b\x32\x1c.protobuf_unittest.Aggregate\x12*\n\x04\x66ile\x18\x04 \x01(\x0b\x32\x1c.google.protobuf.FileOptions\x12\x34\n\x04mset\x18\x05 \x01(\x0b\x32&.protobuf_unittest.AggregateMessageSet\x12!\n\x03\x61ny\x18\x06 \x01(\x0b\x32\x14.google.protobuf.Any2M\n\x06nested\x12\x1c.google.protobuf.FileOptions\x18\xa7\xd1\xb0\x07 \x01(\x0b\x32\x1c.protobuf_unittest.Aggregate\"Y\n\x10\x41ggregateMessage\x12)\n\tfieldname\x18\x01 \x01(\x05\x42\x16\xf2\xa1\x87;\x11\x12\x0f\x46ieldAnnotation:\x1a\xc2\xd1\x86;\x15\x08\x65\x12\x11MessageAnnotation\"\xc9\x01\n\x10NestedOptionType\x1a;\n\rNestedMessage\x12\"\n\x0cnested_field\x18\x01 \x01(\x05\x42\x0c\xc1\xe0\xc3\x1d\xea\x03\x00\x00\x00\x00\x00\x00:\x06\xe0\xe9\xc2\x1d\xe9\x07\"5\n\nNestedEnum\x12\x1d\n\x11NESTED_ENUM_VALUE\x10\x01\x1a\x06\xb0\x86\xfa\x05\xec\x07\x1a\x08\xc5\xf6\xc9\x1d\xeb\x03\x00\x00\x32\x41\n\x10nested_extension\x12\x1c.google.protobuf.FileOptions\x18\xfd\xf8\xe2\x03 \x01(\x05\x42\x06\xc8\x8b\xca\x1d\xed\x07\"d\n\rOldOptionType\x12\x38\n\x05value\x18\x01 \x02(\x0e\x32).protobuf_unittest.OldOptionType.TestEnum\"\x19\n\x08TestEnum\x12\r\n\tOLD_VALUE\x10\x00\"s\n\rNewOptionType\x12\x38\n\x05value\x18\x01 \x02(\x0e\x32).protobuf_unittest.NewOptionType.TestEnum\"(\n\x08TestEnum\x12\r\n\tOLD_VALUE\x10\x00\x12\r\n\tNEW_VALUE\x10\x01\"-\n!TestMessageWithRequiredEnumOption:\x08\xfa\xe8\xfc\x94\x03\x02\x08\x00*6\n\nMethodOpt1\x12\x13\n\x0fMETHODOPT1_VAL1\x10\x01\x12\x13\n\x0fMETHODOPT1_VAL2\x10\x02*M\n\rAggregateEnum\x12%\n\x05VALUE\x10\x01\x1a\x1a\xca\xfc\x89;\x15\x12\x13\x45numValueAnnotation\x1a\x15\x92\x95\x88;\x10\x12\x0e\x45numAnnotation2\x8e\x01\n\x1cTestServiceWithCustomOptions\x12\x63\n\x03\x46oo\x12).protobuf_unittest.CustomOptionFooRequest\x1a*.protobuf_unittest.CustomOptionFooResponse\"\x05\xe0\xfa\x8c\x1e\x02\x1a\t\x90\xb2\x8b\x1e\xd3\xdb\x80\xcbI2\x99\x01\n\x10\x41ggregateService\x12k\n\x06Method\x12#.protobuf_unittest.AggregateMessage\x1a#.protobuf_unittest.AggregateMessage\"\x17\xca\xc8\x96;\x12\x12\x10MethodAnnotation\x1a\x18\xca\xfb\x8e;\x13\x12\x11ServiceAnnotation:2\n\tfile_opt1\x12\x1c.google.protobuf.FileOptions\x18\x8e\x9d\xd8\x03 \x01(\x04:8\n\x0cmessage_opt1\x12\x1f.google.protobuf.MessageOptions\x18\x9c\xad\xd8\x03 \x01(\x05:4\n\nfield_opt1\x12\x1d.google.protobuf.FieldOptions\x18\x88\xbc\xd8\x03 \x01(\x06:8\n\nfield_opt2\x12\x1d.google.protobuf.FieldOptions\x18\xb9\xa1\xd9\x03 \x01(\x05:\x02\x34\x32:4\n\noneof_opt1\x12\x1d.google.protobuf.OneofOptions\x18\xcf\xb5\xd8\x03 \x01(\x05:2\n\tenum_opt1\x12\x1c.google.protobuf.EnumOptions\x18\xe8\x9e\xd9\x03 \x01(\x0f:<\n\x0f\x65num_value_opt1\x12!.google.protobuf.EnumValueOptions\x18\xe6\xa0_ \x01(\x05:8\n\x0cservice_opt1\x12\x1f.google.protobuf.ServiceOptions\x18\xa2\xb6\xe1\x03 \x01(\x12:U\n\x0bmethod_opt1\x12\x1e.google.protobuf.MethodOptions\x18\xac\xcf\xe1\x03 \x01(\x0e\x32\x1d.protobuf_unittest.MethodOpt1:4\n\x08\x62ool_opt\x12\x1f.google.protobuf.MessageOptions\x18\xea\xab\xd6\x03 \x01(\x08:5\n\tint32_opt\x12\x1f.google.protobuf.MessageOptions\x18\xed\xa8\xd6\x03 \x01(\x05:5\n\tint64_opt\x12\x1f.google.protobuf.MessageOptions\x18\xc6\xa7\xd6\x03 \x01(\x03:6\n\nuint32_opt\x12\x1f.google.protobuf.MessageOptions\x18\xb0\xa2\xd6\x03 \x01(\r:6\n\nuint64_opt\x12\x1f.google.protobuf.MessageOptions\x18\xdf\x8e\xd6\x03 \x01(\x04:6\n\nsint32_opt\x12\x1f.google.protobuf.MessageOptions\x18\xc0\x88\xd6\x03 \x01(\x11:6\n\nsint64_opt\x12\x1f.google.protobuf.MessageOptions\x18\xff\x82\xd6\x03 \x01(\x12:7\n\x0b\x66ixed32_opt\x12\x1f.google.protobuf.MessageOptions\x18\xd3\xfe\xd5\x03 \x01(\x07:7\n\x0b\x66ixed64_opt\x12\x1f.google.protobuf.MessageOptions\x18\xe2\xfd\xd5\x03 \x01(\x06:8\n\x0csfixed32_opt\x12\x1f.google.protobuf.MessageOptions\x18\xd5\xf1\xd5\x03 \x01(\x0f:8\n\x0csfixed64_opt\x12\x1f.google.protobuf.MessageOptions\x18\xe3\x8a\xd5\x03 \x01(\x10:5\n\tfloat_opt\x12\x1f.google.protobuf.MessageOptions\x18\xfe\xbb\xd4\x03 \x01(\x02:6\n\ndouble_opt\x12\x1f.google.protobuf.MessageOptions\x18\xcd\xab\xd4\x03 \x01(\x01:6\n\nstring_opt\x12\x1f.google.protobuf.MessageOptions\x18\xc5\xab\xd4\x03 \x01(\t:5\n\tbytes_opt\x12\x1f.google.protobuf.MessageOptions\x18\x96\xab\xd4\x03 \x01(\x0c:p\n\x08\x65num_opt\x12\x1f.google.protobuf.MessageOptions\x18\x91\xab\xd4\x03 \x01(\x0e\x32:.protobuf_unittest.DummyMessageContainingEnum.TestEnumType:p\n\x10message_type_opt\x12\x1f.google.protobuf.MessageOptions\x18\xaf\xf2\xd3\x03 \x01(\x0b\x32\x32.protobuf_unittest.DummyMessageInvalidAsOptionType:6\n\x04mooo\x12%.protobuf_unittest.ComplexOptionType1\x18\xdb\xe0\xd3\x03 \x01(\x05:^\n\x05\x63orge\x12%.protobuf_unittest.ComplexOptionType1\x18\xd2\xde\xd3\x03 \x01(\x0b\x32%.protobuf_unittest.ComplexOptionType3:8\n\x06grault\x12%.protobuf_unittest.ComplexOptionType2\x18\xef\xfc\xd2\x03 \x01(\x05:_\n\x06garply\x12%.protobuf_unittest.ComplexOptionType2\x18\xc8\xf5\xd2\x03 \x01(\x0b\x32%.protobuf_unittest.ComplexOptionType1:_\n\x0c\x63omplex_opt1\x12\x1f.google.protobuf.MessageOptions\x18\xa4\xdc\xd2\x03 \x01(\x0b\x32%.protobuf_unittest.ComplexOptionType1:_\n\x0c\x63omplex_opt2\x12\x1f.google.protobuf.MessageOptions\x18\xd5\x8f\xd2\x03 \x01(\x0b\x32%.protobuf_unittest.ComplexOptionType2:_\n\x0c\x63omplex_opt3\x12\x1f.google.protobuf.MessageOptions\x18\xef\x8b\xd2\x03 \x01(\x0b\x32%.protobuf_unittest.ComplexOptionType3:W\n\x0b\x63omplexopt6\x12\x1f.google.protobuf.MessageOptions\x18\xcc\xcb\xcf\x03 \x01(\n2\x1e.protobuf_unittest.ComplexOpt6:N\n\x07\x66ileopt\x12\x1c.google.protobuf.FileOptions\x18\xcf\xdd\xb0\x07 \x01(\x0b\x32\x1c.protobuf_unittest.Aggregate:P\n\x06msgopt\x12\x1f.google.protobuf.MessageOptions\x18\x98\xea\xb0\x07 \x01(\x0b\x32\x1c.protobuf_unittest.Aggregate:P\n\x08\x66ieldopt\x12\x1d.google.protobuf.FieldOptions\x18\x9e\xf4\xb0\x07 \x01(\x0b\x32\x1c.protobuf_unittest.Aggregate:N\n\x07\x65numopt\x12\x1c.google.protobuf.EnumOptions\x18\xd2\x82\xb1\x07 \x01(\x0b\x32\x1c.protobuf_unittest.Aggregate:V\n\nenumvalopt\x12!.google.protobuf.EnumValueOptions\x18\xc9\x9f\xb1\x07 \x01(\x0b\x32\x1c.protobuf_unittest.Aggregate:T\n\nserviceopt\x12\x1f.google.protobuf.ServiceOptions\x18\xb9\xef\xb1\x07 \x01(\x0b\x32\x1c.protobuf_unittest.Aggregate:R\n\tmethodopt\x12\x1e.google.protobuf.MethodOptions\x18\x89\xe9\xb2\x07 \x01(\x0b\x32\x1c.protobuf_unittest.Aggregate:_\n\x11required_enum_opt\x12\x1f.google.protobuf.MessageOptions\x18\x8f\xcd\xcf\x32 \x01(\x0b\x32 .protobuf_unittest.OldOptionTypeB\xe9\x01\x80\x01\x01\x88\x01\x01\x90\x01\x01\xf0\xe8\xc1\x1d\xea\xad\xc0\xe5$\xfa\xec\x85;\xd1\x01\x08\x64\x12\x0e\x46ileAnnotation\x1a\x16\x12\x14NestedFileAnnotation\"\x1e\xfa\xec\x85;\x19\x12\x17\x46ileExtensionAnnotation*$\x0b\x10\xf6\xeb\xae\x07\x1a\x1b\n\x19\x45mbeddedMessageSetElement\x0c\x32_\n@type.googleapis.com/protobuf_unittest.AggregateMessageSetElement\x12\x1b\n\x19\x45mbeddedMessageSetElement')

_builder.BuildMessageAndEnumDescriptors(DESCRIPTOR, globals())
_builder.BuildTopDescriptorsAndMessages(DESCRIPTOR, 'google.protobuf.unittest_custom_options_pb2', globals())
if _descriptor._USE_C_DESCRIPTORS == False:
    google_dot_protobuf_dot_descriptor__pb2.FileOptions.RegisterExtension(file_opt1)
    google_dot_protobuf_dot_descriptor__pb2.MessageOptions.RegisterExtension(message_opt1)
    google_dot_protobuf_dot_descriptor__pb2.FieldOptions.RegisterExtension(field_opt1)
    google_dot_protobuf_dot_descriptor__pb2.FieldOptions.RegisterExtension(field_opt2)
    google_dot_protobuf_dot_descriptor__pb2.OneofOptions.RegisterExtension(oneof_opt1)
    google_dot_protobuf_dot_descriptor__pb2.EnumOptions.RegisterExtension(enum_opt1)
    google_dot_protobuf_dot_descriptor__pb2.EnumValueOptions.RegisterExtension(enum_value_opt1)
    google_dot_protobuf_dot_descriptor__pb2.ServiceOptions.RegisterExtension(service_opt1)
    google_dot_protobuf_dot_descriptor__pb2.MethodOptions.RegisterExtension(method_opt1)
    google_dot_protobuf_dot_descriptor__pb2.MessageOptions.RegisterExtension(bool_opt)
    google_dot_protobuf_dot_descriptor__pb2.MessageOptions.RegisterExtension(int32_opt)
    google_dot_protobuf_dot_descriptor__pb2.MessageOptions.RegisterExtension(int64_opt)
    google_dot_protobuf_dot_descriptor__pb2.MessageOptions.RegisterExtension(uint32_opt)
    google_dot_protobuf_dot_descriptor__pb2.MessageOptions.RegisterExtension(uint64_opt)
    google_dot_protobuf_dot_descriptor__pb2.MessageOptions.RegisterExtension(sint32_opt)
    google_dot_protobuf_dot_descriptor__pb2.MessageOptions.RegisterExtension(sint64_opt)
    google_dot_protobuf_dot_descriptor__pb2.MessageOptions.RegisterExtension(fixed32_opt)
    google_dot_protobuf_dot_descriptor__pb2.MessageOptions.RegisterExtension(fixed64_opt)
    google_dot_protobuf_dot_descriptor__pb2.MessageOptions.RegisterExtension(sfixed32_opt)
    google_dot_protobuf_dot_descriptor__pb2.MessageOptions.RegisterExtension(sfixed64_opt)
    google_dot_protobuf_dot_descriptor__pb2.MessageOptions.RegisterExtension(float_opt)
    google_dot_protobuf_dot_descriptor__pb2.MessageOptions.RegisterExtension(double_opt)
    google_dot_protobuf_dot_descriptor__pb2.MessageOptions.RegisterExtension(string_opt)
    google_dot_protobuf_dot_descriptor__pb2.MessageOptions.RegisterExtension(bytes_opt)
    google_dot_protobuf_dot_descriptor__pb2.MessageOptions.RegisterExtension(enum_opt)
    google_dot_protobuf_dot_descriptor__pb2.MessageOptions.RegisterExtension(message_type_opt)
    ComplexOptionType1.RegisterExtension(mooo)
    ComplexOptionType1.RegisterExtension(corge)
    ComplexOptionType2.RegisterExtension(grault)
    ComplexOptionType2.RegisterExtension(garply)
    google_dot_protobuf_dot_descriptor__pb2.MessageOptions.RegisterExtension(complex_opt1)
    google_dot_protobuf_dot_descriptor__pb2.MessageOptions.RegisterExtension(complex_opt2)
    google_dot_protobuf_dot_descriptor__pb2.MessageOptions.RegisterExtension(complex_opt3)
    google_dot_protobuf_dot_descriptor__pb2.MessageOptions.RegisterExtension(complexopt6)
    google_dot_protobuf_dot_descriptor__pb2.FileOptions.RegisterExtension(fileopt)
    google_dot_protobuf_dot_descriptor__pb2.MessageOptions.RegisterExtension(msgopt)
    google_dot_protobuf_dot_descriptor__pb2.FieldOptions.RegisterExtension(fieldopt)
    google_dot_protobuf_dot_descriptor__pb2.EnumOptions.RegisterExtension(enumopt)
    google_dot_protobuf_dot_descriptor__pb2.EnumValueOptions.RegisterExtension(enumvalopt)
    google_dot_protobuf_dot_descriptor__pb2.ServiceOptions.RegisterExtension(serviceopt)
    google_dot_protobuf_dot_descriptor__pb2.MethodOptions.RegisterExtension(methodopt)
    google_dot_protobuf_dot_descriptor__pb2.MessageOptions.RegisterExtension(required_enum_opt)
    google_dot_protobuf_dot_descriptor__pb2.MessageOptions.RegisterExtension(
        _COMPLEXOPTIONTYPE2_COMPLEXOPTIONTYPE4.extensions_by_name['complex_opt4'])
    AggregateMessageSet.RegisterExtension(_AGGREGATEMESSAGESETELEMENT.extensions_by_name['message_set_extension'])
    google_dot_protobuf_dot_descriptor__pb2.FileOptions.RegisterExtension(_AGGREGATE.extensions_by_name['nested'])
    google_dot_protobuf_dot_descriptor__pb2.FileOptions.RegisterExtension(
        _NESTEDOPTIONTYPE.extensions_by_name['nested_extension'])

    DESCRIPTOR._options = None
    DESCRIPTOR._serialized_options = b'\200\001\001\210\001\001\220\001\001\360\350\301\035\352\255\300\345$\372\354\205;\321\001\010d\022\016FileAnnotation\032\026\022\024NestedFileAnnotation\"\036\372\354\205;\031\022\027FileExtensionAnnotation*$\013\020\366\353\256\007\032\033\n\031EmbeddedMessageSetElement\0142_\n@type.googleapis.com/protobuf_unittest.AggregateMessageSetElement\022\033\n\031EmbeddedMessageSetElement'
    _AGGREGATEENUM._options = None
    _AGGREGATEENUM._serialized_options = b'\222\225\210;\020\022\016EnumAnnotation'
    _AGGREGATEENUM.values_by_name["VALUE"]._options = None
    _AGGREGATEENUM.values_by_name["VALUE"]._serialized_options = b'\312\374\211;\025\022\023EnumValueAnnotation'
    _TESTMESSAGEWITHCUSTOMOPTIONS_MAPFIELDENTRY._options = None
    _TESTMESSAGEWITHCUSTOMOPTIONS_MAPFIELDENTRY._serialized_options = b'8\001'
    _TESTMESSAGEWITHCUSTOMOPTIONS.oneofs_by_name['AnOneof']._options = None
    _TESTMESSAGEWITHCUSTOMOPTIONS.oneofs_by_name[
        'AnOneof']._serialized_options = b'\370\254\303\035\235\377\377\377\377\377\377\377\377\001'
    _TESTMESSAGEWITHCUSTOMOPTIONS_ANENUM._options = None
    _TESTMESSAGEWITHCUSTOMOPTIONS_ANENUM._serialized_options = b'\305\366\311\035\353\374\377\377'
    _TESTMESSAGEWITHCUSTOMOPTIONS_ANENUM.values_by_name["ANENUM_VAL2"]._options = None
    _TESTMESSAGEWITHCUSTOMOPTIONS_ANENUM.values_by_name["ANENUM_VAL2"]._serialized_options = b'\260\206\372\005{'
    _TESTMESSAGEWITHCUSTOMOPTIONS.fields_by_name['field1']._options = None
    _TESTMESSAGEWITHCUSTOMOPTIONS.fields_by_name[
        'field1']._serialized_options = b'\010\001\301\340\303\035-\341u\n\002\000\000\000'
    _TESTMESSAGEWITHCUSTOMOPTIONS.fields_by_name['map_field']._options = None
    _TESTMESSAGEWITHCUSTOMOPTIONS.fields_by_name[
        'map_field']._serialized_options = b'\301\340\303\03590\000\000\000\000\000\000'
    _TESTMESSAGEWITHCUSTOMOPTIONS._options = None
    _TESTMESSAGEWITHCUSTOMOPTIONS._serialized_options = b'\010\000\340\351\302\035\310\377\377\377\377\377\377\377\377\001'
    _CUSTOMOPTIONMININTEGERVALUES._options = None
    _CUSTOMOPTIONMININTEGERVALUES._serialized_options = b'\320\336\262\035\000\350\306\262\035\200\200\200\200\370\377\377\377\377\001\260\274\262\035\200\200\200\200\200\200\200\200\200\001\200\223\262\035\000\370\365\260\035\000\200\304\260\035\377\377\377\377\017\370\227\260\035\377\377\377\377\377\377\377\377\377\001\235\365\257\035\000\000\000\000\221\356\257\035\000\000\000\000\000\000\000\000\255\215\257\035\000\000\000\200\231\326\250\035\000\000\000\000\000\000\000\200'
    _CUSTOMOPTIONMAXINTEGERVALUES._options = None
    _CUSTOMOPTIONMAXINTEGERVALUES._serialized_options = b'\320\336\262\035\001\350\306\262\035\377\377\377\377\007\260\274\262\035\377\377\377\377\377\377\377\377\177\200\223\262\035\377\377\377\377\017\370\365\260\035\377\377\377\377\377\377\377\377\377\001\200\304\260\035\376\377\377\377\017\370\227\260\035\376\377\377\377\377\377\377\377\377\001\235\365\257\035\377\377\377\377\221\356\257\035\377\377\377\377\377\377\377\377\255\215\257\035\377\377\377\177\231\326\250\035\377\377\377\377\377\377\377\177'
    _CUSTOMOPTIONOTHERVALUES._options = None
    _CUSTOMOPTIONOTHERVALUES._serialized_options = b'\350\306\262\035\234\377\377\377\377\377\377\377\377\001\365\337\243\035\347\207EA\351\334\242\035\373Y\214B\312\300\363?\252\334\242\035\016Hello, \"World\"\262\331\242\035\013Hello\000World\210\331\242\035\351\377\377\377\377\377\377\377\377\001'
    _SETTINGREALSFROMPOSITIVEINTS._options = None
    _SETTINGREALSFROMPOSITIVEINTS._serialized_options = b'\365\337\243\035\000\000@A\351\334\242\035\000\000\000\000\000@c@'
    _SETTINGREALSFROMNEGATIVEINTS._options = None
    _SETTINGREALSFROMNEGATIVEINTS._serialized_options = b'\365\337\243\035\000\000@\301\351\334\242\035\000\000\000\000\000@c\300'
    _VARIOUSCOMPLEXOPTIONS._options = None
    _VARIOUSCOMPLEXOPTIONS._serialized_options = b'\242\342\225\035\002\010*\242\342\225\035\006\330\205\236\035\304\002\242\342\225\035\010\222\365\235\035\003\010\354\006\242\342\225\035\002 c\242\342\225\035\002 X\252\375\220\035\003\020\333\007\252\375\220\035\006\370\346\227\035\216\005\252\375\220\035\005\n\003\010\347\005\252\375\220\035\010\n\006\330\205\236\035\317\017\252\375\220\035\n\n\010\222\365\235\035\003\010\330\017\252\375\220\035\010\302\254\227\035\003\010\345\005\252\375\220\035\013\302\254\227\035\006\330\205\236\035\316\017\252\375\220\035\r\302\254\227\035\010\222\365\235\035\003\010\311\020\322\250\217\035\003\010\263\017\252\375\220\035\005\032\003\010\301\002\252\375\220\035\004\"\002\010e\252\375\220\035\005\"\003\010\324\001\372\336\220\035\002\010\t\372\336\220\035\004\023\030\026\024\343\334\374\034\370\375\373\034\030\344\334\374\034'
    _AGGREGATEMESSAGESET._options = None
    _AGGREGATEMESSAGESET._serialized_options = b'\010\001'
    _AGGREGATEMESSAGE.fields_by_name['fieldname']._options = None
    _AGGREGATEMESSAGE.fields_by_name['fieldname']._serialized_options = b'\362\241\207;\021\022\017FieldAnnotation'
    _AGGREGATEMESSAGE._options = None
    _AGGREGATEMESSAGE._serialized_options = b'\302\321\206;\025\010e\022\021MessageAnnotation'
    _NESTEDOPTIONTYPE_NESTEDMESSAGE.fields_by_name['nested_field']._options = None
    _NESTEDOPTIONTYPE_NESTEDMESSAGE.fields_by_name[
        'nested_field']._serialized_options = b'\301\340\303\035\352\003\000\000\000\000\000\000'
    _NESTEDOPTIONTYPE_NESTEDMESSAGE._options = None
    _NESTEDOPTIONTYPE_NESTEDMESSAGE._serialized_options = b'\340\351\302\035\351\007'
    _NESTEDOPTIONTYPE_NESTEDENUM._options = None
    _NESTEDOPTIONTYPE_NESTEDENUM._serialized_options = b'\305\366\311\035\353\003\000\000'
    _NESTEDOPTIONTYPE_NESTEDENUM.values_by_name["NESTED_ENUM_VALUE"]._options = None
    _NESTEDOPTIONTYPE_NESTEDENUM.values_by_name["NESTED_ENUM_VALUE"]._serialized_options = b'\260\206\372\005\354\007'
    _NESTEDOPTIONTYPE.extensions_by_name['nested_extension']._options = None
    _NESTEDOPTIONTYPE.extensions_by_name['nested_extension']._serialized_options = b'\310\213\312\035\355\007'
    _TESTMESSAGEWITHREQUIREDENUMOPTION._options = None
    _TESTMESSAGEWITHREQUIREDENUMOPTION._serialized_options = b'\372\350\374\224\003\002\010\000'
    _TESTSERVICEWITHCUSTOMOPTIONS._options = None
    _TESTSERVICEWITHCUSTOMOPTIONS._serialized_options = b'\220\262\213\036\323\333\200\313I'
    _TESTSERVICEWITHCUSTOMOPTIONS.methods_by_name['Foo']._options = None
    _TESTSERVICEWITHCUSTOMOPTIONS.methods_by_name['Foo']._serialized_options = b'\340\372\214\036\002'
    _AGGREGATESERVICE._options = None
    _AGGREGATESERVICE._serialized_options = b'\312\373\216;\023\022\021ServiceAnnotation'
    _AGGREGATESERVICE.methods_by_name['Method']._options = None
    _AGGREGATESERVICE.methods_by_name['Method']._serialized_options = b'\312\310\226;\022\022\020MethodAnnotation'
    _METHODOPT1._serialized_start = 3213
    _METHODOPT1._serialized_end = 3267
    _AGGREGATEENUM._serialized_start = 3269
    _AGGREGATEENUM._serialized_end = 3346
    _TESTMESSAGEWITHCUSTOMOPTIONS._serialized_start = 130
    _TESTMESSAGEWITHCUSTOMOPTIONS._serialized_end = 466
    _TESTMESSAGEWITHCUSTOMOPTIONS_MAPFIELDENTRY._serialized_start = 313
    _TESTMESSAGEWITHCUSTOMOPTIONS_MAPFIELDENTRY._serialized_end = 360
    _TESTMESSAGEWITHCUSTOMOPTIONS_ANENUM._serialized_start = 362
    _TESTMESSAGEWITHCUSTOMOPTIONS_ANENUM._serialized_end = 421
    _CUSTOMOPTIONFOOREQUEST._serialized_start = 468
    _CUSTOMOPTIONFOOREQUEST._serialized_end = 492
    _CUSTOMOPTIONFOORESPONSE._serialized_start = 494
    _CUSTOMOPTIONFOORESPONSE._serialized_end = 519
    _CUSTOMOPTIONFOOCLIENTMESSAGE._serialized_start = 521
    _CUSTOMOPTIONFOOCLIENTMESSAGE._serialized_end = 551
    _CUSTOMOPTIONFOOSERVERMESSAGE._serialized_start = 553
    _CUSTOMOPTIONFOOSERVERMESSAGE._serialized_end = 583
    _DUMMYMESSAGECONTAININGENUM._serialized_start = 585
    _DUMMYMESSAGECONTAININGENUM._serialized_end = 694
    _DUMMYMESSAGECONTAININGENUM_TESTENUMTYPE._serialized_start = 615
    _DUMMYMESSAGECONTAININGENUM_TESTENUMTYPE._serialized_end = 694
    _DUMMYMESSAGEINVALIDASOPTIONTYPE._serialized_start = 696
    _DUMMYMESSAGEINVALIDASOPTIONTYPE._serialized_end = 729
    _CUSTOMOPTIONMININTEGERVALUES._serialized_start = 732
    _CUSTOMOPTIONMININTEGERVALUES._serialized_end = 870
    _CUSTOMOPTIONMAXINTEGERVALUES._serialized_start = 873
    _CUSTOMOPTIONMAXINTEGERVALUES._serialized_end = 1018
    _CUSTOMOPTIONOTHERVALUES._serialized_start = 1020
    _CUSTOMOPTIONOTHERVALUES._serialized_end = 1130
    _SETTINGREALSFROMPOSITIVEINTS._serialized_start = 1132
    _SETTINGREALSFROMPOSITIVEINTS._serialized_end = 1184
    _SETTINGREALSFROMNEGATIVEINTS._serialized_start = 1186
    _SETTINGREALSFROMNEGATIVEINTS._serialized_end = 1238
    _COMPLEXOPTIONTYPE1._serialized_start = 1240
    _COMPLEXOPTIONTYPE1._serialized_end = 1325
    _COMPLEXOPTIONTYPE2._serialized_start = 1328
    _COMPLEXOPTIONTYPE2._serialized_end = 1723
    _COMPLEXOPTIONTYPE2_COMPLEXOPTIONTYPE4._serialized_start = 1562
    _COMPLEXOPTIONTYPE2_COMPLEXOPTIONTYPE4._serialized_end = 1713
    _COMPLEXOPTIONTYPE3._serialized_start = 1726
    _COMPLEXOPTIONTYPE3._serialized_end = 1882
    _COMPLEXOPTIONTYPE3_COMPLEXOPTIONTYPE5._serialized_start = 1847
    _COMPLEXOPTIONTYPE3_COMPLEXOPTIONTYPE5._serialized_end = 1882
    _COMPLEXOPT6._serialized_start = 1884
    _COMPLEXOPT6._serialized_end = 1915
    _VARIOUSCOMPLEXOPTIONS._serialized_start = 1918
    _VARIOUSCOMPLEXOPTIONS._serialized_end = 2159
    _AGGREGATEMESSAGESET._serialized_start = 2161
    _AGGREGATEMESSAGESET._serialized_end = 2196
    _AGGREGATEMESSAGESETELEMENT._serialized_start = 2199
    _AGGREGATEMESSAGESETELEMENT._serialized_end = 2359
    _AGGREGATE._serialized_start = 2362
    _AGGREGATE._serialized_end = 2650
    _AGGREGATEMESSAGE._serialized_start = 2652
    _AGGREGATEMESSAGE._serialized_end = 2741
    _NESTEDOPTIONTYPE._serialized_start = 2744
    _NESTEDOPTIONTYPE._serialized_end = 2945
    _NESTEDOPTIONTYPE_NESTEDMESSAGE._serialized_start = 2764
    _NESTEDOPTIONTYPE_NESTEDMESSAGE._serialized_end = 2823
    _NESTEDOPTIONTYPE_NESTEDENUM._serialized_start = 2825
    _NESTEDOPTIONTYPE_NESTEDENUM._serialized_end = 2878
    _OLDOPTIONTYPE._serialized_start = 2947
    _OLDOPTIONTYPE._serialized_end = 3047
    _OLDOPTIONTYPE_TESTENUM._serialized_start = 3022
    _OLDOPTIONTYPE_TESTENUM._serialized_end = 3047
    _NEWOPTIONTYPE._serialized_start = 3049
    _NEWOPTIONTYPE._serialized_end = 3164
    _NEWOPTIONTYPE_TESTENUM._serialized_start = 3124
    _NEWOPTIONTYPE_TESTENUM._serialized_end = 3164
    _TESTMESSAGEWITHREQUIREDENUMOPTION._serialized_start = 3166
    _TESTMESSAGEWITHREQUIREDENUMOPTION._serialized_end = 3211
    _TESTSERVICEWITHCUSTOMOPTIONS._serialized_start = 3349
    _TESTSERVICEWITHCUSTOMOPTIONS._serialized_end = 3491
    _AGGREGATESERVICE._serialized_start = 3494
    _AGGREGATESERVICE._serialized_end = 3647
_builder.BuildServices(DESCRIPTOR, 'google.protobuf.unittest_custom_options_pb2', globals())
# @@protoc_insertion_point(module_scope)
