namespace GrpcService.Models
{
    public class Meter
    {
        public int MeterId { get; set; }

        //  TODO: Add unique constraint
        public string MeterNumber { get; set; }
    }
}
