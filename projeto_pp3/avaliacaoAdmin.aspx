<%@ Page Title="" Language="C#" MasterPageFile="~/layoutAdmin.Master" AutoEventWireup="true" CodeBehind="avaliacaoAdmin.aspx.cs" Inherits="projeto_pp3.contatoAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <table class="striped">
            <thead>
                <tr>
                    <th>Índice</th>
                    <th>Data</th>
                    <th>Nota</th>
                    <th>Mensagem</th>
                </tr>
            </thead>

            <tbody>
                <%=printar%>
            </tbody>

        </table>

    </div>

</asp:Content>
