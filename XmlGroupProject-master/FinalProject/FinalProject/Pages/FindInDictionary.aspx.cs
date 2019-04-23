using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject
{
    public partial class FindInDictionary : System.Web.UI.Page
    {
        DictionaryService.DictServiceSoapClient client;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                client = new DictionaryService.DictServiceSoapClient("DictServiceSoap");
                var dictList = client.DictionaryList();

                Dictionary<string, string> internalDict = new Dictionary<string, string>();
                foreach (var dictionary in dictList)
                {
                    internalDict.Add(dictionary.Id, dictionary.Name);
                }

                DropDownListSelectDict.DataSource = internalDict;
                DropDownListSelectDict.DataTextField = "Value";
                DropDownListSelectDict.DataValueField = "Key";
                DropDownListSelectDict.DataBind();
            }

        }

        protected void BtnFind_Click(object sender, EventArgs e)
        {
            client = new DictionaryService.DictServiceSoapClient("DictServiceSoap");
            List<string> definationList = new List<string>();
            try
            {
                var clientDefinition = client.DefineInDict(DropDownListSelectDict.SelectedValue, TextBoxWord.Text);                
                foreach (var definition in clientDefinition.Definitions)
                {
                    definationList.Add(definition.WordDefinition);
                }
            }
            catch (Exception)
            {
                definationList.Add("Please enter a word.");
            }

            BulletedListDefinition.DataSource = definationList;
            BulletedListDefinition.DataBind();
        }
    }
}