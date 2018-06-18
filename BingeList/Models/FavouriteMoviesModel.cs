using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace BingeList.Models
{
    public class FavouriteMovie
    {
        public int ID { get; set; }
        public string UserId { get; set; }
        public string MovieId { get; set; }
        [Column(TypeName = "xml")]
        public string movieInfo { get; set; }
        public bool UserHasWatched { get; set; }

        [NotMapped]
        public XElement MovieInfo
        {
            get { return XElement.Parse(movieInfo); }
            set { movieInfo = value.ToString(); }
        }
    }

    public class BingeListDBContext : DbContext
    {
        public DbSet<FavouriteMovie> FavouriteMovies { get; set; }
    }
}