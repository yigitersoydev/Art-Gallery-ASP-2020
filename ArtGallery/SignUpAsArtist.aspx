﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SignUpAsArtist.aspx.cs" Inherits="SignUpAsArtist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="signUpContent">
        <h2>Sign Up As An Artist</h2>
        <div class="lineForm"></div>
        <asp:Label ID="lblEmail" runat="server" Text="Email"> </asp:Label><asp:TextBox ID="txtEmail" Placeholder="example@info.com" runat="server"></asp:TextBox><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*" ForeColor="Red" Style="float: right;" Font-Bold="True" ValidationExpression="^((([!#$%&'*+\-/=?^_`{|}~\w])|([!#$%&'*+\-/=?^_`{|}~\w][!#$%&'*+\-/=?^_`{|}~\.\w]{0,}[!#$%&'*+\-/=?^_`{|}~\w]))[@]\w+([-.]\w+)*\.\w+([-.]\w+)*)$" ControlToValidate="txtEmail"></asp:RegularExpressionValidator><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" Font-Bold="True" ForeColor="Red" Style="float: right;" ControlToValidate="txtEmail"></asp:RequiredFieldValidator><br />
        <asp:Label ID="lblName" runat="server" Text="Name"> </asp:Label><asp:TextBox ID="txtName" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" Font-Bold="True" ForeColor="Red" Style="float: right; margin-right: 7px;" ControlToValidate="txtName"></asp:RequiredFieldValidator><br />
        <asp:Label ID="lblSurname" runat="server" Text="Surname"> </asp:Label><asp:TextBox ID="txtSurname" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" Font-Bold="True" ForeColor="Red" Style="float: right; margin-right: 7px;" ControlToValidate="txtSurname"></asp:RequiredFieldValidator><br />
        
        <asp:Label ID="lblDOB" runat="server" Text="Date Of Birth"> </asp:Label><asp:TextBox ID="txtDOB" Placeholder="dd.MM.yyyy" runat="server"></asp:TextBox> <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*" Font-Bold="True" ForeColor="Red" Style="float: right; margin-right: 7px;" ControlToValidate="txtDOB"></asp:RequiredFieldValidator><br />
        <asp:Label ID="lblBorn" runat="server" Text="Born"> </asp:Label><asp:TextBox ID="txtBorn" Placeholder="City, Country" runat="server"></asp:TextBox> <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*" Font-Bold="True" ForeColor="Red" Style="float: right; margin-right: 7px;" ControlToValidate="txtBorn"></asp:RequiredFieldValidator><br />
         <asp:Label ID="lblNationality" runat="server" Text="Nationality"> </asp:Label><asp:TextBox ID="txtNationality" runat="server"></asp:TextBox> <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="*" Font-Bold="True" ForeColor="Red" Style="float: right; margin-right: 7px;" ControlToValidate="txtNationality"></asp:RequiredFieldValidator><br />
        <asp:Label ID="lblAddress" runat="server" Text="Address"> </asp:Label><asp:TextBox ID="txtAddress" TextMode="MultiLine" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" Font-Bold="True" ForeColor="Red" Style="float: right; margin-right: 9px;" ControlToValidate="txtAddress"></asp:RequiredFieldValidator><br />
        <br />
        <asp:Label ID="lblPhone" runat="server" Text="Phone"> </asp:Label><asp:TextBox ID="txtPhone" TextMode="Phone" Placeholder="###-###-##-##" runat="server"></asp:TextBox><asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="*" Font-Bold="True" ForeColor="Red" Style="float: right;" ValidationExpression="^[2-9]\d{2}-\d{3}-\d{2}-\d{2}$" ControlToValidate="txtPhone"></asp:RegularExpressionValidator><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" Font-Bold="True" ForeColor="Red" Style="float: right;" ControlToValidate="txtPhone"></asp:RequiredFieldValidator><br />
        <asp:Label ID="lblNumber" runat="server" Text="Number"> </asp:Label><asp:TextBox ID="txtNumber" MaxLength="10" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*" Font-Bold="True" ForeColor="Red" Style="float: right; margin-right: 7px;" ControlToValidate="txtNumber"></asp:RequiredFieldValidator><br />
     
        <asp:Label ID="lblPassword" runat="server" Text="Password"> </asp:Label><asp:TextBox ID="txtPassword" Placeholder="4 to 16 digits, at least one number" runat="server" TextMode="Password"></asp:TextBox><asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="*" ForeColor="Red" Style="float: right;" Font-Bold="True" ControlToValidate="txtPassword" ValidationExpression="^(?=.*\d).{4,16}$"></asp:RegularExpressionValidator><asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" Font-Bold="True" ForeColor="Red" Style="float: right;" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
        <br /><br />
         <asp:Label ID="lblImage" runat="server" Text="Photo"> </asp:Label><asp:FileUpload ID="FileUpload1" CssClass="form-control" style="float:right;" runat="server" />
        <br /><br />
        <asp:Button ID="btnSignUp" OnClick="btnSignUp_Click" runat="server" Text="Sign Up" />
        <br />
        <br />
        <asp:Label ID="lblCreateAccount" runat="server" Text="Do you already have an account?"></asp:Label>
        <a href="Login.aspx">Login!</a>
        <br />
        <asp:Label ID="lblRegisterAsArtist" runat="server" Text="If you want to register as a normal user,"></asp:Label>
        <a href="SignUp.aspx">Click here!</a>
    </div>
</asp:Content>
