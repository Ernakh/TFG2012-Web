<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PainelGerencial.aspx.cs" Inherits="TFG___Web.PainelGerencial" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <br />
        <asp:Button ID="Button1"  BackColor="Transparent" BorderColor="Transparent" 
            BorderStyle="None" ForeColor="Black" 
            Style="background-image:url(img/botao.png); cursor:pointer;" Height="31px" 
            Width="73px" Font-Bold="False" Font-Names="Arial" Font-Overline="False" 
            Font-Size="X-Small" Font-Strikeout="False" Font-Underline="False"  runat="server" Text="Usuários" 
            onclick="Button1_Click" />
        <br />
        <asp:Button ID="Button2"  BackColor="Transparent" BorderColor="Transparent" 
            BorderStyle="None" ForeColor="Black" 
            Style="background-image:url(img/botao.png); cursor:pointer;" Height="31px" 
            Width="73px" Font-Bold="False" Font-Names="Arial" Font-Overline="False" 
            Font-Size="X-Small" Font-Strikeout="False" Font-Underline="False"  runat="server" Text="Locais" onclick="Button2_Click" />
        <br />
        <asp:Button ID="Button5"  BackColor="Transparent" BorderColor="Transparent" 
            BorderStyle="None" ForeColor="Black" 
            Style="background-image:url(img/botao.png); cursor:pointer;" Height="31px" 
            Width="73px" Font-Bold="False" Font-Names="Arial" Font-Overline="False" 
            Font-Size="X-Small" Font-Strikeout="False" Font-Underline="False"  runat="server" Text="Produtos" 
            onclick="Button5_Click" />
        <br />
        <asp:Button ID="Button3"  BackColor="Transparent" BorderColor="Transparent" 
            BorderStyle="None" ForeColor="Black" 
            Style="background-image:url(img/botao.png); cursor:pointer;" Height="31px" 
            Width="73px" Font-Bold="False" Font-Names="Arial" Font-Overline="False" 
            Font-Size="X-Small" Font-Strikeout="False" Font-Underline="False"  runat="server" Text="Categorias" 
            onclick="Button3_Click" />
        <br />
        <asp:Button ID="Button4"  BackColor="Transparent" BorderColor="Transparent" 
            BorderStyle="None" ForeColor="Black" 
            Style="background-image:url(img/botao.png); cursor:pointer;" Height="31px" 
            Width="73px" Font-Bold="False" Font-Names="Arial" Font-Overline="False" 
            Font-Size="X-Small" Font-Strikeout="False" Font-Underline="False" runat="server" Text="Sair" onclick="Button4_Click" /><br />
    </div>
    </form>
</body>
</html>
