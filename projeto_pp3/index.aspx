<%@ Page Title="" Language="C#" MasterPageFile="~/layout.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="projeto_pratica3.index" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2 class="center-align">Bem vindo ao HomoPatus<%=usuario%>, o seu portal de Homeopatia e Fitoterapia!</h2>

    <br />

    <div class="row">

        <div class="col s9 offset-m1">
            <div class="card horizontal">
                <div class="card-stacked">
                    <div class="card-content">
                        <p style="font-size:25px">Avalie-nos para podermos melhorar o serviço!</p>
                    </div>
                    <div class="card-action">
                        <a href="avaliacao.aspx">Avalie-nos</a>
                    </div>
                </div>
            </div>
        </div>

        <div class="col s12 m12">
            <div class="card horizontal">
                <div class="card-stacked">
                    <div class="card-content">
                        <p style="font-size:25px">Mal estar? Sintomas incomodos? Pesquise-os aqui e iremos ajudá-lo com tratamentos.</p>
                    </div>
                    <div class="card-action">
                        <a href="busca.aspx">Busca</a>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
