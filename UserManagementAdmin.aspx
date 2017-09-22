<%@ Page Title="" Language="VB" MasterPageFile="~/BSMasterPageAdmin.master" AutoEventWireup="false" CodeFile="UserManagementAdmin.aspx.vb" Inherits="UserManagementAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
            <h2>User Management</h2>

            <hr />

            <div style="margin: 10px">
                <asp:Button ID="btnAddUser" runat="server" Text="Add User" OnClick="Insert"/>
            </div>

            <div class="row" style="margin:10px">
                <asp:Label ID="FilterUser" Text="Filter By: " runat="server"></asp:Label>
                
                <asp:Label ID="lblUsername" Text="Username: " runat="server"></asp:Label>
                <asp:TextBox ID="txtUsername"  runat="server" placeholder="Username" AutoPostBack="true" OnTextChanged="txtUsername_TextChanged"></asp:TextBox>

                <asp:Label ID="lblType" Text="Type: " runat="server"></asp:Label>
                <asp:DropDownList ID="ddlType" runat="server" OnSelectedIndexChanged="ddlType_SelectedIndexChanged"
                    AppendDataBoundItems="true" AutoPostBack="true">
                </asp:DropDownList>
            </div>

            <div>
                <asp:Repeater ID="RepeaterUser" runat="server">
                    
                    <HeaderTemplate>
                        <div class="table-responsive">
                            <table class="table table-bordered table-hover table-striped">
                                <tr>
                                    <th>Title</th>
                                    <th>Last Name</th>
                                    <th>Other Name</th>
                                    <th>Gender</th>
                                    <th>Phone Number</th>
                                    <th>Address</th>
                                    <th>Email Address</th>
                                    <th>Username</th>
                                    <th>Type of User</th>
                                    <th>Status</th>
                                    <th>Actions</th>
                                </tr>
               
                    </HeaderTemplate>

                    <ItemTemplate>
                        
                                <tr> 
                                    <td>
                                        <asp:Label ID="lblUserID" runat="server" Text='<%# Eval("UserID") %>' Visible="false"></asp:Label>

                                        <asp:Label ID="lblTitle" runat="server" Text='<%# Eval("Title") %>'></asp:Label>
                                        <asp:TextBox ID="txtTitle" runat="server" Width="120" Text='<%#Eval("Title")%>' Visible="false"></asp:TextBox>
                                    </td>

                                    <td>
                                        <asp:Label ID="lblLname" runat="server" Text='<%# Eval("LastName")%>'></asp:Label>
                                        <asp:TextBox ID="txtLname" runat="server" Width="120" Text='<%#Eval("LastName")%>' Visible="false"></asp:TextBox>
                                    </td>

                                    <td>
                                        <asp:Label ID="lblOname" runat="server" Text='<%#Eval("OtherName")%>'></asp:Label>
                                        <asp:TextBox ID="txtOname" runat="server" Width="120" Text='<%#Eval("OtherName")%>' Visible="false"></asp:TextBox>
                                    </td>

                                    <td>
                                        <asp:Label ID="lblGender" runat="server" Text='<%#Eval("Gender")%>'></asp:Label>
                                        <asp:TextBox ID="txtGender" runat="server" Width="120" Text='<%#Eval("Gender")%>' Visible="false"></asp:TextBox>
                                    </td>

                                    <td>
                                        <asp:Label ID="lblPhoneNum" runat="server" Text='<%#Eval("PhoneNum")%>'></asp:Label>
                                        <asp:TextBox ID="txtPhoneNum" runat="server" Width="120" Text='<%#Eval("PhoneNum")%>' Visible="false"></asp:TextBox>
                                    </td>

                                    <td>
                                        <asp:Label ID="lblAddress" runat="server" Text='<%#Eval("UAddress")%>'></asp:Label>
                                        <asp:TextBox ID="txtAddress" runat="server" Width="120" Text='<%#Eval("UAddress")%>' Visible="false"></asp:TextBox>
                                    </td>

                                    <td>
                                        <asp:Label ID="lblEmailAdd" runat="server" Text='<%#Eval("EmailAdd")%>'></asp:Label>
                                        <asp:TextBox ID="txtEmail" runat="server" Width="120" Text='<%#Eval("EmailAdd")%>' Visible="false"></asp:TextBox>
                                    </td>

                                    <td>
                                        <asp:Label ID="lblUname" runat="server" Text='<%#Eval("Username")%>'></asp:Label>
                                        <asp:TextBox ID="txtUname" runat="server" Width="120" Text='<%#Eval("Username")%>' Visible="false"></asp:TextBox>
                                    </td>

                                    <td>
                                        <asp:Label ID="lblType" runat="server" Text='<%#Eval("TypeUser")%>'></asp:Label>
                                        <asp:TextBox ID="txtType" runat="server" Width="120" Text='<%#Eval("TypeUser")%>' Visible="false"></asp:TextBox>
                                    </td>

                                    <td>
                                        <asp:Label ID="lblstatus" runat="server" Text='<%#Eval("Ustatus")%>'></asp:Label>
                                        <asp:TextBox ID="txtstatus" runat="server" Width="120" Text='<%#Eval("Ustatus")%>' Visible="false"></asp:TextBox>
                                    </td>


                                    <td>
                                        <asp:LinkButton ID="lnkEdit" Text="Edit" runat="server" CommandName="EditCommand"
                                             CommandArgument='<%# Eval("UserID") %>'/>
                                        <asp:LinkButton ID="lnkDelete" Text="Delete" runat="server" OnClick="OnDelete"
                                                OnClientClick="return confirm('Do you want to delete this row?');" />
                                   </td>
                                </tr>
                    </ItemTemplate>

                    <FooterTemplate>
                         </table>
                        </div>
                    </FooterTemplate>
                    
                </asp:Repeater>
            </div>
    </div>
</asp:Content>

