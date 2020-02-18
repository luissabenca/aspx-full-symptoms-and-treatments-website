<%@ Page Title="" Language="C#" MasterPageFile="~/layout.Master" AutoEventWireup="true" CodeBehind="cadastro.aspx.cs" Inherits="projeto_pp3.cadastro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="Content/login.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">

        <div class="col s6 offset-s3 z-depth-1" id="panell">
            <h5 id="title">Cadastro</h5>

            <form>

                <div class="input-field" id="username">

                    <asp:Label ID="lblErro" runat="server" Font-Bold="True" Font-Size="30px" ForeColor="Red"></asp:Label>

                </div>

                <div class="input-field" id="username">
                    <asp:TextBox ID="txtNome" placeholder="Nome" runat="server"></asp:TextBox>
                </div>

                <div class="input-field" id="username">
                    <asp:TextBox ID="txtEmail" placeholder="Email" runat="server"></asp:TextBox>
                </div>

                <div class="input-field" id="username">
                    <asp:TextBox ID="txtDataNascimento" placeholder="Data de nascimento(DD/MM/AAAA)" runat="server"></asp:TextBox>
                </div>

                <div class="input-field" id="password">
                    <asp:TextBox ID="txtSenha" placeholder="Senha" runat="server" TextMode="Password"></asp:TextBox>
                </div>

                <div class="input-field" id="password">
                    <asp:TextBox ID="txtConfirmaSenha" placeholder="Confirmação da senha" runat="server" TextMode="Password"></asp:TextBox>
                </div>

            </form>

            <asp:Button ID="btnLogin" runat="server" BackColor="#0097A7" CssClass="waves-effect waves-light btn" OnClick="btnLogin_Click" Text="Login" />

            <asp:Button ID="btnCadastrar" runat="server" BackColor="#0097A7" CssClass="waves-effect waves-light btn" Text="Cadastrar" OnClick="btnCadastrar_Click" />

        </div>
    </div>


</asp:Content>
