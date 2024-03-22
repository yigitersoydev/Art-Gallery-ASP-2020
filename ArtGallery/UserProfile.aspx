<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UserProfile.aspx.cs" Inherits="UserProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="innerContent">

        <asp:Repeater ID="rptr_Profile" runat="server">
            <HeaderTemplate>
                <div class="profileContent">
            </HeaderTemplate>
            <ItemTemplate>
                <div class="profileLeft">
                    <div>
                        <img src="Images/Users/<%#Eval("image") %>" /><br />
                        <h2>
                            <%#Eval("name") %> <%#Eval("surname") %>
                        </h2>
                        <h3>Part of the Art Gallery<br />
                            since  <%# Convert.ToDateTime(Eval("dateRegistered")).ToString("MMMM dd, yyyy")%>
                        </h3>
                    </div>
                </div>
                <div class="verticalLine"></div>
                <div class="profileRight">
                    <h2>Contact Info</h2>
                    <div class="line" style="width: 50%; margin-bottom: 5%;"></div>

                    <h3>Email</h3>
                    <p><%#Eval("email") %> </p>
                    <h3>Address </h3>
                    <p><%#Eval("address") %> </p>
                    <h3>Phone </h3>
                    <p><%#Eval("phone") %> </p>
                    <h3>Nationality </h3>
                    <p><%#Eval("nationality") %> </p>
                    <div class="updateProfileBtn">
                        <a href="?user=<%#Eval("userID") %>" style="color: white;">Update Profile</a>
                    </div>

                    <div class="btnChangePassword">
                        <a href="?userC=<%#Eval("userID") %>" style="color: white;">Change Password</a>
                    </div>

                </div>

            </ItemTemplate>
            <FooterTemplate>
                </div>
            </FooterTemplate>
        </asp:Repeater>
        <div class="profileFooterButton">
            <div class="pfbLeft">
                <asp:Button ID="btnAddGalery" OnClick="btnAddGalery_Click" runat="server" Text="Add Gallery" />
                <asp:Button ID="btnAddArtist" OnClick="btnAddArtist_Click" runat="server" Text="Add Artist" />
                <asp:Button ID="btnAddArt" OnClick="btnAddArt_Click" runat="server" Text="Add Art" />
            </div>
            <div class="pfbRight">
                <asp:Button ID="btnApplication" OnClick="btnApplication_Click" runat="server" Text="Make an Application" />
                <asp:Button ID="btnApplications" OnClick="btnApplications_Click" runat="server" Text="List Applications" />
            </div>


        </div>
    </div>
</asp:Content>

