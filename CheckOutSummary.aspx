<%@ Page Title="" Language="VB" MasterPageFile="~/BSMasterPageClient.master" AutoEventWireup="false" CodeFile="CheckOutSummary.aspx.vb" Inherits="CheckOutSummary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <h2>Summary Booking</h2>

        <hr />
        <div>

        <asp:Repeater ID="RepeaterCart" runat="server">

             <HeaderTemplate>
                        <div class="table-responsive">
                            <table class="table table-hover">
                                <tr>
                                    <th></th>
                                    <th>Hotel Name</th>
                                    <th>Room Type</th>
                                    <th>Check In</th>
                                    <th>Check Out</th>
                                    <th>Number of Person</th>
                                    <th>Price</th>
                                    <th>Action</th>
                                </tr>
               
                    </HeaderTemplate>
                    <ItemTemplate>
                        
                                <tr> 
                                    <td>

                                        <asp:Label ID="lblCID" runat="server" Text='<%#Eval("Id")%>' Visible="false"></asp:Label>

                                    </td>

                                    <td>
                                        <asp:Label ID="lblHotelID" runat="server" Text='<%# Eval("Hotel_ID") %>' Visible="false"></asp:Label>
                                        <asp:Label ID="lblHotel_name" runat="server" Text='<%# Eval("Hotel_name") %>'></asp:Label>
                                    </td>

                                    <td>
                                        <asp:Label ID="lblRoomTypeID" runat="server" Text='<%# Eval("roomType_ID") %>' Visible="false"></asp:Label>
                                        <asp:Label ID="lblTypeRoom" runat="server" Text='<%# Eval("TypeRoom")%>'></asp:Label>
                                    </td>

                                    <td>
                                        <asp:Label ID="lblCIn" runat="server" Text='<%#Eval("CIn")%>'></asp:Label>
                                    </td>

                                    <td>
                                        <asp:Label ID="lblCOut" runat="server" Text='<%#Eval("COut")%>'></asp:Label>
                                    </td>

                                    <td>
                                        <asp:Label ID="lblNumP" runat="server" Text='<%#Eval("NumP")%>'></asp:Label>
                                    </td>

                                    <td>
                                        <asp:Label ID="lblPrice" runat="server" Text='<%#Eval("Price")%>'></asp:Label>
                                    </td>

                                    <td>
                                        <asp:LinkButton ID="lnkDelete" Text="Delete" runat="server" OnClick="lnkDelete_Click"
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

        <div style="margin:10px; float:right">

            <asp:Button ID="btnContinue" Text="Continue Booking" runat="server" OnClick="btnContinue_Click" />
            <asp:Button ID="btnCheckOut" Text="Check Out" runat="server" OnClick="btnCheckOut_Click" />
        </div>
    </div>
</asp:Content>

