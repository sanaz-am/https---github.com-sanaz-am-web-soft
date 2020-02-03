using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Security.Models
{
    public class OrderList
    {
        [Key]
        public int id { get; set; }
        [Display(Name = "شماره رهگیری")]
        public int checkId { get; set; }
          [Display(Name = "وضعیت")]
        public bool sent { get; set; }
        [Display(Name="تاریخ")]
        public DateTime date { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User user { get; set; }
        public List<Product> products { get; set; }
    }
}