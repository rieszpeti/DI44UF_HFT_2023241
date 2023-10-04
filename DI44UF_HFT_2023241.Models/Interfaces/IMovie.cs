using System;
using System.Collections.Generic;

namespace DI44UF_HFT_2023241.Models
{
    public interface IMovie
    {
        int DirectorId { get; set; }
        double Income { get; set; }
        int MovieId { get; set; }
        double Rating { get; set; }
        DateTime Release { get; set; }
        string Title { get; set; }
    }
}