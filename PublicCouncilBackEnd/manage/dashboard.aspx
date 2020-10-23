<%@ Page Title="" Language="C#" MasterPageFile="~/manage/Admin.Master" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="PublicCouncilBackEnd.manage.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="managelayout" runat="server">
    <div class="card my-2 bg-primary">
      
        <div class="card-body">
            <div class="container-fluid p-0">
                <div class="row">
                    <div class="col-md-4">
                        <div class="card card-stats m-0">
                            <div class="card-body">
                                <div class="row">
                                    <div class="col">
                                        <h5 class="card-title text-uppercase text-muted mb-0">Yüklənmiş məqalələr</h5>
                                        <span class="h2 font-weight-bold mb-0">
                                            <asp:Literal ID="postCount" runat="server"></asp:Literal>
                                        </span>
                                    </div>
                                    <div class="col-auto">
                                        <div class="icon icon-shape bg-gradient-red text-white rounded-circle shadow">
                                            <i class="ni ni-active-40"></i>
                                        </div>
                                    </div>
                                </div>      
                            </div>
                        </div>
                    </div>

                    <asp:Panel ID="PCCOUNT_PANEL" runat="server" CssClass="col-md-4">
                        <div class="card card-stats m-0">
                            <div class="card-body">
                                <div class="row">
                                    <div class="col">
                                        <h5 class="card-title text-uppercase text-muted mb-0">Qeydiyyatdan keçmiş şuralar</h5>
                                        <span class="h2 font-weight-bold mb-0">
                                            <asp:Literal ID="pcCount" runat="server"></asp:Literal>
                                        </span>
                                    </div>
                                    <div class="col-auto">
                                        <div class="icon icon-shape bg-gradient-red text-white rounded-circle shadow">
                                            <i class="ni ni-active-40"></i>
                                        </div>
                                    </div>
                                </div>      
                            </div>
                        </div>
                    </asp:Panel>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
