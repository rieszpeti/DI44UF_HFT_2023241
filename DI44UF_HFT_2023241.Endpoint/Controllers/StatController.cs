using Microsoft.AspNetCore.Mvc;
using DI44UF_HFT_2023241.Logic;
using System.Collections.Generic;

namespace DI44UF_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        IMovieLogic logic;

        public StatController(IMovieLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet("{year}")]
        public double? AverageRatePerYear(int year)
        {
            return this.logic.GetAverageRatePerYear(year);
        }

        [HttpGet]
        public IEnumerable<MovieLogic.YearInfo> YearStatistics(int year)
        {
            return this.logic.YearStatistics();
        }
    }
}
