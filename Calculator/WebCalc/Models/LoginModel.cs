using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebCalc.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Без имени мы вас не узнаем")]
        [Display(Name = "Логин или e-mail")]
        public string Login { get; set; }

        [Required]
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        //[StringLength(maximumLength: 50, MinimumLength = 8)]
        public string Password { get; set; }
    }
}