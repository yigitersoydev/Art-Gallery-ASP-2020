<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Artists.aspx.cs" Inherits="Artists" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <div class="innerContent">
         <asp:Repeater ID="rptr_Artists" runat="server">
             <HeaderTemplate>
                 <h2>Artists</h2>
                 <div class="line"></div>
             </HeaderTemplate>
             <ItemTemplate>
                 <a href="?artist=<%#Eval("artistID") %>">
              <div class="boxShort" style="width:202px;height:310px;margin-right:2px;">
                      
                 <img src="Images/Artists/<%#Eval("image") %>" style="object-fit:cover;"  alt=""/>
               <h3 style="text-transform:none;">  <%#Eval("name") %> <%#Eval("surname") %></h3>
                  
                  </div>
             </a>
             </ItemTemplate>
             <FooterTemplate>
                 
             </FooterTemplate>
         </asp:Repeater>
    </div>
</asp:Content>

