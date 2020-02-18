<%@ Page Title="" Language="C#" MasterPageFile="~/layoutAdmin.Master" AutoEventWireup="true" CodeBehind="buscaAdmin.aspx.cs" Inherits="projeto_pp3.buscaAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link rel="stylesheet" href="Content/loginAdmin.css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="row">

        <div class="col s6 offset-s3 z-depth-1" id="panell">
            <h5 id="title">Tratamentos por sintomas</h5>

            <div class="input-field" id="username">
                <asp:TextBox ID="txtSintoma" placeholder="Sintoma" runat="server"></asp:TextBox>
            </div>

            <asp:Button ID="btnSintoma" runat="server" BackColor="#004D40" CssClass="waves-effect waves-light btn" Text="Buscar" OnClick="btnSintoma_Click1"/>



        </div>
    </div>

    <div class="col s10 offset-s1 z-depth-1" id="panell">

            <%=printar%>

    </div>

    <div class="row">

        <div class="col s6 offset-s3 z-depth-1" id="panell">
            <h5 id="title">Possíveis diagnósticos por tratamentos</h5>

            <div class="input-field" id="username">
                <asp:TextBox ID="txtTratamento" placeholder="Tratamento" runat="server"></asp:TextBox>
            </div>

            <asp:Button ID="btnTratamento" runat="server" BackColor="#004D40" CssClass="waves-effect waves-light btn" Text="Buscar" OnClick="btnTratamento_Click"/>



        </div>
    </div>

    <div class="col s10 offset-s1 z-depth-1" id="panell">

            <%=printar2%>

    </div>

</asp:Content>
