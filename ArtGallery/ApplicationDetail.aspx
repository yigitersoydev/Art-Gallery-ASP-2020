<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ApplicationDetail.aspx.cs" Inherits="ApplicationDetail" EnableEventValidation="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="innerContent">
        <asp:Repeater ID="rptr_AppDetail" runat="server">
            <HeaderTemplate>
              <div id="applicationDetail">
            </HeaderTemplate>
            <ItemTemplate>

                 <div class="left">
                <img src="Images/Arts/<%#Eval("image") %>" alt="" />
            </div>
            <div class="right">
              
                <h2><%#Eval("titleOfArt") %></h2>
                <div class="line"></div>
                  <br />
                <p><span>Year :</span> <%# Convert.ToDateTime(Eval("yearOfArt")).ToString("yyyy")%></p>
                <p><span>Type :</span> <%#Eval("artType") %></p>
                <br />
                <p><span>History :</span> <%#Eval("history") %></p>
                <br />
                <p><span>Gallery :</span><a href="?gallery=<%#Eval("galleryID") %>"><%#Eval("gname") %> </a> <span style="color:darkgrey;margin-left:2%;float:none;font-size:12pt;">(the gallery that artist wants to exhibit the his/her artwork)</span></p>
            </div>
                <div class="applicationFooter">
                    
                    <div style="margin-left:auto;margin-right:auto;display:block;width:25%;">
                    <asp:Button ID="btnConfirm" CssClass="confirm" OnClick="btnConfirm_Click" runat="server" Text="Confirm" /> <asp:Button ID="btnReject" OnClick="btnReject_Click" CssClass="reject" runat="server" Text="Reject" />
                        </div>
                </div>
            </ItemTemplate>
            <FooterTemplate>
               </div>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>

