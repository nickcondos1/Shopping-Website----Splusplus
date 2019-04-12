using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CartItem
/// </summary>
[Serializable]
public class CartItem
{
    private Item item;
    private int quantity;

    public CartItem(Item i, int q)
    {
        this.item = i;
        this.quantity = q;
    }
    
    public Item Item
    {
        get
        {
            return this.item;
        }
        set
        {
            this.item = value;
        }
    }

    public int Quantity
    {
        get
        {
            return this.quantity;
        }
        set
        {
            this.quantity = value;
        }
    }
}