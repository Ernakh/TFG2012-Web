<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="TFG___Web.Usuarios" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Usuários cadastrados:
         <br />
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView> 
        <br />
        <br />

        Nome:<br />
        <asp:TextBox ID="TextBox1" Style="background-image:url(img/input-box-pequeno.png); text-align: left; display:inline" 
        BackColor="Transparent" BorderColor="Transparent" Height="26px" Width="146px" runat="server"></asp:TextBox><br /><br />

        Email:<br />
        <asp:TextBox ID="TextBox2" Style="background-image:url(img/input-box-pequeno.png); text-align: left; display:inline" 
        BackColor="Transparent" BorderColor="Transparent" Height="26px" Width="146px" runat="server"></asp:TextBox><br /><br />

        Login: <br />
        <asp:TextBox ID="TextBox3" Style="background-image:url(img/input-box-pequeno.png); text-align: left; display:inline" 
        BackColor="Transparent" BorderColor="Transparent" Height="26px" Width="146px" runat="server"></asp:TextBox><br /><br />

        Senha: <br />
        <asp:TextBox ID="TextBox4" Style="background-image:url(img/input-box-pequeno.png); text-align: left; display:inline" 
        BackColor="Transparent" BorderColor="Transparent" Height="26px" Width="146px" runat="server"></asp:TextBox><br /><br />

        Gerente:<br />
        <asp:RadioButton ID="RadioButton1" Text="SIM" runat="server" GroupName="gerentes"/>
        <asp:RadioButton ID="RadioButton2" Text="NÃO" runat="server" GroupName="gerentes" Checked="True"/>
        <br /><br />

        <asp:Button ID="Button1" runat="server" Text="Cadastrar"  BackColor="Transparent" BorderColor="Transparent" 
            BorderStyle="None" ForeColor="Black" 
            Style="background-image:url(img/botao.png); cursor:pointer;" Height="31px" 
            Width="73px" Font-Bold="False" Font-Names="Arial" Font-Overline="False" 
            Font-Size="X-Small" Font-Strikeout="False" Font-Underline="False" 
            onclick="Button1_Click" />
        <asp:Button ID="Button2" runat="server" Text="Cancelar"  BackColor="Transparent" BorderColor="Transparent" 
            BorderStyle="None" ForeColor="Black" 
            Style="background-image:url(img/botao.png); cursor:pointer;" Height="31px" 
            Width="73px" Font-Bold="False" Font-Names="Arial" Font-Overline="False" 
            Font-Size="X-Small" Font-Strikeout="False" Font-Underline="False" 
            onclick="Button2_Click" />

    </div>
    </form>
</body>
</html>
