using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyClass.Model;
using MyClass.DAO;

namespace CongCafe.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        //private MyDBContext db = new MyDBContext();
        CategoriesDAO categoryDAO = new CategoriesDAO();

        // GET: Admin/Category
        public ActionResult Index()
        {
            //return View(db.Categories.ToList());
            return View(categoryDAO.getList("Index"));
        }

        // GET: Admin/Category/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categories categories = categoryDAO.getRow(id);
            if (categories == null)
            {
                return HttpNotFound();
            }
            return View(categories);
        }

        // GET: Admin/Category/Create
        public ActionResult Create()
        {
            ViewBag.ListCat = new SelectList(categoryDAO.getList("Index"), "Id", "Name");
            return View();
        }

        // POST: Admin/Category/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categories categories)
        {
            if (ModelState.IsValid)
            {

                //db.Categories.Add(categories);
                //db.SaveChanges();
                categoryDAO.Insert(categories);
                return RedirectToAction("Index");
            }

            return View(categories);
        }

        // GET: Admin/Category/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Categories categories = db.Categories.Find(id);
            Categories categories = categoryDAO.getRow(id);
                if (categories == null)
            {
                return HttpNotFound();
            }
            return View(categories);
        }

        // POST: Admin/Category/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categories categories)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(categories).State = EntityState.Modified;
                //db.SaveChanges();
                categoryDAO.Update(categories);
                return RedirectToAction("Index");
            }
            return View(categories);
        }

        // GET: Admin/Category/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Categories categories = db.Categories.Find(id);
            Categories categories = categoryDAO.getRow(id);
            if (categories == null)
            {
                return HttpNotFound();
            }
            return View(categories);
        }

        // POST: Admin/Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Categories categories = db.Categories.Find(id);
            Categories categories = categoryDAO.getRow(id);
            categoryDAO.Delete(categories);
            //db.Categories.Remove(categories);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
