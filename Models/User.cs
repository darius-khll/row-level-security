namespace Console1.Models
{
    public enum UserType
    {
        Admin,
        Ordinary
    }
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public UserType Type { get; set; }

    }
}
