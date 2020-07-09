using Grpc.Net.Client;
using GrpcService.Protos;
using System;
using System.Threading.Tasks;

namespace GrpcClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var service = "authentication";
            switch (service)
            {
                case "authentication": {
                        var credentials = new LoginRequest { Username = "admin", Password = "admin" };
                        var channel = GrpcChannel.ForAddress("https://localhost:5001");
                        var client = new Authentication.AuthenticationClient(channel);
                        var authorization = client.Login(credentials);

                        var jwt = authorization.AccessToken == null ? "null" : authorization.AccessToken;
                        Console.WriteLine($"JWT: {jwt}");

                        credentials = new LoginRequest { Username = "admin", Password = "admin1" };
                        authorization = client.Login(credentials);

                        jwt = authorization.AccessToken == null ? "null" : authorization.AccessToken;
                        Console.WriteLine($"JWT: {jwt}");

                        break; 
                    }
                case "greeter":
                    {
                        var input = new HelloRequest { Name = "Jim Bob" };

                        var channel = GrpcChannel.ForAddress("https://localhost:5001");
                        var client = new Greeter.GreeterClient(channel);

                        var reply = await client.SayHelloAsync(input);

                        Console.WriteLine(reply.Message);

                        break;
                    }
                case "meter": {
                        var channel = GrpcChannel.ForAddress("https://localhost:5001");
                        var meterClient = new RemoteMeter.RemoteMeterClient(channel);
                        var meterInput = new MeterLookupModel { MeterId = 3 };
                        var meterReply = await meterClient.GetMeterInfoAsync(meterInput);

                        Console.WriteLine($"{meterReply.MeterNumber}");
                        
                        break;
                    }
            }



            Console.ReadLine();
        }
    }
}
