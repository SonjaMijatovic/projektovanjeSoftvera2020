import io.grpc.Server;
import io.grpc.ServerBuilder;
import java.io.IOException;

public class GRPCServer {
    public static void main(String[] args) throws IOException, InterruptedException {
        Server server = ServerBuilder
                .forPort(8081)
                .addService(new MedicineServiceImpl()).build();

        server.start();
        server.awaitTermination();
    }
}
