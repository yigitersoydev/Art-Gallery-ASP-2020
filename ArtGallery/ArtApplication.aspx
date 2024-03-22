<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ArtApplication.aspx.cs" Inherits="ArtApplication" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="applicationContent">
        <h2>Make an Application</h2>
        <div class="lineForm"></div>
        <asp:Label ID="lblEmail" runat="server" Text="Email"> </asp:Label><asp:TextBox ID="txtEmail" ReadOnly="true" Placeholder="example@info.com" runat="server"></asp:TextBox><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*" ForeColor="Red" Style="float: right;" Font-Bold="True" ValidationExpression="^((([!#$%&'*+\-/=?^_`{|}~\w])|([!#$%&'*+\-/=?^_`{|}~\w][!#$%&'*+\-/=?^_`{|}~\.\w]{0,}[!#$%&'*+\-/=?^_`{|}~\w]))[@]\w+([-.]\w+)*\.\w+([-.]\w+)*)$" ControlToValidate="txtEmail"></asp:RegularExpressionValidator><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" Font-Bold="True" ForeColor="Red" Style="float: right;" ControlToValidate="txtEmail"></asp:RequiredFieldValidator><br />
        <asp:Label ID="lblName" runat="server" Text="Name"> </asp:Label><asp:TextBox ID="txtName" ReadOnly="true" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" Font-Bold="True" ForeColor="Red" Style="float: right; margin-right: 7px;" ControlToValidate="txtName"></asp:RequiredFieldValidator><br />
        <asp:Label ID="lblSurname" runat="server" Text="Surname"> </asp:Label><asp:TextBox ID="txtSurname" ReadOnly="true" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" Font-Bold="True" ForeColor="Red" Style="float: right; margin-right: 7px;" ControlToValidate="txtSurname"></asp:RequiredFieldValidator><br />
        
        <asp:Label ID="lblTitle" runat="server" Text="Title"> </asp:Label><asp:TextBox ID="txtTitle" runat="server"></asp:TextBox> <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*" Font-Bold="True" ForeColor="Red" Style="float: right; margin-right: 7px;" ControlToValidate="txtTitle"></asp:RequiredFieldValidator><br />
        <asp:Label ID="lblYear" runat="server" Text="Year"> </asp:Label><asp:TextBox ID="txtYear" runat="server"></asp:TextBox> <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*" Font-Bold="True" ForeColor="Red" Style="float: right; margin-right: 7px;" ControlToValidate="txtYear"></asp:RequiredFieldValidator><br />
        <asp:Label ID="lblGallery" runat="server" Text="Gallery"></asp:Label><asp:DropDownList ID="ddlGallery" style="width:61%;float:right;height:25px;" runat="server"></asp:DropDownList><br />
          <asp:Label ID="lblArtType" runat="server" Text="Type"></asp:Label><asp:DropDownList ID="ddlArtType"  style="width:61%;float:right;height:25px;" runat="server"></asp:DropDownList><br />
        <asp:Label ID="lblHistory" runat="server" Text="History"> </asp:Label><asp:TextBox ID="txtHistory" TextMode="MultiLine" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" Font-Bold="True" ForeColor="Red" Style="float: right; margin-right: 9px;" ControlToValidate="txtHistory"></asp:RequiredFieldValidator><br />
        <br /><br />

         <asp:Label ID="lblImage" runat="server" Text="Photo"> </asp:Label><asp:FileUpload ID="FileUpload1" CssClass="form-control" style="float:right;" runat="server" />
        <br /><br />
        <asp:Button ID="btnApply" OnClick="btnApply_Click" runat="server" Text="Apply" />
        <br />
        <br />
    </div>
</asp:Content>

