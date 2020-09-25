<%@ Page Title="" Language="C#" MasterPageFile="~/manage/Admin.Master" AutoEventWireup="true" CodeBehind="sponsors.aspx.cs" Inherits="PublicCouncilBackEnd.manage.WebForm8" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="managelayout" runat="server">
    <asp:UpdatePanel ID="PostsUpdatePanel" runat="server">
        <ContentTemplate>
            <div class="card my-md-2">
                <!-- Card header -->
                <div class="card-header">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-12 col-md-6">
                                <h3 class="mb-0">Sponsorlar</h3>
                            </div>
                            <div class="col-12 col-md-6 text-right">
                                <asp:LinkButton ID="new_sponsor" runat="server" CssClass="btn btn-primary btn-sm btn-round" OnClick="new_sponsor_Click">
                                        Yeni Sponsor
                                </asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="table-responsive py-2">
                    <asp:GridView ID="SponsorList"
                        CssClass="table"
                        GridLines="None"
                        runat="server"
                        AutoGenerateColumns="False"
                        HorizontalAlign="Center"
                        PageSize="7" Width="100%"
                        OnPageIndexChanging="SponsorList_PageIndexChanging"
                        OnRowCreated="SponsorList_RowCreated"
                        OnSelectedIndexChanged="SponsorList_SelectedIndexChanged">
                        <Columns>
                            <asp:BoundField DataField="#" HeaderText="#" />
                            <asp:BoundField DataField="DATA_ID" HeaderText="DATA_ID" />
                            <asp:BoundField DataField="SPONSOR_TITLE" HeaderText="Sponsor" />
                            <asp:HyperLinkField DataNavigateUrlFields="SPONSOR_LINK" Target="_blank" DataTextField="SPONSOR_LINK" HeaderText="Link">
                                <ItemStyle CssClass="d-block" HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:HyperLinkField>
                            <asp:CommandField SelectText="Seç" ShowSelectButton="True" ButtonType="Button">
                                <ControlStyle ForeColor="White" CssClass="btn btn-primary btn-sm" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="32px" />
                            </asp:CommandField>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton
                                        ID="delete_sponsor"
                                        runat="server"
                                        OnClientClick="return confirm('Silməyə əminsiz?'); "
                                        OnClick="delete_sponsor_Click"
                                        CausesValidation="False"
                                        CommandName="Delete"
                                        Text="Sil"></asp:LinkButton>
                                </ItemTemplate>
                                <ControlStyle CssClass="btn btn-danger btn-sm" />
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#9900CC" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <HeaderStyle ForeColor="#9900CC" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:GridView>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
