# waterworks

A fictional water utility.

Began with https://www.youtube.com/watch?v=Xh47x_C-aMM&feature=youtu.be

Ignore the GrpcWebService project for now. First trying to get things working with HTTP 2.0.

Then looking at https://dev.to/techschoolguru/use-grpc-interceptor-for-authorization-with-jwt-1c5h for authentication to obtain JWT. I have begun this work, but have not completed it.

Run the gRPC service and go to it in a browser to accept the license. Then the gRPC client should work. (After running the service, then run the client.)

The gRPC Web Service is intended to be "functionally equivalent" to the gRPC Service, but using HTTP 1.1 instead of HTTP 2.0. This is so a browser (with WebAssembly) can make use of gRPC service.