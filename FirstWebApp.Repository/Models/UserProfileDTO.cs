using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FirstWebApp.Repository.Interfaces;
using System.Linq;
using System.Web;

namespace FirstWebApp.Repository.Models
{
    [Table("UserProfile")]
    public class UserProfileDTO
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FullUserName { get; set; }
    }
}