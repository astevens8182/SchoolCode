<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestAds.aspx.cs" Inherits="AdRotatorLab.TestAds" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:AdRotator ID="AdRotator1" runat="server" DataSourceID="XmlDataSource1" />
            <asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/App_Data/Sample.ads"></asp:XmlDataSource>
        </div>
        <asp:Button ID="Button1" runat="server" Text="Button" />
    </form>
</body>
</html>
