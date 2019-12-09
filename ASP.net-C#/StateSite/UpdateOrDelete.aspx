<%@ Page Title="Explore Kansas || Update or Delete?" Language="C#" MasterPageFile="~/Master1.Master" AutoEventWireup="true" CodeBehind="UpdateOrDelete.aspx.cs" Inherits="ProjectVer1Steven.UpdateOrDelete" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            font-family: "Segoe UI";
            font-weight: normal;
            font-size: 12px;
            background-color: #F0F0F0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Would you like to update or delete your account?<span class="auto-style2">d<asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        </span></h1>
    <p>
        <asp:Button ID="btnDelete" class="btn btn-dark" runat="server" Text="Delete" OnClick="btnDelete_Click" />
        <ajaxToolkit:ConfirmButtonExtender ID="btnDelete_ConfirmButtonExtender" runat="server" BehaviorID="btnDelete_ConfirmButtonExtender" ConfirmText="Are you sure you want to delete your account" TargetControlID="btnDelete" />
    </p>
    <p>
        <asp:Button ID="btnUpdate" class="btn btn-dark" runat="server" Text="Update" />
    </p>
    <p>
        <asp:Button ID="btnChangePassword" class="btn btn-dark" runat="server" Text="Change Password" OnClick="btnChangePassword_Click" />
    </p>
</asp:Content>
