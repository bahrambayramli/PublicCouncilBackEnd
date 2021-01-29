<%@ Page Title="" Language="C#" MasterPageFile="~/subsite/Subdomain.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="PublicCouncilBackEnd.subsite.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="sublayout" runat="server">
    <!-- Start  Sliders  -->
    <section class="site-sliders mb-3">
        <div class="container-fluid p-0">
            <div class="row">
                <div class="col col-12">
                    <asp:ListView ID="MAINSLIDER_AZ" runat="server">
                        <LayoutTemplate>
                            <div class="main-slider">
                                <div class="owl-main owl-carousel owl-theme rounded overflow-hidden">
                                    <asp:PlaceHolder ID="itemplaceholder" runat="server"></asp:PlaceHolder>
                                </div>
                            </div>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <div class="slider-item">
                                <img src="/images/<%#Eval("POST_IMG")%>" alt="/<%#Eval("POST_SEOAZ")%>" />
                                <div class="slider-caption">
                                    <span class="btn btn-sm btn-round slider-time">
                                        <i class="far fa-calendar-alt"></i>
                                        <%#Eval("POST_DATE").ToString().Substring(0, Eval("POST_DATE").ToString().Length - 3).Replace("/",".")%>
                                    </span>
                                    <h2 class="slider-title">
                                        <%#Eval("POST_AZ_TITLE")%>
                                    </h2>
                                    <a class="caption-link" href="/site/details/az/<%#Eval("DATA_ID")%>" title="<%#Eval("POST_SEOAZ")%>"></a>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:ListView>

                    <asp:ListView ID="MAINSLIDER_EN" runat="server">
                        <LayoutTemplate>
                            <div class="main-slider">
                                <div class="owl-main owl-carousel owl-theme rounded overflow-hidden">
                                    <asp:PlaceHolder ID="itemplaceholder" runat="server"></asp:PlaceHolder>
                                </div>
                            </div>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <div class="slider-item">
                                <img src="/images/<%#Eval("POST_IMG")%>" alt="<%#Eval("POST_SEOEN")%>" />
                                <div class="slider-caption">
                                    <span class="btn btn-sm btn-round slider-time">
                                        <i class="far fa-calendar-alt"></i>
                                        <%#Eval("POST_DATE").ToString().Substring(0, Eval("POST_DATE").ToString().Length - 3).Replace("/",".")%>
                                    </span>
                                    <h2 class="slider-title">
                                        <%#Eval("POST_EN_TITLE")%>
                                    </h2>
                                    <a class="caption-link" href="/site/details/en/<%#Eval("DATA_ID")%>" title="<%#Eval("POST_SEOEN")%>"></a>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:ListView>

                    <script>
                        $(".owl-main").owlCarousel({
                            loop: true,
                            autoplay: true,
                            autoplayTimeout: 5000,
                            responsive: {
                                0: {
                                    items: 1,
                                },
                                600: {
                                    items: 1,
                                    nav: true,
                                }
                            },

                            dots: false,
                            autoplaySpeed: 2000,
                        });
                    </script>
                </div>

            </div>
        </div>
    </section>
    <!-- End Sliders  -->

    <!-- Start  Posts  -->

    <!-- Posts -->
    <section class="site-posts mb-2">
        <asp:ListView ID="SIMPLEPOSTS_AZ" runat="server">
            <LayoutTemplate>
                <div class="container-fluid p-0">
                    <div class="row">
                        <div class="col">
                            <a href="#" class="d-block text-default p-2 py-md-3 my-2 bg-white rounded shadow-sm post-block-title text-uppercase">
                                <i class="far fa-newspaper mr-2"></i>
                                Xəbərlər
                            </a>
                        </div>
                    </div>
                    <div class="row">
                        <asp:PlaceHolder ID="itemplaceholder" runat="server"></asp:PlaceHolder>
                    </div>
                </div>
            </LayoutTemplate>
            <ItemTemplate>
                <article class="col-12 col-md-6 d-flex align-items-stretch">
                    <div class="card mb-3 rounded post overflow-hidden">
                        <div class="post-header overflow-hidden">
                            <a href="/site/details/az/<%#Eval("DATA_ID")%>" class="d-block" title="">
                                <img src="/images/<%#Eval("POST_IMG")%>" class="post-img" alt="<%#Eval("POST_SEOAZ")%>">
                            </a>
                        </div>
                        <div class="d-flex justify-content-between py-2 px-2">
                            <a class="btn btn-sm btn-outline-default btn-round shadow-sm" href="/posts/az">
                                <%#Eval("POST_SITECATEGORYAZ")%>
                            </a>
                            <a class="btn btn-sm btn-outline-danger btn-round shadow-sm" href="<%#Eval("DATA_ID")%>">
                                <%#Eval("POST_DATE").ToString().Substring(0, Eval("POST_DATE").ToString().Length - 3).Replace("/",".")%>
                            </a>
                        </div>
                        <div class="card-body px-3 pt-0 font-weight-300">
                            <%#Eval("POST_AZ_TITLE")%>
                        </div>
                    </div>
                </article>
            </ItemTemplate>
        </asp:ListView>

        <asp:ListView ID="SIMPLEPOSTS_EN" runat="server">
            <LayoutTemplate>
                <div class="container-fluid p-0">
                    <div class="row">
                        <div class="col">
                            <a href="#" class="d-block text-default p-2 py-md-3 my-2 bg-white rounded shadow-sm post-block-title text-uppercase">
                                <i class="far fa-newspaper mr-2"></i>
                                News
                            </a>
                        </div>
                    </div>
                    <div class="row">
                        <asp:PlaceHolder ID="itemplaceholder" runat="server"></asp:PlaceHolder>
                    </div>
                </div>
            </LayoutTemplate>
            <ItemTemplate>
                <article class="col-12 col-md-6 d-flex align-items-stretch">
                    <div class="card mb-3 rounded post overflow-hidden">
                        <div class="post-header overflow-hidden">
                            <a href="/site/details/en/<%#Eval("DATA_ID")%>" class="d-block" title="">
                                <img src="/images/<%#Eval("POST_IMG")%>" class="post-img" alt="<%#Eval("POST_SEOEN")%>">
                            </a>
                        </div>
                        <div class="d-flex justify-content-between py-2 px-2">
                            <a class="btn btn-sm btn-outline-default btn-round shadow-sm" href="/posts/az">
                                <%#Eval("POST_SITECATEGORYEN")%>
                            </a>
                            <a class="btn btn-sm btn-outline-danger btn-round shadow-sm" href="<%#Eval("DATA_ID")%>">
                                <%#Eval("POST_DATE").ToString().Substring(0, Eval("POST_DATE").ToString().Length - 3).Replace("/",".")%>
                            </a>
                        </div>
                        <div class="card-body px-3 pt-0 font-weight-300">
                            <%#Eval("POST_EN_TITLE")%>
                        </div>
                    </div>
                </article>
            </ItemTemplate>
        </asp:ListView>
    </section>
</asp:Content>
