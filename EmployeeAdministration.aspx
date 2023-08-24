<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeAdministration.aspx.cs" Inherits="PROG2_Livestock.EmployeeAdministration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            text-align: center;
        }
        .auto-style3 {
            height: 25px;
        }
        .auto-style4 {
            height: 25px;
            width: 400px;
        }
        .auto-style5 {
            width: 400px;
        }
        .auto-style6 {
            width: 400px;
            height: 28px;
        }
        .auto-style7 {
            height: 28px;
        }
        .auto-style8 {
            width: 400px;
            height: 32px;
        }
        .auto-style9 {
            height: 32px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table cellpadding="2" class="auto-style1">
                <tr>
                    <td class="auto-style2" colspan="2"><strong>Administration</strong></td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:Button ID="btnReturn" runat="server" OnClick="btnReturn_Click" Text="Return to Main Menu" />
                    </td>
                    <td class="auto-style3"></td>
                </tr>
                <tr>
                    <td class="auto-style5">Choose Farmer</td>
                    <td>
                        <asp:TextBox ID="txtFarmer" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style6">Choose Product Type</td>
                    <td class="auto-style7">
                        <asp:TextBox ID="txtProductType" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style3">
                        <asp:Button ID="btnFilterFarmer" runat="server" OnClick="btnFilterFarmer_Click" Text="Filter by Farmer" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4"></td>
                    <td class="auto-style3">
                        <asp:Button ID="btnFilterType" runat="server" OnClick="btnFilter_Click" Text="Filter by Product Type" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">From Date<asp:Calendar ID="cldFrom" runat="server"></asp:Calendar>
                    </td>
                    <td>To Date<asp:Calendar ID="cldTo" runat="server"></asp:Calendar>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style8"></td>
                    <td class="auto-style9">
                        <asp:Button ID="btnFilterDate" runat="server" OnClick="btnFilterDate_Click" Text="Filter by Date Added" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td>
                        <asp:Button ID="btnClear" runat="server" OnClick="btnClear_Click" Text="Clear Filters" Width="140px" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:GridView ID="grdDisplay" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
