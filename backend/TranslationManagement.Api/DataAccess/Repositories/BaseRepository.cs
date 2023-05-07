using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TranslationManagement.Api;
using TranslationManagement.Api.Controlers;
using TranslationManagement.Api.Controllers;
using TranslationManagement.Api.DataAccess.Interfaces;

namespace TranslationManagement.Api.DataAccess.Repositories
{
    public abstract class BaseRepository
    {
        protected AppDbContext _context;

        public BaseRepository(AppDbContext dbContext)
        {
            _context = dbContext;
        }

    }
}


