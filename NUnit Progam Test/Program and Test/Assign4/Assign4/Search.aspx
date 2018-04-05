<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="Assign4.Search" %>

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

      <form id="form1" runat="server">

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
                <li class="active"><a href="Search.aspx">Search Car</a></li>
                <!-- Read about Bootstrap dropdowns at http://twitter.github.com/bootstrap/javascript.html#dropdowns -->
              </ul>
            </div><!--/.nav-collapse -->
          </div><!-- /.navbar-inner -->
        </div><!-- /.navbar -->

      </div> <!-- /.container -->
    </div><!-- /.navbar-wrapper -->
    <div class="jumbotron jumbotron-fluid">
      <div class="container">
        <h1 class="display-3">Search Car</h1>
      </div>
    </div>
    <div class="container marketing">
            <label for="manu" class="sr-only" style="display: inline-block; width:18%; text-align: right;">Maker: 
            </label>
            <asp:DropDownList ID="manu" AutoPostBack="True" runat="server"  type="text" name="manu" 
                class="form-control" placeholder="Maker" required autofocus style="width: 75%"
                 DataSourceID="SqlDataSource1" DataTextField="Manufacturer" DataValueField="Manufacturer"
                OnSelectedIndexChanged="modelsearch_SelectedIndexChanged">
                <asp:ListItem Text="--Select One--" Value="" Selected="True" />
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:JDCarsConnectionString %>" SelectCommand="SELECT [Manufacturer] FROM [CarMake]">
            </asp:SqlDataSource>
                    <br>
            <label for="model" class="sr-only" style="display: inline-block; width:18%; text-align: right;">Model: 
            </label>
            <asp:DropDownList ID="models" AutoPostBack="true" runat="server" 
                OnSelectedIndexChanged="models_SelectedIndexChanged" type="text" name="models" 
                class="form-control" placeholder="Model" required autofocus style="width: 75%">
                <asp:ListItem Text="--Select One--" Value="" />   
            </asp:DropDownList>
                    <br>
            <label id="lblyear" for="ddlyear" class="sr-only" style="display: inline-block; 
                width:18%; text-align: right;">Year: 
            </label>
            <asp:DropDownList ID="ddlYear" AutoPostBack="true" runat="server" 
                OnSelectedIndexChanged="ddlYear_SelectedIndexChanged" type="text" name="ddlYear" 
                class="form-control" placeholder="Year" required autofocus style="width: 75%">
                <asp:ListItem Text="--Select One--" Value="" />   
            </asp:DropDownList>
                    <br>
    </div>
          
          <hr class="featurette-divider">
    <div class="container marketing">
        <asp:GridView ID="gvCars" runat="server" AllowPaging="True" AllowSorting="True" 
            AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" style="width:100%;"
            BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" 
            OnSelectedIndexChanged="gvCars_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                <asp:BoundField DataField="CarMake" HeaderText="CarMake" SortExpression="CarMake" />
                <asp:BoundField DataField="Model" HeaderText="Model" SortExpression="Model" />
                <asp:BoundField DataField="Year" HeaderText="Year" SortExpression="Year" />
                <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                <asp:CommandField ShowSelectButton="True" HeaderText="View" />
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
            ConnectionString="<%$ ConnectionStrings:JDCarsConnectionString %>" 
            SelectCommand="SELECT [CarMake], [Model], [Year], [Price] FROM [Cars]"></asp:SqlDataSource>
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
      </form>
  </body>
</html>


