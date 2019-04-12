<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="ItemDetails.aspx.cs" Inherits="ItemDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
       
    
     .contains {
      display:inline-block;
      margin-left:auto;
      margin-right:auto;
      padding-right: 15px;
      padding-left: 15px;
      padding-bottom: 15px;
      padding-top: 15px;
      border: 3px solid #e53714;
      background-color: #000000;
      text-align: center;
      align-items: center;
      
     }
     .spanClass{
         display: inline-block;
         float: left;
         width: 50%;
         text-align: center;
         color: white;
     }
     Content{
         width:80%;
     }
     .picture{
        text-align: left;
        float: left;
        width: 50%;
     }
     .AddCart{
         display: inline-block;
         color: white;         
         text-align: center;
     }
     .shopping{
         text-align: center;
         color: white;
     }
     #backto{
         text-align: center;
     }
     

    
          
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" CssClass="holder" Runat="Server">
    <br />
    <br />
    <br />
    <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
    <div id="backto">
        <asp:Button ID="Shopping"  CssClass="shopping" runat="server" Text="Back to Shopping" OnClick="Back_Shopping" BackColor="#000000" BorderStyle="Solid" BorderColor="#808080" />
    </div>
        <br />
    
     <div id="scrollHere" class="contains">
            <asp:Image ID="pic" CssClass="picture" runat="server" />
            <asp:Label ID = "ItemInfo" runat="server" CssClass="spanClass" Text="Label"></asp:Label>
         <asp:Button ID="AddToCart" CssClass="AddCart" runat="server" Text="Add to Cart" OnClick="AddToCart_Click" BackColor="#000000" BorderStyle="Solid" BorderColor="#808080"/>                                  
         <asp:Label ID="AddedLabel" CssClass="AddCart" runat="server" Text=""></asp:Label>
     </div>
    <br />
    <br />
    <br />
    <script>
        function bottom() {
            document.getElementById("scrollHere").scrollIntoView({
                behavior: 'smooth'
            });
        }
    </script>
</asp:Content>

