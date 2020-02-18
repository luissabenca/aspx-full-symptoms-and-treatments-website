<%@ Page Title="" Language="C#" MasterPageFile="~/layoutAdmin.Master" AutoEventWireup="true" CodeBehind="usuarios.aspx.cs" Inherits="projeto_pp3.usuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">

        <h2>Usuários ativos</h2>

        <table class="striped">
            <thead>
                <tr>
                    <th>Índice</th>
                    <th>Nome</th>
                    <th>Email</th>
                    <th>Gerenciamento</th>
                </tr>
            </thead>

            <tbody>
                 <%=printar%>
            </tbody>
        </table>

        <h2>Usuários desativados</h2>

        <table class="striped">
            <thead>
                <tr>
                    <th>Índice</th>
                    <th>Nome</th>
                    <th>Email</th>
                    <th>Gerenciamento</th>
                </tr>
            </thead>

            <tbody> 
                <%=printar2%>

            </tbody> 
        </table>

    </div>

</asp:Content>
