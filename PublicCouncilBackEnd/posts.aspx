<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="posts.aspx.cs" Inherits="PublicCouncilBackEnd.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainlayout" runat="server">
    <asp:UpdatePanel ID="POSTS_PANEL" runat="server" class="container-fluid">
        <ContentTemplate>
            <div class="row">
                <div class="col-12">
                    <asp:HyperLink ID="postsName" runat="server" CssClass="d-block text-white p-2 my-2 bg-default rounded shadow-sm post-block-title text-center text-uppercase" Style="font-size: 2rem"></asp:HyperLink>
                </div>
            </div>
            <div class="row">
                <asp:ListView ID="POSTLIST_AZ" runat="server" OnPagePropertiesChanging="POSTLIST_AZ_PagePropertiesChanging">
                    <ItemTemplate>
                        <article class="col-12 col-md-6 col-xl-4 d-flex align-items-stretch">

                            <div class="card mb-3 rounded post overflow-hidden">
                                <div class="post-header overflow-hidden">
                                    <a href="/details/az/<%#Eval("DATA_ID")%>" class="d-block">
                                        <img src="/images/<%#Eval("POST_IMG")%>" class="post-img" alt="<%#Eval("POST_SEOAZ")%>">
                                    </a>
                                </div>
                                <div class="d-flex justify-content-between py-2 px-2">
                                    <a class="btn btn-sm btn-outline-default btn-round shadow-sm" href="/posts/az">
                                           <%#Eval("POST_SITECATEGORYAZ")%>
                                    </a>
                                    <a class="btn btn-sm btn-outline-danger btn-round shadow-sm" href="#">
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
                <asp:ListView ID="POSTLIST_EN" runat="server" OnPagePropertiesChanging="POSTLIST_EN_PagePropertiesChanging">
                    <ItemTemplate>
                        <article class="col-12 col-md-6 col-xl-4 d-flex align-items-stretch">

                            <div class="card mb-3 rounded post overflow-hidden">
                                <div class="post-header overflow-hidden">
                                    <a href="/details/en/<%#Eval("DATA_ID")%>" class="d-block">
                                        <img src="/images/<%#Eval("POST_IMG")%>" class="post-img" alt="<%#Eval("POST_SEOEN")%>">
                                    </a>
                                </div>
                                <div class="d-flex justify-content-between py-2 px-2">
                                    <a class="btn btn-sm btn-outline-default btn-round shadow-sm" href="/posts/en">
                                           <%#Eval("POST_SITECATEGORYEN")%>
                                    </a>
                                    <a class="btn btn-sm btn-outline-danger btn-round shadow-sm" href="#">
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
            </div>
            <div class="row">
                <div class="col-12">
                    <nav aria-label="Page navigation example">
                        <asp:DataPager ID="DataPager_AZ" runat="server" PagedControlID="POSTLIST_AZ" PageSize="9" class="pagination">
                            <Fields>
                                <asp:NextPreviousPagerField
                                    ButtonType="Link"
                                    ShowFirstPageButton="False"
                                    ShowNextPageButton="False"
                                    ShowPreviousPageButton="True"
                                    ButtonCssClass="btn btn-primary btn-sm"
                                    RenderDisabledButtonsAsLabels="False" Visible="True" PreviousPageText="Əvvəlki" />
                                <asp:NumericPagerField
                                    CurrentPageLabelCssClass="page-link page-link btn btn-primary btn-sm rounded"
                                    NumericButtonCssClass="page-link btn btn-danger btn-sm rounded"
                                    NextPreviousButtonCssClass="page-item" PreviousPageText="..." NextPageText="..." ButtonCount="5" />
                                <asp:NextPreviousPagerField
                                    ButtonType="Link"
                                    ShowLastPageButton="False"
                                    ShowNextPageButton="True"
                                    ShowPreviousPageButton="False"
                                    ButtonCssClass="btn btn-primary btn-sm rounded" NextPageText="Sonraki" Visible="True" />
                            </Fields>
                        </asp:DataPager>

                        <asp:DataPager ID="DataPager_EN" runat="server" PagedControlID="POSTLIST_EN" PageSize="9" class="pagination">
                            <Fields>
                                <asp:NextPreviousPagerField
                                    ButtonType="Link"
                                    ShowFirstPageButton="False"
                                    ShowNextPageButton="False"
                                    ShowPreviousPageButton="True"
                                    ButtonCssClass="btn btn-primary btn-sm"
                                    RenderDisabledButtonsAsLabels="False" Visible="True" PreviousPageText="Previous" />
                                <asp:NumericPagerField
                                     CurrentPageLabelCssClass="page-link page-link btn btn-primary btn-sm rounded"
                                    NumericButtonCssClass="page-link btn btn-danger btn-sm rounded"
                                    NextPreviousButtonCssClass="page-item" PreviousPageText="..." NextPageText="..." ButtonCount="5" />
                                <asp:NextPreviousPagerField
                                     ButtonType="Link"
                                    ShowLastPageButton="False"
                                    ShowNextPageButton="True"
                                    ShowPreviousPageButton="False"
                                    ButtonCssClass="btn btn-primary btn-sm rounded" NextPageText="Next" Visible="True" />
                            </Fields>
                        </asp:DataPager>
                    </nav>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
