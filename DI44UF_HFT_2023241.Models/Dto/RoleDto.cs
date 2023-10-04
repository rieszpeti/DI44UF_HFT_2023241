using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI44UF_HFT_2023241.Models
{
    public class RoleDto : IRole
    {
        public int RoleId { get; set; }

        public int Priority { get; set; }
        public string RoleName { get; set; }

        public int MovieId { get; set; }
        public int ActorId { get; set; }

        public RoleDto()
        {

        }
    }
}
