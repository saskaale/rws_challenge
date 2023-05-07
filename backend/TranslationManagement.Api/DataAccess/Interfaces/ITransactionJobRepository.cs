using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TranslationManagement.Api;
using TranslationManagement.Api.Controlers;

namespace TranslationManagement.Api.DataAccess.Interfaces
{
    public interface ITranslationJobRepository
    {
        Task<TranslationJobModel[]> GetJobsAsync();
        Task SaveJobAsync(TranslationJobModel jobModel);
        Task<TranslationJobModel> GetJobByIdAsync(int jobId);

    }    
}
