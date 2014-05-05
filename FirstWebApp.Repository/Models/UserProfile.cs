using FirstWebApp.Repository.Interfaces;

namespace FirstWebApp.Repository.Models
{
    public class UserProfile : IUserProfile
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FullUserName { get; set; }
    }
}