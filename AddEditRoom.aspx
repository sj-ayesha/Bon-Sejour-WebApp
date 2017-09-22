<%@ Page Title="" Language="VB" MasterPageFile="~/BSMasterPageHotel.master" AutoEventWireup="false" CodeFile="AddEditRoom.aspx.vb" Inherits="AddEditRoom" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <div class="form-horizontal">
            <h2>Add Room</h2>
            <hr />


            <div class="form-group">
                <label class="col-md-2 control-label">Hotel Name</label>
                    <div class="col-md-3">
                        <asp:DropDownList ID="ddlHotelName" runat="server" AppendDataBoundItems="True" AutoPostBack="true" >
                            <asp:ListItem Text="--Select Hotel--" Value=""></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorHotelName" runat="server" 
                                ControlToValidate="ddlHotelName" ForeColor="Red" 
                                ErrorMessage="Please select a Hotel"></asp:RequiredFieldValidator>
                    </div>

            </div>

            <div class="form-group">
                <label class="col-md-2 control-label">Type</label>
                    <div class="col-md-3">
                        <asp:DropDownList ID="ddlTypeRoom" class="form-control" runat="server">
                            <asp:ListItem Text="Select Type Room" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="Deluxe" Value="Deluxe"></asp:ListItem>
                            <asp:ListItem Text="Single" Value="Single"></asp:ListItem>
                            <asp:ListItem Text="Double" Value="Double"></asp:ListItem>
                            <asp:ListItem Text="Interconnecting" Value="Interconnecting"></asp:ListItem>
                            <asp:ListItem Text="Duplex" Value="Duplex"></asp:ListItem>
                            <asp:ListItem Text="Studio" Value="Studio"></asp:ListItem>
                            <asp:ListItem Text="Suite" Value="Suite"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorTypeRoom" runat="server" 
                                ControlToValidate="ddlTypeRoom" ForeColor="Red" InitialValue="-1" 
                                ErrorMessage="Please select Type of Room"></asp:RequiredFieldValidator>
                    </div>
            </div>

            <div class="form-group">
                <label class="col-md-2 control-label">Number of Room (this type)</label>
                    <div class="col-md-3">
                         <asp:TextBox ID="numRoom" class="form-control" runat="server" placeholder="Number of Room"></asp:TextBox>
                           <asp:RequiredFieldValidator ID="RequiredFieldValidatornumRoom" runat="server" 
                                ControlToValidate="numRoom"
                                ForeColor="Red" ErrorMessage="Number of room is required"></asp:RequiredFieldValidator>
                    </div>
            </div>

            <div class="form-group">
                <label class="col-md-2 control-label">Price</label>
                    <div class="col-md-3">
                         <asp:TextBox ID="txtPrice" class="form-control" runat="server" placeholder="Price"></asp:TextBox>
                           <asp:RegularExpressionValidator ID="RegularExpressionValidatorPrice" runat="server" 
                                ErrorMessage="Invalid Price" ControlToValidate="txtPrice" ForeColor="Red" 
                                ValidationExpression="^[0-9]+(\.[0-9]{2})?$"></asp:RegularExpressionValidator>
                    </div>        
            </div>

            <div class="form-group">
                <label class="col-md-2 control-label"></label>
                    <%--<div class="col-md-3">--%>
                         <fieldset>
                             <legend>Images</legend>
                             <asp:Label ID="lbltest" runat="server"></asp:Label>
                                <div class="col-md-3">
                                    Image Icon:
                                    <asp:FileUpload AllowMultiple="true" ID="FileUploadRoomImgIcon" runat="server" />
                                    <asp:Label ID="lblStatus" runat="server"></asp:Label>
                                    <br />

                                    <%--Image 1:
                                    <asp:FileUpload ID="FileUploadRoomImg1" runat="server" />
                                    <asp:Label ID="lblStatus1" runat="server"></asp:Label>
                                    <br />

                                    Image 2:
                                    <asp:FileUpload ID="FileUploadRoomImg2" runat="server" />
                                    <asp:Label ID="lblStatus2" runat="server"></asp:Label>
                                    <br />

                                    Image 3:
                                    <asp:FileUpload ID="FileUploadRoomImg3" runat="server" />
                                    <asp:Label ID="lblStatus3" runat="server"></asp:Label>--%>
                                </div>
                         </fieldset>
                    <%--</div> --%>       
            </div>

            <div class="form-group">
                    <div class="col-md-2"></div>
                    <div class="col-md-6">
                        <asp:Button ID="btnAdd" runat="server" Text="Add" class ="btn btn-success" />
                        <asp:Button ID="btnCancel" runat="server" class="btn btn-warning" Text="Cancel" />
                    </div>
            </div>

            <div class="col-md-6">
                <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
            </div>

        </div>
    </div>
</asp:Content>

