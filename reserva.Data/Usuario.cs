using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace reserva.Data
{
    public class Usuario : Generica
    {
        /// <summary>
        /// Lista os registros da tabela Usuario
        /// </summary>
        /// <param name="Sql">Síntaxe Sql</param>
        /// <returns></returns>
        public List<Entity.Usuario> Listar(string Sql)
        {
            SqlConnection oConn = new SqlConnection(oConexao.ConexaoBancoDeDados);
            SqlCommand oComm = new SqlCommand(Sql, oConn);

            SqlDataReader oDr;

            List<Entity.Usuario> usuarios = new List<Entity.Usuario>();
            try
            {
                oConn.Open();
                oDr = oComm.ExecuteReader();

                while (oDr.Read())
                    usuarios.Add(MontarObjeto(oDr));
            }
            catch (Exception e)
            {
                new Log(e);
            }
            finally
            {
                oDr = null;
                oComm = null;
                oConn.Close();
            }

            return usuarios;
        }

        /// <summary>
        /// Consulta um registro da tabela Usuario
        /// </summary>
        /// <param name="Sql">Síntaxe Sql</param>
        /// <returns></returns>
        public Entity.Usuario Consultar(string Sql)
        {
            SqlConnection oConn = new SqlConnection(oConexao.ConexaoBancoDeDados);
            SqlCommand oComm = new SqlCommand(Sql, oConn);

            SqlDataReader oDr;

            Entity.Usuario usuario = new Entity.Usuario();
            try
            {
                oConn.Open();
                oDr = oComm.ExecuteReader();

                while (oDr.Read())
                    usuario = MontarObjeto(oDr);
            }
            catch (Exception e)
            {
                new Log(e);
            }
            finally
            {
                oDr = null;
                oComm = null;
                oConn.Close();
            }

            return usuario;
        }

        /// <summary>
        /// Monta o objeto Entity.Usuario
        /// </summary>
        /// <param name="oDr">Linha de resultado do banco de dados</param>
        /// <returns></returns>
        private Entity.Usuario MontarObjeto(SqlDataReader oDr)
        {
            Entity.Usuario usuario = new Entity.Usuario();

            if (Coluna(oDr, "IDUsuario")) usuario.IDUsuario = (int)oDr["IDUsuario"];
            if (Coluna(oDr, "Nome")) usuario.Nome = oDr["Nome"].ToString();
            if (Coluna(oDr, "Login")) usuario.Login = oDr["Login"].ToString();
            if (Coluna(oDr, "Senha")) usuario.Senha = oDr["Senha"].ToString();
            if (Coluna(oDr, "Apartamento")) usuario.Apartamento = (int)oDr["Apartamento"];
            if (Coluna(oDr, "Torre")) usuario.Torre = oDr["Torre"].ToString();
            if (Coluna(oDr, "DataInclusao")) usuario.DataInclusao = (DateTime)oDr["DataInclusao"];

            return usuario;
        }
    }
}