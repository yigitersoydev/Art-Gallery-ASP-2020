<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="innerContent">
        <div class="upperContent">
            <div class="img-gradient">
                <img src="Images/banner.jpg" />
            </div>
            <p><span style="margin-left:2%;"></span>Step through our door in the streets and you will be on a journey of discovery.&nbsp Inside the Gallery, you will find interlinked spaces and changing displays of contemporary art to browse and buy.&nbsp You can also treat yourself to a leisurely view of some of our Permanent Collection.</p>
            <br />
            <blockquote>Every child is an artist. The problem is how to remain an artist once we grow up. -<strong> Pablo Picasso</strong></blockquote>
             <blockquote>You don’t take a photograph, you make it. -<strong> Ansel Adams</strong></blockquote>
            <blockquote>Painting is easy when you don’t know how, but very difficult when you do. -<strong> Edgar Degas</strong></blockquote>
            <blockquote>Creativity takes courage. -<strong> Henri Matisse</strong></blockquote>
            <blockquote>Every artist was first an amateur. -<strong> Ralph Waldo Emerson</strong></blockquote>
        </div>
        <div class="lowerContent">
            <div class="homeLeft">
                <asp:Repeater ID="rptr_HomeExhib" runat="server">
                    <HeaderTemplate>
                        <h2>Upcoming Exhibitons</h2>
                        <div class="line"></div>
                        <div class="boxLong">
                            <table style="width: 100%; float: left; text-align: center;">
                                <tr>
                                    <th>
                                        <p>Title</p>
                                    </th>
                                    <th>
                                        <p>Gallery</p>
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
                                        <div class="line" style="height: 3px;"></div>
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

                   <a class="moreExhib" style="float: right;background-color: #3b3b3b;color: white;padding: 10px;border-radius: 10px;margin-top: 2%;text-transform: none;"  href="Exhibitions.aspx">For more information about upcoming exhibitions...</a>
                        </div>
                    </FooterTemplate>
                </asp:Repeater>
            </div>

            <div class="homeRight">
                <asp:Repeater ID="rptr_RandomArts" runat="server">
                    <HeaderTemplate>
                         <h2>Random Arts</h2>
                        <div class="line"></div>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <a href="?art=<%#Eval("artID") %>">
                        <div class="homeRightBox">
                            <img src="Images/Arts/<%#Eval("image") %>"/>
                            <div style="float:left;margin-left:2%;">
                            <h3 style="inline-size: 300px;"><%#Eval("title") %></h3>
                                <p><%#Eval("name") %> <%#Eval("surname") %> - <%# Convert.ToDateTime(Eval("date")).ToString("yyyy")%></p>
                                </div>
                        </div>
                            </a>
                    </ItemTemplate>
                    <FooterTemplate>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
</asp:Content>

