<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Galleries.aspx.cs" Inherits="Galleries" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="innerContent">
         <asp:Repeater ID="rptr_Galleries" runat="server">
             <HeaderTemplate>
                <h2>Galleries</h2>
                 <div class="line"></div>
             </HeaderTemplate>
             <ItemTemplate>
                 <a href="?gallery=<%#Eval("galleryID") %>">
              <div class="boxShort">
                      
                 <img src="Images/Galleries/<%#Eval("image") %>" style="object-fit:cover;" alt=""/>
               <h3>  <%#Eval("gname") %> </h3>
                      <h5><%#Eval("city") %>, <%#Eval("country") %></h5>
              
                  </div>
             </a>
             </ItemTemplate>
             <FooterTemplate>
                 
             </FooterTemplate>
         </asp:Repeater>
    
    </div>
</asp:Content>

