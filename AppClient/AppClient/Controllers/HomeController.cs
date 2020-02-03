using AppClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AppClient.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        context _db = new context();
        string email;
        public string Getusername()
        {

            HttpCookie cookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (cookie != null)
            {
                FormsAuthenticationTicket ticket1 = FormsAuthentication.Decrypt(cookie.Value);
                email = ticket1.UserData;
            }
            return email;
        }
        public bool IsUserLog()
        {
            string name = Getusername();
            if (name==null)
            {
                return false;
            }
            return true;

        }

        async static Task<string> Get_Request(string URL)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(URL);
            HttpContent content = response.Content;
            string FinalResult = await content.ReadAsStringAsync();
            return FinalResult;
            
        }
        async static Task<string> Post_Request(string URL, string myContent)
        {
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PostAsync(URL, byteContent);
            HttpContent ResultContent = response.Content;
            string FinalResult = await ResultContent.ReadAsStringAsync();
            HttpContentHeaders ResultHeader = ResultContent.Headers;
            return FinalResult;
        }
        async static Task<string> Put_Request(string URL, string myContent)
        {
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PutAsync(URL, byteContent);
            HttpContent ResultContent = response.Content;
            string FinalResult = await ResultContent.ReadAsStringAsync();
            HttpContentHeaders ResultHeader = ResultContent.Headers;
            return FinalResult;
        }
        async static Task<string> Delete_Request(string URL)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.DeleteAsync(URL);
            HttpContent content = response.Content;
            string FinalResult = await content.ReadAsStringAsync();
            return FinalResult;

        }
        //خواندن اطلاعات کاربر از وب سرویس
        [HttpGet]
        public ActionResult Index(string message)
        {
            if (message == null)
            {
                ViewBag.message = "  ";
            }
            else
            {
               ViewBag.message = message;
            }
            ViewBag.userloged = IsUserLog();
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Index(string username, string passwoerd, string ReturnUrl)
        {     User user;
            string result = await Get_Request("http://localhost:1593/api/User/User?username=" + username);
            try
            {
                string deser = JsonConvert.DeserializeObject<string>(result);
                user = JsonConvert.DeserializeObject<User>(deser);
                 if (user != null)
                 {
                     if (user.Password==passwoerd)
                     {

                         FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                   1, "UserLogin", DateTime.Now, DateTime.Now.AddMinutes(30), false, username, FormsAuthentication.FormsCookiePath
                   );
                         string encticket = FormsAuthentication.Encrypt(ticket);
                         Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encticket));

                         if (Url.IsLocalUrl(ReturnUrl))
                         {
                             return Redirect(ReturnUrl);
                         }
                         else
                         {
                             return RedirectToAction("mail", "Home");
                         }

                     }

                 }
                 else
                 {
                     return RedirectToAction("Index", "Home", new { message = "نام یا رمز عبور اشتباه است" });
                 }
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Home", new { message = result });
            }


            return RedirectToAction("Index", "Home", new { message = result });

        }
        //اضافه کردن یک کاربر در وب سرویس
        [HttpGet]
        public ActionResult JoinUs()
        {
            ViewBag.userloged = IsUserLog();
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> JoinUs(User model)
        {
            model.IsActive = false;
            string myContent = JsonConvert.SerializeObject(model);

            string result = await Post_Request("http://localhost:1593/api/User/Add_new", myContent);
            string msg = result;

            return RedirectToAction("Index", "Home", new { message = msg });
        }
        //مشاهده لیست کاربران
        public async Task<ActionResult> Users(string message)
        {
            ViewBag.userloged = IsUserLog();
              string result = await Get_Request("http://localhost:1593/api/User/User");
            string deser = JsonConvert.DeserializeObject<string>(result);
            var users = JsonConvert.DeserializeObject<List<User>>(deser);
            return View(users);
        }
        //ویرایش کاربر در وب سرویس
        [HttpGet]
        public async Task<ActionResult> Edit_User(string message)
        {
            if (message != null)
            {
                ViewBag.msg = message;
            }
            else
            {
                ViewBag.msg = "";
            }
            ViewBag.userloged = IsUserLog();
            string username = Getusername();
            string result = await Get_Request("http://localhost:1593/api/User/User");
            string deser = JsonConvert.DeserializeObject<string>(result);
            var users = JsonConvert.DeserializeObject<List<User>>(deser);
            User temp = (from m in users where m.Email == username select m).FirstOrDefault();
            return View(temp);
        }
        [HttpPost]
        public async Task<ActionResult> Edit_User(User model)
        {
            string myContent = JsonConvert.SerializeObject(model);
            string result = await Put_Request("http://localhost:1593/api/User/Edit", myContent);

            return RedirectToAction("Edit_User", "Home", new { message = result });
        }
        //حذف از جدول کاربر در وب سرویس
        public async Task<ActionResult> Delete_User(int? id)
        {
            ViewBag.userloged = IsUserLog();
            string result = await Delete_Request("http://localhost:1593/api/User/Delete?id=" + id);

            return RedirectToAction("Users", "Home", new { message = result });
          
        }
        //خواندن تمام ایمیل های کاربر از وب سرویس
        [HttpGet]
        public async Task<ActionResult> mail(string message)
        {
            ViewBag.userloged = IsUserLog();
            if (message != null)
            {
                ViewBag.message = message;
            }
            else
            {
                ViewBag.message = "";
            }
            string result = await Get_Request("http://localhost:1593/api/Mail/Mail");
            string deser = JsonConvert.DeserializeObject<string>(result);
            var mails = JsonConvert.DeserializeObject<List<Mail>>(deser);
            return View(mails);
        }
        [HttpGet]
        public async Task<ActionResult> Show_mail(int? id)
        {
            ViewBag.userloged = IsUserLog();
            string result = await Get_Request("http://localhost:1593/api/Mail/Mail");
            string deser = JsonConvert.DeserializeObject<string>(result);
            var mails = JsonConvert.DeserializeObject<List<Mail>>(deser);
            Mail temp = (from m in mails where m.id == id select m).FirstOrDefault();
            return View(temp);
        }
     
        //ارسال ایمیل جدید با کمک وب سرویس
        [HttpGet]
        public ActionResult Send_mail()
        {
            ViewBag.userloged = IsUserLog();

            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Send_mail(Mail model)
        {
            model.IsChecked = false;
            model.Sender = Getusername();
            string myContent = JsonConvert.SerializeObject(model);

            string result = await Post_Request("http://localhost:1593/api/Mail/Add_new", myContent);
            string msg = result;

            return RedirectToAction("mail", "Home", new { message = msg });
          
        }
        //حذف از ایمیل در وب سرویس
 
        public async Task<ActionResult> delete_Mail(int? id)
        {
            string result = await Delete_Request("http://localhost:1593/api/Mail/Delete?id="+id);

            return RedirectToAction("mail", "Home", new { message = result });
        }
        //خروج کاربر
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
	}
}