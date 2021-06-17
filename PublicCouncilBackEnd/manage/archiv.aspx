<%@ Page Title="" Language="C#" MasterPageFile="~/manage/Admin.Master" AutoEventWireup="true" CodeBehind="archiv.aspx.cs" Inherits="PublicCouncilBackEnd.manage.WebForm17" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="managelayout" runat="server">
    <div class="card my-md-2">
        <div class="card-header">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-12">
                        <p class="h3 m-0">
                            Arxiv et
                        </p>
                    </div>
                </div>
            </div>
        </div>
        <div class="card-body">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-md-6">
                        <label class="mb-2">Saytı arxiv et</label>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <div class="mb-2">
                                    <asp:Button ID="get_archives" runat="server" CssClass="btn btn-primary" Text="Yenilə" OnClick="get_archives_Click" />
                                    <asp:Button ID="hosting_back_up" runat="server" CssClass="btn btn-warning" Text="Arxiv et" OnClick="hosting_back_up_Click" />
                                    <asp:Literal ID="backup_status" runat="server"></asp:Literal>
                                </div>
                                <asp:GridView
                                    ID="SiteArchivesList"
                                    runat="server"
                                    Width="100%"
                                    AutoGenerateColumns="False"
                                    CssClass="table"
                                    OnRowCreated="SiteArchivesList_RowCreated"
                                    CellPadding="4"
                                    ForeColor="#333333"
                                    GridLines="None"
                                    AllowPaging="True"
                                    OnPageIndexChanging="SiteArchivesList_PageIndexChanging">
                                    <AlternatingRowStyle BackColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />

                                    <Columns>
                                        <asp:BoundField DataField="#" HeaderText="#" />
                                        <asp:BoundField DataField="ARCHIVE_ID" HeaderText="ARCHIVE_ID" />
                                        <asp:BoundField DataField="ARCHIVE_NAME" HeaderText="Arxiv" />
                                        <asp:BoundField DataField="CREATED_DATE" HeaderText="Tarix" />
                                        <asp:ImageField DataImageUrlFormatString="~/images/zip-file.png" />
                                        <asp:HyperLinkField DataNavigateUrlFields="ZIP_LINK" DataTextField="ZIP_LINK" Target="_blank" DataTextFormatString="Yüklə" />
                                        <asp:TemplateField ShowHeader="False">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="delete_archive" runat="server" OnClientClick="return confirm('Silməyə əminsiz?'); " OnClick="delete_archive_Click" CausesValidation="False" CommandName="Delete" Text="Sil"></asp:LinkButton>
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
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="col-md-6">
                        <label class="mb-2">Bazanı arxiv et</label>
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <div class="mb-2">
                                    <asp:Button ID="get_dbs" runat="server" CssClass="btn btn-primary" Text="Yenilə" OnClick="get_dbs_Click" />
                                    <asp:Button ID="hoisting_db_backup" runat="server" CssClass="btn btn-warning" Text="Arxiv et" OnClick="hoisting_db_backup_Click" />
                                    <asp:Literal ID="db_status" runat="server"></asp:Literal>
                                </div>
                                <asp:GridView
                                    ID="DBArchiveList"
                                    runat="server"
                                    Width="100%"
                                    AutoGenerateColumns="False"
                                    CssClass="table"
                                    OnRowCreated="DBArchiveList_RowCreated"
                                    CellPadding="4"
                                    ForeColor="#333333"
                                    GridLines="None"
                                    AllowPaging="True"
                                    OnPageIndexChanging="DBArchiveList_PageIndexChanging">
                                    <AlternatingRowStyle BackColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />

                                    <Columns>
                                        <asp:BoundField DataField="#" HeaderText="#" />
                                        <asp:BoundField DataField="DB_ID" HeaderText="ARCHIVE_ID" />
                                        <asp:BoundField DataField="DB_NAME" HeaderText="Arxiv" />
                                        <asp:BoundField DataField="CREATED_DATE" HeaderText="Tarix" />
                                        <asp:HyperLinkField DataNavigateUrlFields="ZIP_LINK" DataTextField="ZIP_LINK" Target="_blank" DataTextFormatString="Yüklə" />
                                        <asp:TemplateField ShowHeader="false">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="delete_db_archive" runat="server" OnClientClick="return confirm('Silməyə əminsiz?'); " OnClick="delete_db_archive_Click" CausesValidation="False" CommandName="Delete" Text="Sil"></asp:LinkButton>
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
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
