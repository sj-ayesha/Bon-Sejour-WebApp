<%@ Page Title="" Language="VB" MasterPageFile="~/BSMasterPageClient.master" AutoEventWireup="false" CodeFile="Login.aspx.vb" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <!--Login-->
    <div class="container">
        <div class="form-horizontal">
            <h2>Login</h2>
            <hr />
            <div class="row">
             <div class="col-lg-6">
            <div class="form-group">
                <asp:Label ID="Uname" runat="server" CssClass="col-md-2 control-label" Text="Username"></asp:Label>
                <div class="col-md-8">
                    <asp:TextBox ID="txtUname" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorUname" CssClass="text-danger" runat="server" 
                        ControlToValidate="txtUname" ForeColor="Red" ErrorMessage="Username is required!"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="Pass" runat="server" CssClass="col-md-2 control-label" Text="Password"></asp:Label>
                <div class="col-md-8">
                    <asp:TextBox ID="txtPass" TextMode="password" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorPass" CssClass="text-danger" runat="server" 
                        ControlToValidate="txtPass" ForeColor="Red" ErrorMessage="Password is required!"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-2"></div>
                <div class="col-md-6">
                    <asp:CheckBox ID="CheckBoxRemember" runat="server" />
                    <asp:Label ID="Remember" runat="server" CssClass="control-label" Text="Remember me?"></asp:Label>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-2"></div>
                <div class="col-md-6">
                    <asp:Button ID="btnLogin" runat="server" Text="Sign In" CssClass="btn btn-default" />
                    <asp:LinkButton ID="lbtnSignUp" runat="server" PostBackUrl="~/Registration.aspx">Sign Up</asp:LinkButton>
                </div>
            </div>

            <div class="form-group">
                <div class="col-md-2"></div>
                <div class="col-md-6">
                    <asp:Label ID="lblError" runat="server" CssClass="text-danger"></asp:Label>
                </div>
            </div>
                 </div>

                <div class="col-lg-6">
                    <asp:AdRotator ID="AdRotator1" runat="server" AdvertisementFile="~/xmlfile1.xml" Target="_blank" />
                </div>
        </div>
        </div>
    </div>
</asp:Content>

