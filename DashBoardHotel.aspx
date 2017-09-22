<%@ Page Title="" Language="VB" MasterPageFile="~/BSMasterPageHotel.master" AutoEventWireup="false" CodeFile="DashBoardHotel.aspx.vb" Inherits="DashBoardHotel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
                <div class="row">
                    <div class="col-lg-12">
                        <h1>Dashboard</h1>
                        
                        <hr />

                        <div class="row">
                            <div class="col-md-6">
                                <asp:ImageButton ID="imgbtnRoom" CssClass="thumbnail" Width="300px" Height="300px" ImageUrl="~/Images/bed_icon.png" runat="server" />
                                <asp:LinkButton ID="lnkbtnRoom" runat="server">Room Management</asp:LinkButton>
                            </div>

                            <div class="col-md-6">
                                <asp:ImageButton ID="imgbtnBooking" CssClass="thumbnail" Width="300px" Height="300px" ImageUrl="~/Images/booking.png" runat="server" />
                                <asp:LinkButton ID="lnkbtnBooking" runat="server">Booking Management</asp:LinkButton>
                            </div>
                    </div>
                </div>
            </div>
</asp:Content>

