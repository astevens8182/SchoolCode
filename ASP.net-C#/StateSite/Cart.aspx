<%@ Page Title="Explore Kansas || Cart" Language="C#" MasterPageFile="~/Master1.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="ProjectVer1Steven.Cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        <asp:Label ID="Label2" runat="server" Text="Shopping Cart"></asp:Label>
    </h1>
    <p>
        <asp:ListBox ID="lstCart" runat="server"></asp:ListBox>
        <asp:Button ID="btnRemove" runat="server" OnClick="btnRemove_Click" Text="Remove Item" />
        <asp:Button ID="btnEmpty" runat="server" OnClick="btnEmpty_Click" Text="Empty Cart" />
    </p>
    <p>
        <asp:Button ID="btnContinue" runat="server" Text="Continue Shopping" OnClick="btnContinue_Click" />
    </p>
    <p>
        <asp:Button ID="btnCheckOut" runat="server" OnClick="btnCheckOut_Click" Text="Check Out" />
    </p>
</asp:Content>
