namespace reserva
{
    using System;
    using System.Collections.Generic;
    using System.Web;

    public abstract class BasePage : System.Web.UI.Page
    {
        public Entity.Usuario usuario = new Entity.Usuario();

        protected void Page_Init(object sender, EventArgs e)
        {
            usuario = (Entity.Usuario)Session[Constante.Sessions.LOGIN];
        }
    }
}