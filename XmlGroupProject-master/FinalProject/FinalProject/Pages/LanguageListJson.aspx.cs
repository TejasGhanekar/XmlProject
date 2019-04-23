using FinalProject.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FinalProject.Pages
{
    public partial class LanguageListJson : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Clear();

            // change the content type, so the browser knows it's JSON
            Response.ContentType = "application/json; charset=utf-8";

            // Mapping of abbreviation with its language
            List<AbbreviateLanguage> languageAbbreviation = new List<AbbreviateLanguage>
            {
                new AbbreviateLanguage("cs", "Czech"),
                new AbbreviateLanguage("da", "Danish"),
                new AbbreviateLanguage("de", "German"),
                new AbbreviateLanguage("el", "Greek"),
                new AbbreviateLanguage("en", "English"),
                new AbbreviateLanguage("es", "Spanish"),
                new AbbreviateLanguage("et", "Estonian"),
                new AbbreviateLanguage("fi", "Finnish"),
                new AbbreviateLanguage("fr", "French"),
                new AbbreviateLanguage("it", "Italian"),
                new AbbreviateLanguage("lt", "Lithuanian"),
                new AbbreviateLanguage("lv", "Latvian"),
                new AbbreviateLanguage("nl", "Dutch "),
                new AbbreviateLanguage("no", "Norwegian"),
                new AbbreviateLanguage("pt", "Portuguese"),
                new AbbreviateLanguage("ru", "Russian"),
                new AbbreviateLanguage("sk", "Slovak"),
                new AbbreviateLanguage("sv", "Swedish"),
                new AbbreviateLanguage("tr", "Turkish"),
                new AbbreviateLanguage("uk", "Ukrainian")
            };

            // Change the language with abbreviations to a JSON stream.
            string languageAbbrevationsJson = JsonConvert.SerializeObject(languageAbbreviation);

            // Write out json in response
            Response.Write(languageAbbrevationsJson);
            
            Response.End();
        }
    }
}