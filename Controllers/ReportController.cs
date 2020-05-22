using EverestAlbumLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EverestAlbumLibrary.Controllers
{
    public class ReportController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Report
        public ActionResult Index()
        {
            return View();
        }

        //Task1
        public ActionResult FilterTitlesByLastName(string LastName)
        {
            ViewBag.LastName = db.Artists.ToList();
            if (string.IsNullOrEmpty(LastName))
            {
                return View();
            }
            var data = db.ArtistAlbums.Include("Albums").Include("Artist")
                .Where(x => x.Artist.LastName == LastName).ToList();
            return View(data);
        }

        //Task2
        public ActionResult FilterTitlesOnShelve(string LastName)
        {
            ViewBag.LastName = db.Artists.ToList();
            if (string.IsNullOrEmpty(LastName))
            {
                return View();
            }
            string Query = ("SELECT a.Id, Title, CoverImagePath FROM Albums a"+
                "JOIN Loans l ON l.Id = a.Id"+
                "JOIN ArtistAlbums aa ON ar.Id = a.Id"+
                "JOIN Artist ar ON ar.Id = ar.Id" +
                "WHERE ar.LastName = "+LastName+";");

            var data = db.Database.SqlQuery<Album>(Query);

            return View(data);
        }

    }
}