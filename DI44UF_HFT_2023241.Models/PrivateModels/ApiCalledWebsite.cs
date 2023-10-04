using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DI44UF_HFT_2023241.Models
{
    /// <summary>
    /// Get information from websites
    /// You have to call api from a webpage multiple times
    /// When it happend etc
    /// What items got it
    /// </summary>
    public class ApiCalledWebsite : IApiCalledWebsite
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; init; }
        public DateTime ApiCallStartTime { get; init; }
        public DateTime ApiCallEndTime { get; init; }

        [NotMapped]
        public TimeSpan CrawleProcessTime
        {
            get
            {
                return ApiCallStartTime - ApiCallEndTime;
            }
        }
    }
}
