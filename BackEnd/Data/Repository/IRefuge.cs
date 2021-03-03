using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Albergue.Data.Entities;

namespace Albergue.Data.Repository
{
    public interface IRefuge
    {
        public IEnumerable<PetEntity> GetPets();
        public PetEntity GetPet(int PetId);
        public PetEntity CreatePet(PetEntity petEntity);
        public bool DeletePet(int PetId);
        public PetEntity UpdatePet(PetEntity petEntity);
    }
}
