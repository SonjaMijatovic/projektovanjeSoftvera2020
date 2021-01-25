import com.google.protobuf.RpcCallback;
import com.google.protobuf.RpcController;
import org.baeldung.grpc.MedicineRequest;
import org.baeldung.grpc.MedicineResponse;
import org.baeldung.grpc.MedicineServiceGrpc;

import java.util.Random;

public class MedicineServiceImpl extends MedicineServiceGrpc.MedicineServiceImplBase {

    @Override
    public void getMedicine(MedicineRequest request,
                            io.grpc.stub.StreamObserver<MedicineResponse> responseObserver) {
    	
    	System.out.println("Medicine id is: " + request.getMedicineId());

        Random random = new Random();

        int number = random.nextInt(1000);

        String response = "OK";

        if(number > 500) {
            response = "ERROR";
        }
        
    	System.out.println("Response is: " + response);


        MedicineResponse res = MedicineResponse.newBuilder().setResult(response).build();

        responseObserver.onNext(res);
        responseObserver.onCompleted();
    }
}
