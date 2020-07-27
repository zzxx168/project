using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace project.Models
{
    public class FoodUsersController : Controller
    {
        private OrderFoodEntities db = new OrderFoodEntities();

        // GET: FoodUsers
        public ActionResult Index()
        {
            return View(db.FoodUser.ToList());
        }

        // GET: FoodUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodUser foodUser = db.FoodUser.Find(id);
            if (foodUser == null)
            {
                return HttpNotFound();
            }
            return View(foodUser);
        }

        // GET: FoodUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FoodUsers/Create
        // 若要免於大量指派 (overposting) 攻擊，請啟用您要繫結的特定屬性，
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,UserName,PhoneNum,Email,BirthDate,Address")] FoodUser foodUser)
        {
            if (ModelState.IsValid)
            {
                db.FoodUser.Add(foodUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(foodUser);
        }

        // GET: FoodUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodUser foodUser = db.FoodUser.Find(id);
            if (foodUser == null)
            {
                return HttpNotFound();
            }
            return View(foodUser);
        }

        // POST: FoodUsers/Edit/5
        // 若要免於大量指派 (overposting) 攻擊，請啟用您要繫結的特定屬性，
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,UserName,PhoneNum,Email,BirthDate,Address")] FoodUser foodUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(foodUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(foodUser);
        }

        // GET: FoodUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodUser foodUser = db.FoodUser.Find(id);
            if (foodUser == null)
            {
                return HttpNotFound();
            }
            return View(foodUser);
        }

        // POST: FoodUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FoodUser foodUser = db.FoodUser.Find(id);
            db.FoodUser.Remove(foodUser);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
