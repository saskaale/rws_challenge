using System.Threading.Tasks;
using TranslationManagement.Api.Services.Dtos;

namespace TranslationManagement.Api.Services.Interfaces
{
    public interface ITranslationJobService
    {
        Task<TranslationJobDto[]> GetJobsAsync();

        Task<TranslationJobDto> CreateJobAsync(NewTranslationJobDto jobModel);
        Task UpdateJobStatus(int jobId, string newStatus);

    }
}