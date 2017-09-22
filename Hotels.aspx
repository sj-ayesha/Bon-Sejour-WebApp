<%@ Page Title="" Language="VB" MasterPageFile="~/BSMasterPageClient.master" AutoEventWireup="false" CodeFile="Hotels.aspx.vb" Inherits="Hotels" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="css/sarah.css" rel="stylesheet" />
    <div class="container">
        <h2 class="text-center">Hotels</h2>

        <hr />
        
        <div class="cd-gallery">
            <ul class="grid">
            <asp:ListView ID="listviewHotel" runat="server" RepeatColumns ="3" RepeatDirection="Horizontal">

                <ItemTemplate>

                    <li>
                        <asp:LinkButton ID="HotelCommand" Text="" runat="server" CommandName="HotelNameCommand" CommandArgument='<%# Eval("Hotel_ID") %>'>
                        <figure class="effect-sarah">
                    <asp:Image ID="HImage" ImageUrl='<%# Bind("H_Image", "~/UploadImages/{0}") %>' Width="300px" Height="215px" runat="server" />
                    
                    <figcaption>
                        <h2><span>
                            <asp:Label ID="HotelName" Text='<%# Bind("Hotel_name") %>' runat="server"></asp:Label>
                            <%--<asp:LinkButton ID="HotelName" Text='<%# Bind("Hotel_name") %>' runat="server" CommandName="HotelNameCommand" CommandArgument='<%# Eval("Hotel_ID") %>'></asp:LinkButton>--%>
                        </span></h2>
                        <p><asp:Label ID="HotelDescri" Text='<%# Bind("Hotel_Descri") %>' runat="server"></asp:Label></p>
                    </figcaption>
                        
                    <%--<asp:HyperLink ID="HotelName" Text='<%# Bind("Hotel_name") %>' NavigateUrl='<%#Bind ("Hotel_name" , "~/UploadImages/{0}") %>' runat="server"></asp:HyperLink>--%>
                        </figure>
                            </asp:LinkButton>
                    </li>
                </ItemTemplate>
            </asp:ListView>
            </ul>
        </div>
    </div>
</asp:Content>

