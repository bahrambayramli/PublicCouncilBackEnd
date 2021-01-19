<%@ Page Title="" Language="C#" MasterPageFile="~/subsite/Subdomain.Master" AutoEventWireup="true" CodeBehind="members.aspx.cs" Inherits="PublicCouncilBackEnd.subsite.WebForm10" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="sublayout" runat="server">
    <asp:UpdatePanel ID="POSTS_PANEL" runat="server" class="container-fluid">
        <ContentTemplate>
            <div class="row">
                <div class="col-12 px-md-1">
                    <asp:HyperLink ID="pageName" runat="server" CssClass="d-block text-default p-2 mb-2 bg-white rounded shadow-sm post-block-title text-center text-uppercase" Style="font-size: 2rem"></asp:HyperLink>
                </div>
            </div>
            <div class="row">
                <asp:ListView ID="MEMBERS_AZ" runat="server" OnPagePropertiesChanging="MEMBERS_AZ_PagePropertiesChanging">
                    <ItemTemplate>
                        <div class="col-12 col-md-4  d-flex align-items-stretch px-md-1">

                            <div class="card mb-3 post overflow-hidden">
                                <div class="member-card">
                                    <div class="member-card-inner">
                                        <div class="member-card-front">
                                            <img src="/images/members/<%#Eval("MEMBER_IMAGE")%>" alt="Avatar" style="width: 300px; height: 300px;">
                                        </div>
                                        <div class="member-card-back">
                                            <p>
                                                <%#Eval("MEMBER_POSITION")%>
                                            </p>
                                            <p class="h4">
                                                <%#Eval("MEMBER_NAME")%>  <%#Eval("MEMBER_SURNAME")%>
                                            </p>
                                            <a class="btn btn-outline-secondary btn-round btn-sm" href="/site/memberdetail/az/<%#Eval("MEMBER_ID")%>">Ətraflı</a>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </ItemTemplate>
                </asp:ListView>
                <asp:ListView ID="MEMBERS_EN" runat="server" OnPagePropertiesChanging="MEMBERS_EN_PagePropertiesChanging">
                    <ItemTemplate>
                        <div class="member-card">
                                    <div class="member-card-inner">
                                        <div class="member-card-front">
                                            <img src="/images/members/<%#Eval("MEMBER_IMAGE")%>" alt="Avatar" style="width: 300px; height: 300px;">
                                        </div>
                                        <div class="member-card-back">
                                            <p>
                                                <%#Eval("MEMBER_POSITION_EN")%>
                                            </p>
                                            <p class="h4">
                                                <%#Eval("MEMBER_NAME_EN")%>  <%#Eval("MEMBER_SURNAME_EN")%>
                                            </p>
                                            <a class="btn btn-outline-secondary btn-round btn-sm" href="/site/memberdetail/en/<%#Eval("MEMBER_ID")%>">Ətraflı</a>
                                        </div>
                                    </div>
                                </div>
                    </ItemTemplate>
                </asp:ListView>
            </div>
            <div class="row">
                <div class="col-12 px-md-1">
                    <nav aria-label="Page navigation example">
                        <asp:DataPager ID="DataPager_AZ" runat="server" PagedControlID="MEMBERS_AZ" PageSize="9" class="pagination">
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

                        <asp:DataPager ID="DataPager_EN" runat="server" PagedControlID="MEMBERS_EN" PageSize="9" class="pagination">
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
