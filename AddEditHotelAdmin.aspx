<%@ Page Title="" Language="VB" MasterPageFile="~/BSMasterPageAdmin.master" AutoEventWireup="false" CodeFile="AddEditHotelAdmin.aspx.vb" Inherits="AddHotelAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="container">
        <div class="form-horizontal">
            <h2>Hotel</h2>
            <hr />

            <div class="form-group">
                <label class="col-md-2 control-label">Hotel Name</label>
                    <div class="col-md-3">
                        <asp:TextBox ID="Hname" class="form-control" runat="server" placeholder="Hotel Name"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorHotelname" runat="server" 
                            ControlToValidate="Hname"
                            ForeColor="Red" ErrorMessage="Hotel name is required"></asp:RequiredFieldValidator>
                    </div>
            </div>

            <div class="form-group">
                <label class="col-md-2 control-label">Description</label>
                    <div class="col-md-3">
                        <asp:TextBox ID="txtDescri" TextMode ="multiline" class ="form-control" runat="server" placeholder="Description"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorDescri" runat="server" 
                            ControlToValidate="txtDescri"
                            ForeColor="Red" ErrorMessage="Description is required"></asp:RequiredFieldValidator>
                    </div>
            </div>

            <div class="form-group">
                <label class="col-md-2 control-label">Address</label>
                    <div class="col-md-3">
                        <asp:TextBox ID="txtAdd" class="form-control" runat="server" placeholder="Address"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorAddress" runat="server" 
                            ControlToValidate="txtAdd"
                            ForeColor="Red" ErrorMessage="Address is required"></asp:RequiredFieldValidator>
                    </div>
            </div>

            <div class="form-group">
                <label class="col-md-2 control-label">Image</label>
                    <div class="col-md-3">
                        <asp:FileUpload ID="FileUploadHotelImage" runat="server" />
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

