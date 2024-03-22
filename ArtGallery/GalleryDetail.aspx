<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="GalleryDetail.aspx.cs" Inherits="GalleryDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Repeater ID="rptr_GalleryDetail" runat="server">
        <HeaderTemplate>
            <div id="galleryDetail">
        </HeaderTemplate>
        <ItemTemplate>
            <div class="left">
                 <img src="Images/Galleries/<%#Eval("image") %>" alt="" />
                
            </div>
            <div class="right">
               <h2><%#Eval("gname") %></h2>
                <div class="line"></div>
                  <br />
                <p><span>Year:</span> <%# Convert.ToDateTime(Eval("date")).ToString("yyyy")%></p>
                <p><span>Location:</span> <%#Eval("city") %>, <%#Eval("country") %></p>
                <br />
                <p><span>About:</span> <%#Eval("description") %></p>
            </div>
        </ItemTemplate>
        <FooterTemplate>
            </div>
             <div id="artistDetailFooter">
                <h2>Artworks in the Gallery</h2>
                <div class="line"></div>
            </div>
        </FooterTemplate>
    </asp:Repeater>

     <asp:Repeater ID="rptr_GalleryArt" runat="server">
        <HeaderTemplate>
            <div id="galleryArts">
        </HeaderTemplate>
        <ItemTemplate>
          <a href="?art=<%#Eval("artID") %>">
                <div class="boxShort" style="width: 18%;height:300px;">
                    <img src="Images/Arts/<%#Eval("image") %>" style="object-fit:contain;border-radius:10px;border:none;" alt="" />
                    <h4><%#Eval("title") %></h4>
                </div>
            </a>
        </ItemTemplate>
        <FooterTemplate>
            </div>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>

