<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <div class="contactContent">
        <h2>Contact Us</h2>
           <div class="lineForm"></div>
        <asp:Label ID="lblEmail" runat="server" Text="Email"> </asp:Label><asp:TextBox ID="txtEmail"  Placeholder="example@info.com" runat="server"></asp:TextBox><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*" ForeColor="Red" style="float: right;" Font-Bold="True" ValidationExpression="^((([!#$%&'*+\-/=?^_`{|}~\w])|([!#$%&'*+\-/=?^_`{|}~\w][!#$%&'*+\-/=?^_`{|}~\.\w]{0,}[!#$%&'*+\-/=?^_`{|}~\w]))[@]\w+([-.]\w+)*\.\w+([-.]\w+)*)$" ControlToValidate="txtEmail"></asp:RegularExpressionValidator><asp:RequiredFieldValidator ID="RequiredFieldValidator1"  runat="server" ErrorMessage="*" Font-Bold="True" ForeColor="Red" style="float: right;" ControlToValidate="txtEmail" ></asp:RequiredFieldValidator><br />
         <asp:Label ID="lblName" runat="server" Text="Name"> </asp:Label><asp:TextBox ID="txtName"  runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" Font-Bold="True" ForeColor="Red" style="float: right;margin-right:7px;" ControlToValidate="txtName"></asp:RequiredFieldValidator><br />
        <asp:Label ID="lblSurname" runat="server" Text="Surname"> </asp:Label><asp:TextBox ID="txtSurname"  runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" Font-Bold="True" ForeColor="Red" style="float: right;margin-right:7px;" ControlToValidate="txtSurname"></asp:RequiredFieldValidator><br />
       <asp:Label ID="lblMessage" runat="server" Text="Message"> </asp:Label><asp:TextBox ID="txtMessage"  TextMode="MultiLine" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" Font-Bold="True" ForeColor="Red" style="float: right;margin-right:9px;" ControlToValidate="txtMessage"></asp:RequiredFieldValidator><br />
        <br />
     
            <br /><br />
        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Send" />
        <br /><br />
    
    </div>
</asp:Content>

