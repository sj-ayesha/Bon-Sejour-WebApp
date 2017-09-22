<%@ Page Title="" Language="VB" MasterPageFile="~/BSMasterPageClient.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!--Carousel-->
        <div id="carousel-example-generic" class="carousel slide" data-ride="carousel">
            <!-- Indicators -->
            <ol class="carousel-indicators">
                <li data-target="#carousel-example-generic" data-slide-to="0" class="active"></li>
                <li data-target="#carousel-example-generic" data-slide-to="1"></li>
                <li data-target="#carousel-example-generic" data-slide-to="2"></li>
            </ol>

            <!-- Wrapper for slides -->
            <div class="carousel-inner" role="listbox">
                <div class="item active">
                    <img src="Images/Carousel_1.jpg" alt="Carousel1.jpg"/>
                </div>

                <div class="item">
                    <img src="Images/Carousel_2.jpg" alt="Carousel2.jpg"/>
                </div>
            
                <div class="item">
                    <img src="Images/Carousel_3.jpg" alt="Carousel3.jpg"/>
                </div>

            </div>

            <!-- Controls -->
            <a class="left carousel-control" href="#carousel-example-generic" role="button" data-slide="prev">
                <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
                <span class="sr-only">Previous</span>
            </a>

            <a class="right carousel-control" href="#carousel-example-generic" role="button" data-slide="next">
                <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
                <span class="sr-only">Next</span>
            </a>
        </div>
    <br />

    <!--END of Carousel-->

    <div class="container">
        <div class="row">
            <div class="col-lg-12">

                <h2 style="text-align:center">Bon Sejour</h2>

                <p style="text-align:justify">Planning a trip to Africa? Perhaps you'd like to visit some of the continent's most popular travel destinations, like Mauritius. 
                    Bon Sejour offers the best prices for hotels in Mauritius. 
                    The country offers its visitors a great diversity of beautiful landscapes as well as a vibrant culture and lifestyle. 
                    While any city is sure to excite, Mauritius Island, Rodrigues Island, Blue Bay go above and beyond to capture your attention.
                    With our best price guarantee, we are determined to offer you the best hotels at the best prices.</p>
            </div>
        </div>

        <div class="row hotel-bottom">
            <h2 style="text-align:center">Hotels</h2>

            <div class="col-lg-4">
                <asp:Image ID="imgLeMeridien" runat="server" Width="300px" Height="215px" />
            </div>

            <div class="col-lg-4">
                <asp:Image ID="imgHilton" runat="server" Width="300px" Height="215px" />
            </div>

            <div class="col-lg-4">
                <asp:Image ID="imgTamassa" runat="server" Width="300px" Height="215px" />
            </div>

            <div class="row bouton">
                <%--<asp:LinkButton ID="View" runat="server" CssClass="btn btn-link" Text="View All Hotels" />--%>
                <asp:Button ID="View" runat="server" Text="View Hotels >>" CssClass="btn btn-primary" />
            </div>

        </div>
    </div>

         <div class="row discover-section">
            <div class="col-sm-4 para">
    	        <h2>Discover <strong>Mauritius</strong></h2>
        	        <p>Welcome to Mauritius, where the sands are white as the smiles of the locals, where fish swim happily in the warm waters of the Indian Ocean, where the weather is a dream, and the deep rays of the sun waits to engulf you in their arms.
            
                    <br/>
            

            </div>
    
            <div class="col-sm-6">
    	        <img src="Images/mrumap.png" width="510" height="290" alt="mrumap.png"/>
            </div>
    
            </div>
    
</asp:Content>

