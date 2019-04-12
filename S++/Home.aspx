<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .img-thumbnail{
            border: 3px solid #e53714;
            
            background-color: #000000;
            border-radius: 3px
        }
        .caption{
            color: white;
            text-align: center;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <br />
    <br />
    <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
    <div id="itemsContainer" class="container">
        <asp:Label ID="content" runat="server" Text=""></asp:Label>
    </div>
    <br />
    <br />
    <br />
    
</asp:Content>

