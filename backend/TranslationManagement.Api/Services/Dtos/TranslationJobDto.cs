namespace TranslationManagement.Api.Services.Dtos
{
    public class TranslationJobDto : NewTranslationJobDto
    {
        public string Status { get; set; } = "New";
        public int Id { get; set; }
        public double Price { get; set; }
    }
}