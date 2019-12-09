<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewAdData.aspx.cs" Inherits="AdRotatorLab.ViewAdData" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/App_Data/AdResponses.xml"></asp:XmlDataSource>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="XmlDataSource1">
                <Columns>
                    <asp:BoundField DataField="adname" HeaderText="adname" SortExpression="adname" />
                    <asp:BoundField DataField="hitCount" HeaderText="hitCount" SortExpression="hitCount" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
