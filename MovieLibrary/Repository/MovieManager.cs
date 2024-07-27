using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieLibrary.Exceptions;
using MovieLibrary.Model;
using MovieLibrary.Services;

namespace MovieLibrary.Repository
{
    public class MovieManager
    {
        public static List<Movie> movies = new List<Movie>();


        public static void ManageMovies()
        {
            movies = DataSerialize.DeserializeMovies();
        }

        public static void AddNewMovie(int id, string name, string genre, DateTime yearOfRelease)
        {
            if (movies.Count >= 5)
            {
                throw new CapacityIsFullException("Insufficient space, only 5 movies allowed.");
                return;
            }
            Movie newMovie = Movie.CreateMovie(id, name, genre, yearOfRelease);
            movies.Add(newMovie);
        }

        public static List<Movie> DisplayMovies()
        {
            if (movies.Count == 0)
                throw new MovieStoreIsEmptyException("Movie List is Empty");
            else
                return movies;
        }

        public static Movie FindMovieById(int id)
        {
            Movie findMovie = null;

            findMovie = movies.Where(item => item.Id == id).FirstOrDefault();

            if (findMovie != null)
                return findMovie;
            else
                throw new MovieNotFoundException("Movie Not Found");
        }

        public static void RemoveMovie(int id)
        {
            Movie findMovie = FindMovieById(id);
            if (findMovie == null)
                throw new MovieNotFoundException("Movie Not Found");
            else
            {
                movies.Remove(findMovie);
            }
        }

        public static void ClearAllMovies()
        {
            if (movies.Count == 0)
                throw new MovieStoreIsEmptyException("Movie List is already Empty !");
            else
                movies.Clear();
        }

        public static void ExitMovie()
        {
            DataSerialize.SerializeMovies(movies);
        }
    }
}
