using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryAPI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public  AutoMapperProfiles()
        {

            //CreateMap<InventoryDomain.Model.Almacen, InventoryAPI.Models.Almacen>();
            //CreateMap<InventoryDomain.Model.Ubicacion, InventoryAPI.Models.Ubicacion>();
        }
    }
}
