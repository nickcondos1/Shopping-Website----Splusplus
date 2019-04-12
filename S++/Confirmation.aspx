<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="Confirmation.aspx.cs" Inherits="Confirmation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        #OrderDiv{
            border: 3px solid #e53714;
            background-color: #000000; 
        }
        .confirm{
            background-color: black;
            color: white;
        }
        #centerMe{
            text-align:center;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <br />
    <br />
    <div id="OrderDiv" class="container">
        <div id="centerMe">
            <asp:Label ID="OrderConformation" CssClass="confirm" runat="server" Text="test"></asp:Label>
        </div>
    </div>
    <br />
    <br />
    <br />
</asp:Content>

