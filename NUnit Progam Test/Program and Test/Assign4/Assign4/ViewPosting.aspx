<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewPosting.aspx.cs" Inherits="Assign4.ViewPosting" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <meta charset="UTF-8">
        <title>JD Power</title>
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <meta name="description" content="">
        <meta name="author" content="">

        <link href="css/bootstrap.css" rel="stylesheet" type="text/css"/>
        <link href="css/responsive.css" rel="stylesheet" type="text/css"/>
        <link href="styles_main.css" rel="stylesheet" type="text/css"/>

        <link rel="apple-touch-icon-precomposed" sizes="144x144" href="favicon/android-icon-144x144.png">
        <link rel="apple-touch-icon-precomposed" sizes="96x96" href=".favicon/android-icon-96x96.png">
        <link rel="apple-touch-icon-precomposed" sizes="72x72" href="favicon/android-icon-72x72.png">
        <link rel="apple-touch-icon-precomposed" href="favicon/android-icon-48x48.png">
        <link rel="shortcut icon" href="favicon/favicon.png">
    </head>

  <body>

    <!-- NAVBAR
    ================================================== -->
    <div class="navbar-wrapper">
      <!-- Wrap the .navbar in .container to center it within the absolutely positioned parent. -->
      <div class="container">

        <div class="navbar navbar-inverse">
          <div class="navbar-inner">
            <!-- Responsive Navbar Part 1: Button for triggering responsive navbar (not covered in tutorial). Include responsive CSS to utilize. -->
            <button type="button" class="btn btn-navbar" data-toggle="collapse" data-target=".nav-collapse">
              <span class="icon-bar"></span>
              <span class="icon-bar"></span>
              <span class="icon-bar"></span>
            </button>
            <a class="brand" href="Index.aspx">Assignment 4</a>
            <!-- Responsive Navbar Part 2: Place all navbar contents you want collapsed withing .navbar-collapse.collapse. -->
            <div class="nav-collapse collapse">
              <ul class="nav">
                <li><a href="Index.aspx">Home</a></li>
                <li><a href="AddCar.aspx">Add Car</a></li>
                <li><a href="Search.aspx">Search Car</a></li>
                <!-- Read about Bootstrap dropdowns at http://twitter.github.com/bootstrap/javascript.html#dropdowns -->
              </ul>
            </div><!--/.nav-collapse -->
          </div><!-- /.navbar-inner -->
        </div><!-- /.navbar -->

      </div> <!-- /.container -->
    </div><!-- /.navbar-wrapper -->
    <div class="jumbotron jumbotron-fluid">
      <div class="container">
        <h1 class="display-3">Car Details</h1>
      </div>
    </div>
    <div class="container marketing">
      <form  runat="server">
          <hr class="featurette-divider">
          <div class="featurette">
            <h3 class="featurette-heading">Car Details:</h3>
            <p class="lead" style="font-size:medium;">
                 <label for="carmake" class="sr-only" style="display: inline-block;  width:18%; text-align: right;">Car Make: </label>
                    <asp:Label ID="lblmake" runat="server" Text=""></asp:Label>
                    <br />
                <label for="model" class="sr-only" style="display: inline-block;  width:18%; text-align: right;">Model: </label>
                    <asp:Label ID="lblmodel" runat="server" Text=""></asp:Label>
                    <br />
                <label for="year" class="sr-only" style="display: inline-block;  width:18%; text-align: right;">Year: </label>
                    <asp:Label ID="lblyear" runat="server" Text=""></asp:Label>
                    <br />
                <label for="price" class="sr-only" style="display: inline-block;  width:18%; text-align: right;">Price: </label>
                    <asp:Label ID="lblprice" runat="server" Text=""></asp:Label>
                    <br />
                 <label for="Label1" class="sr-only" style="display: inline-block;  width:18%; text-align: right;">Link: </label>
                    <asp:HyperLink ID="Label1" runat="server" Text=""></asp:HyperLink>
                    <br />
            </p>
              <asp:Button ID="submit" runat="server" Text="Show Owner Contact Details"  
                  class="btn btn-large btn-primary btn-block" style="width: 98%" OnClick="submit_Click"/>
              <br />
          </div>
          <div id="ownerDiv" runat="server" class="featurette" Visible="false">
            <hr class="featurette-divider">
            <h3 class="featurette-heading">Car Owner Details:</h3>
            <div class="lead" style="margin-bottom:0px; font-size:medium;">
                <label for="fname" class="sr-only" style="display: inline-block; width:18%; text-align: right;">Firstname: </label>
                    <asp:Label ID="lblfname" runat="server" Text=""></asp:Label>
                        <br>
                <label for="lname" class="sr-only" style="display: inline-block;  width:18%; text-align: right;">Lastname: </label>
                    <asp:Label ID="lbllname" runat="server" Text=""></asp:Label>
                    <br />
                <h4 class="sr-only" style="display: inline-block; width:18%; display: inline-block; text-align:left; 
                    margin-bottom:0px; margin-left:50px;">
                    <span class="muted">&nbsp;&nbsp;Address:</span></h4>
                <br />
                <label for="address" class="sr-only" style="display: inline-block;  width:18%; text-align: right;">Address: </label>
                    <asp:Label ID="lbladdress" runat="server" Text=""></asp:Label>
                    <br />
                <label for="city" class="sr-only" style="display: inline-block;  width:18%; text-align: right;">City, Province: </label>
                    <asp:Label ID="lblcity" runat="server" Text=""></asp:Label>
                <br />
                <br />
                <h4 class="sr-only" style="display: inline-block; width:18%; display: inline-block; text-align:left; 
                    margin-bottom:0px; margin-left:50px;">
                    <span class="muted">&nbsp;&nbsp;Contact Details:</span></h4>
                <br />
                <label for="phone" class="sr-only" style="display: inline-block;  width:18%; text-align: right;">
                    Phone: </label>
                    <asp:Label ID="lblPhone" runat="server" Text=""></asp:Label>
                    <br>
                <label for="inputEmail" class="sr-only" style="display: inline-block; width:18%; text-align: right;">
                    Email: </label>
                    <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
                
            <hr class="featurette-divider">
            </div>
          </div>
          <br />
          <footer>
            <p class="pull-right"><a href="#">Back to top</a></p>
            <p>&copy; JD Power, Inc. &middot; <a href="#">Privacy</a> &middot; <a href="#">Terms</a></p>
          </footer>
          </form>
    </div>

    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/transition.js" type="text/javascript"></script>
    <script src="js/alert.js" type="text/javascript"></script>
    <script src="js/modal.js" type="text/javascript"></script>
    <script src="js/dropdown.js" type="text/javascript"></script>
    <script src="js/scrollspy.js" type="text/javascript"></script>
    <script src="js/tab.js" type="text/javascript"></script>
    <script src="js/tooltip.js" type="text/javascript"></script>
    <script src="js/popover.js" type="text/javascript"></script>
    <script src="js/button.js" type="text/javascript"></script>
    <script src="js/collapse.js" type="text/javascript"></script>
    <script src="js/carousel.js" type="text/javascript"></script>
    <script src="js/typeahead.js" type="text/javascript"></script>
    <script>
      !function ($) {
        $(function(){
          // carousel demo
          $('#myCarousel').carousel();
        });
      }(window.jQuery);
    </script>
    <script src="js/holder.js" type="text/javascript"></script>
  </body>
</html>
