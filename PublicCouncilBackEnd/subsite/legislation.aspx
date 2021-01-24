<%@ Page Title="" Language="C#" MasterPageFile="~/subsite/Subdomain.Master" AutoEventWireup="true" CodeBehind="legislation.aspx.cs" Inherits="PublicCouncilBackEnd.subsite.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="sublayout" runat="server">
    <asp:UpdatePanel ID="POSTS_PANEL" runat="server" class="container-fluid">
        <ContentTemplate>
            <div class="row">
                <div class="col-12">
                    <asp:HyperLink ID="postsName" runat="server" CssClass="d-block bg-white rounded shadow-sm text-center text-default text-uppercase p-2 my-2 px-md-1 page-name"></asp:HyperLink>
                </div>
            </div>
            <div class="row">
                <asp:ListView ID="POSTLIST_AZ" runat="server" OnPagePropertiesChanging="POSTLIST_AZ_PagePropertiesChanging">
                    <ItemTemplate>
                        <article class="col-12 d-flex align-items-stretch border-danger">
                            <a href="/details/az/<%#Eval("DATA_ID")%>" class="shadow p-2 mb-3 rounded d-block text-default h5 w-100 text-wrap" title="<%#Eval("POST_SEOAZ")%>"
                                style="border-left: 4px solid #32325d;">
                                <%#Eval("POST_SEOAZ")%>
                            </a>
                        </article> 
                    </ItemTemplate>
                </asp:ListView>
                <asp:ListView ID="POSTLIST_EN" runat="server" OnPagePropertiesChanging="POSTLIST_EN_PagePropertiesChanging">
                    <ItemTemplate>
                        <article class="col-12 d-flex align-items-stretch border-danger">
                            <a href="/details/en/<%#Eval("DATA_ID")%>" class="shadow p-2 mb-3 rounded d-block text-default h5 w-100 text-wrap" title="<%#Eval("POST_SEOEN")%>"
                                style="border-left: 4px solid #32325d;">
                                <%#Eval("POST_SEOEN")%>
                            </a>
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
        <script src="/scripts/subsite.js"></script>
</asp:Content>
