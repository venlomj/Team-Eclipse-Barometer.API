using Barometer.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barometer.Data
{
    public class BarometerContext: DbContext
    {
        public BarometerContext(DbContextOptions<BarometerContext> options)
            : base(options)
        {
            
        }
        public DbSet<BarometerModel> BarometerModels { get; set; } = null!;
    }
}
