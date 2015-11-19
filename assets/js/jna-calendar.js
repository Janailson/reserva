// ESPAÇOS
var salao = "Salão de Festas";
var churrasqueira1 = "Churrasqueira 1";
var churrasqueira2 = "Churrasqueira 2";

// COMANDOS
var LISTAR = "listar";
var CONSULTAR = "consultar";
var RESERVAR = "reservar";
var CANCELAR = "cancelar";

// AJAX
var Ajax = {
    Request: function () {
        var valor = $.ajax({
            type: "POST",
            url: "/reserva/server.aspx",
            dataType: "text",
            data: arguments[0],
            global: true,
            async: false,
            cache: false
        }).responseText;
        return valor;
    },
    Salao: {
        Listar: function () {
            var json = eval('(' + Ajax.Request({ espaco: salao, act: LISTAR }) + ')');
            return json;
        },
        Consultar: function () {
            var json = eval('(' + Ajax.Request({ espaco: salao, act: CONSULTAR, data: arguments[0] }) + ')');
            return json;
        },
        Reservar: function () {
            var json = eval('(' + Ajax.Request({ espaco: salao, act: RESERVAR, data: arguments[0] }) + ')');
            return json;
        },
        Cancelar: function () {
            var json = eval('(' + Ajax.Request({ espaco: salao, act: CANCELAR, data: arguments[0] }) + ')');
            return json;
        }
    },
    Churrasqueira1: {
        Listar: function () {
            var json = eval('(' + Ajax.Request({ espaco: churrasqueira1, act: LISTAR }) + ')');
            return json;
        },
        Consultar: function () {
            var json = eval('(' + Ajax.Request({ espaco: churrasqueira1, act: CONSULTAR, data: arguments[0] }) + ')');
            return json;
        },
        Reservar: function () {
            var json = eval('(' + Ajax.Request({ espaco: churrasqueira1, act: RESERVAR, data: arguments[0] }) + ')');
            return json;
        },
        Cancelar: function () {
            var json = eval('(' + Ajax.Request({ espaco: churrasqueira1, act: CANCELAR, data: arguments[0] }) + ')');
            return json;
        }
    },
    Churrasqueira2: {
        Listar: function () {
            var json = eval('(' + Ajax.Request({ espaco: churrasqueira2, act: LISTAR }) + ')');
            return json;
        },
        Consultar: function () {
            var json = eval('(' + Ajax.Request({ espaco: churrasqueira2, act: CONSULTAR, data: arguments[0] }) + ')');
            return json;
        },
        Reservar: function () {
            var json = eval('(' + Ajax.Request({ espaco: churrasqueira2, act: RESERVAR, data: arguments[0] }) + ')');
            return json;
        },
        Cancelar: function () {
            var json = eval('(' + Ajax.Request({ espaco: churrasqueira2, act: CANCELAR, data: arguments[0] }) + ')');
            return json;
        }
    }
}