﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace DI44UF_HFT_2023241.Models.Old
{
    /// <summary>
    /// The pages that will be called via API
    /// </summary>
    public class WebSite : IWebSite
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; init; }
        public string Url { get; init; } = null!;
        public bool SafeToCallApi { get; set; }

        public virtual ICollection<ApiCalledWebsite> ApiCalledWebsites { get; set; }
        public virtual ICollection<Product> Products { get; set; }

        public WebSite()
        {
            
        }

        public WebSite(string url, bool safeToCrawl)
        {
            Url = url;
            SafeToCallApi = safeToCrawl;
        }
    }
}