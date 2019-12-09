<%@ Page Title="Explore Kansas || Please login" Language="C#" MasterPageFile="~/Master1.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="ProjectVer1Steven.ChangePasswordForgotPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h1>
        <asp:Label ID="Label2" runat="server" Text="Please login to make changes your account"></asp:Label>
    </h1>
   <form>
        <div class="form-group row">
        <label class="col-sm-2 col-form-label">
       Email</label>
            &nbsp;<div class="col-sm-5">
                <asp:TextBox ID="txtEmail" class="form-control" runat="server"></asp:TextBox>
                  </div>
  </div>
        <div class="form-group row">
        <label class="col-sm-2 col-form-label">
       Password</label>
                            &nbsp;<div class="col-sm-5">
            <asp:TextBox ID="txtPassword" TextMode="Password" class="form-control" runat="server"></asp:TextBox>
                                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                                <br />
                <asp:Button ID="btnLogin" class="btn btn-dark" runat="server" Text="Login" OnClick="btnLogin_Click" />
      


                                <br />
      


                                <br />
                                <asp:Button ID="btnForgotPwd" class="btn btn-dark" runat="server" Text="Forgot Password" OnClick="btnForgotPwd_Click" />
                         


      </div>
  </div>
   </form>
</asp:Content>
