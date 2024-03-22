<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ArtistDetail.aspx.cs" Inherits="ArtistDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Repeater ID="rptr_ArtistDetail" runat="server">
        <HeaderTemplate>
            <div id="artistDetail">
        </HeaderTemplate>
        <ItemTemplate>
            <div class="left">
                <img src="Images/Artists/<%#Eval("image") %>" alt="" />
            </div>
            <div class="right">
              
                <h2><%#Eval("name") %> <%#Eval("surname") %></h2>
                <div class="line"></div>
                  <br />
                <p><span>Born:</span> <%#Eval("dateOfBirth") %> - <%#Eval("bornLocation") %></p>
                <p><span>Died:</span> <%#Eval("dateOfDeath") %> - <%#Eval("deathLocation") %></p>
                <br />
                <p><span> Nationality:</span> <%#Eval("nationality") %></p>
            </div>
        </ItemTemplate>
        <FooterTemplate>
            </div>
            <div id="artistDetailFooter">
                <h2>Arts</h2>
                <div class="line"></div>
            </div>
        </FooterTemplate>
    </asp:Repeater>
    <asp:Repeater ID="rptr_ArtistArt" runat="server">
        <HeaderTemplate>
            <div id="artistArts">
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

