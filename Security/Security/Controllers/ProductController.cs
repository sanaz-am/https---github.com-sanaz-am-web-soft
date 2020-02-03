using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Security.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Security.Controllers
{
    public class ProductController : ApiController
    {
        context _db = new context();
        string result;
        [HttpPost]
        public string Add_Product(JObject jsonResult, string dbKey)
        {
            var prod = JsonConvert.DeserializeObject<Product>(jsonResult.ToString());
            _db.tbl_Product.Add(prod);
            _db.SaveChanges();
            return "محصول جدید اضافه شد";
        }

        [HttpGet]
        public string Get_Product(int id)
        {
            var exist = (from p in _db.tbl_Product
                         where p.id == id
                         select p).FirstOrDefault();
            if (exist != null)
                result = JsonConvert.SerializeObject(exist, Newtonsoft.Json.Formatting.Indented);
            else
                result = "محصول مورد نظر یافت نشد";

            return result;
        }

        [HttpPut]
        public string Edit_Product(JObject jsonResult)
        {
            var modify = JsonConvert.DeserializeObject<Product>(jsonResult.ToString());
            _db.Entry(modify).State = EntityState.Modified;
            _db.SaveChanges();
            return "محصول مورد نظر تغییر یافت";
        }
        [HttpDelete]
        public string Delete_Product(int id)
        {
            var delete = (from u in _db.tbl_Product
                          where u.id == id
                          select u).FirstOrDefault();
            if (delete != null)
            {
                _db.tbl_Product.Remove(delete);
                _db.SaveChanges();
                result = "محصول حذف شد.";
            }
            else
            {
                result = "محصول مورد نظر یافت نشد";
            }

            return result;
        }
    }
}
