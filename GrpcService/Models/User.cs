namespace GrpcService.Models
{
    public class User
    {
        public int UserId { get; set; }

        //  TODO: Add unique constraint
        public string UserName { get; set; }

        public string HashedPassword { get; set; }
    }
}
