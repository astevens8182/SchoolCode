<%@ Page Title="Explore Kansas || Forgot Password" Language="C#" MasterPageFile="~/Master1.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="ProjectVer1Steven.ChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>please verify your account before changing your password</h1>
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
       Secuirty question</label>
                            &nbsp;<div class="col-sm-5">
                                <asp:DropDownList ID="ddlSecurityQuest" class="form-control"   runat="server" >
                <asp:ListItem>---Select Question---</asp:ListItem>
                <asp:ListItem>What is your 1st grade teacher&#39;s name?</asp:ListItem>
                 </asp:DropDownList>
                                </div>

</div>
               <div class="form-group row">
        <label class="col-sm-2 col-form-label">
       Answer</label>
            &nbsp;<div class="col-sm-5">
                <asp:TextBox ID="txtAnwser" textMode="Password" class="form-control" runat="server"></asp:TextBox>
                  </div>
  </div>


                                        
                                <br />
                <asp:Button ID="btnVerify" class="btn btn-dark" runat="server" Text="Verify" onClick="btnVerify_Click"  />
                <br />
   </form>
</asp:Content>
