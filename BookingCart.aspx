<%@ Page Title="" Language="VB" MasterPageFile="~/BSMasterPageClient.master" AutoEventWireup="false" CodeFile="BookingCart.aspx.vb" Inherits="BookingCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <h2>Room Booking</h2>
        <hr />

        <div class="row">
            <p>Select Room: 
                <asp:DropDownList ID="Rooms" runat="server" DataSourceID="RoomsData" DataTextField="TypeRoom" 
                    DataValueField="roomType_ID" AutoPostBack="true">
                </asp:DropDownList>

                <asp:SqlDataSource ID="RoomsData" runat="server" ConnectionString="<%$ ConnectionStrings: ConnectionStringLocal %>" 
                    SelectCommand="SELECT roomType_ID, TypeRoom FROM RoomTypeTable">
                </asp:SqlDataSource>
            </p>


        </div>
    </div>
</asp:Content>

