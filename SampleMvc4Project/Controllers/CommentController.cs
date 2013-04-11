using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SampleMvc4Project.Entitys;
using SampleMvc4Project.Interfaces;

namespace SampleMvc4Project.Controllers
{
    public class CommentController : Controller
    {
        private readonly IBlogUnitOfWork _blogUnitOf;

        public CommentController(IBlogUnitOfWork blogUnitOf)
        {
            _blogUnitOf = blogUnitOf;
        }

        public ActionResult CreateComment(Int64 id)
        {
            ViewBag.id = id;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateComment(Int64 id, Comment comment)
        {
            if (ModelState.IsValid)
            {
                comment.DateCreate = DateTime.Now;
                comment.PostId = id;
                _blogUnitOf.Comment.Add(comment);
                _blogUnitOf.Save();
                return RedirectToAction("ViewAPost", "Post", new {id});
            }
            return View();
        }

        public ActionResult EditComment(Int64 id)
        {
            var comment = _blogUnitOf.Comment.GetById(id);
            return View(comment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditComment(Comment comment)
        {
            if (ModelState.IsValid)
            {
                _blogUnitOf.Comment.Update(comment);
                _blogUnitOf.Save();
                return RedirectToAction("ViewAPost", "Post", new { id= comment.PostId });
            }
            return View();
        }

        public  ActionResult DeleteComment(Int64 id)
        {
            var comment = _blogUnitOf.Comment.GetById(id);
            return View(comment);
        }

        [HttpPost]
        public ActionResult DeleteComment(Int64 id, Int64 postId)
        {
            _blogUnitOf.Comment.Remove(id);
            _blogUnitOf.Save();
            return RedirectToAction("ViewAPost", "Post", new { id = postId });
        }

    }
}
