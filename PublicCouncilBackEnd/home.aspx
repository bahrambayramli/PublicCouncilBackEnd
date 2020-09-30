<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="PublicCouncilBackEnd.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainlayout" runat="server">

    <!-- Start  Sliders  -->
    <section class="site-sliders mb-3">
        <div class="container-fluid p-0">
            <div class="row">
                <div class="col col-12 col-md-8 pr-md-1">
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
                                <img src="images/<%#Eval("POST_IMG")%>" alt="/<%#Eval("POST_SEOAZ")%>" />
                                <div class="slider-caption">
                                    <span class="btn btn-sm btn-round slider-time bg-white text-default ">
                                        <i class="far fa-calendar-alt"></i>
                                        <%#Eval("POST_DATE")%>
                                    </span>
                                    <h2 class="slider-title">
                                       <%#Eval("POST_AZ_TITLE")%>
                                    </h2>
                                    <a class="caption-link"  href="/details/az/<%#Eval("DATA_ID")%>"  title="<%#Eval("POST_SEOAZ")%>"></a>
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
                                <img src="/images/<%#Eval("POST_IMG")%>" alt="/<%#Eval("POST_SEOEN")%>" />
                                <div class="slider-caption">
                                    <span class="btn btn-sm btn-round slider-time bg-white text-default ">
                                        <i class="far fa-calendar-alt"></i>
                                        <%#Eval("POST_DATE")%>
                                    </span>
                                    <h2 class="slider-title">
                                       <%#Eval("POST_EN_TITLE")%>
                                    </h2>
                                    <a class="caption-link"  href="/details/az/<%#Eval("DATA_ID")%>"  title="<%#Eval("POST_SEOEN")%>"></a>
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
                            <div class="owl-carousel owl-right-top rounded overflow-hidden d-none d-md-block">
                                <asp:PlaceHolder ID="itemplaceholder" runat="server"></asp:PlaceHolder>
                            </div>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <div class="slider-item">
                                <img src="images/<%#Eval("POST_IMG")%>" alt="<%#Eval("POST_SEOAZ")%>" />
                                <div class="slider-caption">
                                    <span class="slider-time btn btn-outline-warning btn-sm btn-round">
                                        <i class="far fa-calendar-alt"></i>
                                        <%#Eval("POST_DATE")%>
                                    </span>
                                    <h3 class="slider-title">
                                        <%#Eval("POST_TITLE_AZ")%>
                                    </h3>
                                    <a class="caption-link" title=""<%#Eval("POST_SEOAZ")%>" href="/details/az/<%#Eval("DATA_ID")%>"></a>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:ListView>
                    <asp:ListView ID="RIGHTTOP_EN" runat="server">
                        <LayoutTemplate>
                            <div class="owl-carousel owl-right-top rounded overflow-hidden d-none d-md-block">
                                <asp:PlaceHolder ID="itemplaceholder" runat="server"></asp:PlaceHolder>
                            </div>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <div class="slider-item">
                                <img src="images/<%#Eval("POST_IMG")%>" alt="<%#Eval("POST_SEOEN")%>" />
                                <div class="slider-caption">
                                    <span class="slider-time btn btn-outline-warning btn-sm btn-round">
                                        <i class="far fa-calendar-alt"></i>
                                        <%#Eval("POST_DATE")%>
                                    </span>
                                    <h3 class="slider-title">
                                        <%#Eval("POST_TITLE_EN")%>
                                    </h3>
                                    <a class="caption-link" title=""<%#Eval("POST_SEOEN")%>" href="/details/en/<%#Eval("DATA_ID")%>"></a>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:ListView>

                    <asp:ListView ID="RIGHTBOTTOM_AZ" runat="server">
                        <LayoutTemplate>
                            <div class="owl-carousel owl-theme  mt-md-2 owl-right-bottom rounded overflow-hidden d-none d-md-block">
                                <asp:PlaceHolder ID="itemplaceholder" runat="server"></asp:PlaceHolder>
                            </div>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <div class="slider-item">
                                <img src="images/<%#Eval("POST_IMG")%>" alt="<%#Eval("POST_SEOAZ")%>" />
                                <div class="slider-caption">
                                    <span class="slider-time btn btn-outline-warning btn-sm btn-round">
                                        <i class="far fa-calendar-alt"></i>
                                        <%#Eval("POST_DATE")%>
                                    </span>
                                    <h3 class="slider-title">
                                        <%#Eval("POST_TITLE_AZ")%>
                                    </h3>
                                    <a class="caption-link" title=""<%#Eval("POST_SEOAZ")%>" href="/details/az/<%#Eval("DATA_ID")%>"></a>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:ListView>
                    <asp:ListView ID="RIGHTBOTTOM_EN" runat="server">
                        <LayoutTemplate>
                            <div class="owl-carousel owl-theme  mt-md-2 owl-right-bottom rounded overflow-hidden d-none d-md-block">
                                <asp:PlaceHolder ID="itemplaceholder" runat="server"></asp:PlaceHolder>
                            </div>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <div class="slider-item">
                                <img src="images/<%#Eval("POST_IMG")%>" alt="<%#Eval("POST_SEOEN")%>" />
                                <div class="slider-caption">
                                    <span class="slider-time btn btn-outline-warning btn-sm btn-round">
                                        <i class="far fa-calendar-alt"></i>
                                        <%#Eval("POST_DATE")%>
                                    </span>
                                    <h3 class="slider-title">
                                        <%#Eval("POST_TITLE_EN")%>
                                    </h3>
                                    <a class="caption-link" title=""<%#Eval("POST_SEOEN")%>" href="/details/en/<%#Eval("DATA_ID")%>"></a>
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
        <div class="container-fluid p-0">
            <div class="row">
                <div class="col">
                    <a href="#" class="d-block text-default p-2 my-2 bg-white rounded shadow-sm post-block-title">
                        <i class="far fa-newspaper mr-2"></i>
                        Xəbərlər
                    </a>
                </div>
            </div>
            <div class="row">
                <article class="col-md-4 d-flex align-items-stretch">

                    <div class="card mb-3 rounded post overflow-hidden" href="#">
                        <div class="post-header overflow-hidden">
                            <a href="#" class="d-block">
                                <img src="./images/test/ilhameliyev.jpg" class="post-img" alt="">
                            </a>
                        </div>
                        <div class="d-flex justify-content-between py-2 px-2">
                            <a class="btn btn-sm btn-outline-default btn-round shadow-sm" href="#">Xeberler</a>
                            <a class="btn btn-sm btn-outline-danger btn-round shadow-sm" href="#">05/09/2020
                                                        15:15</a>
                        </div>
                        <div class="card-body px-3 pt-0 font-weight-300">
                            Some quick example text to build on the card title and make up
                                                    the
                                                    bulk
                                                    of the card's content.

                        </div>
                    </div>

                </article>
                <article class="col-md-4 d-flex align-items-stretch">

                    <div class="card mb-3 rounded post overflow-hidden" href="#">
                        <div class="post-header overflow-hidden">
                            <a href="#" class="d-block">
                                <img src="./images/test/ilhameliyev.jpg" class="post-img" alt="">
                            </a>
                        </div>
                        <div class="d-flex justify-content-between py-2 px-2">
                            <a class="btn btn-sm btn-outline-default btn-round shadow-sm" href="#">Xeberler</a>
                            <a class="btn btn-sm btn-outline-danger btn-round shadow-sm" href="#">05/09/2020
                                                        15:15</a>
                        </div>
                        <div class="card-body px-3 pt-0 font-weight-300">
                            Some quick example text to build on the card title and make up
                                                    the
                                                    bulk
                                                    of the card's content.

                        </div>
                    </div>

                </article>
                <article class="col-md-4 d-flex align-items-stretch">

                    <div class="card mb-3 rounded post overflow-hidden" href="#">
                        <div class="post-header overflow-hidden">
                            <a href="#" class="d-block">
                                <img src="./images/test/ilhameliyev.jpg" class="post-img" alt="">
                            </a>
                        </div>
                        <div class="d-flex justify-content-between py-2 px-2">
                            <a class="btn btn-sm btn-outline-default btn-round shadow-sm" href="#">Xeberler</a>
                            <a class="btn btn-sm btn-outline-danger btn-round shadow-sm" href="#">05/09/2020
                                                        15:15</a>
                        </div>
                        <div class="card-body px-3 pt-0 font-weight-300">
                            Some quick example text to build on the card title and make up
                                                    the
                                                    bulk
                                                    of the card's content.

                        </div>
                    </div>

                </article>
                <article class="col-md-4 d-flex align-items-stretch">

                    <div class="card mb-3 rounded post overflow-hidden" href="#">
                        <div class="post-header overflow-hidden">
                            <a href="#" class="d-block">
                                <img src="./images/test/ilhameliyev.jpg" class="post-img" alt="">
                            </a>
                        </div>
                        <div class="d-flex justify-content-between py-2 px-2">
                            <a class="btn btn-sm btn-outline-default btn-round shadow-sm" href="#">Xeberler</a>
                            <a class="btn btn-sm btn-outline-danger btn-round shadow-sm" href="#">05/09/2020
                                                        15:15</a>
                        </div>
                        <div class="card-body px-3 pt-0 font-weight-300">
                            Some quick example text to build on the card title and make up
                                                    the
                                                    bulk
                                                    of the card's content.

                        </div>
                    </div>

                </article>
                <article class="col-md-4 d-flex align-items-stretch">

                    <div class="card mb-3 rounded post overflow-hidden" href="#">
                        <div class="post-header overflow-hidden">
                            <a href="#" class="d-block">
                                <img src="./images/test/ilhameliyev.jpg" class="post-img" alt="">
                            </a>
                        </div>
                        <div class="d-flex justify-content-between py-2 px-2">
                            <a class="btn btn-sm btn-outline-default btn-round shadow-sm" href="#">Xeberler</a>
                            <a class="btn btn-sm btn-outline-danger btn-round shadow-sm" href="#">05/09/2020
                                                        15:15</a>
                        </div>
                        <div class="card-body px-3 pt-0 font-weight-300">
                            Some quick example text to build on the card title and make up
                                                    the
                                                    bulk
                                                    of the card's content.

                        </div>
                    </div>

                </article>
                <article class="col-md-4 d-flex align-items-stretch">

                    <div class="card mb-3 rounded post overflow-hidden" href="#">
                        <div class="post-header overflow-hidden">
                            <a href="#" class="d-block">
                                <img src="./images/test/ilhameliyev.jpg" class="post-img" alt="">
                            </a>
                        </div>
                        <div class="d-flex justify-content-between py-2 px-2">
                            <a class="btn btn-sm btn-outline-default btn-round shadow-sm" href="#">Xeberler</a>
                            <a class="btn btn-sm btn-outline-danger btn-round shadow-sm" href="#">05/09/2020
                                                        15:15</a>
                        </div>
                        <div class="card-body px-3 pt-0 font-weight-300">
                            Some quick example text to build on the card title and make up
                                                    the
                                                    bulk
                                                    of the card's content.

                        </div>
                    </div>

                </article>
            </div>
        </div>
    </section>

     <!-- All  Posts  -->
    <section class="all-news text-center mb-2">
        <a href="#" class="btn btn-warning btn-round  text-uppercase">bütün Xeberler
        </a>
    </section>

    <!-- Publications -->
    <section class="site-posts mb-2">
        <div class="container-fluid p-0">
            <div class="row">
                <div class="col">
                    <a href="#" class="d-block text-default p-2 my-2 bg-white rounded shadow-sm post-block-title">
                        <i class="fas fa-scroll mr-2"></i>
                        Nəşrlər
                    </a>
                </div>
            </div>
            <div class="row">
                <div class="col-12">
                    <div class="owl-carousel publications rounded overflow-hidden">
                        <div class="publication-item">
                            <a href="#" class="rounded overflow-hidden">
                                <img class="publication-img" src="./images/test/boton_chorek.jpg" alt="">
                            </a>
                        </div>
                        <div class="publication-item">
                            <a href="#" class="rounded overflow-hidden">
                                <img class="publication-img" src="./images/test/boton_chorek.jpg" alt="">
                            </a>
                        </div>
                        <div class="publication-item">
                            <a href="#" class="rounded overflow-hidden">
                                <img class="publication-img" src="./images/test/boton_chorek.jpg" alt="">
                            </a>
                        </div>
                        <div class="publication-item">
                            <a href="#" class="rounded overflow-hidden">
                                <img class="publication-img" src="./images/test/boton_chorek.jpg" alt="">
                            </a>
                        </div>
                        <div class="publication-item">
                            <a href="#" class="rounded overflow-hidden">
                                <img class="publication-img" src="./images/test/boton_chorek.jpg" alt="">
                            </a>
                        </div>
                        <div class="publication-item">
                            <a href="#" class="rounded overflow-hidden">
                                <img class="publication-img" src="./images/test/boton_chorek.jpg" alt="">
                            </a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <!-- Reports -->
    <section class="site-posts mb-2">
        <div class="container-fluid p-0">
            <div class="row">
                <div class="col">
                    <a href="#" class="d-block text-default p-2 my-2 bg-white rounded shadow-sm post-block-title">
                        <i class="far fa-flag mr-2"></i>
                        hesabatlar
                    </a>
                </div>
            </div>
            <div class="row">
                <article class="col-md-6 d-flex align-items-stretch">

                    <div class="irem btn btn-outline-default my-1">
                        <div class="container-fluid row">
                            <div class="col-3">
                                07/09/2020 15:15
                            </div>
                            <div class="col-9 text-left">
                                Lorem ipsum dolor sit, amet consectetur adipisicing elit. Eius
                                                        id unde et ut
                                                        similique aliquid?
                            </div>
                        </div>
                    </div>

                </article>
                <article class="col-md-6 d-flex align-items-stretch">

                    <div class="irem btn btn-outline-default my-1">
                        <div class="container-fluid row">
                            <div class="col-3">
                                07/09/2020 15:15
                            </div>
                            <div class="col-9 text-left">
                                Lorem ipsum dolor sit, amet consectetur adipisicing elit. Eius
                                                        id unde et ut
                                                        similique aliquid?
                            </div>
                        </div>
                    </div>

                </article>
                <article class="col-md-6 d-flex align-items-stretch">

                    <div class="irem btn btn-outline-default my-1">
                        <div class="container-fluid row">
                            <div class="col-3">
                                07/09/2020 15:15
                            </div>
                            <div class="col-9 text-left">
                                Lorem ipsum dolor sit, amet consectetur adipisicing elit. Eius
                                                        id unde et ut
                                                        similique aliquid?
                            </div>
                        </div>
                    </div>

                </article>
                <article class="col-md-6 d-flex align-items-stretch">

                    <div class="irem btn btn-outline-default my-1">
                        <div class="container-fluid row">
                            <div class="col-3">
                                07/09/2020 15:15
                            </div>
                            <div class="col-9 text-left">
                                Lorem ipsum dolor sit, amet consectetur adipisicing elit. Eius
                                                        id unde et ut
                                                        similique aliquid?
                            </div>
                        </div>
                    </div>

                </article>
                <article class="col-md-6 d-flex align-items-stretch">

                    <div class="irem btn btn-outline-default my-1">
                        <div class="container-fluid row">
                            <div class="col-3">
                                07/09/2020 15:15
                            </div>
                            <div class="col-9 text-left">
                                Lorem ipsum dolor sit, amet consectetur adipisicing elit. Eius
                                                        id unde et ut
                                                        similique aliquid?
                            </div>
                        </div>
                    </div>

                </article>
                <article class="col-md-6 d-flex align-items-stretch">

                    <div class="irem btn btn-outline-default my-1">
                        <div class="container-fluid row">
                            <div class="col-3">
                                07/09/2020 15:15
                            </div>
                            <div class="col-9 text-left">
                                Lorem ipsum dolor sit, amet consectetur adipisicing elit. Eius
                                                        id unde et ut
                                                        similique aliquid?
                            </div>
                        </div>
                    </div>

                </article>
            </div>
        </div>
    </section>

</asp:Content>
