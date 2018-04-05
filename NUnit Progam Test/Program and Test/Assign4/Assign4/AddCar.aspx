<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddCar.aspx.cs" Inherits="Assign4.AddCar" %>


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
                <li class="active"><a href="AddCar.aspx">Add Car</a></li>
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
        <h1 class="display-3">Add Car</h1>
      </div>
    </div>
    <div class="container marketing">
      <form  runat="server">
          <hr class="featurette-divider">
          <div class="featurette">
            <h3 class="featurette-heading">Car Owner Details:</h3>
              <label class="sr-only" Visible="false" style="display: inline-block; color:red; font-weight:bold;" id="lblemptyField"> </label><br />
              <label class="sr-only" Visible="false" style="display: inline-block; color:red; font-weight:bold;" id="lblemptyFieldAddress"> </label><br />
              <label class="sr-only" Visible="false" style="display: inline-block; color:red; font-weight:bold;" id="lblemptyFieldCar"> </label>
            <div class="lead" style="margin-bottom:0px;">
                <label for="fname" class="sr-only" style="display: inline-block; width:18%; text-align: right;">Firstname: </label>
                    <asp:TextBox runat="server"  type="text" name="fname" id="fname" class="form-control" placeholder="Firstname" required autofocus style="width: 75%">
                        </asp:TextBox>
                        <br>
                <label for="lname" class="sr-only" style="display: inline-block;  width:18%; text-align: right;">Lastname: </label>
                    <asp:TextBox runat="server"  type="text" name="lname" id="lname" class="form-control" placeholder="Lastname" required style="width: 75%">
                        </asp:TextBox>
                    <br />
                <h4 class="sr-only" style="display: inline-block; width:18%; display: inline-block; text-align:left; 
                    margin-bottom:0px; margin-left:50px;">
                    <span class="muted">&nbsp;&nbsp;Address:</span></label>
                    <h4 style="width: 75%"></h4>
                <label for="address" class="sr-only" style="display: inline-block;  width:18%; text-align: right;">Address: </label>
                    <asp:TextBox runat="server"  type="text" name="address" id="address" class="form-control" placeholder="Address" required style="width: 75%">
                        </asp:TextBox>
                    <br />
                <label for="city" class="sr-only" style="display: inline-block;  width:18%; text-align: right;">City: </label>
                    <asp:DropDownList class="form-control input-lg" name="city" id="city" required style="width: 76%" 
                        runat="server" DataSourceID="SqlDataSource1" DataTextField="City" DataValueField="City">
                        </asp:DropDownList>
                      <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:JDCarsConnectionString %>" SelectCommand="SELECT [City] FROM [City]"></asp:SqlDataSource>
                      <asp:LinqDataSource ID="LinqDataSource2" runat="server" EntityTypeName="">
                      </asp:LinqDataSource>
                <h4 class="sr-only" style="display: inline-block; width:18%; display: inline-block; text-align:left; 
                    margin-bottom:0px; margin-left:50px;">
                    <span class="muted">&nbsp;&nbsp;Contact Details:</span></label>
                    <h4 style="width: 75%"></h4>
                <label for="phone" class="sr-only" style="display: inline-block;  width:18%; text-align: right;">
                    Phone: </label>
                    <asp:TextBox runat="server"  type="text" name="phone" id="phone" class="form-control" placeholder="123-123-1234 or (123)123-1234" required style="width: 75%">
                        </asp:TextBox>
                    <br />
                    <asp:RegularExpressionValidator ID="regexpName" runat="server"  style=" font-size:medium; margin-left:20%"   
                                    ErrorMessage="Invalid Phone number." 
                                    ControlToValidate="phone"     
                                    ValidationExpression="^(\+0?1\s)?\(?\d{3}\)?[\s.-]\d{3}[\s.-]\d{4}$" />
                    <br/>
                <label for="inputEmail" class="sr-only" style="display: inline-block; width:18%; text-align: right;">
                    Email: </label>
                    <asp:TextBox runat="server" type="email" id="email" name="email" class="form-control" placeholder="youremail@email.com" required style="width: 75%">
                        </asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"  style=" font-size:medium; margin-left:20%"   
                                    ErrorMessage="Invalid Email." 
                                    ControlToValidate="email"     
                                    ValidationExpression="^\w+[\w-\.]*\@\w+((-\w+)|(\w*))\.[a-z]{2,3}$" />
            </div>
          </div>
          <hr class="featurette-divider">
          <div class="featurette">
            <h3 class="featurette-heading">Car Details:</h3>
            <p class="lead">
                 <label for="carmake" class="sr-only" style="display: inline-block;  width:18%; text-align: right;">Car Make: </label>
                    <asp:DropDownList class="form-control input-lg" name="carmake" id="carmake" required style="width: 76%" 
                        runat="server" DataSourceID="SqlDataSource2" DataTextField="Manufacturer" DataValueField="Manufacturer">
                        </asp:DropDownList>
                      <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                          ConnectionString="<%$ ConnectionStrings:JDCarsConnectionString %>" 
                          SelectCommand="SELECT [Manufacturer] FROM [CarMake]"></asp:SqlDataSource>
                <label for="model" class="sr-only" style="display: inline-block;  width:18%; text-align: right;">Model: </label>
                    <asp:TextBox runat="server"  type="text" name="model" id="model" class="form-control" placeholder="R8" required style="width: 75%">
                        </asp:TextBox>
                    <br />
                <label for="year" class="sr-only" style="display: inline-block;  width:18%; text-align: right;">Year: </label>
                    <asp:TextBox runat="server"  type="text" name="year" id="year" class="form-control" placeholder="2012" required style="width: 75%">
                        </asp:TextBox>
                    <br />
                <label for="price" class="sr-only" style="display: inline-block;  width:18%; text-align: right;">Price: </label>
                    <asp:TextBox runat="server"  type="text" name="price" id="price" class="form-control" placeholder="$5,000.00" required style="width: 75%">
                        </asp:TextBox>
                    <br />
            </p>
              <asp:Button ID="submit" runat="server" Text="Submit"  OnClientClick="Validate();"
                  class="btn btn-large btn-primary btn-block" style="width: 98%" OnClick="submit_Click"/>
              <br />
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
    <script>
        var emptyLabel = document.getElementById("lblemptyField");
        var emptyLabelAddress = document.getElementById("lblemptyFieldAddress");
        var emptyLabelCar = document.getElementById("lblemptyFieldCar");
        
        function Validate()
        {
            NameValidation();
            AddressValidation();
            CarDetailsValidation();
        }
        function NameValidation()
        {
            var fname_item;
            var fnameVal = document.getElementById("<%=fname.ClientID %>");
            var lname_item;
            var lnameVal = document.getElementById("<%=lname.ClientID %>");
            lname_item = lnameVal.value;
            fname_item = fnameVal.value;
            if (fname_item == "" && lname_item == "") 
            {
                lblemptyField.innerHTML = "Please Enter Firstname and Lastname."; 
            }
            else if (fname_item == "")
            {
                lblemptyField.innerHTML ="Please Enter Lastname.";
            }
            else if (fname_item == "")
            {
                lblemptyField.innerHTML = "Please Enter Firstname.";
            }
            else
            {
                lblemptyField.innerHTML = "";
            }
        }
        function AddressValidation()
        {
            var addressItem;
            var addressVal = document.getElementById("<%=address.ClientID%>");
            addressItem = addressVal.value;
            if(addressItem=="")
            {
                emptyLabelAddress.innerHTML = "Please Enter Address.";
            }
            else {
                emptyLabelAddress.innerHTML = "";
            }
        }
        function CarDetailsValidation()
        {
            var modelItem, yearItem, priceItem;
            var modelVal = document.getElementById("<%=model.ClientID%>");
            var yearVal = document.getElementById("<%=year.ClientID%>");
            var priceVal = document.getElementById("<%=price.ClientID%>");
            modelItem = modelVal.value;
            yearItem = yearVal.value;
            priceItem = priceVal.value;
            if (modelItem == "" || yearItem == "" || priceItem == "") {
                emptyLabelCar.innerHTML = "Please Enter Complete Car Details.";
            }
            else {
                emptyLabelCar.innerHTML = "";
            }
        }
    </script>
    <script src="js/holder.js" type="text/javascript"></script>
  </body>
</html>