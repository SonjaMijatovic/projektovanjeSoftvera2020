// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: MedicineService.proto

package org.baeldung.grpc;

public final class MedicineServiceOuterClass {
  private MedicineServiceOuterClass() {}
  public static void registerAllExtensions(
      com.google.protobuf.ExtensionRegistryLite registry) {
  }

  public static void registerAllExtensions(
      com.google.protobuf.ExtensionRegistry registry) {
    registerAllExtensions(
        (com.google.protobuf.ExtensionRegistryLite) registry);
  }
  static final com.google.protobuf.Descriptors.Descriptor
    internal_static_org_baeldung_grpc_MedicineRequest_descriptor;
  static final 
    com.google.protobuf.GeneratedMessageV3.FieldAccessorTable
      internal_static_org_baeldung_grpc_MedicineRequest_fieldAccessorTable;
  static final com.google.protobuf.Descriptors.Descriptor
    internal_static_org_baeldung_grpc_MedicineResponse_descriptor;
  static final 
    com.google.protobuf.GeneratedMessageV3.FieldAccessorTable
      internal_static_org_baeldung_grpc_MedicineResponse_fieldAccessorTable;

  public static com.google.protobuf.Descriptors.FileDescriptor
      getDescriptor() {
    return descriptor;
  }
  private static  com.google.protobuf.Descriptors.FileDescriptor
      descriptor;
  static {
    String[] descriptorData = {
      "\n\025MedicineService.proto\022\021org.baeldung.gr" +
      "pc\"%\n\017MedicineRequest\022\022\n\nmedicineId\030\001 \001(" +
      "\t\"\"\n\020MedicineResponse\022\016\n\006result\030\001 \001(\t2i\n" +
      "\017MedicineService\022V\n\013getMedicine\022\".org.ba" +
      "eldung.grpc.MedicineRequest\032#.org.baeldu" +
      "ng.grpc.MedicineResponseB\005P\001\210\001\001b\006proto3"
    };
    descriptor = com.google.protobuf.Descriptors.FileDescriptor
      .internalBuildGeneratedFileFrom(descriptorData,
        new com.google.protobuf.Descriptors.FileDescriptor[] {
        });
    internal_static_org_baeldung_grpc_MedicineRequest_descriptor =
      getDescriptor().getMessageTypes().get(0);
    internal_static_org_baeldung_grpc_MedicineRequest_fieldAccessorTable = new
      com.google.protobuf.GeneratedMessageV3.FieldAccessorTable(
        internal_static_org_baeldung_grpc_MedicineRequest_descriptor,
        new String[] { "MedicineId", });
    internal_static_org_baeldung_grpc_MedicineResponse_descriptor =
      getDescriptor().getMessageTypes().get(1);
    internal_static_org_baeldung_grpc_MedicineResponse_fieldAccessorTable = new
      com.google.protobuf.GeneratedMessageV3.FieldAccessorTable(
        internal_static_org_baeldung_grpc_MedicineResponse_descriptor,
        new String[] { "Result", });
  }

  // @@protoc_insertion_point(outer_class_scope)
}