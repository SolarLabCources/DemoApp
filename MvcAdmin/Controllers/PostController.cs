using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using BusinessLogic.Abstraction;
using BusinessLogic.Implementation;
using BusinessLogic.Objects;
using MvcAdmin.Models;

namespace MvcAdmin.Controllers
{
    [Authorize]
    public class PostController : Controller
    {
        private IPostManager _postManager;

        public PostController(IPostManager postManager)
        {
            _postManager = postManager;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var posts = _postManager.GetPosts();
            var postVms = AutoMapper.Mapper.Map<IEnumerable<PostViewModel>>(posts);
            return View(postVms);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(PostViewModel post)
        {
            if (ModelState.IsValid)
            {
                var postDto = Mapper.Map<PostDto>(post);
                _postManager.AddPost(postDto);
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
                var postForEdit = _postManager.GetById(id);
                var postVm = Mapper.Map<PostViewModel>(postForEdit);
                return View(postVm);
        }

        [HttpPost]
        public ActionResult Edit(PostViewModel post)
        {
            if (ModelState.IsValid)
            {
                var postDto = Mapper.Map<PostDto>(post);
                _postManager.EditPost(postDto);
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            _postManager.DeletePost(id);

            if (Request.IsAjaxRequest())
            {
                var posts = Mapper.Map<IEnumerable<PostViewModel>>(_postManager.GetPosts());
                return PartialView("_PostsList", posts);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var post = _postManager.GetById(id);
            var postVm = Mapper.Map<PostViewModel>(post);
            return View(postVm);
        }
    }
}