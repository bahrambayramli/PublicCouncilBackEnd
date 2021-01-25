<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="contactus.aspx.cs" Inherits="PublicCouncilBackEnd.WebForm14" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainlayout" runat="server">
    <div class="container-fluid p-0">
        <div class="row">
                <div class="col-12 px-md-1">
                    <asp:HyperLink ID="pageName" 
                        runat="server" 
                        CssClass="d-block bg-white rounded shadow-sm text-center text-default text-uppercase p-2 mb-2 px-md-1 page-name" 
                       ></asp:HyperLink>
                </div>
            </div>
        <div class="row">
            <div class="col-12 px-md-1">
                <div class="about-us bg-white p-2 rounded shadow">
                    <asp:Literal ID="contactUs" runat="server"></asp:Literal>
                </div>
            </div>
        </div>

    </div>
</asp:Content>
