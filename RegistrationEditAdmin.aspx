<%@ Page Title="" Language="VB" MasterPageFile="~/BSMasterPageAdmin.master" AutoEventWireup="false" CodeFile="RegistrationEditAdmin.aspx.vb" Inherits="RegistrationAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <div class="form-horizontal">
            <h2>Register</h2>
            <hr />
        
            <div class="form-group">
                <label class="col-md-2 control-label">Title</label>
                    <div class="col-md-3">
                        <asp:DropDownList ID="ddlTitle" class="form-control" runat="server">
                            <asp:ListItem Text="Select Title" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="Mr" Value="Mr"></asp:ListItem>
                            <asp:ListItem Text="Mrs" Value="Mrs"></asp:ListItem>
                            <asp:ListItem Text="Miss" Value="Miss"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorTitle" runat="server" 
                                ControlToValidate="ddlTitle" ForeColor="Red" InitialValue="-1" 
                                ErrorMessage="Please select a Title"></asp:RequiredFieldValidator>
                    </div>
            </div>

            <div class="form-group">
                <label class="col-md-2 control-label">Last Name</label>
                    <div class="col-md-3">
                         <asp:TextBox ID="Lname" class="form-control" runat="server" placeholder="Last Name"></asp:TextBox>
                           <asp:RequiredFieldValidator ID="RequiredFieldValidatorLastName" runat="server" 
                                ControlToValidate="Lname"
                                ForeColor="Red" ErrorMessage="Last name is required"></asp:RequiredFieldValidator>
                    </div>
            </div>


        
            <div class="form-group">
                <label class="col-md-2 control-label">Other Name</label>
                    <div class="col-md-3">
                         <asp:TextBox ID="txtOname" class="form-control" runat="server" placeholder="Other Name"></asp:TextBox>
                           <asp:RequiredFieldValidator ID="RequiredFieldValidatorOname" runat="server" 
                                ControlToValidate="txtOname"
                                ForeColor="Red" ErrorMessage="Other name is required"></asp:RequiredFieldValidator>
                    </div>
            </div>

            <div class="form-group">
                <label class="col-md-2 control-label">Gender</label>
                    <div class="col-md-3">
                        <asp:RadioButtonList id="Gender" runat="server">
                            <asp:ListItem >Male</asp:ListItem>
                            <asp:ListItem>Female</asp:ListItem>
                        </asp:RadioButtonList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorGender" runat="server" 
                            ControlToValidate="Gender" ForeColor="Red" ErrorMessage="Select a Gender" 
                            Display="Dynamic">
                        </asp:RequiredFieldValidator>
                    </div>
            </div>

            <div class="form-group">
                <label class="col-md-2 control-label">Address</label>
                    <div class="col-md-3">
                         <asp:TextBox ID="Add" class="form-control" runat="server" placeholder="Address"></asp:TextBox>
                           <asp:RequiredFieldValidator ID="RequiredFieldValidatorAddress" runat="server" 
                                ControlToValidate="Add"
                                ForeColor="Red" ErrorMessage="Address is required"></asp:RequiredFieldValidator>
                    </div>
            </div>

            <div class="form-group">
                <label class="col-md-2 control-label">Phone Number</label>
                    <div class="col-md-3">
                         <asp:TextBox ID="txtPhone" class="form-control" runat="server" placeholder="Phone Number"></asp:TextBox>
                           <asp:RequiredFieldValidator ID="RequiredFieldValidatorPhone" runat="server" 
                                ControlToValidate="txtPhone"
                                ForeColor="Red" ErrorMessage="Phone Number is required"></asp:RequiredFieldValidator>
                    </div>
            </div>

       
            <div class="form-group">
                <label class="col-md-2 control-label">Email Address</label>
                    <div class="col-md-3">
                         <asp:TextBox ID="eAdd" class="form-control" runat="server" placeholder="Email Address"></asp:TextBox>
                          <asp:RegularExpressionValidator ID="RegularExpressionValidatorEmail" runat="server" 
                                ErrorMessage="Invalid Email" ControlToValidate="eAdd" ForeColor="Red" 
                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </div>
            </div>

            <div class="form-group">
                <label class="col-md-2 control-label">Username</label>
                    <div class="col-md-3">
                         <asp:TextBox ID="txtUsername" class="form-control" runat="server" placeholder="Username"></asp:TextBox>
                           <asp:RequiredFieldValidator ID="RequiredFieldValidatorUsername" runat="server" 
                                ControlToValidate="txtUsername"
                                ForeColor="Red" ErrorMessage="Username is required"></asp:RequiredFieldValidator>
                    </div>
            </div>

            <div class="form-group">
                <asp:Label ID="lblPass" Font-Bold="true" Text="Password" class="col-md-2 control-label" runat="server"></asp:Label>
                    <div class="col-md-3">
                         <asp:TextBox ID="txtpass" TextMode="Password" CssClass="form-control" runat="server" placeholder="Password"></asp:TextBox>
                    </div>
            </div>

           <div class="form-group">
                <asp:Label ID="lblConfPass" Font-Bold="true" Text="Confirm Password" class="col-md-2 control-label" runat="server"></asp:Label>
                    <div class="col-md-3">
                        <asp:TextBox ID="passConfirm" TextMode="Password" class="form-control" runat="server" placeholder="Confirm Password" EnableViewState="false"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidatorPassword" SetFocusOnError="true" Type="String" Display="Dynamic"
                            ForeColor="Red" ControlToValidate="passConfirm" runat="server" ControlToCompare="txtpass" Operator="Equal"
                            ErrorMessage="Password and Confirm Password is not Matching"></asp:CompareValidator>
                    </div>
            </div>

            <div class="form-group">
                <asp:Label ID="lblTypeUser" Font-Bold="true" Text="Type of User" class="col-md-2 control-label" runat="server"></asp:Label>
                    <div class="col-md-3">
                        <asp:DropDownList ID="ddlTypeUser" class="form-control" runat="server">
                            <asp:ListItem Text="Select Title" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="Admin" Value="Admin"></asp:ListItem>
                            <asp:ListItem Text="Hotel" Value="Hotel"></asp:ListItem>
                            <asp:ListItem Text="Client" Value="Client"></asp:ListItem>      
                        </asp:DropDownList>
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="ddlTitle" ForeColor="Red" InitialValue="-1" 
                                ErrorMessage="Please select a Title"></asp:RequiredFieldValidator>--%>
                    </div>
            </div>

            <div class="form-group">
                <asp:Label ID="lblstatus" Font-Bold="true" Text="Status of User" class="col-md-2 control-label" runat="server"></asp:Label>
                    <div class="col-md-3">
                        <asp:DropDownList ID="ddlstatus" class="form-control" runat="server">
                            <asp:ListItem Text="Select Status" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="Active" Value="Active"></asp:ListItem>
                            <asp:ListItem Text="Inactive" Value="Inactive"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
            </div>
        
            <div class="form-group">
                    <div class="col-md-2"></div>
                    <div class="col-md-6 space-vert">
                        <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="btn btn-success" />
                    </div>
            </div>

            <div class="col-md-6">
                <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
            </div>
    </div>
</div>
</asp:Content>

