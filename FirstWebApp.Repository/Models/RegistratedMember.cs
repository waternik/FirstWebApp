using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FirstWebApp.Repository.Interfaces;

namespace FirstWebApp.Repository.Models
{
    public class RegistratedMember : IRegistratedMember
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual IUserProfile UserProfile { get; set; }
        public DateTime DateRegistration { get; set; }
    }
}