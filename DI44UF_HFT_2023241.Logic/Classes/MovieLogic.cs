﻿//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace DI44UF_HFT_2023241.Logic
//{
//    public class MovieLogic : IMovieLogic
//    {
//        IRepository<Movie> repo;

//        public MovieLogic(IRepository<Movie> repo)
//        {
//            this.repo = repo;
//        }

//        public void Create(Movie item)
//        {
//            if (item.Title.Length < 3)
//            {
//                throw new ArgumentException("title too short...");
//            }
//            this.repo.Create(item);
//        }

//        public void Delete(int id)
//        {
//            this.repo.Delete(id);
//        }

//        public Movie Read(int id)
//        {
//            var movie = this.repo.Read(id);
//            if (movie == null)
//            {
//                throw new ArgumentException("Movie not exists");
//            }
//            return movie;

//        }

//        public IQueryable<Movie> ReadAll()
//        {
//            return this.repo.ReadAll();
//        }

//        public void Update(Movie item)
//        {
//            this.repo.Update(item);
//        }

//        //non cruds

//        public double? GetAverageRatePerYear(int year)
//        {
//            return this.repo
//               .ReadAll()
//               .Where(t => t.Release.Year == year)
//               .Average(t => t.Rating);
//        }


//        public IEnumerable<YearInfo> YearStatistics()
//        {
//            return from x in this.repo.ReadAll()
//                   group x by x.Release.Year into g
//                   select new YearInfo()
//                   {
//                       Year = g.Key,
//                       AvgRating = g.Average(t => t.Rating),
//                       MovieNumber = g.Count()
//                   };
//        }

//        public class YearInfo
//        {
//            public int Year { get; set; }
//            public double? AvgRating { get; set; }
//            public int MovieNumber { get; set; }
//        }
//    }
//}
