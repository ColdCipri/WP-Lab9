<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WP_Lab9.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
        WP-Lab9 ASP.NET
    </title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HiddenField ID="hiddenfieldID" runat="server" />
            <table>
                <tr>
                    <td>
                        <asp:Label Text="Name" runat="server"/>
                    </td>
                    <td colspan ="2">
                        <asp:TextBox ID="textName" runat="server" />
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label Text="Username" runat="server"/>
                    </td>
                    <td colspan ="2">
                        <asp:TextBox ID="textUsername" runat="server" />
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label Text="Age" runat="server"/>
                    </td>
                    <td colspan ="2">
                        <asp:TextBox ID="textAge" runat="server" />
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label Text="Email" runat="server"/>
                    </td>
                    <td colspan ="2">
                        <asp:TextBox ID="textEmail" runat="server" />
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label Text="Webpage" runat="server"/>
                    </td>
                    <td colspan ="2">
                        <asp:TextBox ID="textWebpage" runat="server" />
                    </td>
                </tr>

                <tr>
                    <td></td>
                    <td colspan="2">
                        <asp:Button Text="Save" ID="buttonSave" runat="server" OnClick="buttonSave_Click" />
                        <asp:Button Text="Delete" ID="buttonDelete" runat="server" OnClick="buttonDelete_Click" />
                        <asp:Button Text="Clear" ID="buttonClear" runat="server" OnClick="buttonClear_Click" />
                    </td>
                </tr>

                <tr>
                    <td></td>
                    <td colspan="2">
                        <asp:Label Text="" ID="labelSuccessMessage" runat="server" Forecolor="Green" />
                    </td>
                </tr>

                <tr>
                    <td></td>
                    <td colspan="2">
                        <asp:Label Text="" ID="labelErrorMessage" runat="server" Forecolor="Red" />
                    </td>
                </tr>
            </table>
            
            <br />
            <br />
            <table>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="LabelSearch" runat="server" Text="Search By:"></asp:Label>
                    </td>

                    <td colspan="2">
                        <asp:DropDownList ID="SearchList" runat="server">
                            <asp:ListItem Selected="True">Name</asp:ListItem>
                            <asp:ListItem>Username</asp:ListItem>
                            <asp:ListItem>Age</asp:ListItem>
                            <asp:ListItem>Email</asp:ListItem>
                            <asp:ListItem>Webpage</asp:ListItem>
                        </asp:DropDownList>
                    </td>

                    <td>
                        <asp:TextBox ID="textSearch" runat="server" OnTextChanged="textSearch_TextChanged"></asp:TextBox>
                    </td>

                </tr>
            </table>
            
            
            <br />
            <br />

            <asp:GridView ID="gvName" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="Name" HeaderText="Name" />
                    <asp:BoundField DataField="Username" HeaderText="Username" />
                    <asp:BoundField DataField="Age" HeaderText="Age" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:BoundField DataField="Webpage" HeaderText="Webpage" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton Text="Select" ID="linkSelect" CommandArgument='<%# Eval("ID") %>' runat="server" OnClick="linkSelect_OnClick" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />
            <br />
            <p id="searched">Searched:</p>
            <script type="text/javascript">
                function copyText() {
                    var searchedElem = document.getElementById("<%= SearchList.ClientID %>").value;
                    searchedElem += " with ";
                    searchedElem += document.getElementById("<%= textSearch.ClientID %>").value;
                    var para = document.createElement("p");
                    var node = document.createTextNode(searchedElem);
                    para.appendChild(node);
                    var element = document.getElementById("searched");
                    element.appendChild(para);
                }
                copyText();
            </script>
        </div>
    </form>

</body>
</html>
