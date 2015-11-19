namespace reserva
{
    using System;
    using System.Data;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public partial class MasterPage : System.Web.UI.MasterPage
    {
        public Entity.Usuario usuario = new Entity.Usuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session[Constante.Sessions.LOGIN] == null)
                Response.Redirect("~/login.aspx");

            usuario = (Entity.Usuario)Session[Constante.Sessions.LOGIN];
        }

        protected void lnkSair_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/login.aspx");
        }
    }
}