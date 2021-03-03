using Albergue.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Albergue.Services
{
    public interface IPetServices
    {
        public IEnumerable<PetModel> GetPets();
        public PetModel GetPet(int PetId);
        public PetModel CreatePet(PetModel petModel);
        public bool DeletePet(int PetId);
        public PetModel UpdatePet(int PetId, PetModel petModel);
    }
}
