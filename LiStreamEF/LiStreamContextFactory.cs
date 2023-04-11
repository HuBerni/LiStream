using LiStreamEF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace LiStreamEF
{
    public class LiStreamContextFactory : IDesignTimeDbContextFactory<LiStreamContext>
    {
        public LiStreamContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<LiStreamContext>();
        #pragma warning disable CS8604 // Possible null reference argument.
            optionsBuilder.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]);
        #pragma warning restore CS8604 // Possible null reference argument.


            return new LiStreamContext(optionsBuilder.Options);
        }
    }
}
