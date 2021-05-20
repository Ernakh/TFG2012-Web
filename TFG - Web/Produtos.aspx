<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Produtos.aspx.cs" Inherits="TFG___Web.Produtos" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <br />
        Produtos Cadastrados:
        <br />
    <asp:GridView ID="GridView1" runat="server">
    </asp:GridView><br /><br />

        Nome:<br />
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br /><br />

        Descrição:<br />
        <asp:TextBox ID="TextBox2"  runat="server" TextMode="MultiLine"></asp:TextBox>
        <br /><br />

        Preço:<br />
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <br /><br />

        <fieldset>
        <legend>Categorias</legend>
        <div id="categorias" runat="server">
            
        </div>
        </fieldset>
        <fieldset>
        <legend>Locais</legend>
        <div id="locais" runat="server">
            
        </div>
        </fieldset>
    <asp:Button ID="Button1"  BackColor="Transparent" BorderColor="Transparent" 
            BorderStyle="None" ForeColor="Black" 
            Style="background-image:url(img/botao.png); cursor:pointer;" Height="31px" 
            Width="73px" Font-Bold="False" Font-Names="Arial" Font-Overline="False" 
            Font-Size="X-Small" Font-Strikeout="False" Font-Underline="False"  runat="server" Text="Cadastrar" onclick="Button1_Click" />
    <asp:Button ID="Button2"  BackColor="Transparent" BorderColor="Transparent" 
            BorderStyle="None" ForeColor="Black" 
            Style="background-image:url(img/botao.png); cursor:pointer;" Height="31px" 
            Width="73px" Font-Bold="False" Font-Names="Arial" Font-Overline="False" 
            Font-Size="X-Small" Font-Strikeout="False" Font-Underline="False"  runat="server" Text="Cancelar" onclick="Button2_Click" />
    </form>
</body>
</html>
