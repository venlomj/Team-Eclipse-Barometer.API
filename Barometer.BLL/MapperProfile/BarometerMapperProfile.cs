using AutoMapper;
using Barometer.Data.Model;
using Barometer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barometer.BLL.MapperProfile
{
    public class BarometerMapperProfile : Profile
    {
        public BarometerMapperProfile()
        {
            CreateMap<BarometerModel, BarometerDto>();
            CreateMap<BarometerRequest, BarometerModel>();
        }
    }
}
