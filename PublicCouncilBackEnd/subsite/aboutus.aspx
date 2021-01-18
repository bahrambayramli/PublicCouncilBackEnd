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
                        CssClass="d-block text-white p-2 mb-2 bg-default rounded shadow-sm post-block-title text-center text-uppercase" 
                        Style="font-size: 2rem">
                    </asp:HyperLink>
                </div>
            </div>
         <div class="row">
             <div class="col-12 tex">
                 <h2 class="text-default h3 text-center">
                      <asp:Literal ID="pcName" runat="server"></asp:Literal>
                 </h2>
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
