<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddGallery.aspx.cs" Inherits="AddGallery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="addGalleryContent">
        <h2>Add Gallery</h2>
        <div class="line"></div>
         <asp:Label ID="lblGName" runat="server" Text="Gallery Name"> </asp:Label><asp:TextBox ID="txtGName" runat="server"></asp:TextBox><br />
         <asp:Label ID="lblCity" runat="server" Text="City"> </asp:Label><asp:TextBox ID="txtCity" runat="server"></asp:TextBox><br />
        <asp:Label ID="lblCountry" runat="server" Text="Country"> </asp:Label><asp:TextBox ID="txtCountry" runat="server"></asp:TextBox><br />
        <asp:Label ID="lblDate" runat="server" Text="Established"> </asp:Label><asp:TextBox ID="txtDate" PlaceHolder="01.01.yyyy" runat="server"></asp:TextBox><br />
      <asp:Label ID="lblDescription" runat="server" Text="Description"> </asp:Label><asp:TextBox ID="txtDescription" TextMode="MultiLine" runat="server"></asp:TextBox><br /><br /><br /><br />
          <asp:Label ID="lblImage" runat="server" Text="Photo"> </asp:Label><asp:FileUpload ID="FileUpload1" CssClass="form-control" style="float:right;" runat="server" /><br /><br />

         <asp:Button ID="btnAddGallery" OnClick="btnAddGallery_Click" runat="server" Text="Add Gallery" />
    </div>
</asp:Content>

