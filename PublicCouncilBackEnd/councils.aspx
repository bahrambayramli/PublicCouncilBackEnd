<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="councils.aspx.cs" Inherits="PublicCouncilBackEnd.WebForm12" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="content/css/argon.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainlayout" runat="server">
    <asp:UpdatePanel ID="COUNCIL_PANEL" runat="server" class="container-fluid p-0">
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
                    <div class="d-flex flex-column flex-md-row justify-content-around mb-2">

                        <asp:HyperLink ID="pcucep" runat="server" CssClass="btn btn-default w-100 d-flex align-items-center justify-content-center mb-1 mb-md-0">
                        </asp:HyperLink>

                        <asp:HyperLink ID="pculealsgb" runat="server" CssClass="btn btn-default w-100 d-flex align-items-center justify-content-center mb-1 mb-md-0">
                        </asp:HyperLink>

                        <asp:HyperLink ID="other" runat="server" CssClass="btn btn-default w-100 d-flex align-items-center justify-content-center mb-1 mb-md-0">
                        </asp:HyperLink>

                    </div>
                </div>
            </div>
            <div class="row">

                <asp:ListView ID="PCLIST_AZ" runat="server" OnPagePropertiesChanging="POSTLIST_AZ_PagePropertiesChanging">
                    <ItemTemplate>
                        <div class="col-12 d-flex align-items-stretch px-md-1 mb-md-2">
                            <div class="h5 w-100 bg-white shadow font-weight-bold text-default text-wrap p-2 p-md-3 rounded ">

                                <a href="http://<%#Eval("USER_PCDOMAIN")%>.ictimaishura.az" title="<%#Eval("PC_NAME")%>" target="_blank" class="d-block text-default">
                                    <%#Eval("PC_NAME")%>
                                </a>

                                <hr class="my-1 w-100">
                                <p>
                                    <a href="mailto:<%#Eval("PC_EMAIL")%>" class="text-gray">
                                        <i class="fas fa-envelope mr-2 text-info"></i>
                                        <%#Eval("PC_EMAIL")%>
                                    </a>
                                </p>
                                <p>
                                    <a href="tel:<%#Eval("PC_TELEPHONE")%>" class="text-gray mr-2">
                                        <i class="fas fa-phone-alt mr-2 text-info"></i>
                                        <%#Eval("PC_TELEPHONE")%>
                                    </a>
                                    <a href="tel:<%#Eval("PC_TELEPHONE")%>" class="text-gray">
                                        <i class="fas fa-mobile mr-2 text-info"></i>
                                           <%#Eval("PC_TELEPHONE")%>
                                    </a>
                                </p>





                            </div>
                        </div> 
                    </ItemTemplate>
                </asp:ListView>

                <asp:ListView ID="PCLIST_EN" runat="server" OnPagePropertiesChanging="POSTLIST_EN_PagePropertiesChanging">
                    <ItemTemplate>
                        <div class="col-12 d-flex align-items-stretch px-md-1 mb-md-2">
                            <div class="h5 w-100 bg-white shadow font-weight-bold text-default text-wrap p-2 p-md-3 rounded ">

                                <a href="http://<%#Eval("USER_PCDOMAIN")%>.ictimaishura.az" title="<%#Eval("PC_NAME")%>" target="_blank" class="d-block text-default">
                                    <%#Eval("PC_NAME")%>
                                </a>

                                <hr class="my-1 w-100">
                                <p>
                                    <a href="mailto:<%#Eval("PC_EMAIL")%>" class="text-gray">
                                        <i class="fas fa-envelope mr-2 text-info"></i>
                                        <%#Eval("PC_EMAIL")%>
                                    </a>
                                </p>
                                <p>
                                    <a href="tel:<%#Eval("PC_TELEPHONE")%>" class="text-gray mr-2">
                                        <i class="fas fa-phone-alt mr-2 text-info"></i>
                                        <%#Eval("PC_TELEPHONE")%>
                                    </a>
                                    <a href="tel:<%#Eval("PC_TELEPHONE")%>" class="text-gray">
                                        <i class="fas fa-mobile mr-2 text-info"></i>
                                           <%#Eval("PC_TELEPHONE")%>
                                    </a>
                                </p>





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
