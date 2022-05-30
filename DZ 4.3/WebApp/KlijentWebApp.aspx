<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KlijentWebApp.aspx.cs" Inherits="WebApp.KlijentWebApp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Unesi ID:"></asp:Label>
            <asp:TextBox ID="Id" runat="server" style="margin-left: 21px" Width="115px"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="Search" style="margin-left: 26px" OnClick="Button1_Click" />
            <br />
            <br />
            <asp:GridView ID="gvUsers" calss="table table-bordered responsive-table" AutoGenerateColumns="true" runat="server">
       </asp:GridView>
        </div>
    </form>
</body>
</html>
