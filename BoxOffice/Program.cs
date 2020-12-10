﻿using System;
using System.IO;
using System.Collections.Generic;

namespace BoxOffice
{
    class Program
    {
        class Movie
        {
            int id;
            string title;
            long lifetimeGross;


            public Movie(int _id, string _title, long _lifeTimeGross)
            {
                id = _id;
                title = _title;
                lifetimeGross = _lifeTimeGross;

            }

            public int Id { get { return id; } }
            public string Title { get { return title; } }
            public long LifeTimeGross { get { return lifetimeGross; } }

            

        }
        class MovieList
            {
                List<Movie> movies;
                long totalLifeTimeGross;

                public MovieList()
                {
                    movies = new List<Movie>();
                    totalLifeTimeGross = 0;
                }

                public void AddMoviesToList(int id, string title, long gross)
                {
                    Movie newMovie = new Movie(id, title, gross);
                    movies.Add(newMovie);
                }

                public void PrintAllMovies()
                {
                    foreach(Movie movie in movies)
                    {
                        Console.WriteLine($"{movie.Id}. {movie.Title} has earned {movie.LifeTimeGross}");
                    }
                }

        }

        static void Main(string[] args)
        {
            string filePath = @"C:\Users\opilane\Samples";
            string fileName = @"BoxOffice.txt";
            string fullFilePath = Path.Combine(filePath, fileName);

            //create an array of records from file 

            string[] linesFromFile = File.ReadAllLines(fullFilePath);

            //create a list of movies to sotre the movie objects from file
            MovieList myMovies = new MovieList();

            //create a list of movies to store the movie objects from file
            foreach(string line in linesFromFile)
            {

                //split the line to get the movie data
                string[] tempArray = line.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
                int movieId = int.Parse(tempArray[0]);
                string movieTitle = tempArray[1];
                string totalGrossTemp = tempArray[2].Substring(1);
                Console.WriteLine(totalGrossTemp);

                 long movieGross = long.Parse(totalGrossTemp);
                myMovies.AddMoviesToList(movieId, movieTitle, movieGross);
            }

            myMovies.PrintAllMovies();
        }
    }
}
