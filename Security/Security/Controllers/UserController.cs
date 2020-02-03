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
    public class UserController : ApiController
    {
        context _db = new context();
        string result;
        [HttpPost]
        public string Add_User(JObject jsonResult)
        {
            var user = JsonConvert.DeserializeObject<User>(jsonResult.ToString());
           // user.JoinDate = DateTime.Now;
            _db.tbl_user.Add(user);
            _db.SaveChanges();
            return "کاربر اضافه شد";
        }

        [HttpGet]
        public string Get_User(int id)
        {
            var exist = (from u in _db.tbl_user
                         where u.id == id
                         select u).FirstOrDefault();
            if (exist != null)
                result = JsonConvert.SerializeObject(exist, Newtonsoft.Json.Formatting.Indented);
            else
                result = "کاربر مورد نظر یافت نشد";

            return result;
        }

        [HttpPut]
        public string Edit_User(JObject jsonResult)
        {
            var modify = JsonConvert.DeserializeObject<User>(jsonResult.ToString());
            _db.Entry(modify).State = EntityState.Modified;
            _db.SaveChanges();
            return "کاربر تغییر یافت";
        }
        [HttpDelete]
        public string Delete_User(int id)
        {
            var delete = (from u in _db.tbl_user
                          where u.id == id
                          select u).FirstOrDefault();
            if (delete != null)
            {
                _db.tbl_user.Remove(delete);
                _db.SaveChanges();
                result = "کاربر حذف شد.";
            }
            else
            {
                result = "کاربر مورد نظر یافت نشد";
            }

            return result;
        }
    }
}
