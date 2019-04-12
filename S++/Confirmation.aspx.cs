using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using System.Text;

public partial class Confirmation : System.Web.UI.Page
{
    
        
    protected void Page_Load(object sender, EventArgs e)
    {
        String order = Request.QueryString["OrderNum"];
        this.OrderConformation.Text = "Order " + order + " has been processed. <br />" +
            "An email receipt has been sent to you.";

        

    }

    
}