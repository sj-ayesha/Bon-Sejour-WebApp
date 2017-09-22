<%@ Page Title="" Language="VB" MasterPageFile="~/BSMasterPageHotel.master" AutoEventWireup="false" CodeFile="RoomManagementHotel.aspx.vb" Inherits="RoomManagementHotel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <div class="form-horizontal">
            <h2>Room Management</h2>

            <hr />

            <div style="margin: 10px">
                <asp:Button ID="btnAddRoom" runat="server" Text="Add Room" OnClick="Insert"/>
            </div>

            <%--<div class="row" style="margin: 10px">
                <asp:Label ID="FilterHotel" Text="Hotel" runat="server"></asp:Label>
                <asp:DropDownList ID="ddlHotelAdd" runat="server" OnSelectedIndexChanged="ddlHotelAdd_SelectedIndexChanged" 
                    AppendDataBoundItems="True" AutoPostBack="true">
                </asp:DropDownList>
            </div>
            
            <div class="row" style="margin: 10px">
                <asp:Label ID="FilterTypeRoom" Text="Type Room" runat="server"></asp:Label>
                <asp:DropDownList ID="ddlTypeRoom" runat="server" OnSelectedIndexChanged="ddlTypeRoom_SelectedIndexChanged" 
                    AppendDataBoundItems="True" AutoPostBack="true">
                </asp:DropDownList>
            </div>--%>

            <div>
                <asp:Repeater ID="RepeaterRoom" runat="server">
                    
                    <HeaderTemplate>
                        <div class="table-responsive">
                            <table class="table table-bordered table-hover">
                                <tr>
                                    <th>Hotel</th>
                                    <th>Image</th>
                                    <th>Type Room</th>
                                    <th>Number of Rooms</th>
                                    <th>Price</th>
                                    <th>Action</th>
                                </tr>
               
                    </HeaderTemplate>
                    <ItemTemplate>
                        
                                <tr> 
                                     <td>

                                        <asp:Label ID="lblHotel_name" runat="server" Text='<%# Eval("Hotel_name") %>'></asp:Label>
                                        <asp:TextBox ID="txtHname" runat="server" Width="120" Text='<%#Eval("Hotel_name")%>' Visible="false"></asp:TextBox>
                                    </td>

                                    <td>
                                        <img src="<%# "RoomImages/" + Eval("Images") %>" height="100" width="100" />
                                        <asp:Label ID="lblImages" runat="server" Text='<%#Eval("Images")%>' Visible="false"></asp:Label>
                                    </td>

                                    <td>
                                        <asp:Label ID="lblTypeRoom" runat="server" Text='<%# Eval("TypeRoom")%>'></asp:Label>
                                        <asp:TextBox ID="txtTypeRoom" runat="server" Width="120" Text='<%#Eval("TypeRoom")%>' Visible="false"></asp:TextBox>
                                    </td>

                                    <td>
                                        <asp:Label ID="lblNumRoom" runat="server" Text='<%#Eval("NumRoom")%>'></asp:Label>
                                        <asp:TextBox ID="txtNumRoom" runat="server" Width="120" Text='<%#Eval("NumRoom")%>' Visible="false"></asp:TextBox>
                                    </td>

                                     <td>
                                        <asp:Label ID="lblPrice" runat="server" Text='<%#Eval("Price")%>'></asp:Label>
                                        <asp:TextBox ID="txtPrice" runat="server" Width="120" Text='<%#Eval("Price")%>' Visible="false"></asp:TextBox>
                                    </td>

                                    <td>
                                        <asp:LinkButton ID="lnkEdit" Text="Edit" runat="server" CommandName="EditCommand"
                                             CommandArgument='<%# Eval("room_ID") %>'/>
                                       <%-- <asp:LinkButton ID="lnkDelete" Text="Delete" runat="server" OnClick="OnDelete"
                                                OnClientClick="return confirm('Do you want to delete this row?');" />--%>
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

