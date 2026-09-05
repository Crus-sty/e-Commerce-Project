using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Game_Grid
{
    public partial class account_info : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["UserID"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else if (!IsPostBack)
            {
                //LoadUserInfo();
                txtName.Enabled = false;
                txtSurname.Enabled = false;
                txtGender.Enabled = false;
                txtDOB.Enabled = false;
                txtGender.Enabled = false;
                txtEmail.Enabled = false;
                btnSave.Visible = false;
            }
            
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            // Implement save logic here
        }

        protected void btnEditInfo_Click(object sender, EventArgs e)
        {
            // Implement edit logic here
            btnSave.Visible= true;
            txtName.Enabled= true;
            txtSurname.Enabled= true;
            txtGender.Enabled= true;
            txtDOB.Enabled= true;
            txtEmail.Enabled= true;


        }

    }
}