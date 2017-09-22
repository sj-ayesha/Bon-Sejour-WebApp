<%@ Page Title="" Language="VB" MasterPageFile="~/BSMasterPageClient.master" AutoEventWireup="false" CodeFile="Room.aspx.vb" Inherits="Room" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="css/sarah.css" rel="stylesheet" />
    <div class="container">
        <h2 class="text-center">Room</h2>

        <hr />

        <div class="cd-gallery">
            <ul class="grid">
            <asp:ListView ID="listviewRoom" runat="server" RepeatColumns ="3" RepeatDirection="Horizontal">

                <ItemTemplate>

                    <li>
                        <figure class="effect-sarah">
                        <asp:Image ID="RoomImg" runat="server" ImageUrl='<%# Bind("Images", "~/RoomImages/{0}") %>' Width="300px" Height="215px" />

                        <figcaption>
                            <h2><span>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("TypeRoom") %>'></asp:Label>

                                </span></h2>
                            
                        <p> Price:
                            <asp:Label ID="lblPrice" runat="server" Text='<%# Bind("Price") %>'></asp:Label>
                        </p>
                        <asp:Button ID="Book" runat="server" Text="Book Now"  CommandName="BookCommand" CommandArgument='<%# Convert.ToString(Eval("Hotel_ID")) + "," + Convert.ToString(Eval("roomType_ID"))%>'/>

                        </figcaption>

                            </figure>
                    </li>

                </ItemTemplate>

            </asp:ListView>
                </ul>
        </div>
        <div>
            <asp:Label ID="ErrorMsg" Text="" runat="server" CssClass="alert-danger"></asp:Label>
        </div>
    </div>
</asp:Content>

