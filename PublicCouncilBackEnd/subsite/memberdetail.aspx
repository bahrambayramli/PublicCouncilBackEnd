<%@ Page Title="" Language="C#" MasterPageFile="~/subsite/Subdomain.Master" AutoEventWireup="true" CodeBehind="memberdetail.aspx.cs" Inherits="PublicCouncilBackEnd.subsite.WebForm11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/content/css/argon.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="sublayout" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-12">
                <div class="member-detail">
                    <div class="member-image-block">
                        <asp:Image ID="memberImage" runat="server" CssClass="member-image" />
                        <div class="member-wrapper">
                            <div class="member-position">
                                <asp:Literal ID="memberPosition" runat="server"></asp:Literal>
                            </div>
                            <div class="member-info">
                                <asp:Literal ID="memberNameSurname" runat="server"></asp:Literal>
                            </div>
                        </div>
                    </div>
                    <div class="member-about-block">
                        <asp:Literal ID="memberDetail" runat="server"></asp:Literal>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="/scripts/subsite.js"></script>
</asp:Content>
