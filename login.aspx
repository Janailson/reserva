<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="reserva.login" %>

<!DOCTYPE html>
<!--[if IE 9 ]><html class="ie ie9" lang="en" class="no-js"> <![endif]-->
<!--[if !(IE)]><!-->
<html lang="en" class="no-js">
<!--<![endif]-->

<head>
    <title>Login | KingAdmin - Admin Dashboard</title>
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
    <div class="wrapper full-page-wrapper page-auth page-login text-center">
        <div class="inner-page">
            <div class="logo">
                <img src="assets/img/kingadmin-logo.png" alt="" />
            </div>

            <div class="login-box center-block">
                <form runat="server" class="form-horizontal" role="form">
                    <div class="form-group">
                        <label for="username" class="control-label sr-only">Login</label>
                        <div class="col-sm-12">
                            <div class="input-group">
                                <asp:TextBox ID="txtLogin" runat="server" CssClass="form-control" placeholder="login"></asp:TextBox>
                                <span class="input-group-addon"><i class="fa fa-user"></i></span>
                            </div>
                        </div>
                    </div>
                    <label for="password" class="control-label sr-only">Senha</label>
                    <div class="form-group">
                        <div class="col-sm-12">
                            <div class="input-group">
                                <asp:TextBox ID="txtSenha" runat="server" CssClass="form-control" placeholder="senha" TextMode="Password"></asp:TextBox>
                                <span class="input-group-addon"><i class="fa fa-lock"></i></span>
                            </div>
                        </div>
                    </div>
                    <label class="fancy-checkbox">
                        <input type="checkbox">
                        <span>Lembrar de mim</span>
                    </label>
                    <button id="btnLogin" runat="server" type="submit" class="btn btn-custom-primary btn-lg btn-block btn-auth" onserverclick="btnLogin_ServerClick"><i class="fa fa-arrow-circle-o-right"></i>Login</button>
                </form>

                <div class="links">
                    <p><a href="#">Esqueceu seu Login ou Senha?</a></p>
                    <p><a href="registro.aspx">Criar Nova Conta</a></p>
                </div>
            </div>
        </div>
    </div>

    <footer class="footer">&copy; 2014-2015 The Develovers</footer>

    <!-- Javascript -->
    <script src="assets/js/jquery/jquery-2.1.0.min.js"></script>
    <script src="assets/js/bootstrap/bootstrap.min.js"></script>
    <script src="assets/js/plugins/modernizr/modernizr.js"></script>
</body>

</html>
