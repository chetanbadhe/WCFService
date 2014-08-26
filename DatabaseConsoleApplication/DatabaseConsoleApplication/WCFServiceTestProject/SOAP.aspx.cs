using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Serialization;
using System.IO;

namespace WCFServiceTestProject
{
    public partial class SOAP : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearchBox.Text != null || txtSearchBox.Text != "")
            {
                lblError.Visible = false;

                WCFServiceReference.ServiceClient bservice = new WCFServiceReference.ServiceClient("SOAP");
                WCFServiceReference.Book[] bk = bservice.GetSearchedBooks(txtSearchBox.Text);
                string str1 = "";
                string str2 = "";
                XmlSerializer serializer = null;
                StringWriter writer = null;
                foreach (WCFServiceReference.Book item in bk)
                {
                    serializer = new XmlSerializer(item.GetType());
                    using (writer = new StringWriter())
                    {
                        serializer.Serialize(writer, item);
                        str1 = writer.ToString();
                    }
                    str2 = str2 + str1;
                }
                txtBox.Text = str2;
                bservice.Close();
            }
            else
                lblError.Visible = true;
        }

        protected void btnGetAllBooks_Click(object sender, EventArgs e)
        {
            WCFServiceReference.ServiceClient bservice = new WCFServiceReference.ServiceClient("SOAP");
            WCFServiceReference.Book[] bk = bservice.GetBooks();
            string str1 = "";
            string str2 = "";
            XmlSerializer serializer = null;
            StringWriter writer = null;
            foreach (WCFServiceReference.Book item in bk)
            {
                serializer = new XmlSerializer(item.GetType());
                using (writer = new StringWriter())
                {
                    serializer.Serialize(writer, item);
                    str1 = writer.ToString();
                }
                str2 = str2 + str1;
            }
            txtBox.Text = str2;
            bservice.Close();
            lblError.Visible = false;
        }
    }
}