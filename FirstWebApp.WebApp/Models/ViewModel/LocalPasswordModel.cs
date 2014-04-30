using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FirstWebApp.WebApp.Models.ViewModel
{
    public class LocalPasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Текущий пароль")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Пароль должен содержать не менее {2} символов.", MinimumLength = 3)]
        [DataType(DataType.Password)]
        [Display(Name = "Новый пароль")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Повторите новый пароль")]
        [Compare("NewPassword", ErrorMessage = "Пароли не сопадают, повторите пожалуйста ввод.")]
        public string ConfirmPassword { get; set; }
    }
}