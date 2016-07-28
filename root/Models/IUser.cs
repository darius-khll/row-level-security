namespace Console1.Models
{
    public interface IUser
    {
        int UserId { get; set; }

        User User { get; set; }
    }
}
