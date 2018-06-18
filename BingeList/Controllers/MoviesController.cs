using BingeList.Helpers;
using BingeList.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TMDbLib.Client;
using TMDbLib.Objects.Search;

namespace BingeList.Controllers
{
    public class MoviesController : Controller
    {
        private BingeListDBContext db = new BingeListDBContext();
        public ActionResult Index()
        {
            TMDbClient client = new TMDbClient("a331c3f9e48b75412c7c99a04a4aba78");
            client = MovieDatabase.FetchConfig(client);
            var results = client.DiscoverMoviesAsync().WhereAnyReleaseDateIsInYear(DateTime.Now.Year).OrderBy(TMDbLib.Objects.Discover.DiscoverMovieSortBy.PopularityDesc).Query().Result.Results;
            ViewBag.Results = results;

            string currentUserId = User.Identity.GetUserId();
            ViewBag.Favourites = db.FavouriteMovies.Where(x => x.UserId == currentUserId).Select(x => x.MovieId).ToList();

            return View();
        }

        [HttpPost]
        public ActionResult Index(string search)
        {
            TMDbClient client = new TMDbClient("a331c3f9e48b75412c7c99a04a4aba78");
            client = MovieDatabase.FetchConfig(client);
            var results = client.SearchMovieAsync(search).Result.Results;
            ViewBag.SearchTerm = search;
            ViewBag.Results = results;

            string currentUserId = User.Identity.GetUserId();
            ViewBag.Favourites = db.FavouriteMovies.Where(x => x.UserId == currentUserId).Select(x => x.MovieId).ToList();

            return View();
        }
    }
}