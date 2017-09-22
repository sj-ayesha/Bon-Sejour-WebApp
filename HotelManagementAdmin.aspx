<%@ Page Title="" Language="VB" MasterPageFile="~/BSMasterPageAdmin.master" AutoEventWireup="false" CodeFile="HotelManagementAdmin.aspx.vb" Inherits="HotelManagementAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <div class="form-horizontal">
            <h2>Hotel Management</h2>

            <hr />

            <div style="margin: 10px">
                <asp:Button ID="btnAdd" CssClass="btn btn-info" runat="server" Text="Add New Hotel" OnClick="Insert"/>
            </div>

            <div class="row" style="margin: 10px">
                <asp:Label ID="Filter" Text="Filter By Location" runat="server"></asp:Label>
                <asp:DropDownList ID="ddlHotelAdd" runat="server" OnSelectedIndexChanged="ddlHotelAdd_SelectedIndexChanged" 
                    AppendDataBoundItems="True" AutoPostBack="true">
                </asp:DropDownList>
            </div>
            

            <div>
                <asp:Repeater ID="Repeater1" runat="server">
                    
                    <HeaderTemplate>
                        <div class="table-responsive">
                            <table class="table table-hover table-bordered">
                                <tr>
                                    <th>Photo</th>
                                    <th>Hotel Name</th>
                                    <th>Description</th>
                                    <th>Address</th>
                                    <th>Actions</th>
                                </tr>
               
                    </HeaderTemplate>
                    <ItemTemplate>
                        
                                <tr> 
                                    <td>
                                        <img src="<%# "UploadImages/" + Eval("H_Image") %>" height="100" width="100" />
                                        <asp:Label ID="lblHotel_ID" runat="server" Text='<%#Eval("Hotel_ID")%>' Visible="false"></asp:Label>
                                    </td>
                        

                                    <td>
                                        
                                        <asp:Label ID="lblHotel_name" runat="server" Text='<%# Eval("Hotel_name") %>'></asp:Label>
                                        <asp:TextBox ID="txtHname" runat="server" Width="120" Text='<%#Eval("Hotel_name")%>' Visible="false"></asp:TextBox>
                                    </td>

                                    <td>
                                        <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("Hotel_Descri")%>'></asp:Label>
                                        <asp:TextBox ID="txtDescrip" runat="server" Width="120" Text='<%#Eval("Hotel_Descri")%>' Visible="false"></asp:TextBox>
                                    </td>

                                    <td>
                                        <asp:Label ID="lblAddress" runat="server" Text='<%#Eval("Hotel_Add")%>'></asp:Label>
                                        <asp:TextBox ID="txtAddress" runat="server" Width="120" Text='<%#Eval("Hotel_Add")%>' Visible="false"></asp:TextBox>
                                    </td>

                                    <td>
                                        <asp:LinkButton ID="lnkEdit" Text="Edit" runat="server" CommandName="EditCommand"
                                             CommandArgument='<%# Eval("Hotel_ID") %>'/>
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
    </div>
</asp:Content>

