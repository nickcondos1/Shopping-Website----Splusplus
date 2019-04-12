using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Item
/// </summary>
[Serializable]
public class Item
{
    private string sku;
    private string itemName;
    private string shortDesc;
    private string longDesc;
    private string picName;
    private int quantityOnHand;
    private string price;
    private float weight;

    public Item(string sku, string itemname, string shortdesc, string longdesc,
        string picname, int qoh, string cost, float weight)
    {
        this.sku = sku;
        this.itemName = itemname;
        this.shortDesc = shortdesc;
        this.longDesc = longdesc;
        this.picName = picname;
        this.quantityOnHand = qoh;
        this.price = cost;
        this.weight = weight;
    }

    public float Weight
    {
        get
        {
            return this.weight;
        }
        set
        {
            this.weight = value;
        }
    }

    public string Sku
    {
        get
        {
            return this.sku;
        }
        set
        {
            this.sku = value;
        }
    }

    public string ItemName
    {
        get
        {
            return this.itemName;
        }
        set
        {
            this.itemName = value;
        }
    }

    public string ShortDesc
    {
        get
        {
            return this.shortDesc;
        }
        set
        {
            this.shortDesc = value;
        }
    }

    public string LongDesc
    {
        get
        {
            return this.longDesc;
        }
        set
        {
            this.longDesc = value;
        }
    }

    public string PicName
    {
        get
        {
            return this.picName;
        }
        set
        {
            this.picName = value;
        }
    }

    public int Quantity
    {
        get
        {
            return this.quantityOnHand;
        }
        set
        {
            this.quantityOnHand = value;
        }
    }

    public string Price
    {
        get
        {
            return this.price;
        }
        set
        {
            this.price = value;
        }
    }
}