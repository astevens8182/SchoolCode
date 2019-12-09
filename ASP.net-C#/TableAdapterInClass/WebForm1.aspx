<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="TableAdapterInClass.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="txtFirst" runat="server"></asp:TextBox>
            <br />
            <asp:TextBox ID="txtLast" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="btnInsert" runat="server" OnClick="btnInsert_Click" Text="Insert" />
            <br />
            <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Delete" />
        </div>
    </form>
</body>
</html>
