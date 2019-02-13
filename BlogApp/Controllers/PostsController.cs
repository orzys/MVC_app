using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BlogApp;
using BlogApp.Models;

namespace BlogApp.Controllers
{
    public class PostsController : Controller
    {
        public BlogContext db = new BlogContext();

        // GET: Posts
        [Authorize(Roles = "A,U")]
        public ActionResult Index()
        {
            return View(db.Posts.ToList());
        }

        // GET: Posts/Details/5
        [Authorize(Roles = "A,U")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // GET: Posts/Create
        [Authorize(Roles = "A")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Posts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PostId,Title,ShortContent,Content,Author,PostDate,HidePost")] Post post, HttpPostedFileBase UploadImage)
        {
            if (ModelState.IsValid)
            {
                if(UploadImage != null)
                {
                    if (UploadImage.ContentType == "image/jpg" || UploadImage.ContentType == "image/png" || UploadImage.ContentType == "image/gif" || UploadImage.ContentType == "image/bmp" || UploadImage.ContentType == "image/jpeg")
                    {
                        UploadImage.SaveAs(Server.MapPath("/") + "/Content/Images/" + UploadImage.FileName);
                        post.ImageUrl = UploadImage.FileName;
                    }
                    else
                        return View();
                }
                post.PostDate = DateTime.Now;
                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(post);
        }

        // GET: Posts/Edit/5
        [Authorize(Roles = "A")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PostId,Title,ShortContent,Content,Author,PostDate,HidePost")] Post post, HttpPostedFileBase UploadImage)
        {
            if (ModelState.IsValid)
            {
                if (UploadImage != null)
                {
                    if (UploadImage.ContentType == "image/jpg" || UploadImage.ContentType == "image/png" || UploadImage.ContentType == "image/gif" || UploadImage.ContentType == "image/bmp" || UploadImage.ContentType == "image/jpeg")
                    {
                        UploadImage.SaveAs(Server.MapPath("/") + "/Content/Images/" + UploadImage.FileName);
                        post.ImageUrl = UploadImage.FileName;
                    }
                    else
                        return View();
                }
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(post);
        }

        // GET: Posts/Delete/5
        [Authorize(Roles = "A")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = db.Posts.Find(id);
            db.Posts.Remove(post);
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
