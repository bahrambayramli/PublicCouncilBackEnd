<%@ Page Title="" Language="C#" MasterPageFile="~/subsite/Subdomain.Master" AutoEventWireup="true" CodeBehind="contactus.aspx.cs" Inherits="PublicCouncilBackEnd.subsite.WebForm8" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="sublayout" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-12">
                <asp:HyperLink
                    ID="pageName"
                    runat="server"
                    CssClass="d-block text-white p-2 mb-2 bg-default rounded shadow-sm post-block-title text-center text-uppercase"
                    Style="font-size: 2rem">
                </asp:HyperLink>
            </div>
        </div>
        <div class="row">
            <div class="col-12">
                <div class="sub-tel">
                    <asp:Literal ID="subTel" runat="server"></asp:Literal>
                </div>
                <div class="sub-mob">
                    <asp:Literal ID="subMob" runat="server"></asp:Literal>
                </div>
                <div class="sub-email">
                    <asp:Literal ID="subEmail" runat="server"></asp:Literal>
                </div>
                <div class="sub-web">
                    <asp:Literal ID="subWeb" runat="server"></asp:Literal>
                </div>
            </div>
        </div>

    </div>
        <script src="/scripts/subsite.js"></script>
</asp:Content>
