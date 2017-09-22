<%@ Page Title="" Language="VB" MasterPageFile="~/BSMasterPageHotel.master" AutoEventWireup="false" CodeFile="ActivityManagementHotel.aspx.vb" Inherits="ActivityManagementHotel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
    <div class="form-horizontal">
        <h2>Activity Management</h2>

            <hr />

            <div style="margin: 10px">
                <asp:Button ID="btnAddActivity" runat="server" Text="Add Activity" OnClick="Insert"/>
            </div>

            <div>
                <asp:Repeater ID="RepeaterActivity" runat="server">
                    
                    <HeaderTemplate>
                        <div>
                            <table class="table-bordered table-hover">
                                <tr>
                                    <th>Hotel Name</th>
                                    <th>Activity Photo</th>
                                    <th>Activity Name</th>
                                    <th>Description</th>
                                    <th>Price</th>
                                    <th>Action</th>
                                </tr>
               
                    </HeaderTemplate>

                    <ItemTemplate>
                        
                        <tr> 
                            <td>
                                <asp:Label ID="lblHA_ID" runat="server" Text='<%# Eval("HA_ID") %>' Visible="false"></asp:Label>

                                <asp:Label ID="lblHotel_name" runat="server" Text='<%# Eval("Hotel_name") %>'></asp:Label>
                                <asp:TextBox ID="txtHotel_name" runat="server" Width="120" Text='<%#Eval("Hotel_name")%>' Visible="false"></asp:TextBox>
                            </td>

                            <td>
                                <img src="<%# "ActivityImages/" + Eval("A_Image") %>" height="100" width="100" />
                                <asp:Label ID="lblA_Image" runat="server" Text='<%#Eval("A_Image")%>' Visible="false"></asp:Label>
                            </td>

                            <td>
                                <asp:Label ID="lblA_Name" runat="server" Text='<%#Eval("A_Name")%>'></asp:Label>
                                <asp:TextBox ID="txtA_Name" runat="server" Width="120" Text='<%#Eval("A_Name")%>' Visible="false"></asp:TextBox>
                            </td>

                            <td>
                                <asp:Label ID="lblA_Descri" runat="server" Text='<%#Eval("A_Descri")%>'></asp:Label>
                                <asp:TextBox ID="txtA_Descri" runat="server" Width="120" Text='<%#Eval("A_Descri")%>' Visible="false"></asp:TextBox>
                            </td>

                            <td>
                                <asp:Label ID="lblA_Price" runat="server" Text='<%#Eval("A_Price")%>'></asp:Label>
                                <asp:TextBox ID="txtA_Price" runat="server" Width="120" Text='<%#Eval("A_Price")%>' Visible="false"></asp:TextBox>
                            </td>

                             <td>
                                <asp:LinkButton ID="lnkEdit" Text="Edit" runat="server" CommandName="EditCommand"
                                    CommandArgument='<%# Eval("HA_ID") %>'/>
                                <%--<asp:LinkButton ID="lnkDelete" Text="Delete" runat="server" OnClick="OnDelete"
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

