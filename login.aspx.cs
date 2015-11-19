namespace reserva
{
    using System;
    using System.Data;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_ServerClick(object sender, EventArgs e)
        {
            string Login = txtLogin.Text.ToPrepare();
            string Senha = txtSenha.Text.ToPrepare();

            Entity.Usuario usuario = new Business.Usuario().ConsultarUsuario(Login, Senha);

            if (usuario.IDUsuario == 0)
            {

                return;
            }
            else
            {
                Session[Constante.Sessions.LOGIN] = usuario;
                Response.Redirect("~/");
            }
        }
    }
}