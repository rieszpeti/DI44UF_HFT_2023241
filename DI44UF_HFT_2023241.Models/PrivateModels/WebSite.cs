using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DI44UF_HFT_2023241.Models
{
    /// <summary>
    /// The pages that will be called
    /// </summary>
    public class WebSite
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; init; }
        public string Url { get; init; } = null!;
        public string SafeToCrawl { get; set; } = null!;
    }
}
