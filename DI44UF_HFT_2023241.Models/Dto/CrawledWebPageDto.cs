using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DI44UF_HFT_2023241.Models
{
    /// <summary>
    /// Get information from Crawled Webpages
    /// You have to crawl a webpage multiple times
    /// When it happend etc
    /// What items got it
    /// </summary>
    public class CrawledWebPageDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; init; }
        public DateTime CrawlStartTime { get; init; }
        public DateTime CrawlStartEnd { get; init; }

        [NotMapped]
        public TimeSpan CrawleProcessTime
        {
            get 
            {
                return CrawlStartEnd - CrawlStartTime;
            }
        }
    }
}
