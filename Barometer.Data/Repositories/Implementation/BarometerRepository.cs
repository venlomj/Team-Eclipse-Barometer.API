
using Barometer.DAL.Repositories.Interfaec;
using Barometer.Data;
using Barometer.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barometer.DAL.Repositories.Implementation
{
    public class BarometerRepository : IBarometerRepository
    {
        private readonly BarometerContext _context;
        public BarometerRepository(BarometerContext context)
        {
            _context = context;
        }

        public async Task<BarometerModel> CreateBarometerAsync(BarometerModel barometer)
        {
            _context.BarometerModels.Add(barometer);
            await _context.SaveChangesAsync();
            return barometer;
        }

        public async Task<bool> DeleteBarometerAsync(int id)
        {
            var barometer = await GetBarometerByIdAsync(id);
            _context.BarometerModels.Remove(barometer);
            return true;
        }

        public async Task<IEnumerable<BarometerModel>> GetAllBarometersAsync()
        {
            return await _context.BarometerModels.ToArrayAsync();
        }

        public async Task<BarometerModel> GetBarometerByIdAsync(int id)
        {
            return await _context.BarometerModels.FindAsync(id);
        }

        public async Task<BarometerModel> UpdateBarometerAsync(BarometerModel barometer)
        {
            _context.BarometerModels.Update(barometer);
            await _context.SaveChangesAsync();
            return barometer;
        }
    }
}
