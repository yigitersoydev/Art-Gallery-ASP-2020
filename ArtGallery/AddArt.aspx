<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddArt.aspx.cs" Inherits="AddArt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="addGalleryContent">
        <h2>Add Art</h2>
        <div class="line"></div>
         <asp:Label ID="lblTitle" runat="server" Text="Title"> </asp:Label><asp:TextBox ID="txtTitle" runat="server"></asp:TextBox><br />
         <asp:Label ID="lblDate" runat="server" Text="Date"> </asp:Label><asp:TextBox ID="txtDate" PlaceHolder="dd.MM.yyyy" runat="server"></asp:TextBox><br />
          <asp:Label ID="lblArtist" runat="server" Text="Artist"></asp:Label><asp:DropDownList ID="ddlArtist" style="width:61%;float:right;height:25px;" runat="server"></asp:DropDownList><br />
          <asp:Label ID="lblArtType" runat="server" Text="Type"></asp:Label><asp:DropDownList ID="ddlArtType"  style="width:61%;float:right;height:25px;" runat="server"></asp:DropDownList><br />
         <asp:Label ID="lblGallery" runat="server" Text="Gallery"></asp:Label><asp:DropDownList ID="ddlGallery"  style="width:61%;float:right;height:25px;" runat="server"></asp:DropDownList><br />
            <asp:Label ID="lblHistory" runat="server" Text="History"> </asp:Label><asp:TextBox ID="txtHistory" TextMode="MultiLine" runat="server"></asp:TextBox><br /><br /><br /><br />
          <asp:Label ID="lblImage" runat="server" Text="Photo"> </asp:Label><asp:FileUpload ID="FileUpload1" CssClass="form-control" style="float:right;" runat="server" /><br /><br />

         <asp:Button ID="btnAddArt" OnClick="btnAddArt_Click" runat="server" Text="Add Art" />
    </div>
</asp:Content>

