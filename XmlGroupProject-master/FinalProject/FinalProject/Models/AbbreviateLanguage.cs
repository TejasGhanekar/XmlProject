namespace FinalProject.Models
{
    public class AbbreviateLanguage
    {
        public AbbreviateLanguage(string abbreviation, string languageName)
        {
            Abbreviation = abbreviation;
            LanguageName = languageName;
        }

        public string Abbreviation { get; }
        public string LanguageName { get; }
    }
}