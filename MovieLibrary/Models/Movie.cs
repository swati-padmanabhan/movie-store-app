using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Model
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public DateTime YearOfRelease { get; set; }

        public Movie()
        { }

        public Movie(int id, string name, string genre, DateTime yearOfRelease)
        {
            Id = id;
            Name = name;
            Genre = genre;
            YearOfRelease = yearOfRelease;
        }

        public static Movie CreateMovie(int id, string name, string genre, DateTime yearOfRelease)
        {
            return new Movie(id, name, genre, yearOfRelease);
        }

        public override string ToString()
        {
            return $"Movie Id: {Id}\n" +
                $"Movie Name: {Name}\n" +
                $"Movie Genre: {Genre}\n" +
                $"Movie Year of Release: {YearOfRelease}" +
                $"\n====================================================";
        }
    }
}
