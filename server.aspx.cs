namespace reserva
{
    using System;
    using System.Data;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using System.Web.Script.Serialization;

    public partial class server : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            switch (Request["act"])
            {
                case "listar": Listar(); break;
                case "consultar": Consultar(); break;
                case "reservar": Reservar(); break;
                case "cancelar": Cancelar(); break;
            }
        }

        private void Listar()
        {
            List<Reserve> reserves = new List<Reserve>();

            new Business.Reserva().ListarReserva(Request["espaco"]).ForEach(delegate(Entity.Reserva reserva)
            {
                Reserve reserve = new Reserve();
                reserve.title = (reserva.Usuario_ID == usuario.IDUsuario) ? "MINHA RESERVA" : "RESERVADO";
                reserve.start = reserva.Data.ToString("yyyy-MM-dd");
                reserve.color = (reserva.Usuario_ID == usuario.IDUsuario) ? "#008" : "#800";

                reserves.Add(reserve);
            });

            Response.Write(new JavaScriptSerializer().Serialize(reserves));
        }

        private void Consultar()
        {
            try
            {
                Error error = new Error();
                string Data = Request["data"];
                Data = Data.Remove(Data.IndexOf("GMT"));
                Entity.Reserva reserva = new Business.Reserva().ConsultarReserva(Request["espaco"], Convert.ToDateTime(Data));

                if (reserva.IDReserva == 0)
                {
                    error.code = "0";
                    error.error = false;
                    error.message = "";

                    Response.Write(new JavaScriptSerializer().Serialize(error));
                    return;
                }
                else if (reserva.Usuario_ID != usuario.IDUsuario)
                {
                    error.code = "13";
                    error.error = true;
                    error.message = "Data agendada por outro usuário. Não é possível agendar.";

                    Response.Write(new JavaScriptSerializer().Serialize(error));
                    return;
                }

                error.code = "10";
                error.error = true;
                error.message = "Data agendada pelo usuário. Cancelar agendamento?";

                Response.Write(new JavaScriptSerializer().Serialize(error));
            }
            catch (ArgumentOutOfRangeException)
            {
                Error error = new Error();
                error.code = "1010";
                error.error = true;
                error.message = "Valor de Fuso Horário não encontrado.";

                Response.Write(new JavaScriptSerializer().Serialize(error));
            }
            catch (NullReferenceException)
            {
                Error error = new Error();
                error.code = "1030";
                error.error = true;
                error.message = "Sessão expirada, efetue o login novamente.";

                Response.Write(new JavaScriptSerializer().Serialize(error));
            }
            catch (FormatException)
            {
                Error error = new Error();
                error.code = "1050";
                error.error = true;
                error.message = "Data inválida.";

                Response.Write(new JavaScriptSerializer().Serialize(error));
            }
        }

        private void Reservar()
        {
            try
            {
                Error error = new Error();
                string Data = Request["data"];
                Data = Data.Remove(Data.IndexOf("GMT"));
                Entity.Reserva reserva = new Business.Reserva().ConsultarReserva(Request["espaco"], Convert.ToDateTime(Data));

                if (reserva.IDReserva > 0)
                {
                    if (reserva.Usuario_ID == usuario.IDUsuario)
                    {
                        error.code = "10";
                        error.error = true;
                        error.message = "Data agendada pelo usuário. Cancelar agendamento?";
                    }
                    else
                    {
                        error.code = "13";
                        error.error = true;
                        error.message = "Data agendada por outro usuário. Não é possível agendar.";
                    }

                    Response.Write(new JavaScriptSerializer().Serialize(error));
                    return;
                }
                
                reserva.Usuario_ID = usuario.IDUsuario;
                reserva.Data = Convert.ToDateTime(Data);
                reserva.Espaco = Request["espaco"];

                Entity.Retorno ret = new Business.Reserva().InserirReserva(reserva);
                if (!ret.Status)
                {
                    error.code = "1000";
                    error.error = true;
                    error.message = ret.Erro;

                    Response.Write(new JavaScriptSerializer().Serialize(error));
                    return;
                }

                error.code = "0";
                error.error = false;
                error.message = "";

                Response.Write(new JavaScriptSerializer().Serialize(error));
            }
            catch (ArgumentOutOfRangeException)
            {
                Error error = new Error();
                error.code = "1010";
                error.error = true;
                error.message = "Valor de Fuso Horário não encontrado.";

                Response.Write(new JavaScriptSerializer().Serialize(error));
            }
            catch (NullReferenceException)
            {
                Error error = new Error();
                error.code = "1030";
                error.error = true;
                error.message = "Sessão expirada, efetue o login novamente.";

                Response.Write(new JavaScriptSerializer().Serialize(error));
            }
            catch (FormatException)
            {
                Error error = new Error();
                error.code = "1050";
                error.error = true;
                error.message = "Data inválida.";

                Response.Write(new JavaScriptSerializer().Serialize(error));
            }
        }

        private void Cancelar()
        {
            try
            {
                Error error = new Error();
                string Data = Request["data"];
                Data = Data.Remove(Data.IndexOf("GMT"));
                Entity.Reserva reserva = new Business.Reserva().ConsultarReserva(Request["espaco"], Convert.ToDateTime(Data));

                Entity.Retorno ret = new Business.Reserva().ExcluirReserva(reserva.IDReserva);
                if (!ret.Status)
                {
                    error.code = "1000";
                    error.error = true;
                    error.message = ret.Erro;

                    Response.Write(new JavaScriptSerializer().Serialize(error));
                    return;
                }

                error.code = "0";
                error.error = false;
                error.message = "";

                Response.Write(new JavaScriptSerializer().Serialize(error));
            }
            catch (ArgumentOutOfRangeException)
            {
                Error error = new Error();
                error.code = "1010";
                error.error = true;
                error.message = "Valor de Fuso Horário não encontrado.";

                Response.Write(new JavaScriptSerializer().Serialize(error));
            }
            catch (NullReferenceException)
            {
                Error error = new Error();
                error.code = "1030";
                error.error = true;
                error.message = "Sessão expirada, efetue o login novamente.";

                Response.Write(new JavaScriptSerializer().Serialize(error));
            }
            catch (FormatException)
            {
                Error error = new Error();
                error.code = "1050";
                error.error = true;
                error.message = "Data inválida.";

                Response.Write(new JavaScriptSerializer().Serialize(error));
            }
        }

        public class Reserve
        {
            public string title { get; set; }
            public string start { get; set; }
            public string color { get; set; }
        }

        public class Error
        {
            public string code { get; set; }
            public bool error { get; set; }
            public string message { get; set; }
        }
    }
}