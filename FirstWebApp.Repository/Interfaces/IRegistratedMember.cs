using System;

namespace FirstWebApp.Repository.Interfaces
{
    public interface IRegistratedMember
    {
        int Id { get; set; }
        int UserId { get; set; }
        IUserProfile UserProfile { get; set; }
        DateTime DateRegistration { get; set; }
    }
}
