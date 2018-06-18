using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;
using System.Xml.Serialization;
using TMDbLib.Client;
using TMDbLib.Objects.Discover;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Movies;
using TMDbLib.Objects.Search;

namespace BingeList.Helpers
{
    public static class MovieDatabase
    {
        public static TMDbClient FetchConfig(TMDbClient client)
        {
            FileInfo configJson = new FileInfo(HttpContext.Current.Server.MapPath(@"~\Content\MovieDBConfig.json"));

            //Use stored config
            string json = File.ReadAllText(configJson.FullName, Encoding.UTF8);

            client.SetConfig(JsonConvert.DeserializeObject<TMDbConfig>(json));

            return client;
        }

        public static Movie FetchFeaturedMovie(TMDbClient client)
        {
            int[] featuredMovies = { 402900, 284054, 299536, 348350, 383498 };

            Random rnd = new Random();
            int r = rnd.Next(featuredMovies.Count());

            Movie movie = client.GetMovieAsync(featuredMovies[r], MovieMethods.Videos).Result;

            return movie;
        }

        public static Movie GetMovieDetails(TMDbClient client, int movieId)
        {
            Movie movie = client.GetMovieAsync(movieId, MovieMethods.Videos | MovieMethods.Images).Result;

            return movie;
        }

        public static List<SearchMovie> SearchMovies(TMDbClient client, string searchTerm)
        {
            var results = client.SearchMovieAsync(searchTerm).Result.Results;

            return results;
        }

        public static string GetXMLFromObject(object o)
        {
            StringWriter sw = new StringWriter();
            XmlTextWriter tw = null;
            try
            {
                XmlSerializer serializer = new XmlSerializer(o.GetType());
                tw = new XmlTextWriter(sw);
                serializer.Serialize(tw, o);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sw.Close();
                if (tw != null)
                {
                    tw.Close();
                }
            }
            return sw.ToString();
        }

        public static Object ObjectToXML(string xml, Type objectType)
        {
            StringReader strReader = null;
            XmlSerializer serializer = null;
            XmlTextReader xmlReader = null;
            Object obj = null;
            try
            {
                strReader = new StringReader(xml);
                serializer = new XmlSerializer(objectType);
                xmlReader = new XmlTextReader(strReader);
                obj = serializer.Deserialize(xmlReader);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (xmlReader != null)
                {
                    xmlReader.Close();
                }
                if (strReader != null)
                {
                    strReader.Close();
                }
            }
            return obj;
        }
    }
}