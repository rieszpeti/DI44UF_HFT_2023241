using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI44UF_HFT_2023241.Models
{
    public class Director : IDirector
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DirectorId { get; set; }

        [Required]
        [StringLength(240)]
        public string DirectorName { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }

        public Director()
        {
            Movies = new HashSet<Movie>();
        }

        public Director(string line)
        {
            string[] split = line.Split('#');
            DirectorId = int.Parse(split[0]);
            DirectorName = split[1];
            Movies = new HashSet<Movie>();
        }
    }
}
