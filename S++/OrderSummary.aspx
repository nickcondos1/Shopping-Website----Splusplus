<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="OrderSummary.aspx.cs" Inherits="OrderSummary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        #billing{
          
          border: 3px solid #e53714;
          background-color: #000000;
        }
        .Labels{
            color: white;
        }
        .textBoxes{
            background-color: white;
            color: black;

        }
        #containMe{
            width: 100%;
            border: 3px solid #e53714;
            background-color: #000000;
        }
       
        
        
        

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <br />
    <br />
    
    <div id="containMe" class="container">
         <div style="overflow-x:auto;">       
        <asp:Table ID="Table1" runat="server" CellPadding="10" CellSpacing="10">
        
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="NameLabel" CssClass="Labels" runat="server" Text="Name: "></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="Name" CssClass="textBoxes" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="Namevalidator" ControlToValidate="Name" runat="server" ErrorMessage="Required" ForeColor="White"></asp:RequiredFieldValidator>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="StreetLabel" CssClass="Labels" runat="server" Text="Street: "></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="Street" CssClass="textBoxes" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="Streetvalidator" ControlToValidate="Street" runat="server" ErrorMessage="Required" ForeColor="White"></asp:RequiredFieldValidator>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="ZipLabel" CssClass="Labels" runat="server" Text="Zipcode: "></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="Zipcode" CssClass="textBoxes" runat="server"></asp:TextBox>
                <asp:RangeValidator ID="ZipValidator" runat="server" ControlToValidate="Zipcode"
                    MaximumValue="99999" MinimumValue="00000" Type="Integer" ErrorMessage="Max: 99999 Min: 00000" ForeColor="White"></asp:RangeValidator>
                <asp:RequiredFieldValidator ID="zipcodevalidator" ControlToValidate="Zipcode" runat="server" ErrorMessage="Required" ForeColor="White"></asp:RequiredFieldValidator>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="CityLabel" CssClass="Labels" runat="server" Text="City: "></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="City" CssClass="textBoxes" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="Cityvalidator" ControlToValidate="City" runat="server" ErrorMessage="Required" ForeColor="White"></asp:RequiredFieldValidator>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="StateLabel" CssClass="Labels" runat="server" Text="State: "></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="State" CssClass="textBoxes" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="Statevalidator" ControlToValidate="State" runat="server" ErrorMessage="Required" ForeColor="White"></asp:RequiredFieldValidator>
            </asp:TableCell>
        </asp:TableRow>
          
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="EmailLabel" CssClass="Labels" runat="server" Text="Email: "></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="Email" CssClass="textBoxes" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="emailvalidator" ControlToValidate="Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" runat="server" ErrorMessage="Enter a valid email" ForeColor="White"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="emailvalid" ControlToValidate="Email" runat="server" ErrorMessage="Required" ForeColor="White"></asp:RequiredFieldValidator>
            </asp:TableCell>
        </asp:TableRow>
        
        </asp:Table>
         
                <br />
                <br />
                
                <asp:Table ID="Summary" runat="server" ForeColor="White" CellPadding="10" CellSpacing="0" Font-Size="Medium"></asp:Table>
                
          </div> 
        
        <asp:Button id="confirmation" runat="server" text="Submit Order" onClick="Confirmation_Click" ForeColor="White" BackColor="Black" BorderStyle="Solid"/>
    </div>    

    

    <br />
    <br />
    <br />
</asp:Content>

