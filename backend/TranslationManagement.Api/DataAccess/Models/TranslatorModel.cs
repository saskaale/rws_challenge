namespace TranslationManagement.Api
{
    public class TranslatorModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string HourlyRate { get; set; }
        public string Status { get; set; }
        public string CreditCardNumber { get; set; }

        public static readonly string[] TranslatorStatuses = { "Applicant", "Certified", "Deleted" };
    }
}