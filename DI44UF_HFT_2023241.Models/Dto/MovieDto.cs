using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DI44UF_HFT_2023241.Models
{
    public class MovieDto : IMovie
    {
        public int MovieId { get; set; }

        [StringLength(240)]
        public string Title { get; set; }

        [Range(0, 10000)]
        public double Income { get; set; }

        [Range(0, 10)]
        public double Rating { get; set; }

        public DateTime Release { get; set; }

        public int DirectorId { get; set; }

        public MovieDto()
        {

        }
    }
}
