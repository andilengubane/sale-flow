using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace wwwSalesFlow.adminForms
{
    public partial class batchAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdminUserID"] == null)
            {
                Response.Redirect("Login.aspx", true);
                return;
            }
            else
            {
            }
        }
    }
}