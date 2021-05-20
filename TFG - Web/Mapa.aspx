<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Mapa.aspx.cs" Inherits="TFG___Web.Mapa" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta name="viewport"
              content="width=device-width, initial-scale=1.0, user-scalable=no">
        <meta charset="UTF-8">
        <style type="text/css">
            html, body, #map_canvas {
                margin: 0;
                padding: 0;
                height: 100%;
            }
        </style>
        <script type="text/javascript"
        src="http://maps.googleapis.com/maps/api/js?sensor=false&language=pt-br"></script>
        <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js" type="text/javascript"></script>
        <script src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8.18/jquery-ui.min.js" type="text/javascript"></script>
        <script type="text/javascript">
            var map;
            var polys = new Array();

            function initialize() {
                var myOptions = {
                    zoom: 8,
                    center: new google.maps.LatLng(-34.397, 150.644),
                    mapTypeId: google.maps.MapTypeId.ROADMAP,
                    streetViewControl: false
                };
                map = new google.maps.Map(document.getElementById('map_canvas'), myOptions);
                if (navigator.geolocation) {
                    navigator.geolocation.getCurrentPosition(function (position) {
                        console.log(position);
                        initialPosition = new google.maps.LatLng(position.coords.latitude, position.coords.longitude);
                        Load(initialPosition);
                    }, fail, {
                        enableHighAccuracy: true
                    })
                }

            }
            function fail() {
                console.log("Sem gps...");
            }
            function Load(position) {
                map.setZoom(18);
                map.panTo(initialPosition);
            }
            function addPoint(e) {
                if (polys.length)
                    console.log(polys[polys.length - 1].getPath().push(e.latLng));
            }
            function removePoint(e) {
                if (polys.length)
                    console.log(polys[polys.length - 1].getPath().pop());
            }
            function newPolygon() {
                var poly = new google.maps.Polygon({
                    map: map,
                    strokeColor: '#ff0000',
                    strokeOpacity: 0.8,
                    strokeWeight: 2,
                    fillColor: '#ff0000',
                    fillOpacity: 0.35,
                    editable: true
                });
                google.maps.event.addListener(map, 'click', addPoint);
                google.maps.event.addListener(map, 'rightclick', removePoint);
                polys.push(poly);
                map.draggableCursor = "crosshair";

            }
            function closePolygon() {

                google.maps.event.clearListeners(map, 'click');
                google.maps.event.clearListeners(map, 'rightclick');
                map.draggableCursor = "";
            }
            function salvarPolygon() {
                dados = "";
                for (var i = 0; i < polys[polys.length - 1].getPath().length; i++) {
                    if (dados != "") {
                        dados += "&";
                    }
                    dados += "lat" + i + "=" + polys[polys.length - 1].getPath().getAt(i).lat();
                    dados += "&long" + i + "=" + polys[polys.length - 1].getPath().getAt(i).lng();
                }
                alert(dados);
                $.ajax({
                    type: "POST",
                    url: "WebService.asmx/SalvarCoordenadas",
                    data: dados,
                    data: "{dados: '" + dados + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    beforeSend: function () {
                        alert("...");
                    },
                    success: function (json) {
                        var JSONObject = json.d;

                        if (JSONObject == "0")
                        {
                            alert("Erro ao incluir local!");
                        }
                        else 
                        {
                            alert("Inclusão efetuada com exito!");
                        }

                        window.location("PainelGerencial.aspx");
                    },
                    error: function (e) 
                    {
                        alert("erro:" + e.Text);
                    }
                });
            }

        </script>
        <style type="text/css">
            #maps_canvas
            {
                cursor: crosshair;
            }
        </style>
</head>
<body onload="initialize()">
    <%--<form id="form1" runat="server">--%>
    <div id="map_canvas"></div>
    <input type="button" Font-Strikeout="False" Font-Underline="False"  value="Nova Área" style="position:absolute;bottom: 20px;left:20px" onclick="newPolygon()" />
    <%--<input type="button" value="Fechou Aréa" style="position:absolute;bottom: 20px;left:120px" onclick="closePolygon()" />--%>
    <input type="button" Font-Strikeout="False" Font-Underline="False"  value="Salvar Área" style="position:absolute;bottom: 20px;left:240px" onclick="salvarPolygon()" />
   <%-- </form>--%>
</body>
</html>
