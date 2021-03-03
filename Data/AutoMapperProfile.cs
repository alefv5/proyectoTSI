using AutoMapper;
using Albergue.Data.Entities;
using Albergue.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practicando_WEBAPI.Data
{
    public class AutoMapperProfile:Profile
    {


        public AutoMapperProfile()
        {
            this.CreateMap <PetEntity, PetModel > ()
            .ReverseMap();

            this.CreateMap<PetModel, PetEntity>()
                   .ReverseMap();
        }
    }
}
