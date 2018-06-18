using BingeList.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TMDbLib.Client;
using TMDbLib.Objects.Movies;

namespace BingeList.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            TMDbClient client = new TMDbClient("a331c3f9e48b75412c7c99a04a4aba78");
            client = MovieDatabase.FetchConfig(client);
            Movie latestMovie = MovieDatabase.FetchFeaturedMovie(client);
            ViewBag.Movie = latestMovie;
            ViewBag.Poster = "https://image.tmdb.org/t/p/w342" + latestMovie.PosterPath;

            if (latestMovie.Videos.Results.Count > 0)
            {
                ViewBag.ButtonLink = "https://www.youtube.com/embed/" + latestMovie.Videos.Results[0].Key;
                ViewBag.ButtonText = "Check out the Trailer »";
            }
            else
            {
                ViewBag.ButtonLink = latestMovie.Homepage;
                ViewBag.ButtonText = "Check out the Website »";
            }


            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}