<%@ Page Title="" Language="C#" MasterPageFile="~/manage/Admin.Master" AutoEventWireup="true" CodeBehind="sociallinks.aspx.cs" Inherits="PublicCouncilBackEnd.manage.WebForm18" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="managelayout" runat="server">
    <asp:UpdatePanel ID="UpdatePanel" runat="server">
        <ContentTemplate>
            <div class="card my-md-2">
                <!-- Card header -->
                <div class="card-header card-header-primary">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-12 col-md-6">
                                <h3 class="m-0">Sosial media linklər</h3>
                            </div>
                            <div class="col-12 col-md-6 text-right">
                                <asp:LinkButton ID="new_SOCIAL_link" runat="server" CssClass="btn btn-sm btn-facebook btn-sm btn-round" OnClick="new_SOCIAL_link_Click">
                                        Yeni Link
                                </asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- Card body -->
                <div class="card-body">
                    <div class="table-responsive py-2">
                        <asp:GridView
                            ID="SocialLinks"
                            runat="server"
                            Width="100%"
                            AutoGenerateColumns="False"
                            CssClass="table"
                            OnRowCreated="SocialLinks_RowCreated"
                            CellPadding="4"
                            ForeColor="#333333"
                            GridLines="None"
                            AllowPaging="True"
                            OnPageIndexChanging="SocialLinks_PageIndexChanging"
                            OnSelectedIndexChanged="SocialLinks_SelectedIndexChanged">
                            <AlternatingRowStyle BackColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />

                            <Columns>
                                <asp:BoundField DataField="#" HeaderText="#" />
                                <asp:BoundField DataField="SOCIAL_LINK_ID" HeaderText="SOCIAL_LINK_ID" />
                                <asp:BoundField DataField="SOCIAL_LINK_NAME" HeaderText="Link ad" />
                                <asp:BoundField DataField="SOCIAL_LINK_URL" HeaderText="Link url" />
                                <asp:CommandField SelectText="Seç" ShowSelectButton="True" ButtonType="Button">
                                    <ControlStyle ForeColor="White" CssClass="btn btn-primary btn-sm" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="32px" />
                                </asp:CommandField>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="delete_link" runat="server" OnClientClick="return confirm('Silməyə əminsiz?'); " OnClick="delete_link_Click" CausesValidation="False" CommandName="Delete" Text="Sil"></asp:LinkButton>
                                    </ItemTemplate>
                                    <ControlStyle CssClass="btn btn-danger btn-sm" />
                                </asp:TemplateField>
                            </Columns>

                            <EditRowStyle BackColor="#2461BF" HorizontalAlign="Center" VerticalAlign="Middle" />
                            <FooterStyle BackColor="#003366" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#003366" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
                            <PagerStyle BackColor="#003366" ForeColor="White" HorizontalAlign="Center" Font-Size="Large" VerticalAlign="Middle" />
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
