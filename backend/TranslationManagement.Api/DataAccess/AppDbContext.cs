using System.Data.Common;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TranslationManagement.Api.DataAccess.Exceptions;

namespace TranslationManagement.Api
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<TranslationJobModel> TranslationJobs { get; set; }
        public DbSet<TranslatorModel> Translators { get; set; }
        
        
        public async Task SaveAndAssertAsync()
        {
            if ( await SaveChangesAsync() <= 0 )
            {
                throw new DatabaseException();
            }

        }


    }
}