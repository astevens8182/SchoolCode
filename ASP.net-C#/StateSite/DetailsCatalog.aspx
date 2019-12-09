<%@ Page Title="Explore Kansas || Details" Language="C#" MasterPageFile="~/Master1.Master" AutoEventWireup="true" CodeBehind="DetailsCatalog.aspx.cs" Inherits="ProjectVer1Steven.DetailsCatalog" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
    <asp:Label ID="productNamelabel" runat="server" Text="Label"></asp:Label>
    </h1>
    <br />
    <asp:Image ID="detailsImage" runat="server" Height="400px" ToolTip="400px" />
    <br />
    <asp:Label ID="productDescriptionLabel" runat="server" Text="Label"></asp:Label>
    <br />
    <asp:Label ID="Label5" runat="server" Text="Price: "></asp:Label>
    <asp:Label ID="priceLabel" runat="server" Text="$$$"></asp:Label>
    <br />
    <asp:Label ID="Label3" runat="server" Text="Quantity Available:"></asp:Label>
&nbsp;<asp:Label ID="quanLabel" runat="server" Text="#"></asp:Label>
    <br />
    <asp:Label ID="Label4" runat="server" Text="Quantity to order: "></asp:Label>
    <asp:DropDownList ID="ddlQuantityOrdered" runat="server">
    </asp:DropDownList>
    <br />
    <asp:Button ID="btnAddToCart" runat="server" Text="Add To Cart" OnClick="btnAddToCart_Click" />
    <asp:Button ID="btnGoToCart" runat="server" Text="Go To Cart" PostBackUrl="~/Cart.aspx" CausesValidation="false"/>
    <br />
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:steveale_dbConnectionString %>" SelectCommand="SELECT * FROM [Product] WHERE ([Number] = @Number)">
        <SelectParameters>
            <asp:SessionParameter Name="Number" SessionField="sessionProduct" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
