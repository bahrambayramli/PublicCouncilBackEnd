<%@ Page Title="" Language="C#" MasterPageFile="~/subsite/Subdomain.Master" AutoEventWireup="true" CodeBehind="members.aspx.cs" Inherits="PublicCouncilBackEnd.subsite.WebForm10" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="sublayout" runat="server">
    <asp:UpdatePanel ID="POSTS_PANEL" runat="server" class="container-fluid">
        <ContentTemplate>
            <div class="row">
                <div class="col-12 px-md-1">
                    <asp:HyperLink ID="pageName" runat="server" CssClass="d-block bg-white rounded shadow-sm text-center text-default text-uppercase p-2 mb-2 px-md-1 page-name"></asp:HyperLink>
                </div>
            </div>
            <div class="row">
                <div class="col-12">
                    <asp:Literal ID="pcActivityPeriod" runat="server"></asp:Literal>
                </div>
            </div>
            <div class="row">
                <div class="col-12">
                    <div class="table-responsive py-2 mb-2">
                        <asp:GridView
                            ID="MemberList"
                            runat="server"
                            Width="100%"
                            CssClass="table"
                            OnRowCreated="MemberList_RowCreated"
                            CellPadding="3"
                            ForeColor="#333333"
                            GridLines="None"
                            AllowPaging="True"
                            OnPageIndexChanging="MemberList_PageIndexChanging"
                            OnSelectedIndexChanged="MemberList_SelectedIndexChanged" PageSize="15">
                            <AlternatingRowStyle BackColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />

                            <EditRowStyle BackColor="#2461BF" HorizontalAlign="Center" VerticalAlign="Middle" />
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#32325d" Font-Bold="True" ForeColor="#ffffff" HorizontalAlign="Center" VerticalAlign="Middle" />
                            <PagerStyle BackColor="#A641B9" ForeColor="White" HorizontalAlign="Center" Font-Size="Large" VerticalAlign="Middle" />
                            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" VerticalAlign="Middle" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                        </asp:GridView>
                    </div>
                </div>
            </div>

            <div class="row d-flex justify-content-center">
                <asp:ListView ID="MEMBERS_AZ" runat="server" OnPagePropertiesChanging="MEMBERS_AZ_PagePropertiesChanging">
                    <ItemTemplate>
                        <div class="member-card mb-md-2">
                            <div class="member-card-inner">
                                <div class="member-card-front">
                                    <img src="/images/members/<%#Eval("MEMBER_IMAGE")%>" alt="Avatar" style="width: 300px; height: 300px;">
                                </div>
                                <div class="member-card-back">
                                    <p>
                                        <%#Eval("MEMBER_POSITION_AZ")%>
                                    </p>
                                    <p class="h4">
                                        <%#Eval("MEMBER_NAME_AZ")%>  <%#Eval("MEMBER_SURNAME_AZ")%>
                                    </p>
                                    <a class="btn btn-outline-secondary btn-round btn-sm" href="/site/memberdetail/az/<%#Eval("MEMBER_ID")%>">Ətraflı</a>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:ListView>
                <asp:ListView ID="MEMBERS_EN" runat="server" OnPagePropertiesChanging="MEMBERS_EN_PagePropertiesChanging">
                    <ItemTemplate>
                        <div class="member-card mb-md-2">
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
                                            <a class="btn btn-outline-secondary btn-round btn-sm" href="/site/memberdetail/en/<%#Eval("MEMBER_ID")%>">Details</a>
                                        </div>
                                    </div>
                                </div>
                    </ItemTemplate>
                </asp:ListView>
            </div>
            <div class="row">
                <div class="col-12 px-md-1">
                    <nav aria-label="Page navigation example">
                        <asp:DataPager ID="DataPager_AZ" runat="server" PagedControlID="MEMBERS_AZ" PageSize="20" class="pagination">
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

                        <asp:DataPager ID="DataPager_EN" runat="server" PagedControlID="MEMBERS_EN" PageSize="20" class="pagination">
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
       <script>
           document.addEventListener("DOMContentLoaded", () => {
               changeLayout({ Id: "contentside", className: "col-12 content-side" }, { Id: "rightside", className: "d-none" });
           });
       </script>
</asp:Content>
