<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="loginContent">
        <h2>Login</h2>
         <div class="lineForm"></div>
        <asp:Label ID="lblEmail" runat="server" Text="Email"> </asp:Label><asp:TextBox ID="txtEmail"  Placeholder="example@info.com" runat="server"></asp:TextBox><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*" ForeColor="Red" style="float: right;" Font-Bold="True" ValidationExpression="^((([!#$%&'*+\-/=?^_`{|}~\w])|([!#$%&'*+\-/=?^_`{|}~\w][!#$%&'*+\-/=?^_`{|}~\.\w]{0,}[!#$%&'*+\-/=?^_`{|}~\w]))[@]\w+([-.]\w+)*\.\w+([-.]\w+)*)$" ControlToValidate="txtEmail"></asp:RegularExpressionValidator><asp:RequiredFieldValidator ID="RequiredFieldValidator1"  runat="server" ErrorMessage="*" Font-Bold="True" ForeColor="Red" style="float: right;" ControlToValidate="txtEmail" ></asp:RequiredFieldValidator><br />
        
        <asp:Label ID="lblPassword" runat="server" Text="Password" > </asp:Label><asp:TextBox ID="txtPassword" Placeholder="4 to 16 digits, at least one number" runat="server" TextMode="Password"></asp:TextBox><asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="*" ForeColor="Red" style="float: right;" Font-Bold="True" ControlToValidate="txtPassword" ValidationExpression="^(?=.*\d).{4,16}$"></asp:RegularExpressionValidator><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" Font-Bold="True" ForeColor="Red" style="float: right;" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
        <br />
        <asp:CheckBox ID="chkRemember" runat="server" /> <asp:Label ID="lblRemember" runat="server" Text="Remember Me"> </asp:Label> <br />
            <br />
        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Login" />
        <br /><br />
        <asp:Label ID="Label1" runat="server" Text="Forgot your password?"></asp:Label> <a href="ForgotPassword.aspx">Click here!</a> <br />
        <asp:Label ID="lblCreateAccount" runat="server" Text="If you don't have an account,"></asp:Label> <a href="SignUp.aspx">create one!</a> 
    </div>
</asp:Content>

