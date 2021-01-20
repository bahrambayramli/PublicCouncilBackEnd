﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="councils.aspx.cs" Inherits="PublicCouncilBackEnd.WebForm12" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainlayout" runat="server">
<%--                            <a href="http://<%#Eval("USER_PCDOMAIN")%>.ictimaishura.az" class="shadow p-2 mb-3 rounded d-block text-default h5 w-100 text-wrap" title="<%#Eval("PC_NAME")%>" style="border-left: 4px solid #32325d;">

                                <%#Eval("PC_NAME")%>
                            </a>--%>
    <asp:UpdatePanel ID="COUNCIL_PANEL" runat="server" class="container-fluid">
        <ContentTemplate>
            <div class="row">
                <div class="col-12 px-md-1">
                    <asp:HyperLink 
                        ID="pcTitle" runat="server" 
                        CssClass="d-block text-default p-2 my-2 bg-white rounded shadow-sm post-block-title text-center text-uppercase px-md-1 page-name">

                    </asp:HyperLink>
                </div>
            </div>
            <div class="row">
                <div class="col-12 px-md-1">
                    <div class="d-flex justify-content-around mb-2">
                        

                        <asp:HyperLink ID="pcucep" runat="server" CssClass="btn btn-default w-100 d-flex align-items-center justify-content-center">

                        </asp:HyperLink>

                        <asp:HyperLink ID="pculealsgb" runat="server" CssClass="btn btn-success w-100 d-flex align-items-center justify-content-center">

                        </asp:HyperLink>

                        <asp:HyperLink ID="other" runat="server" CssClass="btn btn-warning w-100 d-flex align-items-center justify-content-center">

                        </asp:HyperLink>

                    </div>
                </div>
            </div>
            <div class="row">
                <asp:ListView ID="PCLIST_AZ" runat="server" OnPagePropertiesChanging="POSTLIST_AZ_PagePropertiesChanging">
                    <ItemTemplate>
                        <div class="col-12 col-md-4 d-flex align-items-stretch border-danger px-md-1">
                           
                            <div class="card mb-3 post overflow-hidden">
                                <div class="post-header overflow-hidden">
                                    <a href="http://<%#Eval("USER_PCDOMAIN")%>.ictimaishura.az" class="shadow rounded d-block" title="<%#Eval("PC_NAME")%>">
                                        <img src="/images/logos/<%#Eval("LOGO_IMG")%>" alt="" />
                                    </a>
                                </div>
                                <div class="card-body px-3 pt-2">
                                   <%#Eval("PC_NAME")%>
                                </div>
                            </div>
                        </div> 
                    </ItemTemplate>
                </asp:ListView>
                <asp:ListView ID="PCLIST_EN" runat="server" OnPagePropertiesChanging="POSTLIST_EN_PagePropertiesChanging">
                    <ItemTemplate>
                        <div class="col-12 col-md-4 d-flex align-items-stretch border-danger px-md-1">
                           
                            <div class="card mb-3 post overflow-hidden">
                                <div class="post-header overflow-hidden">
                                    <a href="http://<%#Eval("USER_PCDOMAIN")%>.ictimaishura.az" class="shadow rounded d-block" title="<%#Eval("PC_NAME")%>">
                                        <img src="/images/logos/<%#Eval("LOGO_IMG")%>" alt="" />
                                    </a>
                                </div>
                                <div class="card-body px-3 pt-2">
                                   <%#Eval("PC_NAME")%>
                                </div>
                            </div>
                        </div> 
                    </ItemTemplate>
                </asp:ListView>
            </div>
            <div class="row">
                <div class="col-12 px-md-1">
                    <nav aria-label="Page navigation example">
                        <asp:DataPager ID="DataPager_AZ" runat="server" PagedControlID="PCLIST_AZ" PageSize="9" class="pagination">
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

                        <asp:DataPager ID="DataPager_EN" runat="server" PagedControlID="PCLIST_EN" PageSize="9" class="pagination">
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

    <script>
        $('#contentside').removeData('col-md-9')
        $('#contentside').addClass('col-md-12 px-md-1');
        $(document).ready(function () {
            $('#rightside').remove();
        });
    </script>

</asp:Content>
