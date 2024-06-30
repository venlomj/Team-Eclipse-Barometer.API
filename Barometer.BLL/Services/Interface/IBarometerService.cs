using Barometer.Data.Model;
using Barometer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barometer.BLL.Services.Interface
{
    public interface IBarometerService
    {
        Task<Response<IEnumerable<BarometerDto>>> GetAllBarometersAsync();
        Task<Response<BarometerDto>> GetBarometerByIdAsync(int id);
        Task<Response<BarometerDto>> CreateBarometerAsync(BarometerRequest barometerRequest);
        Task<Response<BarometerDto>> UpdateBarometerAsync(int id, BarometerRequest barometerRequest);
        Task<Response<bool>> DeleteBarometerAsync(int id);
    }
}
