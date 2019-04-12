using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class OrderSummary : System.Web.UI.Page
{
    private List<CartItem> cart;
    private float perPoundCost;
    private int previousOrder;
    private int totalQuantity = 0;
    private float totalWeight = 0;
    private float orderTotal = 0;
    private float shipping = 0;
    private float totalPrice = 0;
    private String itemsInCart = "Items: <br />";

    protected void Page_Load(object sender, EventArgs e)
    {
        perPoundCost = 2.05f;
        cart = (List<CartItem>)Session["MyCart"];       

        foreach (CartItem item in cart)
        {
            itemsInCart += item.Item.ItemName + "<br />";
            totalQuantity += item.Quantity;
            totalWeight += item.Item.Weight;
            orderTotal += ((float)item.Quantity * float.Parse(item.Item.Price.TrimStart('$')));
        }
        orderTotal = (float)Math.Round(orderTotal, 2);
        shipping = totalWeight * perPoundCost / 16;
        shipping = (float)Math.Round(shipping, 2);
        totalPrice = orderTotal + shipping;
        totalPrice = (float)Math.Round(totalPrice, 2);


        TableRow row = new TableRow();
        TableCell cell = new TableCell();
        cell.Text = "Items: ";
        cell.ColumnSpan = 50;
        row.Cells.Add(cell);

        cell = new TableCell();
        cell.Text = cart.Count + "";
        row.Cells.Add(cell);
        this.Summary.Rows.Add(row);


        row = new TableRow();
        cell = new TableCell();
        cell.Text = "Quantity: ";
        cell.ColumnSpan = 50;
        row.Cells.Add(cell);

        cell = new TableCell();
        cell.Text = totalQuantity + "";
        row.Cells.Add(cell);
        this.Summary.Rows.Add(row);


        row = new TableRow();
        cell = new TableCell();
        cell.Text = "Weight: ";
        cell.ColumnSpan = 50;
        row.Cells.Add(cell);

        cell = new TableCell();
        cell.Text = totalWeight + " Oz";
        row.Cells.Add(cell);
        this.Summary.Rows.Add(row);


        row = new TableRow();
        cell = new TableCell();
        cell.Text = "Order Total: ";
        cell.ColumnSpan = 50;
        row.Cells.Add(cell);

        cell = new TableCell();
        cell.Text = "$" + orderTotal;
        row.Cells.Add(cell);
        this.Summary.Rows.Add(row);


        row = new TableRow();
        cell = new TableCell();
        cell.Text = "Shipping cost: ";
        cell.ColumnSpan = 50;
        row.Cells.Add(cell);

        cell = new TableCell();
        cell.Text = "$" + shipping;
        row.Cells.Add(cell);
        this.Summary.Rows.Add(row);


        row = new TableRow();
        cell = new TableCell();
        cell.Text = "Total: ";
        cell.ColumnSpan = 50;
        row.Cells.Add(cell);

        cell = new TableCell();
        cell.Text = "$" + totalPrice;
        row.Cells.Add(cell);
      
        this.Summary.Rows.Add(row);
        
    }

    protected void Confirmation_Click(object sender, EventArgs e)
    {
        GetOrderNum();
        SetOrder();
        SendEmail();
        string url = "Confirmation.aspx?";
        url += "OrderNum=" + Server.UrlEncode("" + previousOrder);
        Response.Redirect(url); 
    }

    private void SendEmail()
    {
        string to = this.Email.Text;
        string from = "nickcondos1234@gmail.com";
        MailMessage message = new MailMessage(from, to);

        message.Subject = "Your order from S++ has been processed";
        message.Body = "Your order has been processed. <br />" +
            "<br /> Order number: " + previousOrder +
            "<br /><br />ItemCount: " + cart.Count + "<br />" +
            itemsInCart +
            "<br />Quantity: " + totalQuantity +
            "<br />Price: $" + orderTotal +
            "<br />" +
            "<br />Weight: " + totalWeight + " ounces" +
            "<br />Shipping cost: $" + shipping +
            "<br />Total order cost: $" + totalPrice;
            
        message.BodyEncoding = Encoding.UTF8;
        message.IsBodyHtml = true;
        SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
        System.Net.NetworkCredential basicCredential1 = new System.Net.NetworkCredential("nickcondos1234@gmail.com", "********");
        client.EnableSsl = true;
        client.UseDefaultCredentials = false;
        client.Credentials = basicCredential1;
        try
        {
            client.Send(message);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void GetOrderNum()
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;

        String cnString = WebConfigurationManager.ConnectionStrings["Content"].ToString();
        cn = new SqlConnection();
        cn.ConnectionString = cnString;

        cmd = new SqlCommand("SELECT TOP 1 * FROM Orders ORDER BY Ordernum DESC", cn);
        cn.Open();
        dr = cmd.ExecuteReader();
        string temp = "0";
        while (dr.Read())
            temp = dr["Ordernum"].ToString();

        previousOrder = int.Parse(temp);
        previousOrder++;
    }

    private void SetOrder()
    {
        SqlConnection conn;
        SqlCommand cmd;

        conn = new SqlConnection();
        cmd = new SqlCommand();

        String cnString = WebConfigurationManager.ConnectionStrings["OrderConf"].ToString();
        conn = new SqlConnection();
        conn.ConnectionString = cnString;
        cmd.Connection = conn;
        conn.Open();
        cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;";
        cmd.ExecuteNonQuery();
        cmd.CommandText = "BEGIN TRANSACTION;";
        cmd.ExecuteNonQuery();

        cmd.CommandText = "INSERT INTO Orders (Ordernum, Name, Street, Location, Email, PreviousOrder) values (" + previousOrder + ",'"+ this.Name.Text +"','"+ this.Street.Text +"', '"+ this.City.Text + " "+ this.State.Text +" " + this.Zipcode.Text +"', '"+this.Email.Text+"',"+ (previousOrder - 1) +")";
        cmd.ExecuteNonQuery();
        cmd.CommandText = "COMMIT TRANSACTION;";
        cmd.ExecuteNonQuery();
        cmd = null;
        conn.Close();
        conn = null;

    }
}