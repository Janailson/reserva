using System;

namespace reserva.Entity
{
    public class Usuario
    {
        public int IDUsuario { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public int Apartamento { get; set; }
        public string Torre { get; set; }
        public DateTime DataInclusao { get; set; }
    }
}