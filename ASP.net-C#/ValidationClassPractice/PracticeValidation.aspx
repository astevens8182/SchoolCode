<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PracticeValidation.aspx.cs" Inherits="validationClassPractice.PracticeValidation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Phone: "></asp:Label>
            <asp:TextBox ID="txtPhoneNumber" runat="server" OnTextChanged="txtPhoneNumber_TextChanged" style="height: 22px"></asp:TextBox>
            <asp:RegularExpressionValidator  ID="vailidationPhone" runat="server" ErrorMessage="Must be vailid U.S phone number" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}" ControlToValidate="txtPhoneNumber"></asp:RegularExpressionValidator>
        </div>
    </form>
</body>
</html>
