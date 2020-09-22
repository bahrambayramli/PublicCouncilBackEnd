<%@ Page Title="" Language="C#" MasterPageFile="~/manage/Admin.Master" AutoEventWireup="true" CodeBehind="logos.aspx.cs" Inherits="PublicCouncilBackEnd.manage.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="managelayout" runat="server">
<asp:UpdatePanel ID="LogoListPanel" runat="server">
        <ContentTemplate>
            <div class="card my-md-2">
                <!-- Card header -->
                <div class="card-header">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-12 col-md-6">
                                <h3 class="mb-0">Postlar</h3>
                            </div>
                            <div class="col-12 col-md-6 text-right">
                                <asp:LinkButton ID="new_logo" runat="server" CssClass="btn btn-primary btn-sm btn-round" OnClick="new_logo_Click">
                                        Yeni Logo
                                </asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="table-responsive py-2">
                    <asp:GridView
                        ID="LogoList"
                        runat="server"
                        Width="100%"
                        AutoGenerateColumns="False"
                        CssClass="table"
                        OnRowCreated="LogoList_RowCreated"
                        CellPadding="4"
                        ForeColor="#333333"
                        GridLines="None"
                        AllowPaging="True"
                        OnPageIndexChanging="LogoList_PageIndexChanging"
                        OnSelectedIndexChanged="LogoList_SelectedIndexChanged">
                        <AlternatingRowStyle BackColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />

                        <Columns>
                            <asp:BoundField DataField="#" HeaderText="#" />
                            <asp:BoundField DataField="DATA_ID" HeaderText="DATA_ID" />
                            <asp:BoundField DataField="LOGO_SERIAL" HeaderText="LOGO_SERIAL" />
                            <asp:BoundField DataField="USER_ID" HeaderText="USER_ID" />
                            <asp:BoundField DataField="LOGO_TITLE" HeaderText="Logo">
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="80%"></ItemStyle>
                            </asp:BoundField>
                            <asp:ImageField
                                ControlStyle-CssClass="d-block"
                                DataImageUrlField="LOGO_IMG"
                                DataImageUrlFormatString="~/Images/logos/{0}"
                                HeaderText="Şəkil">
                                <ControlStyle CssClass="d-block" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%"></ItemStyle>
                            </asp:ImageField>
                            <asp:CommandField SelectText="Seç" ShowSelectButton="True" ButtonType="Button">
                                <ControlStyle ForeColor="White" CssClass="btn btn-primary btn-sm" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="32px" />
                            </asp:CommandField>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="delete_logo" runat="server" OnClientClick="return confirm('Silməyə əminsiz?'); " OnClick="delete_logo_Click" CausesValidation="False" CommandName="Delete" Text="Sil"></asp:LinkButton>
                                </ItemTemplate>
                                <ControlStyle CssClass="btn btn-danger btn-sm" />
                            </asp:TemplateField>
                        </Columns>

                        <EditRowStyle BackColor="#2461BF" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="White" Font-Bold="True" ForeColor="#9900CC" HorizontalAlign="Center" VerticalAlign="Middle" />
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
