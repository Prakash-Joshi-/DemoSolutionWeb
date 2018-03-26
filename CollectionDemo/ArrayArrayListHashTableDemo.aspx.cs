using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CollectionDemo
{
    public partial class ArrayDemo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] strArray = new string[10];
            for (int i = 0; i < 10; i++)
            {
                if(strArray[i]==null)
                {
                    strArray[i] = (i + 1).ToString();
                    Response.Write("<br>" + strArray[i]);
                }
            }

            System.Collections.ArrayList strArrayList = new System.Collections.ArrayList();
            strArrayList.Add(1);
            strArrayList.Add("hello");
            strArrayList.Add(3.04);
            strArrayList.Add(new Product("101", "Saree"));
            strArrayList.Add(new Product("102", "Lehenga"));

            foreach (var item in strArrayList)
            {
                Response.Write("<br>" + item);
            }
            System.Collections.Hashtable strHashTable = new System.Collections.Hashtable();
            strHashTable.Add("1001", "Saree");
            strHashTable.Add(1002, "Lehenga");
            //foreach (var item in strHashTable)
            //{
            //    Response.Write("<br>" + item.Key + " "+ item.Value);
            //}
            foreach (System.Collections.DictionaryEntry item in strHashTable)
            {
                Response.Write("<br>" + item.Key + " " + item.Value);
            }
        }
    }

    class Product
    {
        public Product()
        {

        }
        public Product(string Code, string Name)
        {
            _Code = Code;
            _Name = Name;
        }

        public string _Code { get; set; }
        public string _Name { get; set; }
    }
}