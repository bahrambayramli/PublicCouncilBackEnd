<%@ Page Title="" Language="C#" MasterPageFile="~/manage/Admin.Master" AutoEventWireup="true" CodeBehind="sociallinkdetail.aspx.cs" Inherits="PublicCouncilBackEnd.manage.WebForm19" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="managelayout" runat="server">
        <div class="card my-md-2">
        <div class="card-header card-header-primary">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-6">
                        <p class="h3 m-0">Link</p>
                    </div>
                    <div class="col-6">
                        <div class="text-right">
                            <asp:LinkButton ID="back_button" runat="server" CssClass="btn btn-danger btn-sm" OnClick="back_button_Click">
                            Geri
                            </asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="card-body">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-12">
                        <div class="form-group">
                            <label for="managelayout_text_link_name">Link ad</label>
                            <asp:TextBox ID="text_link_name" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-12">
                        <div class="form-group">
                            <label for="managelayout_text_link_url">Link url</label>
                            <asp:TextBox ID="text_link_url" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-12 col-md-6">
                        <div class="form-group">
                            <label for="managelayout_text_link_icon">Link ikon</label>
                            <asp:TextBox ID="text_link_icon" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-12 col-md-6">
                        <div class="form-group">
                            <label for="">Ikonlar</label>
                            <div>
                                 <a class="btn btn-block btn-success text-white" href="https://fontawesome.com/icons?d=gallery&p=2&q=link" target="_blank">Ikon cedveli</a>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-12">
                        <div class="text-center">
                            <asp:Button ID="button_confitm" CssClass="btn btn-primary btn-round" runat="server" Text="Təsdiq et" OnClick="button_confitm_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
