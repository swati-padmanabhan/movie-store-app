using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MovieLibrary.Model;

namespace MovieLibrary.Services
{
    public class DataSerialize
    {
        //public static string path = ConfigurationManager.AppSettings["filePath"]!.ToString();
        public static string path = $"C:/Users/swati.padmanabhan/Desktop/Mini Projects/MovieStoreFinalLevel/FinalLayeredMovieApp/MovieLibrary/Assets/myMovies.json";
        
        public static void SerializeMovies(List<Movie> movies)
        {
            using (StreamWriter sw = new StreamWriter(path, false))
            {
                sw.WriteLine(JsonSerializer.Serialize(movies));
            }
        }

        public static List<Movie> DeserializeMovies()
        {
            if (!File.Exists(path))
                return new List<Movie>();
            using (StreamReader sr = new StreamReader(path))
            {
                List<Movie> movies = JsonSerializer.Deserialize<List<Movie>>(sr.ReadToEnd());
                return movies;
            }
            
        }
    }
}
