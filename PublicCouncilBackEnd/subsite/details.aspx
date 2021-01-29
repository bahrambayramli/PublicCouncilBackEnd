<%@ Page Title="" Language="C#" MasterPageFile="~/subsite/Subdomain.Master" AutoEventWireup="true" CodeBehind="details.aspx.cs" Inherits="PublicCouncilBackEnd.subsite.WebForm12" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/content/css/jquery.fancybox.min.css" rel="stylesheet" />
    <script src='https://platform-api.sharethis.com/js/sharethis.js#property=5f8df40458d8400012272351&product=sop' async></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="sublayout" runat="server">
    <section id="postdetails" class="post-details bg-white rounded p-2 mb-6">

        <div class="post-img overflow-hidden rounded shadow-sm">
            <asp:Image ID="postImage" runat="server" />
        </div>

        <div class="post-info my-2">
            <asp:HyperLink ID="postCategory" runat="server" CssClass="btn btn-sm btn-outline-default btn-round"></asp:HyperLink>
            <asp:HyperLink ID="postDateLink" runat="server" CssClass="btn btn-sm btn-outline-danger btn-round">
                <i class="far fa-clock mr-md-1"></i>
                <asp:Literal ID="postDate" runat="server"></asp:Literal>
            </asp:HyperLink>

            <asp:HyperLink ID="postViewLink" runat="server" CssClass="btn btn-sm btn-outline-warning btn-round">
                <i class="far fa-eye mr-md-1"></i>
                <asp:Literal ID="postView" runat="server"></asp:Literal>
            </asp:HyperLink>
        </div>

        <div class="post-title my-2">
            <h2>
                <asp:Literal ID="postTitle" runat="server"></asp:Literal>
            </h2>
        </div>

        <div class="post-about overflow-hidden my-2">
            <asp:Literal ID="postAbout" runat="server"></asp:Literal>
        </div>

        <div class="post-fotos my-2">
            <asp:ListView ID="POST_IMGGALERYAZ" runat="server">
                <LayoutTemplate>
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-12">
                                <h5 class="text-danger">Fotolar</h5>
                            </div>
                        </div>
                        <div class="row">
                            <asp:PlaceHolder ID="itemplaceholder" runat="server" />
                        </div>
                    </div>
                </LayoutTemplate>
                <ItemTemplate>
                    <div class="col-12 col-sm-6 col-md-3 col-xl-3 p-0">
                        <div class="sub-image p-1">
                            <a href="/Images/subimages/<%#Eval("POST_IMG_NAME")%>" data-fancybox="gallery" data-caption="">
                                <img class="rounded shadow-sm" src="/Images/subimages/<%#Eval("POST_IMG_NAME")%>" alt="" />
                            </a>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:ListView>

            <asp:ListView ID="POST_IMGGALERYEN" runat="server">
                <LayoutTemplate>
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-12">
                                <h5 class="text-danger">Photos</h5>
                            </div>
                        </div>
                        <div class="row">
                            <asp:PlaceHolder ID="itemplaceholder" runat="server"></asp:PlaceHolder>
                        </div>
                    </div>
                </LayoutTemplate>
                <ItemTemplate>
                    <div class="col-12 col-sm-6 col-md-3 col-xl-3 p-0">
                        <div class="sub-image p-1">
                            <a href="/Images/subimages/<%#Eval("POST_IMG_NAME")%>" data-fancybox="gallery" data-caption="">
                                <img class="rounded shadow-sm" src="/Images/subimages/<%#Eval("POST_IMG_NAME")%>" alt="" />
                            </a>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:ListView>
        </div>

        <div class="post-videos my-2">
            <asp:ListView ID="POST_VIDEOGALERYAZ" runat="server">
                <LayoutTemplate>
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-12">
                                <h5 class="post-multimedia text-danger">Videolar</h5>
                            </div>
                        </div>
                        <div class="row">
                            <asp:PlaceHolder ID="itemplaceholder" runat="server"></asp:PlaceHolder>
                        </div>
                    </div>
                </LayoutTemplate>
                <ItemTemplate>
                    <div class="col-12 col-sm-6 col-md-4 col-xl-4 p-1">
                        <div class="sub-videos">
                            <iframe src="<%#Eval("POST_VIDEO_FRAME")%>" class="shadow-md" width="100%" height="250px" frameborder="0" allowfullscreen></iframe>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:ListView>
            <asp:ListView ID="POST_VIDEOGALERYEN" runat="server">
                <LayoutTemplate>
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-12">
                                <h5 class="post-multimedia text-danger">Videos</h5>
                            </div>
                        </div>
                        <div class="row">
                            <asp:PlaceHolder ID="itemplaceholder" runat="server"></asp:PlaceHolder>
                        </div>
                    </div>
                </LayoutTemplate>
                <ItemTemplate>
                    <div class="col-12 col-sm-6 col-md-4 col-xl-4 p-1">
                        <div class="sub-videos">
                            <iframe src="<%#Eval("POST_VIDEO_FRAME")%>" class="shadow-md" width="100%" height="250px" frameborder="0" allowfullscreen></iframe>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:ListView>
        </div>

        <div class="post-documents my-2">
            <asp:ListView ID="POST_DOCUMENTSAZ" runat="server">
                <LayoutTemplate>
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-12">
                                <h5 class="text-danger">Sənədlər</h5>
                            </div>
                        </div>
                        <div class="row">
                            <asp:PlaceHolder ID="itemplaceholder" runat="server"></asp:PlaceHolder>
                        </div>
                    </div>
                </LayoutTemplate>
                <ItemTemplate>
                    <div class="col-12">
                        <a class="btn btn-link text-danger p-0" href="/Uploads/<%#Eval("DOC_NAME")%>" title="<%#Eval("DOC_DEFAULTNAME") %>" download>
                            <i class="fas fa-download text-success font-weight-bolder"></i>
                            <%#Eval("DOC_DEFAULTNAME") %>
                        </a>
                    </div>
                </ItemTemplate>
            </asp:ListView>
            <asp:ListView ID="POST_DOCUMENTSEN" runat="server">
                <LayoutTemplate>
                    <div class="container-fluid p-0">
                        <div class="row">
                            <div class="col-12">
                                <h5 class="text-danger">Documents</h5>
                            </div>
                        </div>
                        <div class="row">
                            <asp:PlaceHolder ID="itemplaceholder" runat="server"></asp:PlaceHolder>
                        </div>
                    </div>
                </LayoutTemplate>
                <ItemTemplate>
                    <div class="col-12">
                        <a class="btn btn-link text-danger p-0" href="/Uploads/<%#Eval("DOC_NAME")%>" title="<%#Eval("DOC_DEFAULTNAME") %>" download>
                            <i class="fas fa-download text-success font-weight-bolder"></i>
                            <%#Eval("DOC_DEFAULTNAME") %>
                        </a>
                    </div>
                </ItemTemplate>
            </asp:ListView>
        </div>

        <div class="author-content my-2">
            <asp:Literal ID="postAUTHOR" runat="server"></asp:Literal>
        </div>

        <div class="post-share my-2">
            <hr class="my-2 w-100" />
            <div class="my-md-1">
                <asp:Literal ID="shareName" runat="server"></asp:Literal>
            </div>
            <div class="my-md-1">
                <div class="sharethis-inline-share-buttons"></div>
            </div>
        </div>
        <script>
            document.addEventListener("DOMContentLoaded", () => {
                changeLayout({ Id: "contentside", className: "col-12 content-side" }, { Id: "rightside", className: "d-none" });
            });
        </script>
        <script src="/scripts/jquery.fancybox.min.js"></script>

        <script>
            $('[data-fancybox="gallery"]').fancybox({
                thumbs: {
                    autoStart: true
                }
            });

        </script>
    </section>

</asp:Content>
