<%@ Page Title="Explore Kansas || Create Account" Language="C#" MasterPageFile="~/Master1.Master" AutoEventWireup="true" CodeBehind="CreateAccount.aspx.cs" Inherits="ProjectVer1Steven.CreateAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <h2>Create an Account</h2>
    <p>
        *Indicates required field</p>
        

     <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
        

     <form>
    <div class="form-group row">
      <label class="col-sm-2 col-form-label">
        *First Name<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtLastName" ErrorMessage="First name is a required field" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
        </label>
        &nbsp;<div class="col-sm-5">
        <asp:TextBox ID="txtFirstName" placeHolder="First Name" class="form-control" runat="server" ></asp:TextBox>
    </div>
   </div>
    <div class="form-group row">
      <label class="col-sm-2 col-form-label">
        *Last Name<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLastName" ErrorMessage="Last name is a required field" ForeColor="Red">*</asp:RequiredFieldValidator>
        </label>
        &nbsp;<div class="col-sm-5">
        <asp:TextBox ID="txtLastName" placeHolder="Last Name" class="form-control" runat="server"></asp:TextBox>
    </div>
  </div>

    <div class="form-group row">
      <label class="col-sm-2 col-form-label">
        *Email<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="Must be a valid email" ForeColor="Red" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3"  runat="server" ControlToValidate="txtEmail" ErrorMessage="Email is a required field" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
        <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="An account with is already be used" OnServerValidate="CustomValidator1_ServerValidate"><script></script></asp:CustomValidator>
        </label>
      &nbsp;<div class="col-sm-5">
     <asp:TextBox ID="txtEmail" placeHolder="Example@mail.com" class="form-control"  runat="server"  TextMode="Email" AutoPostBack="True" OnTextChanged="txtEmail_TextChanged"    ></asp:TextBox>
    </div>
    </div>

    <div class="form-group row">
      <label class="col-sm-2 col-form-label">
        *Password<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPassword" ErrorMessage="Password is a required field" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
        </label>
        &nbsp;<div class="col-sm-5">
      <asp:TextBox ID="txtPassword" textMode="Password" class="form-control" runat="server"></asp:TextBox> 
    </div>
  </div>

    <div class="form-group row">
      <label class="col-sm-2 col-form-label">*Security Question </label>
        &nbsp;<div class="col-sm-5">
            <asp:DropDownList ID="ddlSecurityQuest" class="form-control"   runat="server" >
            <asp:ListItem>What is your 1st grade teacher&#39;s name?</asp:ListItem>
        </asp:DropDownList>    

        </div>
  </div>


    <div class="form-group row">
      <label class="col-sm-2 col-form-label">
        *Anwser<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtSecurityQuestAns" ErrorMessage="Anwser is a required field" ForeColor="Red">*</asp:RequiredFieldValidator>
        </label>
        &nbsp;<div class="col-sm-5">
        <asp:TextBox ID="txtSecurityQuestAns" placeHolder="Anwser" class="form-control"  runat="server"></asp:TextBox>  </div>
    </div>                

     <div class="form-group row">
      <label class="col-sm-2 col-form-label">
         *Phone Number<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtPhoneNumber" ErrorMessage="Phone number is a required field" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
         <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtPhoneNumber" ErrorMessage="Must be a valid phone number" ForeColor="Red" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}">*</asp:RegularExpressionValidator>
         </label>
        &nbsp;<div class="col-sm-5">
        <asp:TextBox ID="txtPhoneNumber" placeHolder="(###)###-####" class="form-control" runat="server" TextMode="Phone"></asp:TextBox>
    </div>   
    </div>
       
</form>

 
    <h3>
        Address Information</h3>
    
         <div class="form-group row">
      <label class="col-sm-2 col-form-label">
             Street Address 1<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtStreetAddress1" ErrorMessage="Street address 1 is a required field" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
             *</label>
        <div class="col-sm-10">
        <asp:TextBox ID="txtStreetAddress1" placeHolder="Street Address" class="form-control" runat="server" ></asp:TextBox>
    </div>   
    </div>

             <div class="form-group row">
                 <label class="col-sm-2 col-form-label">Street Address 2</label>
        <div class="col-sm-10">
        <asp:TextBox ID="txtStreetAddress2" PlaceHolder="Apt, Unit, etc..." class="form-control" runat="server"></asp:TextBox>
    </div>   
    </div>

                 <div class="form-group row">
      <label class="col-sm-2 col-form-label">
                     *City<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtCity" ErrorMessage="City is a required field" ForeColor="Red">*</asp:RequiredFieldValidator>
                     </label>
&nbsp;<div class="col-sm-4">
                         <asp:TextBox ID="txtCity" placeHolder="City" class="form-control" runat="server"></asp:TextBox>
                     </div>
    </div>

                     <div class="form-group row">
      <label class="col-sm-2 col-form-label">&nbsp;*State </label>
        &nbsp;<div class="col-sm-2">
        <asp:DropDownList ID="ddlStates" class="form-control" runat="server">
            <asp:ListItem Value="AL ">Alaska - AK  </asp:ListItem>
            <asp:ListItem Value="AK ">Alabama - AL</asp:ListItem>
            <asp:ListItem Value="AZ ">Arkansas - AR </asp:ListItem>
            <asp:ListItem Value="AR ">Arizona - AZ </asp:ListItem>
            <asp:ListItem Value="CA ">Colorado - CO </asp:ListItem>
            <asp:ListItem Value="CO ">California - CA </asp:ListItem>
            <asp:ListItem Value="CT ">Delaware - DE </asp:ListItem>
            <asp:ListItem Value="DE ">Connecticut - CT </asp:ListItem>
            <asp:ListItem Value="FL ">Georgia - GA </asp:ListItem>
            <asp:ListItem Value="GA ">Florida - FL </asp:ListItem>
            <asp:ListItem Value="HI ">Idaho - ID </asp:ListItem>
            <asp:ListItem Value="ID ">Hawaii - HI </asp:ListItem>
            <asp:ListItem Value="IL ">Indiana - IN </asp:ListItem>
            <asp:ListItem Value="IN ">Illinois - IL </asp:ListItem>
            <asp:ListItem Value="IA ">Kansas - KS </asp:ListItem>
            <asp:ListItem Value="KS ">Iowa - IA </asp:ListItem>
            <asp:ListItem Value="KY ">Louisiana - LA </asp:ListItem>
            <asp:ListItem Value="LA ">Kentucky - KY </asp:ListItem>
            <asp:ListItem Value="ME ">Maryland - MD </asp:ListItem>
            <asp:ListItem Value="MD ">Maine - ME </asp:ListItem>
            <asp:ListItem Value="MA ">Michigan - MI </asp:ListItem>
            <asp:ListItem Value="MI ">Massachusetts - MA </asp:ListItem>
            <asp:ListItem Value="MN ">Minnesota - MN </asp:ListItem>
            <asp:ListItem Value="MN ">Minnesota - MN </asp:ListItem>
            <asp:ListItem Value="MO ">Montana - MT </asp:ListItem>
            <asp:ListItem Value="MT ">Missouri - MO </asp:ListItem>
            <asp:ListItem Value="NE ">Nevada - NV </asp:ListItem>
            <asp:ListItem Value="NV ">Nebraska - NE </asp:ListItem>
            <asp:ListItem Value="NH ">New Jersey - NJ </asp:ListItem>
            <asp:ListItem Value="NJ ">New Hampshire - NH </asp:ListItem>
            <asp:ListItem Value="NM ">New York - NY </asp:ListItem>
            <asp:ListItem Value="NY ">New Mexico - NM </asp:ListItem>
            <asp:ListItem Value="NC ">North Dakota - ND </asp:ListItem>
            <asp:ListItem Value="ND ">North Carolina - NC </asp:ListItem>
            <asp:ListItem Value="OH ">Oklahoma - OK </asp:ListItem>
            <asp:ListItem Value="OK ">Ohio - OH </asp:ListItem>
            <asp:ListItem Value="OR ">Pennsylvania - PA </asp:ListItem>
            <asp:ListItem Value="PA ">Oregon - OR </asp:ListItem>
            <asp:ListItem Value="RI ">South Carolina - SC </asp:ListItem>
            <asp:ListItem Value="SC ">Rhode Island - RI </asp:ListItem>
            <asp:ListItem Value="SD ">Tennessee - TN </asp:ListItem>
            <asp:ListItem Value="TN ">South Dakota - SD </asp:ListItem>
            <asp:ListItem Value="TX ">Utah - UT </asp:ListItem>
            <asp:ListItem Value="UT ">Texas - TX </asp:ListItem>
            <asp:ListItem Value="VT ">Virginia - VA </asp:ListItem>
            <asp:ListItem Value="VA ">Vermont - VT </asp:ListItem>
            <asp:ListItem Value="WA ">West Virginia - WV </asp:ListItem>
            <asp:ListItem Value="WV ">Washington - WA </asp:ListItem>
            <asp:ListItem Value="WI ">Wyoming - WY </asp:ListItem>
            <asp:ListItem Value="WY ">Wisconsin - WI </asp:ListItem>
        </asp:DropDownList>    

        </div>   
    </div>


                     <div class="form-group row">
      <label class="col-sm-2 col-form-label">
                         *Zip Code<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtZipCode" ErrorMessage="Zip code is a required field" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                         <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtZipCode" ErrorMessage="Must be a vald U.S. zip code" ForeColor="Red" ValidationExpression="\d{5}(-\d{4})?">*</asp:RegularExpressionValidator>
                         </label>
        &nbsp;<div class="col-sm-3">
                             <asp:TextBox ID="txtZipCode" placeHolder="#####" class="form-control" runat="server"></asp:TextBox>
                             <br />
                             <asp:Button ID="BtnCreateAcc" class="btn btn-dark" runat="server" Text="Create Account" OnClick="BtnCreateAcc_Click" />
                         </div>
    </div>



   


</asp:Content>
