using ITI.CURDAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ITI.CURDAPI.Present
{
    public class DBContextFactory : IDesignTimeDbContextFactory<DBContext>
    {
        public DBContext CreateDbContext(string[] args)
        {
            IConfigurationRoot settingsObj = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json")
                                        .Build();
            
            DbContextOptionsBuilder<DBContext> builder = new DbContextOptionsBuilder<DBContext>();
            builder.UseSqlServer(settingsObj.GetConnectionString("Connection"));

            return new DBContext(builder.Options);
        }
    }
}
