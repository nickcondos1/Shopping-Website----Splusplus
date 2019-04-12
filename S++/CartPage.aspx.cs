using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CartPage : System.Web.UI.Page
{
    private Boolean firstItem = true;
    private List<CartItem> cart;

    protected void Page_Load(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:bottom();", true);
        cart = new List<CartItem>();
        this.Hoodie.Visible = false;
        this.Sweatpants.Visible = false;
        this.Longsleeve.Visible = false;

        if (!IsPostBack)
        {
            if (Session["MyCart"] != null)
            {
                cart = (List<CartItem>)Session["MyCart"];
                getSession(cart);
                if (cart.Count == 0)
                {
                    this.Error.Text = "You dont have any items!";
                    this.Checkout.Visible = false;
                }
                else
                {
                    this.Error.Text = "";
                    this.Checkout.Visible = true;
                }
            }
        }
        
    }
    protected void Checkout_Click(object sender, EventArgs e)
    {
        Response.Redirect("OrderSummary.aspx");
    }

    protected void Back_Shopping(object sender, EventArgs e)
    {
        Response.Redirect("Home.aspx#itemsContainer");
    }

    private void ExecuteClick(string name)
    {
        cart = (List<CartItem>)Session["MyCart"];

        foreach (CartItem cartItem in cart)
        {
            if (cartItem.Item.ItemName.Equals(name))
            {
                cartItem.Quantity--;
                if (cartItem.Quantity <= 0)
                {                   
                    cart.Remove(cartItem);
                    break;
                }
            }
        }
        if (cart.Count == 0)
        {
            this.Error.Text = "You dont have any items!";
            this.Checkout.Visible = false;
        }
        getSession(cart);
        Session["MyCart"] = cart;
    }

    protected void Hoodie_Click(object sender, EventArgs e)
    {
        ExecuteClick("S++ Hoodie");   
    }

    protected void Sweatpants_Click(object sender, EventArgs e)
    {
        ExecuteClick("S++ Sweatpants");      
    }

    protected void Longsleeve_Click(object sender, EventArgs e)
    {
        ExecuteClick("S++ Longsleeve");
    }

    private void getSession(List<CartItem> cart)
    {
            TableRow row;
            TableCell cell;

            row = new TableHeaderRow();
            cell = new TableHeaderCell();
            cell.Text = "Item";
            cell.ForeColor = Color.White;
            row.Cells.Add(cell);

            cell = new TableHeaderCell();
            cell.Text = "Price";
            cell.ForeColor = Color.White;
            row.Cells.Add(cell);

            cell = new TableHeaderCell();
            cell.Text = "SKU";
            cell.ForeColor = Color.White;
            row.Cells.Add(cell);

            cell = new TableHeaderCell();
            cell.Text = "Quantity";
            cell.ForeColor = Color.White;
            row.Cells.Add(cell);

            cell = new TableHeaderCell();
            cell.Text = "Weight (Oz)";
            cell.ForeColor = Color.White;
            row.Cells.Add(cell);

            cell = new TableHeaderCell();
            cell.Text = "Cost";
            cell.ForeColor = Color.White;
            row.Cells.Add(cell);

            this.CartTable.Rows.Add(row);

            float totalPrice = 0.0f;

            foreach (CartItem cartItem in cart)
            {
                row = new TableRow();
                cell = new TableCell();
                cell.Text = cartItem.Item.ItemName;
                cell.ForeColor = Color.White;
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = cartItem.Item.Price.ToString();
                cell.ForeColor = Color.White;
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = cartItem.Item.Sku;
                cell.ForeColor = Color.White;
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = cartItem.Quantity.ToString();
                cell.ForeColor = Color.White;
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = cartItem.Item.Weight.ToString();
                cell.ForeColor = Color.White;
                row.Cells.Add(cell);

                cell = new TableCell();
                float total = (float)cartItem.Quantity * float.Parse(cartItem.Item.Price.TrimStart('$'));
                totalPrice += total;
                cell.Text = "$" + total.ToString();
                cell.ForeColor = Color.White;
                row.Cells.Add(cell);

                

            cell = new TableCell();

                if (cartItem.Item.ItemName.Equals("S++ Hoodie"))
                {
                    Hoodie.Visible = true;
                    Hoodie.Text = "Remove One";
                    Hoodie.BackColor = Color.Black;
                    Hoodie.BorderStyle = BorderStyle.Dashed;
                    Hoodie.BorderColor = Color.White;
                    Hoodie.ForeColor = Color.White;
                    cell.Controls.Add(Hoodie);
                    row.Cells.Add(cell);
                }
                else if (cartItem.Item.ItemName.Equals("S++ Sweatpants"))
                {
                    Sweatpants.Visible = true;
                    Sweatpants.Text = "Remove One";
                    Sweatpants.BackColor = Color.Black;
                    Sweatpants.BorderStyle = BorderStyle.Dashed;
                    Sweatpants.BorderColor = Color.White;
                    Sweatpants.ForeColor = Color.White;
                    cell.Controls.Add(Sweatpants);
                    row.Cells.Add(cell);
                }
                else if (cartItem.Item.ItemName.Equals("S++ Longsleeve"))
                {
                    Longsleeve.Visible = true;
                    Longsleeve.Text = "Remove One";
                    Longsleeve.BackColor = Color.Black;
                    Longsleeve.BorderStyle = BorderStyle.Dashed;
                    Longsleeve.BorderColor = Color.White;
                    Longsleeve.ForeColor = Color.White;
                    cell.Controls.Add(Longsleeve);
                    row.Cells.Add(cell);
                }

                this.CartTable.Rows.Add(row);
            }
            this.totalLabel.Text = "Totals: $" + (float)Math.Round(totalPrice, 2);


            this.CartTable.CellSpacing = Convert.ToInt32(10);
            this.CartTable.CellPadding = Convert.ToInt32(10);
            this.CartTable.BorderStyle = BorderStyle.Solid;
            this.CartTable.BorderColor = Color.White;
            this.CartTable.GridLines = GridLines.Both;
        }
}
