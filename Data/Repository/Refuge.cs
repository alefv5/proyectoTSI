using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Albergue.Data.Entities;


namespace Albergue.Data.Repository
{
    public class Refuge : IRefuge
    {
    

    private List<PetEntity> pets = new List<PetEntity>(){
            new PetEntity(){Id=1,Name="Negrito",Sex='H',Description="Perrito color negro muy cariñoso"},
            new PetEntity(){Id=2,Name="Pelusa",Sex='M',Description="Perrito muy cariñoso"},
            new PetEntity(){Id=3,Name="Chocolate",Sex='M',Description="Perrito divertido"},
            new PetEntity(){Id=4,Name="Lola",Sex='H',Description="Sabe lamer"}
        };

        public PetEntity GetPet(int breedId)
        {
            return pets.FirstOrDefault(c => c.Id == breedId);
        }
        public PetEntity CreatePet(PetEntity petEntity)
        {
            int petId;
            if (pets.Count() == 0)
            {
                petId = 1;
            }
            else
            {
                petId = pets.OrderByDescending(c => c.Id).FirstOrDefault().Id + 1;
            }
            petEntity.Id = petId;
            pets.Add(petEntity);
            return petEntity;
        }

        public bool DeletePet(int petId)
        {
            var breedToDelete = GetPet(petId);
            pets.Remove(breedToDelete);
            return true;
        }
        public IEnumerable<PetEntity> GetPets()
        {
            return pets;
        }

        public PetEntity UpdatePet(PetEntity petEntity)
        {
            var petToUpdate = GetPet(petEntity.Id);
            petToUpdate.Name = petEntity.Name ?? petToUpdate.Name;
            petToUpdate.Sex = petEntity.Sex ?? petToUpdate.Sex;
            petToUpdate.Description = petEntity.Description ?? petToUpdate.Description;
            return petToUpdate;
        }
    }
}
