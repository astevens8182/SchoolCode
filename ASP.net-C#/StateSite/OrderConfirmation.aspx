<%@ Page Title="Explore Kansas || Order Confirmation" Language="C#" MasterPageFile="~/Master1.Master" AutoEventWireup="true" CodeBehind="OrderConfirmation.aspx.cs" Inherits="ProjectVer1Steven.OrderConfirmation" %>
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            margin-left: 240px;
        }
        .auto-style3 {
            margin-left: 160px;
        }
        .auto-style4 {
            margin-left: 120px;
        }
        .auto-style5 {
            margin-left: 40px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        <asp:Label ID="Label2" runat="server" Text="Order Confirmation"></asp:Label>
    </h1>
    <p>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:steveale_dbConnectionString %>" SelectCommand="SELECT dbo.LineItems.UnitPrice, dbo.LineItems.Quantity, dbo.Product.Name FROM dbo.Product INNER JOIN dbo.LineItems ON dbo.Product.Number = dbo.LineItems.ProductID INNER JOIN dbo.Invoices ON dbo.LineItems.extension = dbo.Invoices.extension WHERE (dbo.LineItems.extension = @extension)">
            <SelectParameters>
                <asp:SessionParameter Name="extension" SessionField="extensionNumber" />
            </SelectParameters>
        </asp:SqlDataSource>
    </p>
    <p class="auto-style5">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" Height="42px" Width="511px">
            <Columns>
                <asp:BoundField DataField="Name" HeaderText="Product" SortExpression="Name" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
                <asp:BoundField DataField="UnitPrice" HeaderText="Unit Price" SortExpression="UnitPrice" DataFormatString="&quot;{0:c}&quot;" />
            </Columns>
        </asp:GridView>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label3" runat="server" Text="Subtotal: "></asp:Label>
        <asp:Label ID="lblSubTotal" runat="server" Text="$$$"></asp:Label>
    </p>
    <p class="auto-style2">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label5" runat="server" Text="Sales Tax: "></asp:Label>
        <asp:Label ID="Label6" runat="server" Text="6.5%"></asp:Label>
    </p>
    <p class="auto-style3">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label7" runat="server" Text="Shipping "></asp:Label>
        <asp:Label ID="lblShipping" runat="server" Text="$$$"></asp:Label>
    </p>
    <p class="auto-style4">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label8" runat="server" Text="Total: "></asp:Label>
        <asp:Label ID="lblTotal" runat="server" Text="$$$"></asp:Label>
    </p>
<h3>
    <asp:Button ID="btnConfirmOrder" runat="server" Text="Confirm Order" />
    </h3>
    <p>
&nbsp;
    </p>
    <h4>&nbsp;</h4>
</asp:Content>
