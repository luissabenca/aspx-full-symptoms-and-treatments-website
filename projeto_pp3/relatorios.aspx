<%@ Page Title="" Language="C#" MasterPageFile="~/layoutAdmin.Master" AutoEventWireup="true" CodeBehind="relatorios.aspx.cs" Inherits="projeto_pp3.relatorios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="Scripts/Chart.bundle.min.js"></script>
    <script src="Content/relatorios.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h3><a href="buscaAdmin.aspx">Busca de tratamentos por sintomas</a></h3>      

    <h3><a href="buscaAdmin.aspx">Busca de sintomas por tratamentos</a></h3>

    <h3><a href="buscaLog.aspx">Quantidade de buscas por sintomas</a></h3>

    <h3><a href="">Gráfico de buscas por sintomas</a></h3>

            <canvas id="myChart" width="300" height="100"></canvas>
            <script>
            var ctx = document.getElementById("myChart").getContext('2d');
            var myChart = new Chart(ctx, {
                type: 'doughnut',
                data: {
                    labels: [<%=nomes%>],
                    datasets: [{
                        data: [<%=dados%>],
                        backgroundColor: [
                            <%=cores%>
                        ],
                        borderColor: [
                            <%=coresBordas%>
                        ],
                        borderWidth: 1
                    }]
                }
            });
            </script>


    <h3><a href="avaliacaoAdmin.aspx">Relatório de medição de satisfação dos clientes que usam o sistema</a></h3>

</asp:Content>
