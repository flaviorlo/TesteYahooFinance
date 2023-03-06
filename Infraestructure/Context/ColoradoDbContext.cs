using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Context
{
    public class ColoradoDbContext : DbContext
    {
        public ColoradoDbContext(DbContextOptions<ColoradoDbContext> options) : base(options)
        {

        }

       

    }
}
