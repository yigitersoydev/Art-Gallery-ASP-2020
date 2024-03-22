<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Exhibitions.aspx.cs" Inherits="Exhibitions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="innerContent">
        <asp:Repeater ID="rptr_Exhibitions" runat="server">
            <HeaderTemplate>
                <div class="boxLong">
                    <table style="width: 100%; float: left;text-align:center;">
                        <tr>
                            <th>
                                <p>Title</p>
                            </th>
                            <th>
                                <p>Gallery</p>
                            </th>
                            <th>
                                <p>Location</p>
                            </th>
                            <th>
                                <p>Type</p>
                            </th>
                            <th>
                                <p>Start Date</p>
                            </th>
                            <th>
                                <p>End Date</p>
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
                        <p><%#Eval("title") %></p>
                    </td>
                    <td>
                        <p><a href="?gallery=<%#Eval("galleryID") %>"><%#Eval("gname") %></a></p>
                    </td>
                    <td>
                        <p><%#Eval("city") %>, <%#Eval("country") %></p>
                    </td>
                    <td>
                        <p><%#Eval("artType") %></p>
                    </td>
                    <td>
                        <p><%# Convert.ToDateTime(Eval("startDate")).ToString("dd/MM/yyyy")%></p>
                    </td>
                    <td>
                        <p><%# Convert.ToDateTime(Eval("endDate")).ToString("dd/MM/yyyy")%></p>
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

