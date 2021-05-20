<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TFG___Web.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style=" text-align:center;">
        <asp:TextBox ID="TextBox1" Style="background-image:url(img/input-box-pequeno.png); text-align: left; display:inline" 
        BackColor="Transparent" BorderColor="Transparent" Height="26px" Width="146px" runat="server"></asp:TextBox><br /><br />
        <asp:TextBox ID="TextBox2" Style="background-image:url(img/input-box-pequeno.png); text-align: left; display:inline" 
        BackColor="Transparent" BorderColor="Transparent" Height="26px" Width="146px" runat="server" TextMode="Password"></asp:TextBox><br /><br />
        <asp:Button ID="Button1"  BackColor="Transparent" BorderColor="Transparent" 
            BorderStyle="None" ForeColor="Black" 
            Style="background-image:url(img/botao.png); cursor:pointer;" Height="31px" 
            Width="73px" Font-Bold="False" Font-Names="Arial" Font-Overline="False" 
            Font-Size="X-Small" Font-Strikeout="False" Font-Underline="False"  runat="server" Text="Logar" onclick="Button1_Click" />
    </div>
    </form>
</body>
</html>
