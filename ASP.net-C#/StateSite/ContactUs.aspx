<%@ Page Title="Explore Kansas || Contact Us" Language="C#" MasterPageFile="~/Master1.Master" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="ProjectVer1Steven.ContactUs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>
    <asp:Label ID="Label2" runat="server" Text="Have Questions?"></asp:Label>
</h2>

   <label style="font-weight:bold;">Email address<asp:RegularExpressionValidator ID="RegularExpressionValidator1"  runat="server" ControlToValidate="txtEmail" ErrorMessage="Please enter a valid email"  ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="Red" SetFocusOnError="True">*</asp:RegularExpressionValidator>

    

                <asp:RequiredFieldValidator ID="RequiredFieldValidator2"   runat="server" ControlToValidate="txtEmail" ErrorMessage="Email cannot be empty" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>



            </label><br /><asp:TextBox ID="txtEmail" class="form-control"  runat="server" Width="201px"></asp:TextBox>

    

         <label style="font-weight:bold;">Message<asp:RequiredFieldValidator ID="RequiredFieldValidator1"  runat="server" ControlToValidate="txtMessage" ErrorMessage="Enter message" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
    </label>
    &nbsp;<asp:TextBox ID="txtMessage" class="form-control" runat="server" TextMode="MultiLine" Width="420px"></asp:TextBox>
    <br />

    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />

    <br /><asp:Button ID="Button1" runat="server" Text="Send" class="btn btn-dark" OnClick="Button1_Click"/>
     

</asp:Content>
