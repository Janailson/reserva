<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="reserva._Default" %>

<asp:Content ID="conteudo" runat="server" ContentPlaceHolderID="conteudo">
    <div class="main-header">
        <h2>Agendamento</h2>
        <em>regras</em>
    </div>

    <div class="main-content">
        <!-- WIDGET CALENDAR -->
        <div class="widget">
            <div class="widget-header">
                <h3><i class="fa fa-info-circle"></i>Regras</h3>
            </div>
            <div class="widget-content">
                <ol>
                    <li>Qualquer condômino pode realizar um agendamento.</li>
                    <li>O condômino pode realizar no máximo 2 reservas de cada espaço por vez.</li>
                    <li>O condômino não pode reservar 2 espaços para o mesmo dia.</li>
                    <li>Cada unidade pode ter apenas 1 (um) único login de acesso.</li>
                    <li>Cada solicitação de agendamento e/ou cancelamento é armazenado em Log. Portanto, reservar o espaço e ficar cancelando consecutivamente afim de impedir que outros condôminos façam a reserva, será passível de punição.</li>
                    <li>O sistema impede que seja feito reserva para datas anteriores ou igual à hoje.</li>
                    <li>O sistema só permite cancelamento de uma reserva com no mínimo 2 dias de antecedência.</li>
                    <li style="color: #f00; font-weight: bold">IMPORTANTE: As regras acima, foram escritas somente como esboço. De todos os itens citados, a ferramente de fato faz apenas os itens 1 e 5. Se a ideia for apreciada por todos, podemos discutir as regras e passar para o síndico e a administradora, para que possamos efetivar essa ferramenta ao invés de fazer a marcação na portaria.<br />
                        <br />
                        Outro ponto importante, a ferramenta não terá custo nenhum para o condomínio. O mesmo será hospedado em meu domínio (ou podemos registrar um domínio próprio ao custo de 30 reais por ano). Se decidido criar um domínio, ainda não teremos custo de hospedagem e banco de dados, pois eu possuo uma e posso deixar lá.<br />
                        <br />
                        O objetivo dessa ferramenta, é facilitar e agilizar o processo de reserva dos espaços de nosso condomínio. E acredito que facilitará o controle do Síndico, Zelador, Portaria e Administração. Já que papel pode ser rasurado, danificado e/ou perdido.
                    </li>
                </ol>
            </div>
        </div>
        <!-- END WIDGET CALENDAR -->
    </div>
</asp:Content>
