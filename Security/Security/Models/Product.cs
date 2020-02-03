using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Security.Models
{
    public class Product
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string Mark { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Cost { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string Content { get; set; }
        [Required]
        public string img { get; set; }
        public string Offer { get; set; }
        [DataType(DataType.MultilineText)]
        public string featureString { get; set; }
        [Required]
        public bool IsExist { get; set; }
        [Required]
        public int count { get; set; }
        public DateTime date { get; set; }
     
        public int seen { get; set; }
       
    }
}