using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieLibrary.Repository;
using MovieLibrary.Exceptions;

namespace MovieManagement.ViewControllers
{
    internal class MovieStore
    {
        public static void DisplayMenu()
        {

            MovieManager.ManageMovies();

            while (true)
            {

                Console.WriteLine("\n==========Welcome to Movie Store Application : Swati Padmanabhan==========");
                Console.WriteLine("What do you wish to do?\n" +
                    "1. Add New Movie\n" +
                    "2. Display All Movies\n" +
                    "3. Find Movie By Id\n" +
                    "4. Remove Movie by Id\n" +
                    "5. Clear All Movies\n" +
                    "6. Exit");

                try
                {
                    int choice = Convert.ToInt32(Console.ReadLine());
                    DoTask(choice);
                }
                catch (FormatException fe)
                {
                    Console.WriteLine($"Please enter number only! - {fe.Message}");
                }
                catch (InvalidChoiceException ice)
                {
                    Console.WriteLine(ice.Message);
                }
                catch (MovieStoreIsEmptyException mee)
                {
                    Console.WriteLine(mee.Message);
                }
                catch (MovieNotFoundException mfe)
                {
                    Console.WriteLine(mfe.Message);
                }
                catch (CapacityIsFullException cfe)
                {
                    Console.WriteLine(cfe.Message);
                }
            }
        }
        static void DoTask(int choice)
        {
            switch (choice)
            {
                case 1:
                    Add();
                    break;
                case 2:
                    Display();
                    break;
                case 3:
                    Find();
                    break;
                case 4:
                    Remove();
                    break;
                case 5:
                    MovieManager.ClearAllMovies();
                    Console.WriteLine("All Movies Cleared ! \n");
                    break;
                case 6:
                    MovieManager.ExitMovie();
                    Environment.Exit(0);
                    break;
                default:
                    throw new InvalidChoiceException("Please Enter Valid Input !");
                    break;
            }

            static void Add()
            {
                Console.WriteLine("Enter Id: ");
                int id = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Name of the Movie: ");
                string name = Console.ReadLine();

                Console.WriteLine("Enter the Genre of the Movie: ");
                string genre = Console.ReadLine();

                Console.WriteLine("Enter Year of Release of the Movie in (DD/MM/YYYY): ");
                DateTime yearOfRelease = Convert.ToDateTime(Console.ReadLine());

                MovieManager.AddNewMovie(id, name, genre, yearOfRelease);

                Console.WriteLine("Movie Created Successfully \n");
            }

            static void Display()
            {
                var movies = MovieManager.DisplayMovies();
                movies.ForEach(movie => Console.WriteLine(movie));
            }

            static void Find()
            {
                Console.WriteLine("Enter Id: ");
                int id = Convert.ToInt32(Console.ReadLine());

                var movie = MovieManager.FindMovieById(id);
                Console.WriteLine(movie);
            }
            static void Remove()
            {
                Console.WriteLine("Enter Id: ");
                int id = Convert.ToInt32(Console.ReadLine());
                MovieManager.RemoveMovie(id);
                Console.WriteLine("Movie Deleted Succesfully ! \n");
            }
        }

    }
}
