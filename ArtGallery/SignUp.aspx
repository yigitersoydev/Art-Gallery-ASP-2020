<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SignUp.aspx.cs" Inherits="SignUp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="signUpContent">
        <h2>Sign Up</h2>
         <div class="lineForm"></div>
        <asp:Label ID="lblEmail" runat="server" Text="Email"> </asp:Label><asp:TextBox ID="txtEmail"  Placeholder="example@info.com" runat="server"></asp:TextBox><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*" ForeColor="Red" style="float: right;" Font-Bold="True" ValidationExpression="^((([!#$%&'*+\-/=?^_`{|}~\w])|([!#$%&'*+\-/=?^_`{|}~\w][!#$%&'*+\-/=?^_`{|}~\.\w]{0,}[!#$%&'*+\-/=?^_`{|}~\w]))[@]\w+([-.]\w+)*\.\w+([-.]\w+)*)$" ControlToValidate="txtEmail"></asp:RegularExpressionValidator><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" Font-Bold="True" ForeColor="Red" style="float: right;" ControlToValidate="txtEmail"></asp:RequiredFieldValidator><br />
        <asp:Label ID="lblName" runat="server" Text="Name"> </asp:Label><asp:TextBox ID="txtName"  runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" Font-Bold="True" ForeColor="Red" style="float: right;margin-right:7px;" ControlToValidate="txtName"></asp:RequiredFieldValidator><br />
        <asp:Label ID="lblSurname" runat="server" Text="Surname"> </asp:Label><asp:TextBox ID="txtSurname"  runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" Font-Bold="True" ForeColor="Red" style="float: right;margin-right:7px;" ControlToValidate="txtSurname"></asp:RequiredFieldValidator><br />
        <asp:Label ID="lblAddress" runat="server" Text="Address"> </asp:Label><asp:TextBox ID="txtAddress"  TextMode="MultiLine" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" Font-Bold="True" ForeColor="Red" style="float: right;margin-right:9px;" ControlToValidate="txtAddress"></asp:RequiredFieldValidator><br />
        <br /><asp:Label ID="lblPhone" runat="server" Text="Phone"> </asp:Label><asp:TextBox ID="txtPhone" TextMode="Phone" Placeholder="###-###-##-##" runat="server"></asp:TextBox><asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="*" Font-Bold="True" ForeColor="Red" style="float: right;" ValidationExpression="^[2-9]\d{2}-\d{3}-\d{2}-\d{2}$" ControlToValidate="txtPhone"></asp:RegularExpressionValidator><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" Font-Bold="True" ForeColor="Red" style="float: right;" ControlToValidate="txtPhone"></asp:RequiredFieldValidator><br />
        <asp:Label ID="lblPassword" runat="server" Text="Password" > </asp:Label><asp:TextBox ID="txtPassword" Placeholder="4 to 16 digits, at least one number" runat="server" TextMode="Password"></asp:TextBox><asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="*" ForeColor="Red" style="float: right;" Font-Bold="True" ControlToValidate="txtPassword" ValidationExpression="^(?=.*\d).{4,16}$"></asp:RegularExpressionValidator><asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" Font-Bold="True" ForeColor="Red" style="float: right;" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
        <br />
            <br />
        <asp:Button ID="btnSignUp" runat="server" OnClick="btnSignUp_Click" Text="Sign Up" />
        <br /><br />
        <asp:Label ID="lblCreateAccount" runat="server" Text="Do you already have an account?"></asp:Label> <a href="Login.aspx">Login!</a> <br />
        <asp:Label ID="lblRegisterAsArtist" runat="server" Text=" If you want to register as an artist,"></asp:Label> <a href="SignUpAsArtist.aspx">Click here!</a> 
    </div>
</asp:Content>

