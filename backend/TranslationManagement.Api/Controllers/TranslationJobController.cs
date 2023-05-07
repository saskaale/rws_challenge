using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using External.ThirdParty.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TranslationManagement.Api.Controlers;
using TranslationManagement.Api.DataAccess.Exceptions;
using TranslationManagement.Api.Services.Dtos;
using TranslationManagement.Api.Services.Interfaces;
using TranslationManagement.Api.Transformers.Interfaces;

namespace TranslationManagement.Api.Controllers
{
    [ApiController]
    public class TranslationJobController : ControllerBase
    {
        private const string URL_PREFIX = "api/jobs";
        
        private readonly ILogger<TranslatorManagementController> _logger;
        private readonly ITranslationJobService _service;
        private readonly IFileParserTransformer _transformer;
        

        public TranslationJobController(
            ILogger<TranslatorManagementController> logger, 
            ITranslationJobService service,
            IFileParserTransformer transformer
            )
        {
            _logger = logger;
            _service = service;
            _transformer = transformer;
        }


        /// <summary>
        /// Get all jobs
        /// </summary>
        /// <returns>Array of the jobs</returns>
        [HttpGet(URL_PREFIX+"/")]
        public async Task<TranslationJobDto[]> GetJobsAsync()
        {
            return await _service.GetJobsAsync();
        }

        [HttpPost(URL_PREFIX+"/")]
        public async Task<TranslationJobDto> CreateJobAsync(NewTranslationJobDto jobModel)
        {
            return await _service.CreateJobAsync(jobModel);
        }

        [HttpPost(URL_PREFIX+"/file")]
        public async Task<TranslationJobDto> CreateJobWithFile(IFormFile file, string customer)
        {
            return await _service.CreateJobAsync( _transformer.ParseFile(file, customer) );
        }

        [HttpPut(URL_PREFIX+"/{jobId}/status")]
        public async void UpdateJobStatus(int jobId, int translatorId, string newStatus = "")
        {
            _logger.LogInformation("Job status update request received: " + newStatus + " for job " + jobId.ToString() + " by translator " + translatorId);
            
            await _service.UpdateJobStatus(jobId, newStatus);
        }
    }
}