using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI44UF_HFT_2023241.Models
{
    public class ActorDto : IActor
    {
        public int ActorId { get; set; }

        [Required]
        [StringLength(240)]
        public string ActorName { get; set; }
    }
}
