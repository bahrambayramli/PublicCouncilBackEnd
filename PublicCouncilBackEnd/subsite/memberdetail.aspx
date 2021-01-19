<%@ Page Title="" Language="C#" MasterPageFile="~/subsite/Subdomain.Master" AutoEventWireup="true" CodeBehind="memberdetail.aspx.cs" Inherits="PublicCouncilBackEnd.subsite.WebForm11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="sublayout" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-12">
                <asp:Image ID="memberImage" runat="server" CssClass="d-block w-100" />
            </div>
            <div class="col-12">
                <asp:Literal ID="memberNameSurname" runat="server"></asp:Literal>
            </div>
            <div class="col-12">
                <asp:Literal ID="memberDetail" runat="server"></asp:Literal>
            </div>
        </div>
    </div>
</asp:Content>
