using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FirstWebApp.Repository.Interfaces;

namespace FirstWebApp.Repository.Models
{
    [Table("RegistratedMembers")]
    public class RegistratedMemberDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("UserProfile")]
        public int UserId { get; set; }
        public virtual UserProfileDTO UserProfile { get; set; }

        public DateTime DateRegistration { get; set; }
    }
}