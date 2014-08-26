using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;

namespace WCFServiceTestProject
{
    public partial class REST : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void btnGetAllBooks_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;
            string uri = "http://localhost:50218/Service.svc/jsonService/Books";
            HttpWebRequest req = WebRequest.Create(uri) as HttpWebRequest;
            HttpWebResponse resp = req.GetResponse() as HttpWebResponse;
            Stream stream = resp.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            string str = reader.ReadToEnd();
            txtBox.Text = str;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearchBox.Text != null || txtSearchBox.Text != "")
            {
                lblError.Visible = false;
                string uri = "http://localhost:50218/Service.svc/jsonService/SearchedBooks?param=" + txtSearchBox.Text;
                HttpWebRequest req = WebRequest.Create(uri) as HttpWebRequest;
                HttpWebResponse resp = req.GetResponse() as HttpWebResponse;
                Stream stream = resp.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                string str = reader.ReadToEnd();
                txtBox.Text = str;
            }
            else
                lblError.Visible = true;
        }

    }
}