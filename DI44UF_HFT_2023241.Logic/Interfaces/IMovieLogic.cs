using DI44UF_HFT_2023241.Models;
using System.Collections.Generic;
using System.Linq;

namespace DI44UF_HFT_2023241.Logic
{
    public interface IMovieLogic
    {
        void Create(Movie item);
        void Delete(int id);
        double? GetAverageRatePerYear(int year);
        Movie Read(int id);
        IQueryable<Movie> ReadAll();
        void Update(Movie item);
        IEnumerable<MovieLogic.YearInfo> YearStatistics();
    }
}