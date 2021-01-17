<%@ Page Title="" Language="C#" MasterPageFile="~/subsite/Subdomain.Master" AutoEventWireup="true" CodeBehind="members.aspx.cs" Inherits="PublicCouncilBackEnd.subsite.WebForm10" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="sublayout" runat="server">
        <asp:UpdatePanel ID="MEMBERS_PANEL" runat="server" class="container-fluid">
        <ContentTemplate>
            <div class="row">
                <div class="col-12">
                    <asp:HyperLink ID="pageName" runat="server" CssClass="d-block text-white p-2 mb-2 bg-default rounded shadow-sm post-block-title text-center text-uppercase" Style="font-size: 2rem"></asp:HyperLink>
                </div>
            </div>
            <div class="row">
                <asp:ListView ID="MEMBERS_AZ" runat="server" OnPagePropertiesChanging="MEMBERS_AZ_PagePropertiesChanging">
                    <ItemTemplate>
                        <div class="col-12 col-md-6  d-flex align-items-stretch">
                            <div class="card mb-3 rounded post overflow-hidden">
                                <div class="post-header overflow-hidden">
                                    <a href="/details/az/<%#Eval("MEMBER_ID")%>" class="d-block">
                                        <img src="/images/members/<%#Eval("MEMBER_IMAGE")%>" class="post-img" alt="<%#Eval("MEMBER_NAME")%>  <%#Eval("MEMBER_SURNAME")%>">
                                    </a>
                                </div>
                                <div class="card-body px-3 pt-0 font-weight-300">
                                    <%#Eval("MEMBER_NAME")%>   <%#Eval("MEMBER_SURNAME")%>
                                </div>
                            </div>

                        </div>
                    </ItemTemplate>
                </asp:ListView>


                <asp:ListView ID="MEMBERS_EN" runat="server" OnPagePropertiesChanging="MEMBERS_EN_PagePropertiesChanging">
                    <ItemTemplate>
                        <div class="col-12 col-md-6  d-flex align-items-stretch">

                            <div class="card mb-3 rounded post overflow-hidden">
                                <div class="post-header overflow-hidden">
                                    <a href="/details/az/<%#Eval("MEMBER_ID")%>" class="d-block">
                                        <img src="/images/members/<%#Eval("MEMBER_IMAGE")%>" class="post-img" alt="<%#Eval("MEMBER_NAME_EN")%>  <%#Eval("MEMBER_SURNAME_EN")%>">
                                    </a>
                                </div>
                                <div class="card-body px-3 pt-0 font-weight-300">
                                    <%#Eval("MEMBER_NAME_EN")%>   <%#Eval("MEMBER_SURNAME_EN")%>
                                </div>
                            </div>

                        </div>
                    </ItemTemplate>
                </asp:ListView>
            </div>
            <div class="row">
                <div class="col-12">
                    <nav aria-label="Page navigation example">
                        <asp:DataPager ID="DataPager_AZ" runat="server" PagedControlID="MEMBER_AZ" PageSize="9" class="pagination">
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

                        <asp:DataPager ID="DataPager_EN" runat="server" PagedControlID="MEMBER_EN" PageSize="9" class="pagination">
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
