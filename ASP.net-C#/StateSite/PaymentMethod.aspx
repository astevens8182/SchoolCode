<%@ Page Title="Explore Kansas || Payment" Language="C#" MasterPageFile="~/Master1.Master" AutoEventWireup="true" CodeBehind="PaymentMethod.aspx.cs" Inherits="ProjectVer1Steven.PaymentMethod" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        <asp:Label ID="Label2" runat="server" Text="Payment Information"></asp:Label>
    </h1>
    <h4>
        <asp:Label ID="Label3" runat="server" Text="Please select credit card type"></asp:Label>
    </h4>
    <p>
&nbsp;&nbsp;<asp:DropDownList ID="ddlCreditCardType" runat="server">
            <asp:ListItem>Visa</asp:ListItem>
            <asp:ListItem Value="MasterCard">Master Card</asp:ListItem>
            <asp:ListItem>Amex</asp:ListItem>
            <asp:ListItem></asp:ListItem>
        </asp:DropDownList>
    </p>
    <p>
        <asp:Label ID="Label4" runat="server" Text="Card number: "></asp:Label>
        <asp:TextBox ID="txtCreditCardNumber" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="Label5" runat="server" Text="Experation date: "></asp:Label>
        <asp:DropDownList ID="ddlExpMonth" runat="server">
            <asp:ListItem>04</asp:ListItem>
            <asp:ListItem>05</asp:ListItem>
            <asp:ListItem>06</asp:ListItem>
            <asp:ListItem>07</asp:ListItem>
            <asp:ListItem>08</asp:ListItem>
            <asp:ListItem>09</asp:ListItem>
            <asp:ListItem>10</asp:ListItem>
            <asp:ListItem>11</asp:ListItem>
            <asp:ListItem>12</asp:ListItem>
        </asp:DropDownList>
&nbsp;<asp:DropDownList ID="ddlexpYear" runat="server">
            <asp:ListItem>2019</asp:ListItem>
            <asp:ListItem>2020</asp:ListItem>
            <asp:ListItem>2021</asp:ListItem>
            <asp:ListItem>2022</asp:ListItem>
            <asp:ListItem>2023</asp:ListItem>
            <asp:ListItem>2024</asp:ListItem>
            <asp:ListItem>2025</asp:ListItem>
            <asp:ListItem>2026</asp:ListItem>
            <asp:ListItem>2027</asp:ListItem>
            <asp:ListItem>2028</asp:ListItem>
            <asp:ListItem>2029</asp:ListItem>
            <asp:ListItem>2030</asp:ListItem>
            <asp:ListItem>2031</asp:ListItem>
            <asp:ListItem>2031</asp:ListItem>
        </asp:DropDownList>
    </p>
    <p>
        <asp:Label ID="Label6" runat="server" Text="CVC code: "></asp:Label>
        <asp:TextBox ID="txtcreditCardCVCcode" runat="server" Width="80px"></asp:TextBox>
    </p>
    <p>
        &nbsp;</p>
    <h2>
        <asp:Label ID="Label7" runat="server" Text="Billing Information"></asp:Label>
    </h2>
    <p>
&nbsp;<asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="DataList1_SelectedIndexChanged">
            <ItemTemplate>
                First Name:
                <asp:Label ID="FirstNameTLabel" runat="server" Text='<%# Eval("FirstNameT") %>' />
                <br />
                Last Name:
                <asp:Label ID="LastNameTLabel" runat="server" Text='<%# Eval("LastNameT") %>' />
                <br />
                Street Address:
                <asp:Label ID="StreetAddress1TLabel" runat="server" Text='<%# Eval("StreetAddress1T") %>' />
                <br />
                City:
                <asp:Label ID="CityTLabel" runat="server" Text='<%# Eval("CityT") %>' />
                <br />
                State:
                <asp:Label ID="StateTLabel" runat="server" Text='<%# Eval("StateT") %>' />
                <br />
                Zip Code:
                <asp:Label ID="ZipCodeTLabel" runat="server" Text='<%# Eval("ZipCodeT") %>' />
                <br />
<br />
            </ItemTemplate>
        </asp:DataList>
    </p>
    <p>
        <asp:Label ID="Label9" runat="server" Text="Is billing address the same as shipping?"></asp:Label>
&nbsp;<asp:RadioButton ID="radYes" runat="server" Text="Yes" AutoPostBack="True" OnCheckedChanged="radYes_CheckedChanged" />
&nbsp;<asp:RadioButton ID="radNo" runat="server" Text="No" AutoPostBack="True" OnCheckedChanged="radNo_CheckedChanged" />
    </p>
    <h2>
        <asp:Label ID="lblShippingaddress" runat="server" Text="Shipping Address" ToolTip="Shipping Address"></asp:Label>
    </h2>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    <p>
        <asp:Label ID="lblSFName" runat="server" Text="First name: "></asp:Label>
        <asp:TextBox ID="txtSFName" runat="server"></asp:TextBox>
&nbsp;&nbsp;
        <asp:Label ID="lblSLName" runat="server" Text="Last name: "></asp:Label>
        <asp:TextBox ID="txtSLName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSFName" ErrorMessage="First Name is Required">*</asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSLName" ErrorMessage="Last Name is Required">*</asp:RequiredFieldValidator>
    </p>
    <p>
        <asp:Label ID="lblSAddress" runat="server" Text="Address"></asp:Label>
&nbsp;<asp:TextBox ID="txtSAddress" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtSAddress" ErrorMessage="Address is a required field">*</asp:RequiredFieldValidator>
    </p>
    <p>
        <asp:Label ID="lblSCity" runat="server" Text="City"></asp:Label>
&nbsp;<asp:TextBox ID="txtSCity" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtSCity" ErrorMessage="City is a required field">*</asp:RequiredFieldValidator>
    </p>
    <p>
        <asp:Label ID="lblSZip" runat="server" Text="Zip code"></asp:Label>
&nbsp;<asp:TextBox ID="txtSZip" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtSZip" ErrorMessage="Zip code is a required field">*</asp:RequiredFieldValidator>
&nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtSZip" ErrorMessage="Zip code must be in number" ValidationExpression="\d{5}(-\d{4})?">*</asp:RegularExpressionValidator>
    </p>
    <p>
&nbsp;<asp:Label ID="lblSState" runat="server" Text="State"></asp:Label>

        <asp:DropDownList ID="ddlSStates" class="form-control" runat="server" Width="137px">
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

        </p>
    <p>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:steveale_dbConnectionString %>" SelectCommand="SELECT [FirstNameT], [LastNameT], [StreetAddress1T], [CityT], [StateT], [ZipCodeT] FROM [AccountTable] WHERE ([EmailT] = @EmailT)">
            <SelectParameters>
                <asp:SessionParameter Name="EmailT" SessionField="sessionAccount" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>

        </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:Button ID="btnProceedOrderConfirm" runat="server" Text="Order Confirmation" OnClick="btnProceedOrderConfirm_Click" />
    </p>
</asp:Content>
