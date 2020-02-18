<%@ Page Title="" Language="C#" MasterPageFile="~/layoutAdmin.Master" AutoEventWireup="true" CodeBehind="informacoes.aspx.cs" Inherits="projeto_pp3.informacoes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="Content/loginAdmin.css" />
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Label ID="lblSucesso" runat="server" Font-Bold="True" Font-Size="30px" ForeColor="Green"></asp:Label>

    <div class="row">

        <div class="col s6 offset-s3 z-depth-1" id="panell">
            <h5 id="title">Adicionar sintoma</h5>

            <asp:Label ID="lblErro1" runat="server" Font-Bold="True" Font-Size="30px" ForeColor="Red"></asp:Label>

            <div class="input-field" id="username">
                <asp:TextBox ID="txtNomeSintoma" placeholder="Nome do sintoma" runat="server"></asp:TextBox>
            </div>
            <div class="input-field" id="password">
                <asp:TextBox ID="txtDescricaoSintoma" placeholder="Descrição do sintoma" runat="server"></asp:TextBox>
            </div>

            <asp:Button ID="btnSintoma" runat="server" BackColor="#004D40" CssClass="waves-effect waves-light btn" Text="Adicionar" OnClick="btnSintoma_Click" />



        </div>
    </div>

    <div class="row">

        <div class="col s6 offset-s3 z-depth-1" id="panell">
            <h5 id="title">Adicionar tratamento</h5>

            <asp:Label ID="lblErro2" runat="server" Font-Bold="True" Font-Size="30px" ForeColor="Red"></asp:Label>

            <div class="input-field" id="username">
                <asp:TextBox ID="txtNomeTratamento" placeholder="Nome do tratamento" runat="server"></asp:TextBox>
            </div>
            <div class="input-field" id="password">
                <asp:TextBox ID="txtDescricaoTratamento" placeholder="Descrição do tratamento" runat="server"></asp:TextBox>
            </div>

            <asp:Button ID="btnTratamento" runat="server" BackColor="#004D40" CssClass="waves-effect waves-light btn" Text="Adicionar" OnClick="btnTratamento_Click" />



        </div>
    </div>

    <div class="row">

        <div class="col s6 offset-s3 z-depth-1" id="panell">
            <h5 id="title">Adicionar relação</h5>

            <asp:Label ID="lblErro3" runat="server" Font-Bold="True" Font-Size="30px" ForeColor="Red"></asp:Label>

            <div class="input-field" id="username">
                <asp:TextBox ID="txtSintoma" placeholder="Nome do sintoma" runat="server"></asp:TextBox>
            </div>
            <div class="input-field" id="password">
                <asp:TextBox ID="txtTratamento" placeholder="Nome do tratamento" runat="server"></asp:TextBox>
            </div>

            <asp:Button ID="btnRelacao" runat="server" BackColor="#004D40" CssClass="waves-effect waves-light btn" Text="Adicionar" OnClick="btnRelacao_Click" />



        </div>
    </div>

</asp:Content>
