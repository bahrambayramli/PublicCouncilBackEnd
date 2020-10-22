<%@ Page Title="" Language="C#" MasterPageFile="~/subsite/Subdomain.Master" AutoEventWireup="true" CodeBehind="aboutus.aspx.cs" Inherits="PublicCouncilBackEnd.subsite.WebForm9" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<%--    <link href="../content/css/argon-design-system.min.css" rel="stylesheet" />--%>
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
                    <div class="about-us">
                        <asp:Literal ID="aboususInfo" runat="server"></asp:Literal>
                    </div>
                </div>
            </div>
            
     </div>
</asp:Content>
