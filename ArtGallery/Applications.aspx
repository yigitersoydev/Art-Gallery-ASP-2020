<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Applications.aspx.cs" Inherits="Applications" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <div id="innerContent">
        <asp:Repeater ID="rptr_Applications" runat="server">
            <HeaderTemplate>
                <div class="boxLong">
                    <table style="width: 100%; float: left;text-align:center;">
                        <tr>
                            <th>
                                <p>Name Surname</p>
                            </th>
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
                                <p>Histroy</p>
                            </th>
                             <th>
                                <p> </p>
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
                        <p class="data"><a href="?artist=<%#Eval("artistID") %>"> <%#Eval("name") %> <%#Eval("surname") %></a></p>
                    </td>
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
                        <p class="data"><%#Eval("history") %>...</p>
                    </td>
                     <td>
                        <p class="data"><a href="?application=<%#Eval("applicationID") %>">Detail</a></p>
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

