using System;
using System.Linq;
using System.Threading.Tasks;
using External.ThirdParty.Services;
using Microsoft.Extensions.Logging;
using TranslationManagement.Api.DataAccess.Exceptions;
using TranslationManagement.Api.DataAccess.Interfaces;
using TranslationManagement.Api.Services.Dtos;

namespace TranslationManagement.Api.Services.Interfaces
{
    public class MyNotificationService : IMyNotificationService
    {
        private readonly ILogger<MyNotificationService> _logger;
        private readonly INotificationService _unreliableNotificationService;

        public MyNotificationService(INotificationService unreliableNotificationService, ILogger<MyNotificationService> logger)
        {
            _logger = logger;
            _unreliableNotificationService = unreliableNotificationService;
        }
        
        public async Task SendNotification(string text)
        {
            _logger.LogInformation($"Sending notification ({text})");

            do
            {
                try
                {
                    var success = await _unreliableNotificationService.SendNotification(text);
                    if (success)
                    {
                        break;
                    }
                    
                }
                catch (ApplicationException)
                {
                    
                }
            }
            while (true) ;

            _logger.LogInformation($"Notification sent ({text})");
        }

    }
}