using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SampleMvc4Project.Entitys;
using SampleMvc4Project.Interfaces;

namespace SampleMvc4Project.Controllers
{
    public class PostController : Controller
    {
        private readonly IBlogUnitOfWork _unitOfWork;

        public PostController(IBlogUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult ViewAllPost(Int64 id = 0)
        {
            ViewBag.id = id;
            var posts = _unitOfWork.Post.Search(x => x.BlogId == id);
            return View(posts);
        }

        public ActionResult ViewAPost(Int64 id = 0)
        {
            var post = _unitOfWork.Post.GetById(id);
            post.Comments = new Collection<Comment>();
            post.Comments = _unitOfWork.Comment.Search(x => x.PostId == post.Id).ToList();
            return View(post);
        }

        public ActionResult CreatePost(Int64 id)
        {
            ViewBag.id = id;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePost(Int64 id, Post post)
        {
            if (ModelState.IsValid)
            {
                post.BlogId = id;
                post.DateCreate = DateTime.Today;
                _unitOfWork.Post.Add(post);
                _unitOfWork.Save();
                return RedirectToAction("ViewAllPost", new { id });
            }
            return View();
        }

        public ActionResult EditPost(Int64 id)
        {
            var post = _unitOfWork.Post.GetById(id);
            return View(post);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(Post post)
        {
            if(ModelState.IsValid)
            {
                _unitOfWork.Post.Update(post);
                _unitOfWork.Save();
                return RedirectToAction("ViewAllPost",new{id= post.BlogId});
            }
            return View();
        }

        public ActionResult DeletePost(Int64 id)
        {
            var post = _unitOfWork.Post.GetById(id);
            return View(post);
        }

        [HttpPost]
        public ActionResult DeletePost(Int64 id, Int64 blogId)
        {
            _unitOfWork.Post.Remove(id);
            _unitOfWork.Save();
            return RedirectToAction("ViewAllPost", new {id = blogId});
        }
    }
}
