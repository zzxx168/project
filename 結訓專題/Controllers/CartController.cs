using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Carts.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }

        //取得目前購物車頁面
        public ActionResult GetCart()
        {
            return PartialView("_CartPartial");
        }

        //以id加入Product至購物車，並回傳購物車頁面
        public ActionResult AddToCart(int id, int quantity)
        {
            var currentCart = Models.Cart.Operation.GetCurrentCart();
            currentCart.AddProduct(id, quantity);
            return PartialView("_CartPartial");
        }
        public ActionResult EditToCart(int id, int quantity)
        {
            // return Content("holyshit");
            var currentCart = Models.Cart.Operation.GetCurrentCart();
            currentCart.EditProduct(id, quantity);
            return PartialView("_CartPartial");
            // return Content("shit");
        }
    }
}