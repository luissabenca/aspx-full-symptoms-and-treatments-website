<%@ Page Title="" Language="C#" MasterPageFile="~/layout.Master" AutoEventWireup="true" CodeBehind="busca.aspx.cs" Inherits="projeto_pp3.busca" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="Content/login.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">

        <div class="col s8 offset-s2 z-depth-1" id="panell">
            <h5 id="title">Busca</h5>

            <div class="input-field col s10 offset-s1" id="termoBusca">
                <asp:TextBox ID="txtBusca" placeholder="Sintoma" runat="server"></asp:TextBox>
            </div>

            <br />

            <asp:Button ID="btnBusca" runat="server" BackColor="#0097A7" CssClass="waves-effect waves-light btn" Text="Buscar" OnClick="btnBusca_Click" />

        </div>

        <div class="col s10 offset-s1 z-depth-1" id="panell">

            <%=printar%>

        </div>

    </div>


</asp:Content>
