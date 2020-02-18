<%@ Page Title="" Language="C#" MasterPageFile="~/layout.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="projeto_pp3.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="Content/login.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">

        <div class="col s6 offset-s3 z-depth-1" id="panell">
            <h5 id="title">Login/Cadastro</h5>

            <asp:Label ID="lblErro" runat="server" Font-Bold="True" Font-Size="20px" ForeColor="Red"></asp:Label>

            <div class="input-field" id="username">
                <asp:TextBox ID="txtEmail" placeholder="Email" runat="server"></asp:TextBox>
            </div>
            <div class="input-field" id="password">
                <asp:TextBox ID="txtSenha" placeholder="Senha" TextMode="Password" runat="server"></asp:TextBox>
            </div>

            <asp:Button ID="btnLogin" runat="server" BackColor="#0097A7" CssClass="waves-effect waves-light btn" OnClick="btnLogin_Click" Text="Login" />
            <asp:Button ID="btnCadastro" runat="server" BackColor="#0097A7" CssClass="waves-effect waves-light btn" OnClick="btnCadastro_Click" Text="Cadastro" />

        </div>
    </div>


</asp:Content>
