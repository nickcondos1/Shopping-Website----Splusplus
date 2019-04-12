<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="CartPage.aspx.cs" Inherits="CartPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">

      #CartContainer {        
          padding-right: 15px;
          padding-left: 15px;
          
          padding-top: 15px;
          border: 3px solid #e53714;
          background-color: #000000;         
     }
     .table{
         text-align: center;
         width: 100%;
     }
     .totals{
         display:inline-block;
         float:left;
         text-align: right;
         color: white;
     }
     .button{
         display:inline-block;
         float:right;
         text-align:right;
     }
     .shopping{
         text-align: center;
         color: white;
     }
     #backto{
         text-align: center;
     }
     .error{
         text-align: center;
         color: white;
     }
     #errorCenter{
         text-align: right;
     }
     #checkout{
         text-align: right;
         padding-bottom: 15px;
     }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <br />
    <br />
    <div id="backto">
        <asp:Button ID="Shopping"  CssClass="shopping" runat="server" Text="Back to Shopping" OnClick="Back_Shopping" BackColor="#000000" BorderStyle="Solid" BorderColor="#808080" />
    </div>
        <br />
    <div id="CartContainer" class="container">
        <div style="overflow-x:auto;">
        <asp:Table ID="CartTable" CssClass="table" runat="server"></asp:Table> 
         </div>       
            <asp:Label ID="totalLabel" CssClass="totals" runat="server" Text=""></asp:Label>
            <asp:Button ID="Hoodie" runat="server" Text="" OnClick="Hoodie_Click" />
            <asp:Button ID="Sweatpants" runat="server" Text="" OnClick="Sweatpants_Click" />
            <asp:Button ID="Longsleeve" runat="server" Text="" onClick="Longsleeve_Click"/>
        <div id="errorCenter">
            <asp:Label ID="Error" CssClass="error" runat="server" Text=""></asp:Label>
        </div>
        <div id="checkout">
            <asp:Button ID="Checkout" CssClass="error" runat="server" Text="Checkout" OnClick="Checkout_Click" BackColor="Black" BorderStyle="Solid"/>
        </div>    
    </div>
    <br />
    
    <br />
    <br />
    <script>
        function bottom() {
            document.getElementById("CartContainer").scrollIntoView({
                behavior: 'smooth'
            });
        }
    </script>
   
</asp:Content>

