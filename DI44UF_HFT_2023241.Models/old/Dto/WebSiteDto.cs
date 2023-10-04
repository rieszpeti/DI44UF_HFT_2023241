﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DI44UF_HFT_2023241.Models.Old
{
    /// <summary>
    /// The pages that will be crawled
    /// </summary>
    public class WebSiteDto : IWebSite
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; init; }
        public string Url { get; init; } = null!;
        public bool SafeToCallApi { get; set; }
    }
}