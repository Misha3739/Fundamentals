﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fundamentals.Models;
using Fundamentals.Models.FundamentalsDBContext;
using Fundamentals.Models.Movies;
using File = Fundamentals.Models.Movies.File;

namespace Fundamentals.Controllers
{
    public class MoviesController : Controller
    {
        private readonly FundamentalsDBContext _dbContext;

        public MoviesController()
        {
            _dbContext = new FundamentalsDBContext();
        }
        // GET: Videos
        public ActionResult Index()
        {
            var movies = _dbContext.Movies.Include(x=>x.Ganre).ToList();
            return View(movies);
        }

        public ActionResult NewMovie()
        {
            EditMovieViewModel model = new EditMovieViewModel()
            {
                Movie = new MovieViewModel(),
                Ganres = _dbContext.Ganres.ToList()
            };
            return View("EditMovie",model);
        }

        public ActionResult EditMovie(int id)
        {
            EditMovieViewModel model = new EditMovieViewModel()
            {
                Movie = _dbContext.Movies.Single(x=>x.Id == id),
                Ganres = _dbContext.Ganres.ToList()
            };
            return View("EditMovie", model);
        }



        [HttpPost]
        public ActionResult Save(EditMovieViewModel model, HttpPostedFileBase upload)
        {
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
                model.Movie.FileId = saved.Id;
            }
           


            _dbContext.Movies.AddOrUpdate(model.Movie);
            _dbContext.SaveChanges();



           return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            this._dbContext.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult PlayMovie(int id)
        {
            var found = _dbContext.Movies.SingleOrDefault(x => x.Id == id);
            return Json("OK");
        }
    }
}