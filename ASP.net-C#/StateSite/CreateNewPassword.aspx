<%@ Page Title="Explore Kansas || Create New Password" Language="C#" MasterPageFile="~/Master1.Master" AutoEventWireup="true" CodeBehind="CreateNewPassword.aspx.cs" Inherits="ProjectVer1Steven.CreateNewPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Please enter your new password</h1>
         <form>
        <div class="form-group row">
        <label class="col-sm-2 col-form-label">
       New Password</label>
            &nbsp;<div class="col-sm-5">
                <asp:TextBox ID="txtNewPassword" textMode="Password" class="form-control" runat="server"></asp:TextBox>
                  </div>
  </div>
        <div class="form-group row">
        <label class="col-sm-2 col-form-label">
       Re-enter Password</label>
            &nbsp;<div class="col-sm-5">
                <asp:TextBox ID="txtReenterPassword" textMode="Password" class="form-control" runat="server"></asp:TextBox>
                  </div>
  </div>
                     <br />
                <asp:Button ID="btnChange" class="btn btn-dark" runat="server" Text="Verify" OnClick="btnChange_Click"   />
                <br />
             </form>
</asp:Content>
