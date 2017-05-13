﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fundamentals.DomainModel;
using Fundamentals.Models;
using Fundamentals.Models.DBContext;
using Fundamentals.Models.Movies;
using File = Fundamentals.DomainModel.File;

namespace Fundamentals.Controllers
{
    [AllowAnonymous]
    public class MoviesController : Controller
    {
        private readonly FundamentalsDBContext _dbContext;

        public MoviesController()
        {
            _dbContext = new FundamentalsDBContext();
        }

        public ActionResult Index()
        {
            if(User.Identity.IsAuthenticated && User.IsInRole(Roles.CanEditMoviesRole))
                return View();
            return View("IndexReadOnly");
        }

        [Authorize(Roles = Roles.CanEditMoviesRole)]
        public ActionResult New()
        {
            EditMovieViewModel model = new EditMovieViewModel()
            {
                Movie = new MovieViewModel(),
                Ganres = _dbContext.Ganres.ToList()
            };
            model.Movie.GanreId = model.Ganres.FirstOrDefault()?.Id ?? 0;
            return View("Edit", model);
        }

        [Authorize(Roles = Roles.CanEditMoviesRole)]
        public ActionResult Edit(int id)
        {
            var movie = _dbContext.Movies.SingleOrDefault(x => x.Id == id);
            if(movie == null)
                   return View("MovieNotFound", id);
            EditMovieViewModel model = new EditMovieViewModel()
            {
                Movie = movie,
                Ganres = _dbContext.Ganres.ToList()
            };
            return View("Edit", model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Roles.CanEditMoviesRole)]
        public ActionResult Delete(int id)
        {
            var movie = _dbContext.Movies.SingleOrDefault(x => x.Id == id);
            if (movie == null)
                return HttpNotFound();
            _dbContext.Movies.Remove(movie);
            _dbContext.SaveChanges();
            return Json("Movie was successfully  deleted");
        }

        [HttpPost]
        [Authorize(Roles = Roles.CanEditMoviesRole)]
        [ValidateAntiForgeryToken]
        public ActionResult Save(EditMovieViewModel model, HttpPostedFileBase upload)
        {
            if (!ModelState.IsValid)
            {
                model.Ganres = _dbContext.Ganres.ToList();
                return View("Edit", model);
            }
            if (upload != null && upload.ContentLength > 0)
            {
                var file = new File
                {
                    FileName = System.IO.Path.GetFileName(upload.FileName),
                    ContentType = upload.ContentType
                };
                using (var reader = new System.IO.BinaryReader(upload.InputStream))
                {
                    file.Content = reader.ReadBytes(upload.ContentLength);
                }

                var saved = _dbContext.Files.Add(file);
                _dbContext.SaveChanges();
                model.Movie.FileId = saved.Id;
            }



            _dbContext.Movies.AddOrUpdate(model.Movie);
            _dbContext.SaveChanges();



            return RedirectToAction("Index");
        }

        public ActionResult Play(int id)
        {
            var movie = _dbContext.Movies.SingleOrDefault(x => x.Id == id);
            var file = _dbContext.Files.FirstOrDefault(x => x.Id == movie.FileId);
            if (file != null)
                return File(file.Content, "audio/mp3");
            return File(new byte[0], "audio/mp3");
        }

        protected override void Dispose(bool disposing)
        {
            this._dbContext.Dispose();
            base.Dispose(disposing);
        }

    
    }
}