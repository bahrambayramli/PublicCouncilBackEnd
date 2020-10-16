<%@ Page Title="" Language="C#" MasterPageFile="~/subsite/Subdomain.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="PublicCouncilBackEnd.subsite.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="sublayout" runat="server">
    <!-- Start  Sliders  -->
    <section class="site-sliders mb-3">
        <div class="container-fluid p-0">
            <div class="row">
                <div class="col col-12">
                    <div class="main-slider">
                        <div
                            class="owl-main owl-carousel owl-theme rounded overflow-hidden">
                            <div class="slider-item">
                                <img src="../images/test/ilhameliyev.jpg"
                                    alt="" />
                                <div class="slider-caption">
                                    <span
                                        class="btn btn-sm btn-round slider-time bg-white text-default ">
                                        <i
                                            class="far fa-calendar-alt"></i>
                                        05/09/2020/12:12
                                    </span>
                                    <h2 class="slider-title">Lorem ipsum dolor
                                                                                                                        sit amet.
                                    </h2>
                                    <a class="caption-link"
                                        title=""
                                        href="#"></a>
                                </div>


                            </div>
                            <div class="slider-item">
                                <img src="../images/test/ilhameliyev.jpg"
                                    alt="" />
                                <div class="slider-caption">
                                    <span
                                        class="btn btn-sm btn-round slider-time bg-white text-default">
                                        <i
                                            class="far fa-calendar-alt"></i>
                                        05/09/2020/12:12
                                    </span>
                                    <h2 class="slider-title">Lorem ipsum dolor
                                                                                                                        sit amet.
                                    </h2>
                                    <a class="caption-link"
                                        title=""
                                        href="#"></a>
                                </div>

                            </div>
                            <div class="slider-item">
                                <img src="../images/test/ilhameliyev.jpg"
                                    alt="" />
                                <div class="slider-caption">
                                    <span
                                        class="btn btn-sm btn-round slider-time bg-white text-default">
                                        <i
                                            class="far fa-calendar-alt"></i>
                                        05/09/2020/12:12
                                    </span>
                                    <h2 class="slider-title">Lorem ipsum dolor
                                                                                                                        sit amet.
                                    </h2>
                                    <a class="caption-link"
                                        title=""
                                        href="#"></a>
                                </div>


                            </div>
                        </div>
                    </div>
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
        <div class="container-fluid p-0">
            <div class="row">
                <div class="col">
                    <a href="#"
                        class="d-block text-default p-2 my-2 bg-white rounded shadow-sm post-block-title">
                        <i class="far fa-newspaper mr-2"></i>
                        Xəbərlər
                    </a>
                </div>
            </div>
            <div class="row">
                <article class="col-md-6 d-flex align-items-stretch">

                    <div class="card mb-3 rounded post overflow-hidden"
                        href="#">
                        <div class="post-header overflow-hidden">
                            <a href="#" class="d-block">
                                <img src="../images/test/ilhameliyev.jpg"
                                    class="post-img" alt="">
                            </a>
                        </div>
                        <div
                            class="d-flex justify-content-between py-2 px-2">
                            <a class="btn btn-sm btn-outline-default btn-round shadow-sm"
                                href="#">Xeberler</a>
                            <a class="btn btn-sm btn-outline-danger btn-round shadow-sm"
                                href="#">05/09/2020
                                                                                                            15:15</a>
                        </div>
                        <div
                            class="card-body px-3 pt-0 font-weight-300">
                            Some quick example text to build on
                                                                                                      the card title and make up
                                                                                                      the
                                                                                                      bulk
                                                                                                      of the card's content.

                        </div>
                    </div>

                </article>
                <article class="col-md-6 d-flex align-items-stretch">

                    <div class="card mb-3 rounded post overflow-hidden"
                        href="#">
                        <div class="post-header overflow-hidden">
                            <a href="#" class="d-block">
                                <img src="../images/test/ilhameliyev.jpg"
                                    class="post-img" alt="">
                            </a>
                        </div>
                        <div
                            class="d-flex justify-content-between py-2 px-2">
                            <a class="btn btn-sm btn-outline-default btn-round shadow-sm"
                                href="#">Xeberler</a>
                            <a class="btn btn-sm btn-outline-danger btn-round shadow-sm"
                                href="#">05/09/2020
                                                                                                            15:15</a>
                        </div>
                        <div
                            class="card-body px-3 pt-0 font-weight-300">
                            Some quick example text to build on
                                                                                                      the card title and make up
                                                                                                      the
                                                                                                      bulk
                                                                                                      of the card's content.

                        </div>
                    </div>

                </article>
                <article class="col-md-6 d-flex align-items-stretch">

                    <div class="card mb-3 rounded post overflow-hidden"
                        href="#">
                        <div class="post-header overflow-hidden">
                            <a href="#" class="d-block">
                                <img src="../images/test/ilhameliyev.jpg"
                                    class="post-img" alt="">
                            </a>
                        </div>
                        <div
                            class="d-flex justify-content-between py-2 px-2">
                            <a class="btn btn-sm btn-outline-default btn-round shadow-sm"
                                href="#">Xeberler</a>
                            <a class="btn btn-sm btn-outline-danger btn-round shadow-sm"
                                href="#">05/09/2020
                                                                                                            15:15</a>
                        </div>
                        <div
                            class="card-body px-3 pt-0 font-weight-300">
                            Some quick example text to build on
                                                                                                      the card title and make up
                                                                                                      the
                                                                                                      bulk
                                                                                                      of the card's content.

                        </div>
                    </div>

                </article>
                <article class="col-md-6 d-flex align-items-stretch">

                    <div class="card mb-3 rounded post overflow-hidden"
                        href="#">
                        <div class="post-header overflow-hidden">
                            <a href="#" class="d-block">
                                <img src="../images/test/ilhameliyev.jpg"
                                    class="post-img" alt="">
                            </a>
                        </div>
                        <div
                            class="d-flex justify-content-between py-2 px-2">
                            <a class="btn btn-sm btn-outline-default btn-round shadow-sm"
                                href="#">Xeberler</a>
                            <a class="btn btn-sm btn-outline-danger btn-round shadow-sm"
                                href="#">05/09/2020
                                                                                                            15:15</a>
                        </div>
                        <div
                            class="card-body px-3 pt-0 font-weight-300">
                            Some quick example text to build on
                                                                                                      the card title and make up
                                                                                                      the
                                                                                                      bulk
                                                                                                      of the card's content.

                        </div>
                    </div>

                </article>

            </div>
        </div>
    </section>
</asp:Content>
