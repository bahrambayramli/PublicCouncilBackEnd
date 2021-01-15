﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="aboutus.aspx.cs" Inherits="PublicCouncilBackEnd.WebForm13" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainlayout" runat="server">
    <div class="container-fluid">
        <div class="row">
                <div class="col-12 px-md-1">
                    <asp:HyperLink ID="pageName" 
                        runat="server" 
                        CssClass="d-block text-default p-2 mb-2 bg-white rounded shadow-sm post-block-title text-center text-uppercase" 
                        Style="font-size: 2rem"></asp:HyperLink>
                </div>
            </div>
        <div class="row">
            <div class="col-12 px-md-1">
                <div class="about-us bg-white p-2 rounded shadow">
                    <asp:Literal ID="aboususInfo" runat="server"></asp:Literal>
                </div>
            </div>
        </div>

    </div>
</asp:Content>
