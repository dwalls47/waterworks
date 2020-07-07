using Grpc.Core;
using GrpcService.Data;
using GrpcService.Protos;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace GrpcService.Services
{
    public class MetersService : RemoteMeter.RemoteMeterBase
    {
        private readonly ILogger<MetersService> _logger;
        private readonly WaterWorksDbContext _context;

        public MetersService(ILogger<MetersService> logger, WaterWorksDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public override Task<MeterModel> GetMeterInfo(MeterLookupModel request, ServerCallContext context)
        {
            MeterModel output = new MeterModel();

            var meter = _context.Meters.Find(request.MeterId);

            _logger.LogInformation("Sending Meter response");

            if (meter != null)
            {
                output.MeterId = meter.MeterId;
                output.MeterNumber = meter.MeterNumber;
            }

            return Task.FromResult(output);
        }
    }
}
