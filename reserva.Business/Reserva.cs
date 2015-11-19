using System;
using System.Collections.Generic;
using System.Text;

namespace reserva.Business
{
    public class Reserva
    {
        #region SELECT

        public List<Entity.Reserva> ListarReserva(string Espaco)
        {
            string Sql = "SELECT * FROM reserva.Reserva WHERE D_E_L_E_T_=0 AND Espaco='" + Espaco + "'";
            return new Data.Reserva().Listar(Sql);
        }

        public Entity.Reserva ConsultarReserva(string Espaco, DateTime Data)
        {
            string Sql = "SELECT * FROM reserva.Reserva WHERE D_E_L_E_T_=0 AND Espaco='" + Espaco + "' AND Data='" + Data.ToString("yyyy-MM-dd") + "'";
            return new Data.Reserva().Consultar(Sql);
        }

        #endregion

        #region INSERT, UPDATE, DELETE

        public Entity.Retorno InserirReserva(Entity.Reserva reserva)
        {
            string Sql = "INSERT INTO reserva.Reserva (Usuario_ID,Data,Espaco) VALUES ('" + reserva.Usuario_ID + "','" + reserva.Data.ToString("yyyy-MM-dd") + "','" + reserva.Espaco + "')";
            return new Data.Reserva().Inserir(Sql);
        }

        public Entity.Retorno ExcluirReserva(object IDReserva)
        {
            string Sql = "UPDATE reserva.Reserva SET D_E_L_E_T_=1, R_E_C_D_E_L_=IDReserva WHERE IDReserva=" + IDReserva;
            return new Data.Reserva().Alterar(Sql);
        }

        #endregion
    }
}