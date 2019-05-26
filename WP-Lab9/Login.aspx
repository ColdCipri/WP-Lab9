<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WP_Lab9.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="background-color:darkgray">
    <form id="form1" runat="server">
        <div style="margin-left: 0; margin-right: 0; padding:0; text-align: center; position:absolute; height:100px; width : 100%">
            <asp:Label ID="Background" runat="server" BackColor="Lime" BorderColor="#003300" Font-Overline="False" Font-Size="XX-Large" ForeColor="Black" Height="100px" Text="Login" Width="100%"></asp:Label>
            <table style="text-align:left; position:relative; top: 0px; left: 112px; width: 150px; margin-left: 521px; margin-bottom: 0px;">
                    <tr>
                        <td>
                            <asp:Label Text="Username:" ID="username" runat="server" />

                        </td>

                        <td colspan="2"> 
                            <asp:TextBox ID="textUsername" runat="server" />
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <asp:Label Text="Password:" ID="password" runat="server" />
                        </td>

                        <td colspan="2">
                            <asp:TextBox ID="textPassword" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td >
                            <asp:Button Text="Login" ID="buttonLogin" runat="server" OnClick="buttonLogin_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:Label Text="" ID="data" runat="server" />
                        </td>
                    </tr>
            </table>
        </div>
    </form>
</body>
</html>
