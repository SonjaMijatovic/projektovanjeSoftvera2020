package org.baeldung.grpc;

import static io.grpc.MethodDescriptor.generateFullMethodName;

/**
 */
@javax.annotation.Generated(
    value = "by gRPC proto compiler (version 1.35.0)",
    comments = "Source: MedicineService.proto")
public final class MedicineServiceGrpc {

  private MedicineServiceGrpc() {}

  public static final String SERVICE_NAME = "org.baeldung.grpc.MedicineService";

  // Static method descriptors that strictly reflect the proto.
  private static volatile io.grpc.MethodDescriptor<MedicineRequest,
      MedicineResponse> getGetMedicineMethod;

  @io.grpc.stub.annotations.RpcMethod(
      fullMethodName = SERVICE_NAME + '/' + "getMedicine",
      requestType = MedicineRequest.class,
      responseType = MedicineResponse.class,
      methodType = io.grpc.MethodDescriptor.MethodType.UNARY)
  public static io.grpc.MethodDescriptor<MedicineRequest,
      MedicineResponse> getGetMedicineMethod() {
    io.grpc.MethodDescriptor<MedicineRequest, MedicineResponse> getGetMedicineMethod;
    if ((getGetMedicineMethod = MedicineServiceGrpc.getGetMedicineMethod) == null) {
      synchronized (MedicineServiceGrpc.class) {
        if ((getGetMedicineMethod = MedicineServiceGrpc.getGetMedicineMethod) == null) {
          MedicineServiceGrpc.getGetMedicineMethod = getGetMedicineMethod =
              io.grpc.MethodDescriptor.<MedicineRequest, MedicineResponse>newBuilder()
              .setType(io.grpc.MethodDescriptor.MethodType.UNARY)
              .setFullMethodName(generateFullMethodName(SERVICE_NAME, "getMedicine"))
              .setSampledToLocalTracing(true)
              .setRequestMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  MedicineRequest.getDefaultInstance()))
              .setResponseMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  MedicineResponse.getDefaultInstance()))
              .setSchemaDescriptor(new MedicineServiceMethodDescriptorSupplier("getMedicine"))
              .build();
        }
      }
    }
    return getGetMedicineMethod;
  }

  /**
   * Creates a new async stub that supports all call types for the service
   */
  public static MedicineServiceStub newStub(io.grpc.Channel channel) {
    io.grpc.stub.AbstractStub.StubFactory<MedicineServiceStub> factory =
      new io.grpc.stub.AbstractStub.StubFactory<MedicineServiceStub>() {
        @Override
        public MedicineServiceStub newStub(io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
          return new MedicineServiceStub(channel, callOptions);
        }
      };
    return MedicineServiceStub.newStub(factory, channel);
  }

  /**
   * Creates a new blocking-style stub that supports unary and streaming output calls on the service
   */
  public static MedicineServiceBlockingStub newBlockingStub(
      io.grpc.Channel channel) {
    io.grpc.stub.AbstractStub.StubFactory<MedicineServiceBlockingStub> factory =
      new io.grpc.stub.AbstractStub.StubFactory<MedicineServiceBlockingStub>() {
        @Override
        public MedicineServiceBlockingStub newStub(io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
          return new MedicineServiceBlockingStub(channel, callOptions);
        }
      };
    return MedicineServiceBlockingStub.newStub(factory, channel);
  }

  /**
   * Creates a new ListenableFuture-style stub that supports unary calls on the service
   */
  public static MedicineServiceFutureStub newFutureStub(
      io.grpc.Channel channel) {
    io.grpc.stub.AbstractStub.StubFactory<MedicineServiceFutureStub> factory =
      new io.grpc.stub.AbstractStub.StubFactory<MedicineServiceFutureStub>() {
        @Override
        public MedicineServiceFutureStub newStub(io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
          return new MedicineServiceFutureStub(channel, callOptions);
        }
      };
    return MedicineServiceFutureStub.newStub(factory, channel);
  }

  /**
   */
  public static abstract class MedicineServiceImplBase implements io.grpc.BindableService {

    /**
     */
    public void getMedicine(MedicineRequest request,
                            io.grpc.stub.StreamObserver<MedicineResponse> responseObserver) {
      io.grpc.stub.ServerCalls.asyncUnimplementedUnaryCall(getGetMedicineMethod(), responseObserver);
    }

    @Override public final io.grpc.ServerServiceDefinition bindService() {
      return io.grpc.ServerServiceDefinition.builder(getServiceDescriptor())
          .addMethod(
            getGetMedicineMethod(),
            io.grpc.stub.ServerCalls.asyncUnaryCall(
              new MethodHandlers<
                MedicineRequest,
                MedicineResponse>(
                  this, METHODID_GET_MEDICINE)))
          .build();
    }
  }

  /**
   */
  public static final class MedicineServiceStub extends io.grpc.stub.AbstractAsyncStub<MedicineServiceStub> {
    private MedicineServiceStub(
        io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
      super(channel, callOptions);
    }

    @Override
    protected MedicineServiceStub build(
        io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
      return new MedicineServiceStub(channel, callOptions);
    }

    /**
     */
    public void getMedicine(MedicineRequest request,
                            io.grpc.stub.StreamObserver<MedicineResponse> responseObserver) {
      io.grpc.stub.ClientCalls.asyncUnaryCall(
          getChannel().newCall(getGetMedicineMethod(), getCallOptions()), request, responseObserver);
    }
  }

  /**
   */
  public static final class MedicineServiceBlockingStub extends io.grpc.stub.AbstractBlockingStub<MedicineServiceBlockingStub> {
    private MedicineServiceBlockingStub(
        io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
      super(channel, callOptions);
    }

    @Override
    protected MedicineServiceBlockingStub build(
        io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
      return new MedicineServiceBlockingStub(channel, callOptions);
    }

    /**
     */
    public MedicineResponse getMedicine(MedicineRequest request) {
      return io.grpc.stub.ClientCalls.blockingUnaryCall(
          getChannel(), getGetMedicineMethod(), getCallOptions(), request);
    }
  }

  /**
   */
  public static final class MedicineServiceFutureStub extends io.grpc.stub.AbstractFutureStub<MedicineServiceFutureStub> {
    private MedicineServiceFutureStub(
        io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
      super(channel, callOptions);
    }

    @Override
    protected MedicineServiceFutureStub build(
        io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
      return new MedicineServiceFutureStub(channel, callOptions);
    }

    /**
     */
    public com.google.common.util.concurrent.ListenableFuture<MedicineResponse> getMedicine(
        MedicineRequest request) {
      return io.grpc.stub.ClientCalls.futureUnaryCall(
          getChannel().newCall(getGetMedicineMethod(), getCallOptions()), request);
    }
  }

  private static final int METHODID_GET_MEDICINE = 0;

  private static final class MethodHandlers<Req, Resp> implements
      io.grpc.stub.ServerCalls.UnaryMethod<Req, Resp>,
      io.grpc.stub.ServerCalls.ServerStreamingMethod<Req, Resp>,
      io.grpc.stub.ServerCalls.ClientStreamingMethod<Req, Resp>,
      io.grpc.stub.ServerCalls.BidiStreamingMethod<Req, Resp> {
    private final MedicineServiceImplBase serviceImpl;
    private final int methodId;

    MethodHandlers(MedicineServiceImplBase serviceImpl, int methodId) {
      this.serviceImpl = serviceImpl;
      this.methodId = methodId;
    }

    @Override
    @SuppressWarnings("unchecked")
    public void invoke(Req request, io.grpc.stub.StreamObserver<Resp> responseObserver) {
      switch (methodId) {
        case METHODID_GET_MEDICINE:
          serviceImpl.getMedicine((MedicineRequest) request,
              (io.grpc.stub.StreamObserver<MedicineResponse>) responseObserver);
          break;
        default:
          throw new AssertionError();
      }
    }

    @Override
    @SuppressWarnings("unchecked")
    public io.grpc.stub.StreamObserver<Req> invoke(
        io.grpc.stub.StreamObserver<Resp> responseObserver) {
      switch (methodId) {
        default:
          throw new AssertionError();
      }
    }
  }

  private static abstract class MedicineServiceBaseDescriptorSupplier
      implements io.grpc.protobuf.ProtoFileDescriptorSupplier, io.grpc.protobuf.ProtoServiceDescriptorSupplier {
    MedicineServiceBaseDescriptorSupplier() {}

    @Override
    public com.google.protobuf.Descriptors.FileDescriptor getFileDescriptor() {
      return MedicineServiceOuterClass.getDescriptor();
    }

    @Override
    public com.google.protobuf.Descriptors.ServiceDescriptor getServiceDescriptor() {
      return getFileDescriptor().findServiceByName("MedicineService");
    }
  }

  private static final class MedicineServiceFileDescriptorSupplier
      extends MedicineServiceBaseDescriptorSupplier {
    MedicineServiceFileDescriptorSupplier() {}
  }

  private static final class MedicineServiceMethodDescriptorSupplier
      extends MedicineServiceBaseDescriptorSupplier
      implements io.grpc.protobuf.ProtoMethodDescriptorSupplier {
    private final String methodName;

    MedicineServiceMethodDescriptorSupplier(String methodName) {
      this.methodName = methodName;
    }

    @Override
    public com.google.protobuf.Descriptors.MethodDescriptor getMethodDescriptor() {
      return getServiceDescriptor().findMethodByName(methodName);
    }
  }

  private static volatile io.grpc.ServiceDescriptor serviceDescriptor;

  public static io.grpc.ServiceDescriptor getServiceDescriptor() {
    io.grpc.ServiceDescriptor result = serviceDescriptor;
    if (result == null) {
      synchronized (MedicineServiceGrpc.class) {
        result = serviceDescriptor;
        if (result == null) {
          serviceDescriptor = result = io.grpc.ServiceDescriptor.newBuilder(SERVICE_NAME)
              .setSchemaDescriptor(new MedicineServiceFileDescriptorSupplier())
              .addMethod(getGetMedicineMethod())
              .build();
        }
      }
    }
    return result;
  }
}
