using System.Threading.Tasks;
using TranslationManagement.Api.Services.Dtos;

namespace TranslationManagement.Api.Services.Interfaces
{
    public interface IMyNotificationService
    {
        Task SendNotification(string text);

    }
}