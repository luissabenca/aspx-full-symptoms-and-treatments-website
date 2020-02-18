<%@ Page Title="" Language="C#" MasterPageFile="~/layoutAdmin.Master" AutoEventWireup="true" CodeBehind="indexAdmin.aspx.cs" Inherits="projeto_pratica3.indexAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Administração</h1>

    <div class="row">

        <div class="col s6">
            <div class="card grey darken-4">
                <div class="card-content white-text">
                    <span class="card-title" style="font-size:35px">Usuários</span>
                    <p style="font-size:20px">Usuários ativos:<asp:Label ID="lblUsuarios" runat="server"></asp:Label>
                    </p>
                </div>
                <div class="card-action">
                    <a href="usuarios.aspx">Mais informações</a>
                </div>
            </div>
        </div>

        <div class="col s6">
            <div class="card grey darken-4">
                <div class="card-content white-text">
                    <span class="card-title" style="font-size:35px">Avaliações</span>
                    <p style="font-size:20px">Média:<asp:Label ID="lblMedia" runat="server"></asp:Label>
                    </p>
                </div>
                <div class="card-action">
                    <a href="avaliacaoAdmin.aspx">Mais informações</a>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
