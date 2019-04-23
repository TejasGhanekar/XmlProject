using FinalProject.Model;
using FinalProject.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject
{
    public partial class LanguageTranslator : System.Web.UI.Page
    {
        private const string baseUrl = "https://dictionary.yandex.net/api/v1/dicservice.json/";
        private const string getLangs = "getLangs?";
        private const string lookup = "lookup?";
        private const string apiKey = "key=dict.1.1.20181124T201226Z.0070d6a650de8fd4.3b433a0d20da9cd9d2001cbe63581eb416d904b3";
        private const string lang = "&lang=";
        private const string text = "&text=";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // Combo box for FROM
                DropDownListFrom.DataSource = GetLang();
                DropDownListFrom.DataTextField = "Value";
                DropDownListFrom.DataValueField = "Key";
                DropDownListFrom.DataBind();

                // Combo box for TO
                DropDownListTo.DataSource = GetLang();
                DropDownListTo.DataTextField = "Value";
                DropDownListTo.DataValueField = "Key";
                DropDownListTo.DataBind();
            }
        }

        private Dictionary<string, string> GetLang()
        {
            var langDictionary = new Dictionary<string, string>();
            // First item
            langDictionary.Add("-", "Please select");


            // Consume JSON from LanguageList.aspx
            using (var webClient = new WebClient())
            {
                var scheme = Request.Url.Scheme;
                var authority = Request.Url.Authority;
                var page = "Pages/LanguageListJson.aspx";
                var url = scheme + "://" + authority + "/" + page;
                String rawData = webClient.DownloadString(url);
                var abbreviateLanguages = JsonConvert.DeserializeObject<List<AbbreviateLanguage>>(rawData);
                foreach (var language in abbreviateLanguages)
                {
                    langDictionary.Add(language.Abbreviation, language.LanguageName);
                }
            }

            return langDictionary;
        }

        protected void BtnTranslate_Click(object sender, EventArgs e)
        {
            LblResult.Text = "";

            var from = DropDownListFrom.SelectedItem.Value;
            var to = DropDownListTo.SelectedItem.Value;
            var selectedLang = from + "-" + to;

            var translateString = TxtTranslateString.Text;
            if (string.IsNullOrEmpty(translateString))
            {
                // Do not translate empty string
                LblResult.Text = "Please enter word to translate";
                return;
            }

            using (var webClient = new WebClient())
            {
                string url = baseUrl + lookup + apiKey + lang + selectedLang + text + translateString;
                try
                {
                    // Get raw data from URL
                    string rawData = webClient.DownloadString(url);

                    // For encoding
                    var contentType = webClient.ResponseHeaders["Content-Type"];
                    var charset = Regex.Match(contentType, "charset=([^;]+)").Groups[1].Value;
                    webClient.Encoding = Encoding.GetEncoding(charset);

                    // Final call
                    rawData = webClient.DownloadString(url);
                    var response = JsonConvert.DeserializeObject<TranslateResponse>(rawData);
                    var def = response.def.FirstOrDefault();
                    if (def != null)
                    {
                        var tr = def.tr.FirstOrDefault();
                        if (tr != null)
                        {
                            LblResult.Text = tr.text;
                        }
                    }
                }
                catch (Exception)
                {
                    LblResult.Text = "Sorry! The API does not provide this translation. Try with diffrent language.";
                }
            }
        }

    }
}