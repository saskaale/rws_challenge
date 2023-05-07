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
    public class TranslationJobRepository : BaseRepository, ITranslationJobRepository
    {
        private readonly ILogger<TranslationJobRepository> _logger;

        public TranslationJobRepository(ILogger<TranslationJobRepository> logger, AppDbContext dbContext) :
            base(dbContext)
        {
            _logger = logger;
        }

        public Task<TranslationJobModel[]> GetJobsAsync()
        {
            return _context.TranslationJobs.ToArrayAsync();
        }

        public async Task SaveJobAsync(TranslationJobModel jobModel)
        {
            _context.TranslationJobs.Add(jobModel);
            await _context.SaveAndAssertAsync();
        }
        
        public async Task<TranslationJobModel> GetJobByIdAsync(int jobId)
        {
            return await _context.TranslationJobs.SingleAsync(j => j.Id == jobId);
        }
    }
}


