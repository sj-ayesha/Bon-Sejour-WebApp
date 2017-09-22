<%@ Page Title="" Language="VB" MasterPageFile="~/BSMasterPageHotel.master" AutoEventWireup="false" CodeFile="BookingManagement.aspx.vb" Inherits="BookingManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="container">
        <div class="form-horizontal">
            <h2>Booking Management</h2>

            <hr />

            <%--<div style="margin: 10px">
                <asp:Button ID="btnAdd" runat="server" Text="Add New Hotel" OnClick="Insert"/>
            </div>--%>

            <%--<div class="row" style="margin: 10px">
                <asp:Label ID="Filter" Text="Filter By Location" runat="server"></asp:Label>
                <asp:DropDownList ID="ddlHotelAdd" runat="server" OnSelectedIndexChanged="ddlHotelAdd_SelectedIndexChanged" 
                    AppendDataBoundItems="True" AutoPostBack="true">
                </asp:DropDownList>
            </div>--%>
            

            <div>
                <asp:Repeater ID="RepeaterBooking" runat="server">
                    
                    <HeaderTemplate>
                        <div>
                            <table class="table-bordered table-hover">
                                <tr>
                                    <th>Booking ID</th>
                                    <th>Hotel Name</th>
                                    <th>Check In</th>
                                    <th>Check Out</th>
                                    <th>Customer</th>
                                    <th>Room Type</th>
                                    <th>Payment</th>
                                    <th>Actions</th>
                                </tr>
               
                    </HeaderTemplate>

                    <ItemTemplate>
                        
                                <tr> 

                                    <td>
                                        
                                        <asp:Label ID="lblReservationID" runat="server" Text='<%# Eval("Reserv_ID") %>'></asp:Label>
                                        <asp:TextBox ID="txtReservID" runat="server" Width="120" Text='<%#Eval("Reserv_ID")%>' Visible="false"></asp:TextBox>
                                    </td>

                                     <td>

                                        <asp:Label ID="lblHotel_name" runat="server" Text='<%# Eval("Hotel_name") %>'></asp:Label>
                                        <asp:TextBox ID="txtHname" runat="server" Width="120" Text='<%#Eval("Hotel_name")%>' Visible="false"></asp:TextBox>
                                    </td>

                                    <td>
                                        <asp:Label ID="lblCheckIn" runat="server" Text='<%# Eval("Check_In")%>'></asp:Label>
                                        <asp:TextBox ID="txtCheckIn" runat="server" Width="120" Text='<%#Eval("Check_In")%>' Visible="false"></asp:TextBox>
                                    </td>

                                    <td>
                                        <asp:Label ID="lblCheckOut" runat="server" Text='<%#Eval("Check_Out")%>'></asp:Label>
                                        <asp:TextBox ID="txtCheckOut" runat="server" Width="120" Text='<%#Eval("Check_Out")%>' Visible="false"></asp:TextBox>
                                    </td>

                                    <td>
                                        <asp:Label ID="lblCustomer" runat="server" Text='<%#Eval("LastName") + " " + Eval("OtherName")%>'></asp:Label>
                                        <asp:TextBox ID="txtCustomer" runat="server" Width="120" Text='<%#Eval("LastName") + " " + Eval("OtherName")%>'> Visible="false"></asp:TextBox>
                                    </td>

                                    <td>
                                        <asp:Label ID="lblTypeRoom" runat="server" Text='<%# Eval("TypeRoom")%>'></asp:Label>
                                        <asp:TextBox ID="txtTypeRoom" runat="server" Width="120" Text='<%#Eval("TypeRoom")%>' Visible="false"></asp:TextBox>
                                    </td>

                                    <td>
                                        <asp:Label ID="lblPayment" runat="server" Text='<%#Eval("Payment")%>'></asp:Label>
                                        <asp:TextBox ID="txtPayment" runat="server" Width="120" Text='<%#Eval("Payment")%>' Visible="false"></asp:TextBox>
                                    </td>

                                    <%--<td>
                                        <asp:LinkButton ID="lnkEdit" Text="Edit" runat="server" CommandName="EditCommand"
                                             CommandArgument='<%# Eval("Hotel_ID") %>'/>
                                        <asp:LinkButton ID="lnkDelete" Text="Delete" runat="server" OnClick="OnDelete"
                                                OnClientClick="return confirm('Do you want to delete this row?');" />
                                   </td>--%>
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

