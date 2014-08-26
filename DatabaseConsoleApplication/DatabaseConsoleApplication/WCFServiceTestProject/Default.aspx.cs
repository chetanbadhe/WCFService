using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using WCFServiceTestProject.Class;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web.Script.Serialization;
using System.Xml.Serialization;

namespace WCFServiceTestProject
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (txtDatePublished.Text.Length != 0 && txtDescription.Text.Length != 0 && txtName.Text.Length != 0)
            {
               DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(WCFServiceReference.Book));
                WCFServiceReference.Book book = new WCFServiceReference.Book();
                book.Name = txtName.Text;
                book.Description = txtDescription.Text;
                book.DatePublished = Convert.ToDateTime(txtDatePublished.Text);
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, book);
                string data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
                WebClient webClient = new WebClient();            
                webClient.Headers["Content-type"] = "application/json";            
                webClient.Encoding = Encoding.UTF8;
                webClient.UploadString("http://localhost:50218/Service.svc/jsonService/PlaceBook", "POST", data);
                txtDatePublished.Text = "";
                txtDescription.Text = "";
                txtName.Text = "";
                Label6.Visible = false;
                Label5.Visible = false;
                Label4.Visible = false;
            }
            else
            {
                if (txtDatePublished.Text.Length == 0)
                    Label6.Visible = true;
                if (txtDescription.Text.Length == 0)
                    Label5.Visible = true;
                if (txtName.Text.Length == 0)
                    Label4.Visible = true;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (txtDatePublished.Text.Length != 0 && txtDescription.Text.Length!=0 && txtName.Text.Length!=0)
            {
                WCFServiceReference.ServiceClient bservice = new WCFServiceReference.ServiceClient("SOAP");
                WCFServiceReference.Book book = new WCFServiceReference.Book();
                book.Name = txtName.Text;
                book.Description = txtDescription.Text;
                book.DatePublished = Convert.ToDateTime(txtDatePublished.Text);
                bservice.InsertBooks(book);
                txtDatePublished.Text = "";
                txtDescription.Text = "";
                txtName.Text = "";
                Label6.Visible = false;
                Label5.Visible = false;
                Label4.Visible = false;
                bservice.Close();
            }
            else
            {
                if (txtDatePublished.Text.Length == 0)
                    Label6.Visible = true;
                if (txtDescription.Text.Length == 0)
                    Label5.Visible = true;
                if (txtName.Text.Length == 0)
                    Label4.Visible = true;
            }
        }

    }
}
