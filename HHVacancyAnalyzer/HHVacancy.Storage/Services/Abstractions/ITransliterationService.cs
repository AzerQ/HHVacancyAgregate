namespace HHVacancy.Storage.Services.Abstractions
{
    public interface ITransliterationService
    {
        string ConvertToLatin(string source);

        bool IsRuString(string source);
    }
}
