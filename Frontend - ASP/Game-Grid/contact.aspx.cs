using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Game_Grid
{
    public partial class contact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Session["Page"] = "contact.aspx";
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

        }
    }
}