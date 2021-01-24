<%@ Page Title="" Language="C#" MasterPageFile="~/subsite/Subdomain.Master" AutoEventWireup="true" CodeBehind="aboutus.aspx.cs" Inherits="PublicCouncilBackEnd.subsite.WebForm9" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="sublayout" runat="server">
     <div class="container-fluid">
            <div class="row">
                <div class="col-12">
                    <asp:HyperLink 
                        ID="pageName" 
                        runat="server" 
                        CssClass="d-block bg-white rounded shadow-sm text-center text-default text-uppercase p-2 my-2 px-md-1 page-name">
                    </asp:HyperLink>
                </div>
            </div>

            <div class="row">
                <div class="col-12">
                    <div class="about-us">
                        <asp:Literal ID="aboususInfo" runat="server"></asp:Literal>
                    </div>
                </div>
            </div>
            
     </div>
    <script src="/scripts/subsite.js"></script>
</asp:Content>
