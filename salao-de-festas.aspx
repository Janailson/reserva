<%@ Page Title="Salão de Festas - Reserva - Condomínio Felicittá" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="salao-de-festas.aspx.cs" Inherits="reserva.salao_de_festas" %>

<asp:Content ID="alerta" runat="server" ContentPlaceHolderID="alerta">
    <div class="alert alert-danger top-general-alert">
        <span>Clique na <strong>data desejada</strong> para realizar ou cancelar um agendamento.</span>
    </div>
</asp:Content>

<asp:Content ID="migalha" runat="server" ContentPlaceHolderID="migalha">
    <li class="active">Salão de Festas</li>
</asp:Content>

<asp:Content ID="conteudo" runat="server" ContentPlaceHolderID="conteudo">
    <div class="main-header">
        <h2>Salão de Festas</h2>
        <em>clique na data desejada para realizar ou cancelar um agendamento</em>
    </div>

    <div class="main-content">
        <!-- WIDGET CALENDAR -->
        <div class="widget">
            <div class="widget-header">
                <h3><i class="fa fa-calendar"></i>Calendário</h3>
            </div>
            <div class="widget-content">
                <div class="calendar"></div>
            </div>
        </div>
        <!-- END WIDGET CALENDAR -->
    </div>
</asp:Content>

<asp:Content ID="footer" runat="server" ContentPlaceHolderID="footer">
    <script src="assets/js/jquery-ui/jquery-ui-1.10.4.custom.min.js"></script>
    <script src="assets/js/plugins/fullcalendar/fullcalendar.min.js"></script>
    <script src="assets/js/plugins/jquery-simplecolorpicker/jquery.simplecolorpicker.js"></script>
    <script src="assets/js/jna-calendar.js"></script>
    <script type="text/javascript">
        jQuery(function () {
            makeCalendar();
        });

        var json;
        var c;

        function makeCalendar() {
            $('.calendar').html('');
            $('.calendar').fullCalendar({
                header: {
                    left: 'none',
                    center: 'title',
                    right: 'prev, next, today'
                },
                dayClick: function (date, jsEvent, view, resourceObj) {
                    json = Ajax.Salao.Consultar(date);
                    if (json["error"]) {
                        if (json["code"] != "10") {
                            alert(json["message"]);
                            return;
                        }

                        c = confirm(json["message"]);
                        if (c == null || !c)
                            return;

                        json = Ajax.Salao.Cancelar(date);
                        if (json["error"]) {
                            alert(json["message"]);
                            return;
                        }

                        makeCalendar();
                        return;
                    }

                    c = confirm('Confirma agendamento para essa data?');
                    if (c == null || !c)
                        return;

                    json = Ajax.Salao.Reservar(date);
                    if (json["error"]) {
                        alert(json["message"]);
                        return;
                    }

                    makeCalendar();
                },
                eventClick: function (event, element) {
                    var date = event.start;
                    json = Ajax.Salao.Consultar(date);
                    if (json["error"]) {
                        if (json["code"] != "10") {
                            alert(json["message"]);
                            return;
                        }

                        c = confirm(json["message"]);
                        if (c == null || !c)
                            return;

                        json = Ajax.Salao.Cancelar(date);
                        if (json["error"]) {
                            alert(json["message"]);
                            return;
                        }

                        makeCalendar();
                        return;
                    }

                    c = confirm('Confirma agendamento para essa data?');
                    if (c == null || !c)
                        return;

                    json = Ajax.Salao.Reservar(date);
                    if (json["error"]) {
                        alert(json["message"]);
                        return;
                    }

                    makeCalendar();
                },
                editable: false,
                droppable: false,
                events: Ajax.Salao.Listar()
            });
        }
    </script>
</asp:Content>
