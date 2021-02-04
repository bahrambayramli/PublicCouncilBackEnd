<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="reports.aspx.cs" Inherits="PublicCouncilBackEnd.WebForm7" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .design-by {
            visibility: hidden;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainlayout" runat="server">
    <asp:UpdatePanel ID="POSTS_PANEL" runat="server" class="container-fluid p-0 mb-2">
        <ContentTemplate>
            <div class="row">
                <div class="col-12 px-md-1">
                    <asp:HyperLink ID="postsName" runat="server" CssClass="d-block bg-white rounded shadow-sm text-center text-default text-uppercase p-2 mb-2 px-md-1 page-name"></asp:HyperLink>
                </div>
            </div>
            <div class="row">
                <asp:ListView ID="POSTLIST_AZ" runat="server" OnPagePropertiesChanging="POSTLIST_AZ_PagePropertiesChanging">
                    <ItemTemplate>
                        <article class="col-12 col-md-6 d-flex align-items-stretch px-md-1">

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
                <asp:ListView ID="POSTLIST_EN" runat="server" OnPagePropertiesChanging="POSTLIST_EN_PagePropertiesChanging">
                    <ItemTemplate>
                        <article class="col-12 col-md-6 d-flex align-items-stretch px-md-1">

                            <a href="/details/en/<%#Eval("DATA_ID")%>" class="d-block irem btn btn-outline-default my-1 w-100" title="<%#Eval("POST_SEOEN") %>">
                                <div class="container-fluid">
                                    <div class="row">
                                        <div class="col-3">
                                            <%#Eval("POST_DATE").ToString().Substring(0, Eval("POST_DATE").ToString().Length - 3).Replace("/",".")%>
                                        </div>
                                        <div class="col-9 text-left">
                                            <%#Eval("POST_EN_TITLE") %>
                                        </div>
                                    </div>
                                </div>
                            </a>

                        </article>
                    </ItemTemplate>
                </asp:ListView>
            </div>
            <div class="row">
                <div class="col-12 px-md-1">
                    <nav aria-label="Page navigation example">
                        <asp:DataPager ID="DataPager_AZ" runat="server" PagedControlID="POSTLIST_AZ" PageSize="9" class="pagination">
                            <Fields>
                                <asp:NextPreviousPagerField
                                    ButtonType="Link"
                                    ShowFirstPageButton="False"
                                    ShowNextPageButton="False"
                                    ShowPreviousPageButton="True"
                                    ButtonCssClass="btn btn-primary btn-sm"
                                    RenderDisabledButtonsAsLabels="False" Visible="True" PreviousPageText="<" />
                                <asp:NumericPagerField
                                    CurrentPageLabelCssClass="page-link page-link btn btn-primary btn-sm rounded"
                                    NumericButtonCssClass="page-link btn btn-danger btn-sm rounded"
                                    NextPreviousButtonCssClass="page-item" PreviousPageText="..." NextPageText="..." ButtonCount="5" />
                                <asp:NextPreviousPagerField
                                    ButtonType="Link"
                                    ShowLastPageButton="False"
                                    ShowNextPageButton="True"
                                    ShowPreviousPageButton="False"
                                    ButtonCssClass="btn btn-primary btn-sm rounded" NextPageText=">" Visible="True" />
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
                                    RenderDisabledButtonsAsLabels="False" Visible="True" PreviousPageText="<" />
                                <asp:NumericPagerField
                                    CurrentPageLabelCssClass="page-link page-link btn btn-primary btn-sm rounded"
                                    NumericButtonCssClass="page-link btn btn-danger btn-sm rounded"
                                    NextPreviousButtonCssClass="page-item" PreviousPageText="..." NextPageText="..." ButtonCount="5" />
                                <asp:NextPreviousPagerField
                                    ButtonType="Link"
                                    ShowLastPageButton="False"
                                    ShowNextPageButton="True"
                                    ShowPreviousPageButton="False"
                                    ButtonCssClass="btn btn-primary btn-sm rounded" NextPageText=">" Visible="True" />
                            </Fields>
                        </asp:DataPager>
                    </nav>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
