namespace reserva
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public partial class registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Criar Nova Conta - Reserva - Condomínio Felicittá";
        }

        protected void btnCriar_ServerClick(object sender, EventArgs e)
        {
            string Nome = txtNome.Text.ToPrepare();
            string Login = txtLogin.Text.ToPrepare();
            string Senha = txtSenha.Text.ToPrepare();
            string Apartamento = txtApartamento.Text.ToPrepare();
            string Torre = ddlTorre.SelectedValue;

            Entity.Usuario usuario = new Entity.Usuario();
            usuario.Nome = Nome;
            usuario.Login = Login;
            usuario.Senha = Senha;
            usuario.Apartamento = Convert.ToInt32(Apartamento);
            usuario.Torre = Torre;

            Entity.Retorno ret = new Business.Usuario().InserirUsuario(usuario);
            if (!ret.Status)
            {
                Response.Write(ret.Erro);
                return;
            }

            usuario.IDUsuario = ret.Identity;
            Session[Constante.Sessions.LOGIN] = usuario;
            Response.Redirect("~/");
        }
    }
}