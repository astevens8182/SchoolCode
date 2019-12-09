<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GridViewLab.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
 
    <form id="form1" runat="server">
        
        <div>
            <asp:GridView ID="Grid1" runat="server" AutoGenerateColumns="False" ShowHeader="False">
                <Columns>
                    <asp:BoundField DataField="Text" HeaderText="Name" />
                    <asp:ImageField DataImageUrlField="Value" ControlStyle-Width="250px" ControlStyle-Height="250px" HeaderText="Images" />
                </Columns>
            </asp:GridView>
            <asp:FileUpload ID="fileUploadControl" runat="server" />
            <asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click" Text="Upload" />
        </div>
    </form>
</body>
</html>
