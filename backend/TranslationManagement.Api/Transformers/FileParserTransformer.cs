using System;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Http;
using TranslationManagement.Api.Services.Dtos;
using TranslationManagement.Api.Transformers.Interfaces;

namespace TranslationManagement.Api.Transformers
{
    public class FileParserTransformer : IFileParserTransformer
    {
        public NewTranslationJobDto ParseFile(IFormFile file, string customer)
        {
            var reader = new StreamReader(file.OpenReadStream());
            string content;

            if (file.FileName.EndsWith(".txt"))
            {
                content = reader.ReadToEnd();
            }
            else if (file.FileName.EndsWith(".xml"))
            {
                var xdoc = XDocument.Parse(reader.ReadToEnd());
                content = xdoc.Root.Element("Content").Value;
                customer = xdoc.Root.Element("Customer").Value.Trim();
            }
            else
            {
                throw new NotSupportedException("unsupported file");
            }

            return new NewTranslationJobDto()
            {
                OriginalContent = content,
                TranslatedContent = "",
                CustomerName = customer,
            };
        }
    }
}



