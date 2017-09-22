<%@ Page Title="" Language="VB" MasterPageFile="~/BSMasterPageClient.master" AutoEventWireup="false" CodeFile="UserProfile.aspx.vb" Inherits="UserProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <h2>Profile</h2>

        <hr />

        <asp:Repeater ID="prof" runat="server">
            <ItemTemplate>
                <div>
                    <asp:Label ID="lblUsername" runat="server" Text='<%# Eval("Username") %>'></asp:Label>
                    <asp:TextBox ID ="txtUname" runat="server" Text='<%# Eval("Username") %>' Visible="false"></asp:TextBox>

                    <asp:Label ID="lblLname" runat="server" Text='<%# Eval("LastName") %>'></asp:Label>
                    <asp:TextBox ID ="txtLname" runat="server" Text='<%# Eval("LastName") %>' Visible="false"></asp:TextBox>

                    <asp:Label ID="lblOname" runat="server" Text='<%# Eval("OtherName") %>'></asp:Label>
                    <asp:TextBox ID ="txtOname" runat="server" Text='<%# Eval("OtherName") %>' Visible="false"></asp:TextBox>

                    <asp:Label ID="lblGender" runat="server" Text='<%# Eval("Gender") %>'></asp:Label>

                    <asp:Label ID="lblPhoneNum" runat="server" Text='<%# Eval("PhoneNum") %>'></asp:Label>
                    <asp:TextBox ID ="txtPhoneNum" runat="server" Text='<%# Eval("PhoneNum") %>' Visible="false"></asp:TextBox>

                    <asp:Label ID="lblUadd" runat="server" Text='<%# Eval("UAddress") %>'></asp:Label>
                    <asp:TextBox ID ="txtUadd" runat="server" Text='<%# Eval("UAddress") %>' Visible="false"></asp:TextBox>

                    <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("EmailAdd") %>'></asp:Label>
                    <asp:TextBox ID ="txtEmail" runat="server" Text='<%# Eval("EmailAdd") %>' Visible="false"></asp:TextBox>

                    <asp:Label ID="lblPass" runat="server" Text='<%# Eval("UserPassword") %>'></asp:Label>
                    <asp:TextBox ID ="txtPass" runat="server" Text='<%# Eval("UserPassword") %>' Visible="false"></asp:TextBox>
                </div>

                <div>
                    <asp:LinkButton ID="lbtnUpdate" runat="server">LinkButton</asp:LinkButton>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        
    </div>
</asp:Content>

