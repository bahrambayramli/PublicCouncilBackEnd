<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="details.aspx.cs" Inherits="PublicCouncilBackEnd.WebForm9" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type='text/javascript' src='https://platform-api.sharethis.com/js/sharethis.js#property=5ee9f4b108ecd500128ef9b7&cms=sop' async='async'></script>
    <link href="/content/css/jquery.fancybox.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainlayout" runat="server">
    <!-- Start News Details  -->
    <section id="postdetails" class="post-details bg-white rounded p-2 mb-6">

        <div class="post-img overflow-hidden rounded shadow-sm">
            <asp:Image ID="postImage" runat="server" />
        </div>

        <div class="post-info my-2">
            
            <asp:HyperLink ID="postCategory" runat="server" CssClass="btn btn-sm btn-outline-default btn-round"></asp:HyperLink>

            <asp:HyperLink ID="postDateLink" runat="server" CssClass="btn btn-sm btn-outline-danger btn-round">
                <svg class="mr-2" width="1em" height="1em" viewBox="0 0 16 16" class="bi bi-clock-history"
                    fill="currentColor" xmlns="http://www.w3.org/2000/svg">
                    <path fill-rule="evenodd"
                        d="M8.515 1.019A7 7 0 0 0 8 1V0a8 8 0 0 1 .589.022l-.074.997zm2.004.45a7.003 7.003 0 0 0-.985-.299l.219-.976c.383.086.76.2 1.126.342l-.36.933zm1.37.71a7.01 7.01 0 0 0-.439-.27l.493-.87a8.025 8.025 0 0 1 .979.654l-.615.789a6.996 6.996 0 0 0-.418-.302zm1.834 1.79a6.99 6.99 0 0 0-.653-.796l.724-.69c.27.285.52.59.747.91l-.818.576zm.744 1.352a7.08 7.08 0 0 0-.214-.468l.893-.45a7.976 7.976 0 0 1 .45 1.088l-.95.313a7.023 7.023 0 0 0-.179-.483zm.53 2.507a6.991 6.991 0 0 0-.1-1.025l.985-.17c.067.386.106.778.116 1.17l-1 .025zm-.131 1.538c.033-.17.06-.339.081-.51l.993.123a7.957 7.957 0 0 1-.23 1.155l-.964-.267c.046-.165.086-.332.12-.501zm-.952 2.379c.184-.29.346-.594.486-.908l.914.405c-.16.36-.345.706-.555 1.038l-.845-.535zm-.964 1.205c.122-.122.239-.248.35-.378l.758.653a8.073 8.073 0 0 1-.401.432l-.707-.707z" />
                    <path fill-rule="evenodd" d="M8 1a7 7 0 1 0 4.95 11.95l.707.707A8.001 8.001 0 1 1 8 0v1z" />
                    <path fill-rule="evenodd"
                        d="M7.5 3a.5.5 0 0 1 .5.5v5.21l3.248 1.856a.5.5 0 0 1-.496.868l-3.5-2A.5.5 0 0 1 7 9V3.5a.5.5 0 0 1 .5-.5z" />
                </svg>
                <asp:Literal ID="postDate" runat="server"></asp:Literal>
            </asp:HyperLink>

            <asp:HyperLink ID="postCountLink" runat="server" CssClass="btn btn-sm btn-outline-warning btn-round">
                <svg class="mr-2" width="1em" height="1em" viewBox="0 0 16 16" class="bi bi-eye" fill="currentColor"
                    xmlns="http://www.w3.org/2000/svg">
                    <path fill-rule="evenodd"
                        d="M16 8s-3-5.5-8-5.5S0 8 0 8s3 5.5 8 5.5S16 8 16 8zM1.173 8a13.134 13.134 0 0 0 1.66 2.043C4.12 11.332 5.88 12.5 8 12.5c2.12 0 3.879-1.168 5.168-2.457A13.134 13.134 0 0 0 14.828 8a13.133 13.133 0 0 0-1.66-2.043C11.879 4.668 10.119 3.5 8 3.5c-2.12 0-3.879 1.168-5.168 2.457A13.133 13.133 0 0 0 1.172 8z" />
                    <path fill-rule="evenodd"
                        d="M8 5.5a2.5 2.5 0 1 0 0 5 2.5 2.5 0 0 0 0-5zM4.5 8a3.5 3.5 0 1 1 7 0 3.5 3.5 0 0 1-7 0z" />
                </svg>
                <asp:Literal ID="postCount" runat="server"></asp:Literal>
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
                            <asp:PlaceHolder ID="itemplaceholder" runat="server"/>
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
             <hr class="my-2 w-100"/>
            <div class="my-md-1">
                <asp:Literal ID="shareName" runat="server"></asp:Literal>
            </div>
            <div class="my-md-1">
                <div class="sharethis-inline-share-buttons post-share-div"></div>
            </div>
        </div>

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
