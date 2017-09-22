<%@ Page Title="" Language="VB" MasterPageFile="~/BSMasterPageHotel.master" AutoEventWireup="false" CodeFile="AddEditActivity.aspx.vb" Inherits="AddEditActivity" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <div class="form-horizontal">
            <h2>Activity</h2>
            <hr />

           <div class="form-group">
                <label class="col-md-2 control-label">Hotel Name</label>
                    <div class="col-md-3">
                        <asp:DropDownList ID="ddlHotelName" runat="server"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorHotelName" runat="server" 
                                ControlToValidate="ddlHotelName" ForeColor="Red" 
                                ErrorMessage="Please select a Hotel"></asp:RequiredFieldValidator>
                    </div>

            </div>

            <div class="form-group">
                <label class="col-md-2 control-label">Activity Name</label>
                    <div class="col-md-3">
                        <asp:TextBox ID="txtActivityName" class ="form-control" runat="server" placeholder="Activity Name"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorActivityName" runat="server" 
                            ControlToValidate="txtActivityName"
                            ForeColor="Red" ErrorMessage="Activity Name is required"></asp:RequiredFieldValidator>
                    </div>
            </div>

            <div class="form-group">
                <label class="col-md-2 control-label">Description</label>
                    <div class="col-md-3">
                        <asp:TextBox ID="txtDescri" TextMode="MultiLine" class="form-control" runat="server" placeholder="Description"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorDescription" runat="server" 
                            ControlToValidate="txtDescri"
                            ForeColor="Red" ErrorMessage="Description is required"></asp:RequiredFieldValidator>
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
                <label class="col-md-2 control-label">Activity Photo</label>
                    <div class="col-md-3">
                        <asp:FileUpload ID="FileUploadHotelActivityPhoto" runat="server" />
                        <asp:Label ID="lblStatus" runat="server"></asp:Label>
                    </div>
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

