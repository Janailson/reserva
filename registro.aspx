<%@ Page Language="C#" AutoEventWireup="true" CodeFile="registro.aspx.cs" Inherits="reserva.registro" %>

<!DOCTYPE html>
<!--[if IE 9 ]><html class="ie ie9" lang="en" class="no-js"> <![endif]-->
<!--[if !(IE)]><!-->
<html lang="en" class="no-js">
<!--<![endif]-->

<head runat="server">
    <title>Register | KingAdmin - Admin Dashboard</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">
    <meta name="description" content="KingAdmin Dashboard">
    <meta name="author" content="The Develovers">

    <!-- CSS -->
    <link href="assets/css/bootstrap.min.css" rel="stylesheet" type="text/css">
    <link href="assets/css/font-awesome.min.css" rel="stylesheet" type="text/css">
    <link href="assets/css/main.css" rel="stylesheet" type="text/css">

    <!--[if lte IE 9]>
		<link href="assets/css/main-ie.css" rel="stylesheet" type="text/css" />
		<link href="assets/css/main-ie-part2.css" rel="stylesheet" type="text/css" />
	<![endif]-->

    <!-- Fav and touch icons -->
    <link rel="apple-touch-icon-precomposed" sizes="144x144" href="assets/ico/kingadmin-favicon144x144.png">
    <link rel="apple-touch-icon-precomposed" sizes="114x114" href="assets/ico/kingadmin-favicon114x114.png">
    <link rel="apple-touch-icon-precomposed" sizes="72x72" href="assets/ico/kingadmin-favicon72x72.png">
    <link rel="apple-touch-icon-precomposed" sizes="57x57" href="assets/ico/kingadmin-favicon57x57.png">
    <link rel="shortcut icon" href="assets/ico/favicon.png">
</head>

<body>
    <div class="wrapper full-page-wrapper page-auth page-register text-center">

        <div class="inner-page">
            <div class="logo">
                <a href="index.html">
                    <img src="assets/img/kingadmin-logo.png" alt="" /></a>
            </div>

            <div class="register-box center-block">
                <form runat="server">
                    <p class="title">Criar Nova Conta</p>
                    <asp:TextBox ID="txtNome" runat="server" CssClass="form-control" MaxLength="50" placeholder="nome" required></asp:TextBox>
                    <asp:TextBox ID="txtLogin" runat="server" CssClass="form-control" MaxLength="30" placeholder="login" required></asp:TextBox>
                    <asp:TextBox ID="txtSenha" runat="server" CssClass="form-control" MaxLength="20" placeholder="senha" required TextMode="Password"></asp:TextBox>
                    <asp:TextBox ID="txtApartamento" runat="server" CssClass="form-control ap" MaxLength="3" placeholder="apartamento" required></asp:TextBox>
                    <asp:DropDownList ID="ddlTorre" runat="server" CssClass="form-control" required>
                        <asp:ListItem>Milão</asp:ListItem>
                        <asp:ListItem>Veneza</asp:ListItem>
                    </asp:DropDownList>
                    <button id="btnCriar" runat="server" type="submit" class="btn btn-custom-primary btn-lg btn-block btn-auth" onserverclick="btnCriar_ServerClick"><i class="fa fa-check-circle"></i>Criar Conta</button>
                </form>
            </div>
        </div>
    </div>

    <div class="footer">&copy; 2014-2015 The Develovers</div>

    <!-- Javascript -->
    <script src="assets/js/jquery/jquery-2.1.0.min.js"></script>
    <script src="assets/js/bootstrap/bootstrap.min.js"></script>
    <script src="assets/js/plugins/modernizr/modernizr.js"></script>
    <script src="assets/js/plugins/jquery-maskedinput/jquery.masked-input.min.js"></script>
    <script type="text/javascript">
        jQuery(function () {
            $('.ap').mask('99?9');
        });
    </script>

</body>

</html>

