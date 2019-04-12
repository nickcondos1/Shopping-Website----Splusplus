using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ItemDetails : System.Web.UI.Page
{
    private Item itemInfo;
    private string item = "";
    private List<CartItem> cart;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["MyCart"] == null)
        {
            cart = new List<CartItem>();
        }
        else
        {
            cart = (List<CartItem>)Session["MyCart"];
        }

        item = Request.QueryString["ItemName"];
        string label = "";
        string picName = "";
        try
        {
            SqlConnection cn;
            SqlCommand cmd;
            SqlDataReader dr;

            String cnString = WebConfigurationManager.ConnectionStrings["Content"].ToString();
            cn = new SqlConnection();
            cn.ConnectionString = cnString;

            cmd = new SqlCommand("SELECT * FROM ClothingItems WHERE ItemName = '" + item + "'", cn);
            cn.Open();
            dr = cmd.ExecuteReader();

            
            while (dr.Read())
            {

                itemInfo = new Item(dr["SKU"].ToString(),
                    dr["ItemName"].ToString(),
                    dr["ShortDesc"].ToString(),
                    dr["LongDesc"].ToString(),
                    dr["PicName"].ToString(),
                    int.Parse(dr["QOH"].ToString()),
                    dr["Price"].ToString(),
                    float.Parse(dr["Weight"].ToString()));

                label += dr["ItemName"].ToString() + "<br />";
                label += dr["Price"].ToString() + "<br />";
                label += dr["ShortDesc"].ToString() + "<br />";
                label += dr["LongDesc"].ToString() + "<br />";
                label += "Weight: " + dr["Weight"].ToString() + " ounces<br />";
                picName = dr["picName"].ToString();

                if (int.Parse(dr["QOH"].ToString()) > 0)
                    label += "In Stock!";
                else
                    label += "Out of Stock!";
                
            }
            label += "<br /><br /><br /><br />";
        }
        catch (Exception err)
        {
            lblStatus.Text = err.Message;
        }

        
        this.ItemInfo.Text = label;
        this.pic.ImageUrl = picName;

        ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:bottom();", true);
    }

    protected void AddToCart_Click(object sender, EventArgs e)
    {
        Boolean isFound = false;
        if (cart.Count > 0)
        {
            foreach (CartItem cartitem in cart)
            {
                if (cartitem.Item.ItemName.Equals(itemInfo.ItemName))
                {
                    cartitem.Quantity++;
                    isFound = true;
                    break;
                }
            }           
        }
        
        if (!isFound)
        {
            CartItem cartItem = new CartItem(itemInfo, 1);
            cart.Add(cartItem);
            Session["MyCart"] = cart;
        }
        this.AddedLabel.Text = "Item added!";
    }

    protected void Back_Shopping(object sender, EventArgs e)
    {
        Response.Redirect("Home.aspx#itemsContainer");
    }
}