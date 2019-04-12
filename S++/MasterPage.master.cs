using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void Search_Click(object sender, EventArgs e)
    {
        Response.Redirect("https://www.google.com/search?q=" + this.SearchBox.Text);
    }

    protected void Home_Click(object sender, EventArgs e)
    {
        Response.Redirect("https://www.google.com");
    }
}
