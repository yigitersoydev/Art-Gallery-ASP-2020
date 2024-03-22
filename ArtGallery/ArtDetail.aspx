<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ArtDetail.aspx.cs" Inherits="ArtDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Repeater ID="rptr_ArtDetail" runat="server">
        <HeaderTemplate>
            <div id="artDetail">
        </HeaderTemplate>
        <ItemTemplate>
            <div class="left">
                <img src="Images/Arts/<%#Eval("image") %>" alt="" />
            </div>
            <div class="right">

                <h2><%#Eval("title") %></h2>
                <div class="line"></div>
                <br />
                <p><span>Year:</span><%# Convert.ToDateTime(Eval("date")).ToString("yyyy")%></p>
                <p><span>Type:</span><%#Eval("artType") %></p>
                <p><span>Made by:</span><a href="?artist=<%#Eval("artistID") %>"> <%#Eval("name") %> <%#Eval("surname") %></a></p>
                <br />
                <p><span>Location:</span><a href="?gallery=<%#Eval("galleryID") %>"><%#Eval("gname") %></a> - <%#Eval("city") %>, <%#Eval("country") %></p>
                <br />

               
                    <asp:LinkButton ID="btnLike" runat="server" OnClick="btnLiked_Click"  CssClass="btn-like">Like | <%#Eval("likes") %></asp:LinkButton>
                    <asp:LinkButton ID="btnLikedAlready" runat="server" OnClick="btnLikedAlready_Click" Visible="false" CssClass="btn-likedAlready">You liked this | <%#Eval("likes") %></asp:LinkButton>
                    <asp:LinkButton ID="btnDislike" runat="server" OnClick="btnDislike_Click" Visible="false" CssClass="btn-dislike">Dislike | <%#Eval("dislikes") %></asp:LinkButton>
                    <asp:LinkButton ID="btnDislikedAlready" runat="server" OnClick="btnDislikedAlready_Click" Visible="false"  CssClass="btn-dislikedAlready">You disliked this | <%#Eval("dislikes") %></asp:LinkButton>


            </div>
            <div class="bottomArt">
                <h2>About the Artifact</h2>
                <div class="line"></div>
                <p><span></span><%#Eval("history") %></p>
            </div>
        </ItemTemplate>
        <FooterTemplate>
            </div>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>

