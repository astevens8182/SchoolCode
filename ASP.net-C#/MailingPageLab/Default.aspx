<%@ Page Title="Contoso Home Page" Language="C#" MasterPageFile="~/Master1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MasterPageLab.Default" %>
<%@ MasterType VirtualPath="~/Master1.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Welcom to the site of
        <asp:Label ID="CompanyName" runat="server" Text="Label"></asp:Label>
    </h1>
    <p>
        Thank you for visiting our site</p>
</asp:Content>
