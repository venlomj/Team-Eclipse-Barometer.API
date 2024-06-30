using AutoMapper;
using Barometer.BLL.Services.Interface;
using Barometer.DAL.Repositories.Interfaec;
using Barometer.Data.Model;
using Barometer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barometer.BLL.Services.Implementation
{
    public class BarometerService : IBarometerService
    {
        private readonly IBarometerRepository _barometerRepository;
        IMapper _mapper;
        public BarometerService(IBarometerRepository barometerRepository, IMapper mapper)
        {
            _barometerRepository = barometerRepository;
            _mapper = mapper;
        }
        public Task<Response<BarometerModel>> CreateBarometerAsync(BarometerRequest barometerRequest)
        {
            throw new NotImplementedException();
        }

        public Task<Response<bool>> DeleteBarometerAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<IEnumerable<BarometerDto>>> GetAllBarometersAsync()
        {
            var response = new Response<IEnumerable<BarometerDto>>();
            var barometers = await _barometerRepository.GetAllBarometersAsync();

            response.Data = _mapper.Map<IEnumerable<BarometerDto>>(barometers);

            return response;
        }


        public async Task<Response<BarometerDto>> GetBarometerByIdAsync(int id)
        {
            var response = new Response<BarometerDto>();
            var barometer = await _barometerRepository.GetBarometerByIdAsync(id);

            if (barometer == null)
            {
                return response;
            }

            response.Data = _mapper.Map<BarometerDto>(barometer);
            return response;
        }


        public async Task<Response<BarometerDto>> UpdateBarometerAsync(int id, BarometerRequest barometerRequest)
        {
            var response = new Response<BarometerDto>();
            var existingBarometer = await _barometerRepository.GetBarometerByIdAsync(id);

            if (existingBarometer == null)
            {
                response.Success = false;
                response.Message = "Barometer not found";
                return response;
            }

            // Use AutoMapper to map values from BarometerRequest to the existingBarometer
            _mapper.Map(barometerRequest, existingBarometer);

            var updatedBarometer = await _barometerRepository.UpdateBarometerAsync(existingBarometer);

            response.Data = _mapper.Map<BarometerDto>(updatedBarometer);
            return response;
        }


    }
}
