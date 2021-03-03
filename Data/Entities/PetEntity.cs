using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Albergue.Data.Entities
{
    public class PetEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public char? Sex { get; set; }
        public string Description { get; set; }
    }
}
