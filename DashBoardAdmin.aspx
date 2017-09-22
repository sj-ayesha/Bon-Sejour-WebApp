<%@ Page Title="" Language="VB" MasterPageFile="~/BSMasterPageAdmin.master" AutoEventWireup="false" CodeFile="DashBoardAdmin.aspx.vb" Inherits="DefaultAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

                <div class="row">
                    <div class="col-lg-12">
                        <h1>Dashboard</h1>
                        
                        <hr />

                        <div class="row">
                            <div class="col-md-6">
                                <asp:ImageButton ID="imgbtnHotel" CssClass="thumbnail" Width="300px" Height="215px" ImageUrl="~/Images/hotel-icon.png" runat="server" />
                                <asp:LinkButton ID="lnkbtnHotel" runat="server">Hotel Management</asp:LinkButton>
                            </div>

                            <div class="col-md-6">
                                <asp:ImageButton ID="imgbtnUser" CssClass="thumbnail" Width="215px" Height="215px" ImageUrl="~/Images/user.png" runat="server" />
                                <asp:LinkButton ID="lnkbtnUser" runat="server">User Management</asp:LinkButton>
                            </div>
                    </div>
                </div>
            </div>

</asp:Content>

