<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImageFeed.aspx.cs" Inherits="PictureFeed.ImageFeed" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="css/StyleSheet.css">    
    <link href="Bootstrap/css/bootstrap.min.css" rel="stylesheet">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin:25px;">
        <h1>
            Welcome to PictureFeed!
        </h1>
        <h3 style="text-indent:10px;">
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Upload Image</asp:LinkButton>
        </h3>
            <br ID="brNoItem" runat="server"/>
            <h2 style="text-indent:10px;" ID="headNoItem" runat="server">No items found!</h2>
        <asp:Repeater ID="RepeaterImages" runat="server" OnItemCreated="RepeaterImages_ItemCreated">
            <ItemTemplate>
                <asp:Label ID="Mes" runat="server" style="margin:auto; display:block;" Text='<%# Container.DataItem %>' ></asp:Label>
                <asp:Image ID="Image" runat="server" style="text-indent:20px; margin:auto; display:block;" ImageUrl='<%# Container.DataItem %>' 
                    Width="200"/>
                <br />
            </ItemTemplate>
        </asp:Repeater>
    </div>
    </form>
</body>
</html>
