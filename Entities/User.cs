namespace Web_Api_User_Management.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? UserAddress { get; set; }
        public int Age { get; set; }

        public string? Job { get; set; }

    }
}
