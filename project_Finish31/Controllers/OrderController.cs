using Carts.Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Carts.Models.Cart;
using project.Models;
//using System.Security.Cryptography.X509Certificates;

namespace project.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            if (Session["login"] == null)
            {
                return RedirectToAction("myLogin", "Home");
            }
            return View();
        }


        public ActionResult Buy()
        {
            if (this.ModelState.IsValid)
            {   //取得目前購物車
                var currentCart = Operation.GetCurrentCart();

                //取得目前登入使用者Id


                using (OrderFoodEntities db = new OrderFoodEntities())
                {
                    string email = Session["login"].ToString();
                    var result = (from d in db.FoodUser
                                  where d.Email == email
                                  select d).FirstOrDefault();
                    var userId = result.UserID;
                    //建立Order物件
                    var order = new OrderTable
                    {
                        UserID = userId,
                        PriceTotal = currentCart.TotalAmount,
                        OrderDate = DateTime.Now
                    };
                    //加其入Orders資料表後，儲存變更
                    db.OrderTable.Add(order);
                    db.SaveChanges();

                    //取得購物車中OrderDetai物件
                    var orderDetails = currentCart.ToOrderDetailList(order.OrderID);

                    //將其加入OrderDetails資料表後，儲存變更
                    db.OrderDetail.AddRange(orderDetails);
                    db.SaveChanges();
                }
                //Session["Cart"] = null;
                currentCart.Clear();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}