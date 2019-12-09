<!--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GridViewDBLab.aspx.cs" Inherits="DBGridViewLab.GridViewDBLab" %>-->
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button2" runat="server" Text="Button" OnClick="Button2_Click" />
            <br />
            <br />
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:steveale_dbConnectionString %>" DeleteCommand="DELETE FROM [Addresses] WHERE [ID] = @ID" InsertCommand="INSERT INTO [Addresses] ([FName], [LName], [Address], [City], [State], [Zip], [PhoneNo], [ytdSalary]) VALUES (@FName, @LName, @Address, @City, @State, @Zip, @PhoneNo, @ytdSalary)" ProviderName="System.Data.SqlClient" SelectCommand="SELECT * FROM [Addresses]" UpdateCommand="UPDATE [Addresses] SET [FName] = @FName, [LName] = @LName, [Address] = @Address, [City] = @City, [State] = @State, [Zip] = @Zip, [PhoneNo] = @PhoneNo, [ytdSalary] = @ytdSalary WHERE [ID] = @ID">
                <DeleteParameters>
                    <asp:Parameter Name="ID" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="FName" Type="String" />
                    <asp:Parameter Name="LName" Type="String" />
                    <asp:Parameter Name="Address" Type="String" />
                    <asp:Parameter Name="City" Type="String" />
                    <asp:Parameter Name="State" Type="String" />
                    <asp:Parameter Name="Zip" Type="String" />
                    <asp:Parameter Name="PhoneNo" Type="String" />
                    <asp:Parameter Name="ytdSalary" Type="Decimal" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="FName" Type="String" />
                    <asp:Parameter Name="LName" Type="String" />
                    <asp:Parameter Name="Address" Type="String" />
                    <asp:Parameter Name="City" Type="String" />
                    <asp:Parameter Name="State" Type="String" />
                    <asp:Parameter Name="Zip" Type="String" />
                    <asp:Parameter Name="PhoneNo" Type="String" />
                    <asp:Parameter Name="ytdSalary" Type="Decimal" />
                    <asp:Parameter Name="ID" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="ID" DataSourceID="SqlDataSource2" ForeColor="#333333" GridLines="None" Height="187px" PageSize="4">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
                    <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                    <asp:BoundField DataField="FName" HeaderText="FName" SortExpression="FName" />
                    <asp:BoundField DataField="LName" HeaderText="LName" SortExpression="LName" />
                    <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                    <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
                    <asp:BoundField DataField="State" HeaderText="State" SortExpression="State" />
                    <asp:BoundField DataField="Zip" HeaderText="Zip" SortExpression="Zip" />
                    <asp:BoundField DataField="PhoneNo" HeaderText="PhoneNo" SortExpression="PhoneNo" />
                    <asp:BoundField DataField="ytdSalary" DataFormatString="{0:c}" HeaderText="ytdSalary" SortExpression="ytdSalary" />
                </Columns>
                <EditRowStyle BackColor="#7C6F57" />
                <EmptyDataTemplate>
                    <asp:Button ID="Button1" runat="server" Text="insert" />
                </EmptyDataTemplate>
                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#E3EAEB" />
                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                <SortedAscendingHeaderStyle BackColor="#246B61" />
                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                <SortedDescendingHeaderStyle BackColor="#15524A" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:steveale_dbConnectionString %>" SelectCommand="SELECT * FROM [Addresses]" ConflictDetection="CompareAllValues" DeleteCommand="DELETE FROM [Addresses] WHERE [ID] = @original_ID AND (([FName] = @original_FName) OR ([FName] IS NULL AND @original_FName IS NULL)) AND (([LName] = @original_LName) OR ([LName] IS NULL AND @original_LName IS NULL)) AND (([Address] = @original_Address) OR ([Address] IS NULL AND @original_Address IS NULL)) AND (([City] = @original_City) OR ([City] IS NULL AND @original_City IS NULL)) AND (([State] = @original_State) OR ([State] IS NULL AND @original_State IS NULL)) AND (([Zip] = @original_Zip) OR ([Zip] IS NULL AND @original_Zip IS NULL)) AND (([PhoneNo] = @original_PhoneNo) OR ([PhoneNo] IS NULL AND @original_PhoneNo IS NULL)) AND (([ytdSalary] = @original_ytdSalary) OR ([ytdSalary] IS NULL AND @original_ytdSalary IS NULL))" InsertCommand="INSERT INTO [Addresses] ([FName], [LName], [Address], [City], [State], [Zip], [PhoneNo], [ytdSalary]) VALUES (@FName, @LName, @Address, @City, @State, @Zip, @PhoneNo, @ytdSalary)" OldValuesParameterFormatString="original_{0}" UpdateCommand="UPDATE [Addresses] SET [FName] = @FName, [LName] = @LName, [Address] = @Address, [City] = @City, [State] = @State, [Zip] = @Zip, [PhoneNo] = @PhoneNo, [ytdSalary] = @ytdSalary WHERE [ID] = @original_ID AND (([FName] = @original_FName) OR ([FName] IS NULL AND @original_FName IS NULL)) AND (([LName] = @original_LName) OR ([LName] IS NULL AND @original_LName IS NULL)) AND (([Address] = @original_Address) OR ([Address] IS NULL AND @original_Address IS NULL)) AND (([City] = @original_City) OR ([City] IS NULL AND @original_City IS NULL)) AND (([State] = @original_State) OR ([State] IS NULL AND @original_State IS NULL)) AND (([Zip] = @original_Zip) OR ([Zip] IS NULL AND @original_Zip IS NULL)) AND (([PhoneNo] = @original_PhoneNo) OR ([PhoneNo] IS NULL AND @original_PhoneNo IS NULL)) AND (([ytdSalary] = @original_ytdSalary) OR ([ytdSalary] IS NULL AND @original_ytdSalary IS NULL))">
                <DeleteParameters>
                    <asp:Parameter Name="original_ID" Type="Int32" />
                    <asp:Parameter Name="original_FName" Type="String" />
                    <asp:Parameter Name="original_LName" Type="String" />
                    <asp:Parameter Name="original_Address" Type="String" />
                    <asp:Parameter Name="original_City" Type="String" />
                    <asp:Parameter Name="original_State" Type="String" />
                    <asp:Parameter Name="original_Zip" Type="String" />
                    <asp:Parameter Name="original_PhoneNo" Type="String" />
                    <asp:Parameter Name="original_ytdSalary" Type="Decimal" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="FName" Type="String" />
                    <asp:Parameter Name="LName" Type="String" />
                    <asp:Parameter Name="Address" Type="String" />
                    <asp:Parameter Name="City" Type="String" />
                    <asp:Parameter Name="State" Type="String" />
                    <asp:Parameter Name="Zip" Type="String" />
                    <asp:Parameter Name="PhoneNo" Type="String" />
                    <asp:Parameter Name="ytdSalary" Type="Decimal" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="FName" Type="String" />
                    <asp:Parameter Name="LName" Type="String" />
                    <asp:Parameter Name="Address" Type="String" />
                    <asp:Parameter Name="City" Type="String" />
                    <asp:Parameter Name="State" Type="String" />
                    <asp:Parameter Name="Zip" Type="String" />
                    <asp:Parameter Name="PhoneNo" Type="String" />
                    <asp:Parameter Name="ytdSalary" Type="Decimal" />
                    <asp:Parameter Name="original_ID" Type="Int32" />
                    <asp:Parameter Name="original_FName" Type="String" />
                    <asp:Parameter Name="original_LName" Type="String" />
                    <asp:Parameter Name="original_Address" Type="String" />
                    <asp:Parameter Name="original_City" Type="String" />
                    <asp:Parameter Name="original_State" Type="String" />
                    <asp:Parameter Name="original_Zip" Type="String" />
                    <asp:Parameter Name="original_PhoneNo" Type="String" />
                    <asp:Parameter Name="original_ytdSalary" Type="Decimal" />
                </UpdateParameters>
            </asp:SqlDataSource>
            <br />
            <br />
            <br />
            id: <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            FName: <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            LName<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <br />
            Address<asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label2" runat="server" Text="City"></asp:Label>
            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label3" runat="server" Text="State"></asp:Label>
            <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label4" runat="server" Text="zip"></asp:Label>
            <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
            <br />
            phone<asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label5" runat="server" Text="salary"></asp:Label>
            <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
            <br />
            <br />
        
</div>
    </form>
        
</body>
</html>
