namespace TranslationManagement.Api.Services.Dtos
{
    public class NewTranslationJobDto
    {
        public string CustomerName { get; set; }
        public string OriginalContent { get; set; }
        public string TranslatedContent { get; set; }
    }
}