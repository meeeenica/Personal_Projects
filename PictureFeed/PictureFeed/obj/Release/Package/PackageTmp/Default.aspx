<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PictureFeed.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="css/StyleSheet.css">    
    <link href="Bootstrap/css/bootstrap.min.css" rel="stylesheet">
    <title></title>
    <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
    <meta name="CODE_LANGUAGE" Content="C#">
    <meta name=vs_defaultClientScript content="JavaScript">
    <meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
</head>
<body>
    <form id="form1" method="post" enctype="multipart/form-data" runat="server">
    <div style="margin:25px;">
        <h1>
            Welcome to PictureFeed!
        </h1>
        <h3 style="text-indent:10px;">
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Picture Feed Home</asp:LinkButton>
        </h3>
        <br />
        <table>
            <tr>
                <td style="width:200px;">
                    Message:
                </td>
                <td>&nbsp;</td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server"  TextMode="Multiline" Height="72px" Width="268px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    Select Image to upload:
                </td>
                <td>&nbsp;</td>
                <td>
                    <INPUT type=file id=File1 name=File1 runat="server" />
                </td>
            </tr>
            <tr ID="headUploadItem" runat="server">
                <td colspan="2">&nbsp;</td>
                <td>
                    <%--<br ID="brUploadItem" runat="server"/>--%>
                    <h6 style="text-indent:10px;" runat="server" id="headerMess">Please select file to Upload!</h6>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    &nbsp;
                </td>
                <td>
                    <input type="submit"  style="margin-top:20px;" id="Submit1" value="Upload" runat="server" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
