<%@ Page Title="" Language="C#" MasterPageFile="~/layout.Master" AutoEventWireup="true" CodeBehind="avaliacao.aspx.cs" Inherits="projeto_pp3.contato" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="Content/login.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">

        <div class="col s6 offset-s3 z-depth-1" id="panell">
            <h5 id="title">Avaliação</h5>

            <form>

                <asp:Label ID="lblErro" runat="server" Font-Bold="True" Font-Size="20px" ForeColor="Red"></asp:Label>

                <h4 class="col s10 offset-s1">Ajude-nos a melhorar o site!</h4>

                <div class="input-field" id="password">
                    <asp:TextBox ID="txtNota" placeholder="De uma nota de 0 a 10 para nós!" min="0" max="10" runat="server" TextMode="Number"></asp:TextBox>
                </div>

                <div class="input-field" id="username">
                    <asp:TextBox ID="txtMensagem" placeholder="Escreva uma mensagem com críticas/sugestões" runat="server"></asp:TextBox>
                </div>

            </form>

            <asp:Button ID="Button1" runat="server" CssClass="waves-effect waves-light btn" Text="Enviar" BackColor="#0097A7" OnClick="Button1_Click" />

            <asp:Label ID="lblAgradecimento" runat="server" Font-Size="30px" ForeColor="Lime"></asp:Label>

        </div>
    </div>


</asp:Content>
