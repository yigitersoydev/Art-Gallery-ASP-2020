<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ForgotPassword.aspx.cs" Inherits="ForgotPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="loginContent">
        <h2>Reset Password</h2>
         <div class="lineForm"></div>
        <asp:Label ID="lblEmail" runat="server" Text="Email"> </asp:Label><asp:TextBox ID="txtEmail"  Placeholder="example@info.com" runat="server"></asp:TextBox><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*" ForeColor="Red" style="float: right;" Font-Bold="True" ValidationExpression="^((([!#$%&'*+\-/=?^_`{|}~\w])|([!#$%&'*+\-/=?^_`{|}~\w][!#$%&'*+\-/=?^_`{|}~\.\w]{0,}[!#$%&'*+\-/=?^_`{|}~\w]))[@]\w+([-.]\w+)*\.\w+([-.]\w+)*)$" ControlToValidate="txtEmail"></asp:RegularExpressionValidator><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Font-Bold="True" ForeColor="Red" style="float: right;"  ErrorMessage="*" ControlToValidate="txtEmail"></asp:RequiredFieldValidator><br />
        
        <asp:Label ID="lblPassword" runat="server" Text="New Password" > </asp:Label><asp:TextBox ID="txtPassword" Placeholder="4 to 16 digits, at least one number" runat="server" TextMode="Password"></asp:TextBox><asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="*" ForeColor="Red" style="float: right;" Font-Bold="True" ControlToValidate="txtPassword" ValidationExpression="^(?=.*\d).{4,16}$"></asp:RegularExpressionValidator><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" Font-Bold="True" ForeColor="Red" style="float: right;" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
        <br />
         <asp:Label ID="lblPasswordAgain" runat="server" Text="Re-Enter Password" > </asp:Label><asp:TextBox ID="txtPasswordAgain" runat="server" TextMode="Password"></asp:TextBox><asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="*" ForeColor="Red" style="float: right;" Font-Bold="True" ControlToCompare="txtPassword" ControlToValidate="txtPasswordAgain"></asp:CompareValidator><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" Font-Bold="True" ForeColor="Red" style="float: right;" ControlToValidate="txtPasswordAgain"> </asp:RequiredFieldValidator>
        <br />
      
            <br />
        <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" runat="server" Text="Change Password" />
        <br /><br />
        <asp:Label ID="lblCreateAccount" runat="server" Text="If you don't have an account,"></asp:Label> <a href="SignUp.aspx">create one!</a> 
        
      
    </div>
</asp:Content>

