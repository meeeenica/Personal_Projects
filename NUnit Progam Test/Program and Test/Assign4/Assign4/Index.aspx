<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Assign4.Index" %>

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
            <a class="brand" href="#">Assignment 4</a>
            <!-- Responsive Navbar Part 2: Place all navbar contents you want collapsed withing .navbar-collapse.collapse. -->
            <div class="nav-collapse collapse">
              <ul class="nav">
                <li class="active"><a href="Index.aspx">Home</a></li>
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
        <h1 class="display-3"  style="margin-left:50px;">JD Power & Associates</h1>
          
        <div style="width:100%">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/9VTkqmo.jpg" />
        </div>
      </div>
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


