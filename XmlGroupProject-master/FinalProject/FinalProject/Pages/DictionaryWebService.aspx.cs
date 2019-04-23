using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject
{
    public partial class DictionaryWebService : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnGetDefinition_Click(object sender, EventArgs e)
        {
            DictionaryService.DictServiceSoapClient client = new DictionaryService.DictServiceSoapClient("DictServiceSoap");
            string word = TxtBoxWord.Text;
            List<string> definationList = new List<string>();
            try
            {
                var wordDefinations = client.Define(word);
                foreach (var definition in wordDefinations.Definitions)
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