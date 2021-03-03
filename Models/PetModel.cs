using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Albergue.Models
{
    public class PetModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public char? Sex { get; set; }
        [StringLength(55, MinimumLength = 3)]
        public string Description { get; set; }
    }
}
