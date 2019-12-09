<%@ Page Title="Explore Kansas || Catalog " Language="C#" MasterPageFile="~/Master1.Master" AutoEventWireup="true" CodeBehind="Catalog.aspx.cs" Inherits="ProjectVer1Steven.Catalog" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
    <asp:Label ID="catlabel" runat="server" Text="Catalog"/>
    </h1>
    <asp:GridView ID="gvCatalog"  runat="server"  AllowPaging="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" ShowHeader="False" DataKeyNames="Number" Height="1595px" Width="344px" >
       
        <Columns>
            <asp:TemplateField HeaderText="ImageURL" SortExpression="ImageURL">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("ImageURL") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:ImageButton ID="ImageButton1" runat="server" Height="200px" ImageUrl='<%# Eval("ImageURL") %>' OnClick="ImageButton1_Click" CommandName='<%# Eval("Number") %>' CommandArgument='<%# Eval("Number") %>'  Width="200px" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" >
                    <ItemStyle CssClass="card" />
            </asp:BoundField>
                    <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" DataFormatString="{0:c}" >
            <ItemStyle CssClass="card" />
            </asp:BoundField>
            <asp:BoundField DataField="Number" HeaderText="Number" ReadOnly="True" SortExpression="Number" Visible="False" />
                    </Columns>
        <EditRowStyle CssClass="card" />
        <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:steveale_dbConnectionString %>" SelectCommand="SELECT [ImageURL], [Name], [Price], [Number] FROM [Product]"></asp:SqlDataSource>


    </asp:Content>
