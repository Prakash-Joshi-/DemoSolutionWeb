using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Josn_demo
{
    public partial class ValidateJsonAgainstSchema : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // http://stackoverflow.com/questions/14977848/how-to-make-sure-that-string-is-valid-json-using-json-net
            // http://www.newtonsoft.com/jsonschema
        }

        protected void btnValidateJosn_Click(object sender, EventArgs e)
        {
            fun();
            JsonSchema schema = JsonSchema.Parse(txtInputSchema.Text);
            JSchema schema1 = JSchema.Parse(txtInputSchema.Text);
            JObject obj = JObject.Parse(txtInputJson.Text);
            bool IsValid = obj.IsValid(schema1);
            lblIsValid.Text = "Json validation is " + IsValid;

        }
        // http://stackoverflow.com/questions/19544183/validate-json-against-json-schema-c-sharp?noredirect=1&lq=1
        public void fun()
        {
            bool isValid = true;
            var schema = JsonSchema.Parse(
            @"{
                'type': 'object',
                'properties': {
                    'name': {'type':'string'},
                    'hobbies': {'type': 'array'}
                },
                'additionalProperties': false
                }");

            isValid = IsValid(JObject.Parse(
            @"{
                'name': 'James',
                'hobbies': ['.NET', 'LOLCATS']
              }"), schema);

            isValid = IsValid(JObject.Parse(
            @"{
                'surname': 2,
                'hobbies': ['.NET', 'LOLCATS']
              }"), schema);

            isValid = IsValid(JObject.Parse(
            @"{
                'name': 2,
                'hobbies': ['.NET', 'LOLCATS']
              }"), schema);

            // http://stackoverflow.com/questions/23906220/deserialize-json-in-a-tryparse-way
            string schemaJson = @"{
                                     'error': {'type': 'string'},
                                     'status': {'type': 'string'},
                                     'code': {'type': 'string'}
                                    }";
            string jsonstring= @"{
                                    'error': {
                                        'status': 'error message',
                                        'code': '999'
                                            }
                                }";
            isValid = IsValid(JObject.Parse(jsonstring), JsonSchema.Parse(schemaJson));

        }

        public bool IsValid(JObject obj, JsonSchema schema)
        {
            return obj.IsValid(schema);
        }

    }
}