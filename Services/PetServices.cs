using Albergue.Data.Entities;
using Albergue.Data.Repository;
using Albergue.Exceptions;
using Albergue.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Albergue.Services
{
    public class PetServices : IPetServices
    {
        private IRefuge _refugeRepository;
        private IMapper _mapper;

        public PetServices(IRefuge refugeRepository, IMapper _mapper)
        {
            this._refugeRepository = refugeRepository;
            this._mapper = _mapper;
        }

        public IEnumerable<PetModel> GetPets()
        {
            var entityList = _refugeRepository.GetPets();
            var modelList = _mapper.Map<IEnumerable<PetModel>>(entityList);
            return modelList;
        }
        public PetModel GetPet(int petId)
        {
            var pet = _refugeRepository.GetPet(petId);

            if (pet == null)
            {
                throw new NotFoundException($"The pet {petId} doesnt exists, try it with a new id");
            }

            return _mapper.Map<PetModel>(pet);
        }

        public PetModel CreatePet(PetModel petModel)
        {

            var entityreturned = _refugeRepository.CreatePet(_mapper.Map<PetEntity>(petModel));

            return _mapper.Map<PetModel>(entityreturned);
        }

        public bool DeletePet(int petId)
        {
            var breedToDelete = GetPet(petId);
            return _refugeRepository.DeletePet(petId);
        }

        public PetModel UpdatePet(int PetId, PetModel petModel)
        {

            var petToUpdate = _refugeRepository.UpdatePet(_mapper.Map<PetEntity>(petModel));

            return _mapper.Map<PetModel>(petToUpdate);
        }
    }
}
