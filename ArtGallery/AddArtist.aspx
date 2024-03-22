<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddArtist.aspx.cs" Inherits="AddArtist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="addGalleryContent">
        <h2>Add Artist</h2>
        <div class="line"></div>
         <asp:Label ID="lblName" runat="server" Text="Name"> </asp:Label><asp:TextBox ID="txtName" runat="server"></asp:TextBox><br />
         <asp:Label ID="lblSurname" runat="server" Text="Surname"> </asp:Label><asp:TextBox ID="txtSurname" runat="server"></asp:TextBox><br />
         <asp:Label ID="lblDOB" runat="server" Text="Date Of Birth"> </asp:Label><asp:TextBox ID="txtDOB" PlaceHolder="dd.MM.yyyy" runat="server"></asp:TextBox><br />
         <asp:Label ID="lblDOD" runat="server" Text="Date Of Death"> </asp:Label><asp:TextBox ID="txtDOD" PlaceHolder="dd.MM.yyyy" runat="server"></asp:TextBox><br />
         <asp:Label ID="lblBornLoca" runat="server" Text="Born Location"> </asp:Label><asp:TextBox ID="txtBorn" runat="server"></asp:TextBox><br />
         <asp:Label ID="lblDeathLoc" runat="server" Text="Death Location"> </asp:Label><asp:TextBox ID="txtDeath" runat="server"></asp:TextBox><br />
         <asp:Label ID="lblNationality" runat="server" Text="Nationality"> </asp:Label><asp:TextBox ID="txtNationality" runat="server"></asp:TextBox><br /><br /><br /><br />

          <asp:Label ID="lblImage" runat="server" Text="Photo"> </asp:Label><asp:FileUpload ID="FileUpload1" CssClass="form-control" style="float:right;" runat="server" /><br /><br />

         <asp:Button ID="btnAddArtist" OnClick="btnAddArtist_Click" runat="server" Text="Add Artist" />
    </div>
</asp:Content>

