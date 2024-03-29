using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design;

namespace NorthWind.Repositories.EFCore.DataContext
{
    class NorthWindContextFactory :
   IDesignTimeDbContextFactory<NorthWindContext>
    {
        public NorthWindContext CreateDbContext(string[] args)
        {
            var OptionBuilder =
                new DbContextOptionsBuilder<NorthWindContext>();
            OptionBuilder.UseSqlServer(
                "Server=(localdb)\\mssqllocaldb;database=NorthWindDB");
            return new NorthWindContext(OptionBuilder.Options);
        }
    }
}
