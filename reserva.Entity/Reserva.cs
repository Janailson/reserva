using System;

namespace reserva.Entity
{
    public class Reserva
    {
        public int IDReserva { get; set; }
        public int Usuario_ID { get; set; }
        public DateTime Data { get; set; }
        public string Espaco { get; set; }
        public DateTime DataInclusao { get; set; }
        public bool D_E_L_E_T_ { get; set; }
        public int R_E_C_D_E_L_ { get; set; }
    }
}