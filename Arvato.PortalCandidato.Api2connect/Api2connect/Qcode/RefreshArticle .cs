using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiSiop.Qcode
{
    //public class RefreshArticle
    //{
    //}

    public class BasePage : System.Web.UI.Page {

        protected virtual void Page_Load(object sender, EventArgs e)
        {
            Response.AddHeader("Refresh", Convert.ToString((Session.Timeout * 60) + 5));
            if (Session["usuarioSiop"] == null)
            {
                Response.Redirect("../../Default.aspx");
            }
        }
    
    }
}