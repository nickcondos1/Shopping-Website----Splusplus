using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home : System.Web.UI.Page
{
    private List<Item> items;

    protected void Page_Load(object sender, EventArgs e)
    {
        items = new List<Item>();

        try
        {
            SqlConnection cn;
            SqlCommand cmd;
            SqlDataReader dr;

            String cnString = WebConfigurationManager.ConnectionStrings["Content"].ToString();
            cn = new SqlConnection();
            cn.ConnectionString = cnString;

            cmd = new SqlCommand("SELECT * FROM ClothingItems", cn);
            cn.Open();
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Item item = new Item(dr["SKU"].ToString(),
                    dr["ItemName"].ToString(),
                    dr["ShortDesc"].ToString(),
                    dr["LongDesc"].ToString(),
                    dr["PicName"].ToString(),
                    int.Parse(dr["QOH"].ToString()),
                    dr["Price"].ToString(),
                    float.Parse(dr["Weight"].ToString()));

                items.Add(item);
            }
        }
        catch (Exception err)
        {
            lblStatus.Text = err.Message;
        }

        string code = "<div class=\"row\">";
        foreach (Item i in items)
        {
            code += "<div class=\"col-md-4\">" +
                         "<div class=\"img-thumbnail\">" +
                            "<a href = \"" + GetURL(i) + "\">" +
                              "<img src =" + "\"" + i.PicName + "\"" + "alt=\"blank\" style=\"width:100%\"/>" +
                              "<div class=\"caption\">" +
                                "<p>" + i.ItemName + "<br />" + i.Price + "<br />" + i.ShortDesc + "</p>" +
                              "</div>" +
                            "</a>" +
                          "</div>" +
                     "</div>";
        }
        code += "</div>";

        this.content.Text = code;
    }

    private string GetURL(Item i)
    {
        string url = "ItemDetails.aspx?";
        url += "ItemName=" + Server.UrlEncode(i.ItemName);
        return url;
    }
}