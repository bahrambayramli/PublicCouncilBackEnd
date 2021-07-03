<%@ Page Title="" Language="C#" MasterPageFile="~/manage/Admin.Master" AutoEventWireup="true" CodeBehind="councils.aspx.cs" Inherits="PublicCouncilBackEnd.manage.WebForm10" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="managelayout" runat="server">
    <div class="card my-md-2">
        <!-- Card header -->
        <div class="card-header">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-12 col-md-6">
                        <h3 class="mb-0">İctimai şuralar</h3>
                    </div>
                    <div class="col-12 col-md-6 text-right">
                        <asp:LinkButton ID="new_pc" runat="server" CssClass="btn btn-primary btn-sm btn-round" OnClick="new_pc_Click">
                                        Yeni şura
                        </asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>

        <div class="card-body">
            <div class="card card-nav-tabs card-plain">
                <div class="card-header p-0">
                    <div class="nav-tabs-navigation">
                        <div class="nav-tabs-wrapper">
                            <ul class="nav nav-tabs" data-tabs="tabs">
                                <li class="nav-item">
                                    <asp:HyperLink ID="pcList" CssClass="nav-link active" runat="server" NavigateUrl="#pclist" data-toggle="tab">İctimai şura</asp:HyperLink>
                                </li>
                                <li class="nav-item">
                                    <asp:HyperLink ID="pcDeleted" CssClass="nav-link" runat="server" NavigateUrl="#pcdeleted" data-toggle="tab">Silinmiş</asp:HyperLink>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
                <div class="card-body p-0">
                    <div class="tab-content bg-white text-center">
                        <div class="tab-pane active" id="pclist">
                            <asp:UpdatePanel ID="UpdatePanel_PC" runat="server">
                                <ContentTemplate>
                                    <div class="table-responsive py-2">
                                        <asp:GridView
                                            ID="PCLists"
                                            runat="server"
                                            Width="100%"
                                            AutoGenerateColumns="False"
                                            CssClass="table"
                                            OnRowCreated="PCLists_RowCreated"
                                            CellPadding="4"
                                            ForeColor="#333333"
                                            GridLines="None"
                                            AllowPaging="True"
                                            OnPageIndexChanging="PCLists_PageIndexChanging"
                                            OnSelectedIndexChanged="PCLists_SelectedIndexChanged">
                                            <AlternatingRowStyle BackColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />

                                            <Columns>
                                                <asp:BoundField DataField="#" HeaderText="#" />
                                                <asp:BoundField DataField="USER_ID" HeaderText="ID" />
                                                <asp:BoundField DataField="USER_SERIAL" HeaderText="USER_SERIAL" />

                                                <asp:BoundField DataField="USER_NAME" HeaderText="Ad">
                                                    <ControlStyle Width="500px" />
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="500px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="USER_SURNAME" HeaderText="Soyad">
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="500px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="PC_NAME" HeaderText="İctimai şura ad">
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="500px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="USER_MEMBERSHIP" HeaderText="Üzvlük növü">
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="500px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="USER_MEMBERSHIP_TYPE" HeaderText="Üzvlük tipi">
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="500px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="USER_PCDOMAIN" HeaderText="Domain" />
                                                <asp:CommandField SelectText="Seç" ShowSelectButton="True" ButtonType="Button">
                                                    <ControlStyle ForeColor="White" CssClass="btn btn-primary btn-sm" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="32px" />
                                                </asp:CommandField>
                                                <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="delete_pc" runat="server" OnClientClick="return confirm('Silməyə əminsiz?'); " OnClick="delete_pc_Click" CausesValidation="False" CommandName="Delete" Text="Sil"></asp:LinkButton>
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
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>

                        <div class="tab-pane" id="pcdeleted">
                            <asp:UpdatePanel ID="UpdatePanel_DELETED" runat="server">
                                <ContentTemplate>
                                    <div class="table-responsive py-2">
                                        <asp:GridView
                                            ID="PC_DELETED"
                                            runat="server"
                                            Width="100%"
                                            AutoGenerateColumns="False"
                                            CssClass="table"
                                            OnRowCreated="PC_DELETED_RowCreated"
                                            CellPadding="4"
                                            ForeColor="#333333"
                                            GridLines="None"
                                            AllowPaging="True"
                                            OnPageIndexChanging="PC_DELETED_PageIndexChanging"
                                            OnSelectedIndexChanged="PC_DELETED_SelectedIndexChanged">
                                            <AlternatingRowStyle BackColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />

                                            <Columns>
                                                <asp:BoundField DataField="#" HeaderText="#" />
                                                <asp:BoundField DataField="USER_ID" HeaderText="ID" />
                                                <asp:BoundField DataField="USER_SERIAL" HeaderText="USER_SERIAL" />

                                                <asp:BoundField DataField="USER_NAME" HeaderText="Ad">
                                                    <ControlStyle Width="500px" />
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="500px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="USER_SURNAME" HeaderText="Soyad">
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="500px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="PC_NAME" HeaderText="İctimai şura ad">
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="500px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="USER_MEMBERSHIP" HeaderText="Üzvlük növü">
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="500px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="USER_MEMBERSHIP_TYPE" HeaderText="Üzvlük tipi">
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="500px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="USER_PCDOMAIN" HeaderText="Domain" />
                                                <asp:CommandField SelectText="Seç" ShowSelectButton="True" ButtonType="Button">
                                                    <ControlStyle ForeColor="White" CssClass="btn btn-primary btn-sm" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="32px" />
                                                </asp:CommandField>
                                                <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="restore_pc" runat="server" OnClientClick="return confirm('Bərpa olunsun?'); " OnClick="restore_pc_Click" CausesValidation="False" CommandName="Delete" Text="Bərpa"></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ControlStyle CssClass="btn btn-success btn-sm" />
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
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
