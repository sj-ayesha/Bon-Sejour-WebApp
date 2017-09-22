<%@ Page Title="" Language="VB" MasterPageFile="~/BSMasterPageClient.master" AutoEventWireup="false" CodeFile="Booking.aspx.vb" Inherits="Booking" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <div class="form-horizontal">
            <h2 class="text-center">Reservation</h2>
            <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
            </asp:ToolkitScriptManager>
            <hr />
        
            <div class="form-group">
                <div class="form-group">
                <label class="col-md-2 control-label">Hotel Name</label>
                    <div class="col-md-3">
                        <asp:DropDownList ID="ddlHotelName" class="form-control" runat="server" AutoPostBack="true" AppendDataBoundItems="True" OnSelectedIndexChanged="ddlHotelName_SelectedIndexChanged" >
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorHotelName" runat="server" 
                                ControlToValidate="ddlHotelName" ForeColor="Red" 
                                ErrorMessage="Please select a Hotel"></asp:RequiredFieldValidator>
                    </div>

                </div>
            </div>

            <div class="form-group">
                <label class="col-md-2 control-label">Type</label>
                    <div class="col-md-3">
                        <asp:DropDownList ID="ddlTypeRoom" class="form-control" runat="server" AutoPostBack="true" Enabled="false" OnSelectedIndexChanged="Price_SelectedIndexChanged">
                            <asp:ListItem Text="--Select a Room Type--" Value=""></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorTypeRoom" runat="server" 
                                ControlToValidate="ddlTypeRoom" ForeColor="Red" InitialValue="-1" 
                                ErrorMessage="Please select Type of Room"></asp:RequiredFieldValidator>
                    </div>
            </div>


            <div class="form-group">
                <label class="col-md-2 control-label">Check In</label>
                    <div class="col-md-3">
                        <asp:TextBox ID="txtCheckIn" class="form-control" runat="server" placeholder="Check In"></asp:TextBox>
                        <asp:ImageButton ID="ImageButtonCalender" runat="server" Height="25px" ImageUrl="~/calender.png" Width="25px" />
                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" 
                            PopupButtonID="ImageButtonCalender" PopupPosition="Right" TargetControlID="txtCheckIn"></asp:CalendarExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorCheckIn" runat="server" 
                                ControlToValidate="txtCheckIn"
                                ForeColor="Red" ErrorMessage="Check In Date is required"></asp:RequiredFieldValidator>
                    </div>
            </div>

        
           <div class="form-group">
                <label class="col-md-2 control-label">Check Out</label>
                    <div class="col-md-3">
                        <asp:TextBox ID="txtCheckOut" class="form-control" runat="server" placeholder="Check Out"></asp:TextBox>
                        <asp:ImageButton ID="ImageButtonCheckOut" runat="server" Height="25px" ImageUrl="~/calender.png" Width="25px" />
                        <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="yyyy-MM-dd" 
                            PopupButtonID="ImageButtonCheckOut" PopupPosition="Right" TargetControlID="txtCheckOut"></asp:CalendarExtender>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorCheckOut" runat="server" 
                                ControlToValidate="txtCheckOut"
                                ForeColor="Red" ErrorMessage="Check Out Date is required"></asp:RequiredFieldValidator>

                    </div>
            </div>
   

            <div class="form-group">
                <label class="col-md-2 control-label">Number of Persons</label>
                    <div class="col-md-3">
                         <asp:TextBox ID="txtNumP" class="form-control" runat="server" placeholder="Number of Persons" Text="1"></asp:TextBox>
                           <asp:RequiredFieldValidator ID="RequiredFieldValidatorNumP" runat="server" 
                                ControlToValidate="txtNumP"
                                ForeColor="Red" ErrorMessage="Number of Persons is required"></asp:RequiredFieldValidator>
                    </div>
            </div>

            <div class="form-group">
                <label class="col-md-2 control-label">Price</label>
                    <div class="col-md-4">
                         <asp:TextBox ID="txtPrice" class="form-control" runat="server" placeholder="Price" Enabled="false"></asp:TextBox>
                         <asp:Button ID="btnEvaluatePrice" runat="server" Text="Evaluate Price" CssClass="btn btn-default" />
                    </div>
            </div>
        
            <div class="form-group">
                    <div class="col-md-2"></div>
                    <div class="col-md-6 space-vert">
                        <asp:Button ID="btnReserve" runat="server" Text="Reserve" CssClass="btn btn-success" />
                    </div>
            </div>

            <div class="col-md-6">
                <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                <asp:Label ID="lbltest" runat="server" Text=""></asp:Label>
            </div>
    </div>
</div>
</asp:Content>

