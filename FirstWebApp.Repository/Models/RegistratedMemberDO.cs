using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstWebApp.Repository.Models
{
    [Table("RegistratedMembers")]
    public class RegistratedMemberDO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("UserProfile")]
        public int UserId { get; set; }
        public virtual UserProfileDO UserProfile { get; set; }

        public DateTime DateRegistration { get; set; }
    }
}