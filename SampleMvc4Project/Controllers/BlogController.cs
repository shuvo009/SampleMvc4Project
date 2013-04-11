using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SampleMvc4Project.Entitys;
using SampleMvc4Project.Interfaces;

namespace SampleMvc4Project.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogUnitOfWork _blogUnitOfWork;

        public BlogController(IBlogUnitOfWork blogUnitOfWork)
        {
            _blogUnitOfWork = blogUnitOfWork;
        }

        public ActionResult Index()
        {
            var z = _blogUnitOfWork.Blog.GetAll();
            return View(z);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Blog blog)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _blogUnitOfWork.Blog.Add(blog);
                    _blogUnitOfWork.Save();
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch (Exception)
            {
                return View();
            }
        }

        public ActionResult DeleteBlog(Int64 id)
        {
            var blog = _blogUnitOfWork.Blog.GetById(id);
            ViewBag.id = id;
            return View(blog);
        }

        [HttpPost]
        public ActionResult DeleteBlog(Int64 id,FormCollection collection)
        {
            _blogUnitOfWork.Blog.Remove(id);
            _blogUnitOfWork.Save();
            return RedirectToAction("Index");
        }

        public ActionResult EditBlog(Int64 id)
        {
            var blog = _blogUnitOfWork.Blog.GetById(id);
            return View(blog);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditBlog(Int64 id, Blog blog)
        {
            _blogUnitOfWork.Blog.Update(blog);
            _blogUnitOfWork.Save();
            return RedirectToAction("Index");
        }

    }
}
