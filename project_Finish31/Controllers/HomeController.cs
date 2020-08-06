using Carts.Models.Cart;
using Microsoft.Ajax.Utilities;
using project.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace project.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()//首頁
        {
            return View();
        }

        public ActionResult About()//關於廚房助手
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()//
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Member()//會員註冊
        {
            return View();
        }
        [HttpPost]
        public ActionResult Member(FoodUser user)//會員註冊
        {
            string DBPassword = user.Password;  //假設密碼是1234
            OrderFoodEntities db = new OrderFoodEntities();
            var data = from d in db.FoodUser where d.Email == user.Email select d;
            List<FoodUser> pList = data.ToList();
            if (pList.Count == 0)
            {
                //使用FormsAuthentication.HashPasswordForStoringInConfigFile方法，
                //第一個參數是要加密的字串，第二個參數是加密的演算法。
                DBPassword = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile
               (DBPassword, System.Web.Configuration.FormsAuthPasswordFormat.SHA1.ToString());
                user.Password = DBPassword;
                db.FoodUser.Add(user);
                //儲存異動資料
                db.SaveChanges();
                Session["BirthDate"] = user.BirthDate.Value.Month.ToString("D2");
                Session["login"] = user.Email;
                if (user.BirthDate.Value.Month == DateTime.Now.Month)
                {
                    var currentCart = Operation.GetCurrentCart();
                    currentCart.discountRate = 0.95f;
                    currentCart.Memo = "生日月份95折價";

                }

                return RedirectToAction("Index", "Home");
            }


            TempData["message"] = "此信箱已註冊";

            return View();
            //return Content($"<h1>{user.Email}{user.PhoneNum}{data}</h1>");
        }
        public ActionResult EmailCheck(string email)
        {
            OrderFoodEntities db = new OrderFoodEntities();
            var data = (from d in db.FoodUser where d.Email == email select d).FirstOrDefault();
            if (data != null)
            {
                return Content("此信箱已註冊");
            }
            return Content("");

        }
        public ActionResult Terms()//隱私權內容
        {
            return View();
        }

        public ActionResult myLogin()//會員登入
        {
            return View();
        }
        [HttpPost]
        public ActionResult myLogin(FoodUser user)//會員登入
        {
            //假設密碼是1234
            user.Password = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(user.Password, System.Web.Configuration.FormsAuthPasswordFormat.SHA1.ToString());

            OrderFoodEntities db = new OrderFoodEntities();
            var data = from d in db.FoodUser where (d.Email == user.Email && d.Password == user.Password) select d;
            List<FoodUser> pList = data.ToList();
            if (pList.Count == 1)
            {
                Session["login"] = user.Email;
                Session["BirthDate"] = (pList[0].BirthDate).Value.Month.ToString("D2");
                if ((pList[0].BirthDate).Value.Month == DateTime.Now.Month)
                {
                    var currentCart = Operation.GetCurrentCart();
                    currentCart.discountRate = 0.95f;
                    currentCart.Memo = "生日月份95折價";

                }
                return RedirectToAction("Index", "Home");
            }
            ViewBag.message = "帳號密碼錯誤";
            return View();
        }

        public ActionResult myLogOff()
        {
            Session["login"] = null;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult memberData()//會員資料維護
        {

            string userAccount = Convert.ToString(Session["login"]);
            OrderFoodEntities db = new OrderFoodEntities();
            var data = from d in db.FoodUser where (d.Email == userAccount) select d;
            List<FoodUser> pList = data.ToList();

            return View(pList);
        }
        [HttpPost]
        public ActionResult memberData(FoodUser user)//會員資料維護
        {

            string userAccount = Session["login"].ToString();
            OrderFoodEntities db = new OrderFoodEntities();
            var result = (from d in db.FoodUser
                          where d.Email == userAccount
                          select d).FirstOrDefault();
            result.UserName = user.UserName;
            result.PhoneNum = user.PhoneNum;
            result.Address = user.Address;
            db.SaveChanges();
            //設定成功訊息
            TempData["Message"] = String.Format($"會員[{user.Email}]成功編輯");


            var data = from d in db.FoodUser where (d.Email == userAccount) select d;
            List<FoodUser> pList = data.ToList();

            return View(pList);


        }


        public ActionResult Menu()//找食材
        {
            //ViewBag.test = select;
            OrderFoodEntities db = new OrderFoodEntities();
            var data = from d in db.FoodProduct where (d.ProductClass == "Vege" || d.ProductClass == "Meat" || d.ProductClass == "Fruit") select d;
            List<FoodProduct> pList = data.ToList();
            return View(pList);
        }
        public ActionResult Test()
        {
            OrderFoodEntities db = new OrderFoodEntities();

            var data = from d in db.FoodProduct select d;
            List<FoodProduct> pList = data.ToList();
            return View(pList);

        }
        public ActionResult Vegetables()//來點菜
        {
            //ViewBag.test = select;
            OrderFoodEntities db = new OrderFoodEntities();
            var data = from d in db.FoodProduct where (d.ProductClass != "Vege" && d.ProductClass != "Meat" && d.ProductClass != "Fruit") select d;
            List<FoodProduct> pList = data.ToList();
            return View(pList);
        }

        public ActionResult Special_LowGi()//Special_LowGi
        {
            return View();
        }

        public ActionResult Special_LowFat()//Special_LowFat
        {
            return View();
        }

        public ActionResult Special_LowNa()//Special_LowNa
        {
            return View();
        }

        //public int ship = 290;


        public ActionResult orderQ(int? id)//訂單明細查詢
        {
            string userAccount = Convert.ToString(Session["login"]);
            OrderFoodEntities db = new OrderFoodEntities();
            var data = from d in db.OrderDetail where (d.OrderID == id) select d;
            List<OrderDetail> pList = data.ToList();

            return View(pList);
        }

        public ActionResult orderL()//訂單查詢列表
        {
            string userAccount = Convert.ToString(Session["login"]);

            OrderFoodEntities db = new OrderFoodEntities();
            var data = (from d in db.FoodUser where (d.Email == userAccount) select d.UserID).FirstOrDefault();
            int userId = data;
            var data2 = from d in db.OrderTable where (d.UserID == userId)  orderby d.OrderDate descending select d;
            List<OrderTable> pList = data2.ToList();

            return View(pList);
        }

    }
}