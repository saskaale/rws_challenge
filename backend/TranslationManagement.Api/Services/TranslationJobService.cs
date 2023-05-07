using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using External.ThirdParty.Services;
using TranslationManagement.Api.DataAccess.Exceptions;
using TranslationManagement.Api.DataAccess.Interfaces;
using TranslationManagement.Api.Services.Dtos;

namespace TranslationManagement.Api.Services.Interfaces
{
    public class TranslationJobService : ITranslationJobService
    {

        static class JobStatuses
        {
            internal static readonly string New = "New";
            internal static readonly string Inprogress = "InProgress";
            internal static readonly string Completed = "Completed";
        }


        private ITranslationJobRepository _translationJobRepository;
        private IMyNotificationService _notificationService;

        public TranslationJobService(ITranslationJobRepository translationJobRepository, IMyNotificationService notificationService)
        {
            _translationJobRepository = translationJobRepository;
            _notificationService = notificationService;
        }
        
        public async Task<TranslationJobDto[]> GetJobsAsync()
        {
            return 
                (await _translationJobRepository.GetJobsAsync())
                    .Select( e=>MapToDto(e) )
                    .ToArray();
        }

        public async Task UpdateJobStatus(int jobId, string newStatus)
        {
            if (typeof(JobStatuses).GetProperties().Count(prop => prop.Name == newStatus) == 0)
            {
                throw new ArgumentException("invalid status");
            }

            var job = await _translationJobRepository.GetJobByIdAsync(jobId);

            bool isInvalidStatusChange = (job.Status == JobStatuses.New && newStatus == JobStatuses.Completed) ||
                                         job.Status == JobStatuses.Completed || newStatus == JobStatuses.New;
            if (isInvalidStatusChange)
            {
                throw new SystemException("invalid status change");
            }

            await _translationJobRepository.SaveJobAsync(job);
        }
        
        const double PricePerCharacter = 0.01;
        // TODO: refactor
        private void SetPrice(TranslationJobModel jobModel)
        {
            jobModel.Price = jobModel.OriginalContent.Length * PricePerCharacter;
        }



        public async Task<TranslationJobDto> CreateJobAsync(NewTranslationJobDto job)
        {
            var model = MapToModel(job);
            SetPrice(model);
            await _translationJobRepository.SaveJobAsync(model);
            await _notificationService.SendNotification("Job created: " + model.Id); 

            return MapToDto(model);
        }

        private TranslationJobDto MapToDto(TranslationJobModel model)
        {
            return new TranslationJobDto()
            {
                CustomerName = model.CustomerName,
                Id = model.Id,
                OriginalContent = model.OriginalContent,
                Price = model.Price,
                Status = model.Status,
                TranslatedContent = model.TranslatedContent
            };
        }

        private TranslationJobModel MapToModel(NewTranslationJobDto model)
        {
            return new TranslationJobModel()
            {
                CustomerName = model.CustomerName,
                OriginalContent = model.OriginalContent,
                Status = "New",
                TranslatedContent = model.TranslatedContent
            };
        }

    }
}