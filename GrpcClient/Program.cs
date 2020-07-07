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

                        Console.WriteLine(authorization.AccessToken);

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
