<%@ Page Title="" Language="C#" MasterPageFile="~/manage/Admin.Master" AutoEventWireup="true" CodeBehind="members.aspx.cs" Inherits="PublicCouncilBackEnd.manage.WebForm13" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="managelayout" runat="server">
    <asp:UpdatePanel ID="UpdatePanel" runat="server">
        <ContentTemplate>
            <div class="card mt-2">
                <div class="card-header">
                    <p class="m-0 h3">Üzvlər</p>
                </div>
                <div class="card-body">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-12">
                                <div class="text-right p-2">
                                    <asp:LinkButton ID="newMember" runat="server" CssClass="btn btn-primary btn-round btn-sm" OnClick="newMember_Click1">
                                                 Yeni üzv
                                    </asp:LinkButton>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-12">
                                <div class="table-responsive py-2">
                                    <asp:GridView
                                        ID="MemberList"
                                        runat="server"
                                        Width="100%"
                                        AutoGenerateColumns="False"
                                        CssClass="table"
                                        OnRowCreated="MemberList_RowCreated"
                                        CellPadding="4"
                                        ForeColor="#333333"
                                        GridLines="None"
                                        AllowPaging="True"
                                        OnPageIndexChanging="MemberList_PageIndexChanging"
                                        OnSelectedIndexChanged="MemberList_SelectedIndexChanged">
                                        <AlternatingRowStyle BackColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />

                                        <Columns>
                                            <asp:BoundField DataField="#" HeaderText="#" />
                                            <asp:BoundField DataField="MEMBER_ID" HeaderText="MEMBER_ID" />
                                            <asp:BoundField DataField="MEMBER_NAME_AZ" HeaderText="Ad" />
                                            <asp:BoundField DataField="MEMBER_SURNAME_AZ" HeaderText="Soyad" />
                                            <asp:CommandField SelectText="Seç" ShowSelectButton="True" ButtonType="Button">
                                                <ControlStyle ForeColor="White" CssClass="btn btn-primary btn-sm" />
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="32px" />
                                            </asp:CommandField>
                                            <asp:TemplateField ShowHeader="False">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="delete_member" runat="server" OnClientClick="return confirm('Silməyə əminsiz?'); " OnClick="delete_member_Click" CausesValidation="False" CommandName="Delete" Text="Sil"></asp:LinkButton>
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
                        </div>
                    </div>
                    
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <script>
        document.addEventListener("DOMContentLoaded", function () {
            document.getElementById("sidenav-main").remove();
            document.getElementById("top-nav").remove();
        });
    </script>
</asp:Content>
