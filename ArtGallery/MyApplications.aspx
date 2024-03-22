<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MyApplications.aspx.cs" Inherits="MyApplications" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="innerContent">
        <asp:Repeater ID="rptr_MyApplications" runat="server">
            <HeaderTemplate>
                <div class="boxLong">
                    <table style="width: 100%; float: left; text-align: center;">
                        <tr>
                            <th>
                                <p>Title</p>
                            </th>
                            <th>
                                <p>Year</p>
                            </th>
                            <th>
                                <p>Type</p>
                            </th>
                            <th>
                                <p>Gallery</p>
                            </th>
                            <th>
                                <p>Histroy</p>
                            </th>
                            <th>
                                <p>Status</p>
                            </th>
                        </tr>
                        <tr>
                            <th colspan="6">
                                <div class="line"></div>
                            </th>

                        </tr>
            </HeaderTemplate>
            <ItemTemplate>

                <tr>
                    <td>
                        <p class="data"><%#Eval("titleOfArt") %></p>
                    </td>
              
                    <td>
                        <p class="data"><%# Convert.ToDateTime(Eval("yearOfArt")).ToString("yyyy")%></p>
                    </td>
                    <td>
                        <p class="data"><%#Eval("artType") %></p>
                    </td>
                    <td>
                        <p class="data"><a href="?gallery=<%#Eval("galleryID") %>"> <%#Eval("gname") %> </a></p>
                    </td>
                    <td>
                        <p class="data"><%#Eval("history") %>...</p>
                    </td>
                    <td>
                        <p class="data"><%#Eval("statusOfApplication")%></p>
                    </td>
                </tr>
                <tr>
                    <th colspan="6">
                        <hr style="float: left; width: 100%;" />
                    </th>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
                  </div>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>

