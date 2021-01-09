<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="PublicCouncilBackEnd.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainlayout" runat="server">

    <!-- Start  Sliders  -->
    <section class="site-sliders mb-2">
        <div class="container-fluid p-0">
            <div class="row">

                <div class="col col-12 col-md-8 px-md-1">

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
                                    <a class="caption-link" href="/details/az/<%#Eval("DATA_ID")%>" title="<%#Eval("POST_SEOAZ")%>"></a>
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
                                    <a class="caption-link" href="/details/en/<%#Eval("DATA_ID")%>" title="<%#Eval("POST_SEOEN")%>"></a>
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

                <div class="col col-12 col-md-4 pl-md-0">

                    <asp:ListView ID="RIGHTTOP_AZ" runat="server">
                        <LayoutTemplate>
                            <div class="owl-carousel owl-right-top ml-md-2 rounded overflow-hidden d-none d-md-block">
                                <asp:PlaceHolder ID="itemplaceholder" runat="server"></asp:PlaceHolder>
                            </div>
                        </LayoutTemplate>
                        <ItemTemplate>

                            <div class="slider-item">
                                <img src="/images/<%#Eval("POST_IMG")%>" alt="<%#Eval("POST_SEOAZ")%>" />
                                <div class="slider-caption">
                                    <span class="btn btn-sm btn-round slider-time">
                                        <i class="far fa-calendar-alt"></i>
                                        <%#Eval("POST_DATE").ToString().Substring(0, Eval("POST_DATE").ToString().Length - 3).Replace("/",".")%>
                                    </span>
                                    <h3 class="slider-title">
                                        <%#Eval("POST_SEOAZ")%>
                                    </h3>
                                    <a class="caption-link" title="<%#Eval("POST_SEOAZ")%>" href="/details/az/<%#Eval("DATA_ID")%>"></a>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:ListView>
                    <asp:ListView ID="RIGHTTOP_EN" runat="server">
                        <LayoutTemplate>
                            <div class="owl-carousel owl-right-top ml-md-2 rounded overflow-hidden d-none d-md-block">
                                <asp:PlaceHolder ID="itemplaceholder" runat="server"></asp:PlaceHolder>
                            </div>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <div class="slider-item">
                                <img src="/images/<%#Eval("POST_IMG")%>" alt="<%#Eval("POST_SEOEN")%>" />
                                <div class="slider-caption">
                                    <span class="slider-time btn btn-outline-warning btn-sm btn-round">
                                        <i class="far fa-calendar-alt"></i>
                                        <%#Eval("POST_DATE").ToString().Substring(0, Eval("POST_DATE").ToString().Length - 3).Replace("/",".")%>
                                    </span>
                                    <h3 class="slider-title">
                                        <%#Eval("POST_SEOEN")%>
                                    </h3>
                                    <a class="caption-link" title="<%#Eval("POST_SEOEN")%>" href="/details/en/<%#Eval("DATA_ID")%>"></a>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:ListView>

                    <asp:ListView ID="RIGHTBOTTOM_AZ" runat="server">
                        <LayoutTemplate>
                            <div class="owl-carousel owl-theme  mt-md-3 ml-md-2 owl-right-bottom rounded overflow-hidden d-none d-md-block">
                                <asp:PlaceHolder ID="itemplaceholder" runat="server"></asp:PlaceHolder>
                            </div>
                        </LayoutTemplate>
                        <ItemTemplate>

                            <div class="slider-item">
                                <img src="/images/<%#Eval("POST_IMG")%>" alt="<%#Eval("POST_SEOAZ")%>"  />
                                <div class="slider-caption">
                                    <span class="slider-time btn btn-outline-warning btn-sm btn-round">
                                        <i class="far fa-calendar-alt"></i>
                                        <%#Eval("POST_DATE").ToString().Substring(0, Eval("POST_DATE").ToString().Length - 3).Replace("/",".")%>
                                    </span>
                                    <h3 class="slider-title">
                                        <%#Eval("POST_SEOAZ")%>
                                    </h3>
                                    <a class="caption-link" title="<%#Eval("POST_SEOAZ")%>" href="/details/az/<%#Eval("DATA_ID")%>"></a>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:ListView>
                    <asp:ListView ID="RIGHTBOTTOM_EN" runat="server">
                        <LayoutTemplate>
                            <div class="owl-carousel owl-theme  mt-md-3 ml-md-2 owl-right-bottom rounded overflow-hidden d-none d-md-block">
                                <asp:PlaceHolder ID="itemplaceholder" runat="server"></asp:PlaceHolder>
                            </div>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <div class="slider-item">
                                <img src="/images/<%#Eval("POST_IMG")%>" alt="<%#Eval("POST_SEOEN")%>" />
                                <div class="slider-caption">
                                    <span class="slider-time btn btn-outline-warning btn-sm btn-round">
                                        <i class="far fa-calendar-alt"></i>
                                        <%#Eval("POST_DATE").ToString().Substring(0, Eval("POST_DATE").ToString().Length - 3).Replace("/",".")%>
                                    </span>
                                    <h3 class="slider-title">
                                        <%#Eval("POST_SEOEN")%>
                                    </h3>
                                    <a class="caption-link" title="<%#Eval("POST_SEOEN")%>" href="/details/en/<%#Eval("DATA_ID")%>"></a>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:ListView>

                </div>

            </div>
        </div>
    </section>

    <!-- Start  Posts  -->
    <section class="site-posts mb-2">
        <asp:ListView ID="SIMPLEPOSTS_AZ" runat="server">
            <LayoutTemplate>
                <div class="container-fluid p-0">
                    <div class="row">
                        <div class="col-12 px-md-1">
                            <a href="#" class="d-block text-default p-2 py-md-3 my-2 bg-white rounded shadow-sm post-block-title">
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
                <article class="col-12 col-md-6 col-xl-4 d-flex align-items-stretch p-md-1">
                    <div class="card mb-2 rounded post overflow-hidden">
                        <div class="post-header overflow-hidden">
                            <a href="/details/az/<%#Eval("DATA_ID")%>" class="d-block" title="">
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
                        <div class="col-12 px-md-1">
                            <a href="#" class="d-block text-default p-2 py-md-3 my-2 bg-white rounded shadow-sm post-block-title">
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
                <article class="col-12 col-md-6 col-xl-4 d-flex align-items-stretch p-md-1">
                    <div class="card mb-2 rounded post overflow-hidden">
                        <div class="post-header overflow-hidden">
                            <a href="/details/en/<%#Eval("DATA_ID")%>" class="d-block" title="">
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

    <!-- All  Posts  -->
    <section class="all-news text-center mb-2">
        <asp:LinkButton ID="allPosts" runat="server" CssClass="btn btn-warning btn-round  text-uppercase">
            bütün Xeberler
        </asp:LinkButton>
    </section>

    <!-- Publications -->
    <section class="site-posts mb-2">
        <asp:ListView ID="PUBLICATIONS_AZ" runat="server">
            <LayoutTemplate>
                <div class="container-fluid p-0">
                    <div class="row">
                        <div class="col-12 px-md-1">
                            <a href="#" class="d-block text-default p-2 py-md-3 my-2 bg-white rounded shadow-sm post-block-title">
                                <i class="fas fa-scroll mr-2"></i>
                                Nəşrlər
                            </a>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-12 px-md-1">
                            <div class="owl-carousel publications rounded overflow-hidden">
                                <asp:PlaceHolder ID="itemplaceholder" runat="server"></asp:PlaceHolder>
                            </div>
                        </div>
                    </div>
                </div>
            </LayoutTemplate>
            <ItemTemplate>
                <div class="publication-item">
                    <a class="rounded overflow-hidden" href="/details/az/<%#Eval("DATA_ID")%>" title="<%#Eval("POST_SEOAZ")%>">
                        <img class="publication-img" src="/images/<%#Eval("POST_IMG")%>" alt="<%#Eval("POST_SEOAZ")%>">
                    </a>
                </div>
            </ItemTemplate>
        </asp:ListView>
        <asp:ListView ID="PUBLICATIONS_EN" runat="server">
            <LayoutTemplate>
                <div class="container-fluid p-0">
                    <div class="row">
                        <div class="col-12 px-md-1">
                            <a href="#" class="d-block text-default p-2 py-md-3 my-2 bg-white rounded shadow-sm post-block-title">
                                <i class="fas fa-scroll mr-2"></i>
                                Publications
                            </a>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-12 px-md-1">
                            <div class="owl-carousel publications rounded overflow-hidden">
                                <asp:PlaceHolder ID="itemplaceholder" runat="server"></asp:PlaceHolder>
                            </div>
                        </div>
                    </div>
                </div>
            </LayoutTemplate>
            <ItemTemplate>
                <div class="publication-item">
                    <a class="rounded overflow-hidden" href="/details/en/<%#Eval("DATA_ID")%>" title="<%#Eval("POST_SEOEN")%>">
                        <img class="publication-img" src="/images/<%#Eval("POST_IMG")%>" alt="<%#Eval("POST_SEOEN")%>">
                    </a>
                </div>
            </ItemTemplate>
        </asp:ListView>
    </section>

    <!-- Reports -->
    <section class="site-posts mb-2">
        <asp:ListView ID="REPORTS_AZ" runat="server">
            <LayoutTemplate>
                <div class="container-fluid p-0">
                    <div class="row">
                        <div class="col-12 px-md-1">
                            <a href="#" class="d-block text-default p-2 py-md-3 my-2 bg-white rounded shadow-sm post-block-title">
                                <i class="far fa-flag mr-2"></i>
                                hesabatlar
                            </a>
                        </div>
                    </div>
                    <div class="row">
                        <asp:PlaceHolder ID="itemplaceholder" runat="server"></asp:PlaceHolder>
                    </div>
                </div>
            </LayoutTemplate>
            <ItemTemplate>
                <article class="col-md-6 d-flex align-items-stretch px-md-1">

                    <a href="/details/az/<%#Eval("DATA_ID")%>" class="d-block irem btn btn-outline-default my-1 w-100" title="<%#Eval("POST_SEOAZ") %>">
                        <div class="container-fluid">
                            <div class="row">
                                <div class="col-3">
                                    <%#Eval("POST_DATE").ToString().Substring(0, Eval("POST_DATE").ToString().Length - 3).Replace("/",".")%>
                                </div>
                                <div class="col-9 text-left">
                                    <%#Eval("POST_AZ_TITLE") %>
                                </div>
                            </div>
                        </div>
                    </a>

                </article>
            </ItemTemplate>
        </asp:ListView>
        <asp:ListView ID="REPORTS_EN" runat="server">
            <LayoutTemplate>
                <div class="container-fluid p-0">
                    <div class="row">
                        <div class="col-12 px-md-1">
                            <a href="#" class="d-block text-default p-2 py-md-3 my-2 bg-white rounded shadow-sm post-block-title">
                                <i class="far fa-flag mr-2"></i>
                                reports
                            </a>
                        </div>
                    </div>
                    <div class="row">
                        <asp:PlaceHolder ID="itemplaceholder" runat="server"></asp:PlaceHolder>
                    </div>
                </div>
            </LayoutTemplate>
            <ItemTemplate>
                <article class="col-md-6 d-flex align-items-stretch px-md-1">

                    <a href="/details/en/<%#Eval("DATA_ID")%>" class="d-block irem btn btn-outline-default my-1 w-100" title="<%#Eval("POST_SEOEN") %>">
                        <div class="container-fluid">
                            <div class="row">
                                <div class="col-3">
                                    <%#Eval("POST_DATE").ToString().Substring(0, Eval("POST_DATE").ToString().Length - 3).Replace("/",".")%>
                                </div>
                                <div class="col-9 text-left">
                                    <%#Eval("POST_SEOEN") %>
                                </div>
                            </div>

                        </div>
                    </a>

                </article>
            </ItemTemplate>
        </asp:ListView>
    </section>

</asp:Content>
