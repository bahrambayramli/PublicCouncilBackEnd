<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="posts.aspx.cs" Inherits="PublicCouncilBackEnd.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainlayout" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-12">
                <asp:HyperLink ID="postsName" runat="server" CssClass="d-block text-white p-2 my-2 bg-default rounded shadow-sm post-block-title text-center text-uppercase" Font-Size="2rem"></asp:HyperLink>
            </div>
        </div>
        <div class="row">
            
          
        </div>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server" class="row">
            <ContentTemplate>
                <asp:ListView ID="POSTLIST_AZ" runat="server">
                    <ItemTemplate>
                        <article class="col-md-4 d-flex align-items-stretch">

                            <div class="card mb-3 rounded post overflow-hidden">
                                <div class="post-header overflow-hidden">
                                    <a href="#" class="d-block">
                                        <img src="/images/<%#Eval("POST_IMG")%>" class="post-img"  alt="<%#Eval("POST_SEOAZ")%>">
                                    </a>
                                </div>
                                <div class="d-flex justify-content-between py-2 px-2">
                                    <a class="btn btn-sm btn-outline-default btn-round shadow-sm" href="#">Xeberler</a>
                                    <a class="btn btn-sm btn-outline-danger btn-round shadow-sm"  href="#">05/09/2020 15:15</a>
                                </div>
                                <div class="card-body px-3 pt-0 font-weight-300">
                                    <%#Eval("POST_AZ_TITLE")%>
                                </div>
                            </div>

                        </article>
                    </ItemTemplate>
                </asp:ListView>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div class="row">
            <div class="col-12">
                <nav aria-label="Page navigation example">
                    <ul class="pagination pagination-danger justify-content-start">
                        <li class="page-item disabled">
                            <a class="page-link" href="#" tabindex="-1">
                                <i class="fa fa-angle-left"></i>
                                <span class="sr-only">Previous</span>
                            </a>
                        </li>
                        <li class="page-item"><a class="page-link" href="#">1</a></li>
                        <li class="page-item active"><a class="page-link" href="#">2</a>
                        </li>
                        <li class="page-item"><a class="page-link" href="#">3</a></li>
                        <li class="page-item">
                            <a class="page-link" href="#">
                                <i class="fa fa-angle-right"></i>
                                <span class="sr-only">Next</span>
                            </a>
                        </li>
                    </ul>
                </nav>
            </div>
        </div>
    </div>
</asp:Content>
