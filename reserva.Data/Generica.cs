using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace reserva.Data
{
    public class Generica
    {
        protected Conexao oConexao = new Conexao();
        protected string ConnectionString;

        public Generica() { this.ConnectionString = oConexao.ConexaoBancoDeDados; }

        /// <summary>
        /// Verifica se o campo está explícito na instrução Sql
        /// </summary>
        /// <param name="oDr">DataReader</param>
        /// <param name="Campo">Nome do Campo</param>
        /// <returns></returns>
        public bool Coluna(SqlDataReader oDr, string Campo)
        {
            for (int i = 0; i < oDr.FieldCount; i++)
            {
                string nome = oDr.GetName(i);
                if (oDr.GetName(i) == Campo)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Insere um novo registro
        /// </summary>
        /// <param name="Sql">Síntaxe Sql</param>
        /// <returns></returns>
        public Entity.Retorno Inserir(string Sql)
        {
            SqlConnection oConn = new SqlConnection(ConnectionString);
            SqlCommand oComm = new SqlCommand(Sql + "; SELECT @@IDENTITY as 'Identity'", oConn);

            SqlDataReader oDr;

            Entity.Retorno retorno = new Entity.Retorno();
            try
            {
                oConn.Open();
                oDr = oComm.ExecuteReader();
                oDr.Read();

                retorno.Status = true;
                retorno.Erro = "";
                retorno.Identity = Convert.ToInt32(oDr["Identity"]);
            }
            catch (Exception e)
            {
                new Log(e, Sql);
                retorno.Status = false;
                retorno.Erro = e.Message;
                retorno.Identity = 0;
            }
            finally
            {
                oDr = null;
                oComm = null;
                oConn.Close();
            }

            return retorno;
        }

        /// <summary>
        /// Altera ou remove um registro
        /// </summary>
        /// <param name="Sql">Síntaxe Sql</param>
        /// <returns></returns>
        public Entity.Retorno Alterar(string Sql)
        {
            SqlConnection oConn = new SqlConnection(ConnectionString);
            SqlCommand oComm = new SqlCommand(Sql, oConn);

            Entity.Retorno retorno = new Entity.Retorno();
            try
            {
                oConn.Open();
                oComm.ExecuteNonQuery();

                retorno.Status = true;
                retorno.Erro = "";
                retorno.Identity = 0;
            }
            catch (Exception e)
            {
                new Log(e, Sql);
                retorno.Status = false;
                retorno.Erro = e.Message;
                retorno.Identity = 0;
            }
            finally
            {
                oComm = null;
                oConn.Close();
            }

            return retorno;
        }

        /// <summary>
        /// Formata data, caso não tenha no banco, retorna valor mínimo de DateTime
        /// </summary>
        /// <param name="Data">Campo de Data</param>
        /// <returns></returns>
        public DateTime FormatarData(object Data)
        {
            return (String.IsNullOrEmpty(Data.ToString())) ? DateTime.MinValue : Convert.ToDateTime(Data);
        }

        /// <summary>
        /// Formata data em formato americano caso seja preenchido, senão retorna null
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        public string FormatarData2(DateTime Data)
        {
            return (Data == DateTime.MinValue) ? "null" : "'" + Data.ToString("yyyy-MM-dd") + "'";
        }
    }
}