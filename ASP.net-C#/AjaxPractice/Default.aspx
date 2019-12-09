<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AjaxPractice.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" OnPageIndexChanged="GridView1_PageIndexChanged" PageSize="5">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="Contact_First_Name" HeaderText="Contact_First_Name" SortExpression="Contact_First_Name" />
                        <asp:BoundField DataField="Contact_Last_Name" HeaderText="Contact_Last_Name" SortExpression="Contact_Last_Name" />
                    </Columns>
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    <SortedAscendingCellStyle BackColor="#FDF5AC" />
                    <SortedAscendingHeaderStyle BackColor="#4D0000" />
                    <SortedDescendingCellStyle BackColor="#FCF6C0" />
                    <SortedDescendingHeaderStyle BackColor="#820000" />
                </asp:GridView>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="TextBox1_CalendarExtender" runat="server" BehaviorID="TextBox1_CalendarExtender" TargetControlID="TextBox1" />
                <asp:Label ID="Label1" runat="server" Text="Calendar extender"></asp:Label>
                <br />
                <asp:Label ID="Label2" runat="server" Text="Area chart"></asp:Label>
                <br />
                <ajaxToolkit:AreaChart ID="AreaChart1" runat="server">
                </ajaxToolkit:AreaChart>
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                    <ProgressTemplate>
                        Getting data...
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:xtremeDBConnectionString %>" SelectCommand="SELECT [Contact First Name] AS Contact_First_Name, [Contact Last Name] AS Contact_Last_Name FROM [Customer] ORDER BY [Contact Last Name], [Contact First Name]"></asp:SqlDataSource>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
