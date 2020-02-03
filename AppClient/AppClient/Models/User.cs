using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppClient.Models
{
    public class User
    {
        [Key]
        public int id { get; set; }
         [Display(Name = "نام")]
         [Required(ErrorMessage = "اجباری")]
        public string Name { get; set; }
         [Remote("ChekExistEmail", "Acount")]
         [Display(Name = "ایمیل")]
         [Required(ErrorMessage = "اجباری")]
        public string Email { get; set; }
         [Display(Name = "آدرس")]

         [DataType(DataType.MultilineText)]
        public string Address { get; set; }
         [Display(Name = "رمز عبور")]
         [Required(ErrorMessage = "اجباری")]
         [DataType(DataType.Password)]
        public string Password { get; set; }
         [DataType(DataType.Password)]
         [Display(Name = "تکرار رمز عبور")]
         [Required(ErrorMessage = "اجباری")]
         [System.Web.Mvc.Compare("Password", ErrorMessage = "رمزها یکسان نمی باشد")]
        public string RePassword { get; set; }
        public bool IsActive { get; set; }
        public User()
        {

        }
    }
}