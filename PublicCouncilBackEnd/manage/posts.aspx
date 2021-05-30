<%@ Page Title="" Language="C#" MasterPageFile="~/manage/Admin.Master" AutoEventWireup="true" CodeBehind="posts.aspx.cs" Inherits="PublicCouncilBackEnd.manage.WebForm2" %>

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
                                <p class="mb-0 h3">Postlar</p>
                            </div>
                            <div class="col-12 col-md-6 text-right">
                                <asp:LinkButton ID="new_post" runat="server" CssClass="btn btn-primary btn-sm btn-round" OnClick="new_post_Click">
                                        Yeni post
                                </asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="card-body">
                    <div class="post-filter my-1">
                        <div class="container-fluid" style="padding: 0!important">
                            <div class="row">
                                <div class="col-6">
                                    <asp:DropDownList ID="pcSelectList" runat="server" CssClass="form-control" DataSourceID="SqlDataSource1" DataTextField="PC_NAME" DataValueField="USER_ID" AutoPostBack="true" OnSelectedIndexChanged="pcSelectList_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:pc %>" SelectCommand="SELECT USER_ID, PC_NAME FROM PC_USERS WHERE (ISACTIVE = @ISACTIVE) AND (ISDELETE = @ISDELETE)">
                                        <SelectParameters>
                                            <asp:QueryStringParameter Name="ISACTIVE" QueryStringField="true" Type="Boolean" DefaultValue="true" />
                                            <asp:QueryStringParameter Name="ISDELETE" QueryStringField="false" Type="Boolean" DefaultValue="false" />

                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                </div>
                                <div class="col-6">
                                    <div class="d-flex justify-content-between">
                                        <asp:TextBox ID="inputSearch" runat="server" CssClass="form-control mr-2"></asp:TextBox>
                                        <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-primary mr-2" Text="Axtar" OnClick="btnSearch_Click" />
                                        <asp:Button ID="btnGetAll" runat="server" CssClass="btn btn-success" Text="Yenilə" OnClick="btnGetAll_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="table-responsive py-2">
                        <asp:GridView
                            ID="PostsList"
                            runat="server"
                            Width="100%"
                            AutoGenerateColumns="False"
                            CssClass="table"
                            OnRowCreated="PostsList_RowCreated"
                            CellPadding="4"
                            ForeColor="#333333"
                            GridLines="None"
                            AllowPaging="True"
                            OnPageIndexChanging="PostsList_PageIndexChanging"
                            OnSelectedIndexChanged="PostsList_SelectedIndexChanged">
                            <AlternatingRowStyle BackColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />

                            <Columns>
                                <asp:BoundField DataField="#" HeaderText="#" />
                                <asp:BoundField DataField="DATA_ID" HeaderText="DATA_ID" />
                                <asp:BoundField DataField="USER_ID" HeaderText="DATA_ID" />
                                <asp:BoundField DataField="POST_SEOAZ" HeaderText="Başlıq Az">
                                    <ControlStyle Width="600px" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="600px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="POST_SEOEN" HeaderText="Başlıq En">
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="600px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="POST_SITECATEGORYAZ" HeaderText="Bölmə" />
                                <asp:BoundField DataField="POST_SITESUBCATEGORYAZ" HeaderText="Alt bölmə" />
                                <asp:BoundField DataField="POST_DATE" HeaderText="Tarix" />
                                <asp:CommandField SelectText="Seç" ShowSelectButton="True" ButtonType="Button">
                                    <ControlStyle ForeColor="White" CssClass="btn btn-primary btn-sm" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="32px" />
                                </asp:CommandField>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="delete_post" runat="server" OnClientClick="return confirm('Silməyə əminsiz?'); " OnClick="delete_post_Click" CausesValidation="False" CommandName="Delete" Text="Sil"></asp:LinkButton>
                                    </ItemTemplate>
                                    <ControlStyle CssClass="btn btn-danger btn-sm" />
                                </asp:TemplateField>
                            </Columns>

                            <EditRowStyle BackColor="#2461BF" HorizontalAlign="Center" VerticalAlign="Middle" />
                            <FooterStyle BackColor="#003366" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="White" Font-Bold="True" ForeColor="#9900CC" HorizontalAlign="Center" VerticalAlign="Middle" />
                            <PagerStyle BackColor="#003366" ForeColor="White" HorizontalAlign="Center" Font-Size="Large" VerticalAlign="Middle" CssClass="p-0" />
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
