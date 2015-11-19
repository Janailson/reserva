using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace reserva.Data
{
    public class Reserva : Generica
    {
        /// <summary>
        /// Lista os registros da tabela Reserva
        /// </summary>
        /// <param name="Sql">Síntaxe Sql</param>
        /// <returns></returns>
        public List<Entity.Reserva> Listar(string Sql)
        {
            SqlConnection oConn = new SqlConnection(oConexao.ConexaoBancoDeDados);
            SqlCommand oComm = new SqlCommand(Sql, oConn);

            SqlDataReader oDr;

            List<Entity.Reserva> reservas = new List<Entity.Reserva>();
            try
            {
                oConn.Open();
                oDr = oComm.ExecuteReader();

                while (oDr.Read())
                    reservas.Add(MontarObjeto(oDr));
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

            return reservas;
        }

        /// <summary>
        /// Consulta um registro da tabela Reserva
        /// </summary>
        /// <param name="Sql">Síntaxe Sql</param>
        /// <returns></returns>
        public Entity.Reserva Consultar(string Sql)
        {
            SqlConnection oConn = new SqlConnection(oConexao.ConexaoBancoDeDados);
            SqlCommand oComm = new SqlCommand(Sql, oConn);

            SqlDataReader oDr;

            Entity.Reserva reserva = new Entity.Reserva();
            try
            {
                oConn.Open();
                oDr = oComm.ExecuteReader();

                while (oDr.Read())
                    reserva = MontarObjeto(oDr);
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

            return reserva;
        }

        /// <summary>
        /// Monta o objeto Entity.Reserva
        /// </summary>
        /// <param name="oDr">Linha de resultado do banco de dados</param>
        /// <returns></returns>
        private Entity.Reserva MontarObjeto(SqlDataReader oDr)
        {
            Entity.Reserva reserva = new Entity.Reserva();

            if (Coluna(oDr, "IDReserva")) reserva.IDReserva = (int)oDr["IDReserva"];
            if (Coluna(oDr, "Usuario_ID")) reserva.Usuario_ID = (int)oDr["Usuario_ID"];
            if (Coluna(oDr, "Data")) reserva.Data = (DateTime)oDr["Data"];
            if (Coluna(oDr, "Espaco")) reserva.Espaco = oDr["Espaco"].ToString();
            if (Coluna(oDr, "DataInclusao")) reserva.DataInclusao = (DateTime)oDr["DataInclusao"];
            if (Coluna(oDr, "D_E_L_E_T_")) reserva.D_E_L_E_T_ = (bool)oDr["D_E_L_E_T_"];
            if (Coluna(oDr, "R_E_C_D_E_L_")) reserva.R_E_C_D_E_L_ = (int)oDr["R_E_C_D_E_L_"];

            return reserva;
        }
    }
}