namespace FirstWebApp.Repository.Interfaces
{
    public interface IUserProfile
    {
        int UserId { get; set; }
        string UserName { get; set; }
        string FullUserName { get; set; }
    }
}
