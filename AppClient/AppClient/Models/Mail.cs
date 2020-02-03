using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppClient.Models
{
    public class Mail
    {
        [Key]
        public int id { get; set; }
        [Display(Name = "موضوع")]
        [Required(ErrorMessage = "اجباری")]
        public string Name { get; set; }
        [Required(ErrorMessage = "اجباری")]
        [Display(Name = "فرستنده")]
        public string Sender { get; set; }
        [Required(ErrorMessage = "اجباری")]
        [Display(Name = "دریافت کننده")]
        public string Resiver { get; set; }
        [Required(ErrorMessage = "اجباری")]
        [Display(Name = "پیام")]
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }
        public bool IsChecked { get; set; }
         public Mail()
        {

        }
    }
}