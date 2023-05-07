using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TranslationManagement.Api.Services.Dtos;

namespace TranslationManagement.Api.Transformers.Interfaces
{
    public interface IFileParserTransformer
    {
        NewTranslationJobDto ParseFile(IFormFile file, string customer);
    }
}