<%@ Page Title="Log in" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MiniVault.Account.Login" Async="true" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <script type="text/javascript">

//If validation has failed on the Client side then render the Field Validator

    </script>

    <noscript>
        <%//If any javascript is missing on the browser, then load some html here %>
    </noscript>
    <div class="container-fluid">
        <div class="row">
            <!--Image and other views go here-->

        </div>
        <div class="row center-block">
            <% //Username %>
            <div class="form-group">
                <label class="text-muted" title="Username" />
                <input runat="server" class="form-control" type="email" placeholder="Username (Email Address)" id="UsernameField" />
                <asp:RequiredFieldValidator runat="server" CssClass="form-control" placeholder="Username (Email Address)" ErrorMessage="Invalid username or password" ControlToValidate="UsernameField" ForeColor="Red" />
            </div>

            <%//Password %>
            <div class="form-group">
                <label class="text-muted" title="Password" />
                <input runat="server" class="form-control" type="password" placeholder="Password" id="PasswordField" />
                <asp:RequiredFieldValidator runat="server" CssClass="form-control" placeholder="Password" ErrorMessage="Invalid username or password" ControlToValidate="PasswordField" ForeColor="Red" />
            </div>

            <asp:CheckBox runat="server" OnCheckedChanged="Unnamed_CheckedChanged" CssClass="checkbox" ForeColor="DarkOrange" />
        </div>
    </div>
</asp:Content>
