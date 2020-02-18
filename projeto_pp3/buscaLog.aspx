<%@ Page Title="" Language="C#" MasterPageFile="~/layoutAdmin.Master" AutoEventWireup="true" CodeBehind="buscaLog.aspx.cs" Inherits="projeto_pp3.buscaLog" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <table class="striped">
            <thead>
                <tr>
                    <th>Índice</th>
                    <th>Termo</th>
                    <th>Vezes buscado</th>
                </tr>
            </thead>

            <tbody>
                <%=printar%>
            </tbody>

        </table>

    </div>

</asp:Content>
