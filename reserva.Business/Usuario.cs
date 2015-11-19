using System;
using System.Collections.Generic;
using System.Text;

namespace reserva.Business
{
    public class Usuario
    {
        #region SELECT

        public Entity.Usuario ConsultarUsuario(string Login, string Senha)
        {
            string Sql = "SELECT * FROM reserva.Usuario WHERE Login='" + Login + "' AND Senha='" + Senha + "'";
            return new Data.Usuario().Consultar(Sql);
        }

        #endregion

        #region INSERT, UPDATE, DELETE

        public Entity.Retorno InserirUsuario(Entity.Usuario usuario)
        {
            string Sql = "INSERT INTO reserva.Usuario (Nome,Login,Senha,Apartamento,Torre) VALUES ('" + usuario.Nome + "','" + usuario.Login + "','" + usuario.Senha + "','" + usuario.Apartamento + "','" + usuario.Torre + "')";
            return new Data.Usuario().Inserir(Sql);
        }

        public Entity.Retorno AlterarUsuario(Entity.Usuario usuario)
        {
            string Sql = "UPDATE reserva.Usuario SET Nome='" + usuario.Nome + "', Login='" + usuario.Login + "', Senha='" + usuario.Senha + "', Apartamento=" + usuario.Apartamento + ", Torre='" + usuario.Torre + "' WHERE IDUsuario=" + usuario.IDUsuario;
            return new Data.Usuario().Alterar(Sql);
        }

        #endregion
    }
}