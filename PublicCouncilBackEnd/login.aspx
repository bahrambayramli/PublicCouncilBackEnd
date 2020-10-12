<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="PublicCouncilBackEnd.WebForm10" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainlayout" runat="server">
    <section class="site-login my-md-5">
        <div class="container">
            <div class="row justify-content-center">
                <div class="col-lg-5 col-md-6">
                    <div class="card bg-secondary border-0 py-md-2 rounded">

                        <div class="card-header bg-transparent">
                            <div class="text-muted text-center mt-2 mb-2">
                                <small class="h4">Daxil ol</small>   
                            </div>
                        </div>

                        <div class="card-body px-lg-5 py-lg-5">
                            <div>
                                <div class="form-group mb-3">
                                    <div
                                        class="input-group input-group-merge input-group-alternative">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text">
                                                <i class="ni ni-email-83"></i>
                                            </span>
                                        </div>
                                        <asp:TextBox ID="inputLogin" runat="server" CssClass="form-control" placeholder="login"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <div
                                        class="input-group input-group-merge input-group-alternative">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text"><i
                                                class="ni ni-lock-circle-open"></i></span>
                                        </div>
                                        
                                        <asp:TextBox ID="inputPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="şifrə"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <div class="text-right">
                                        <a href="/register" class="btn-link text-success">Qeydiyyat</a>
                                    </div>
                                </div>

                                <div class="text-center">
                                    <asp:Button ID="btnLogin" 
                                        runat="server" 
                                        Text="Daxil ol" 
                                        CssClass="btn btn-default my-4 btn-round" 
                                        OnClick="btnLogin_Click"  />
                                </div>

                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </section>

    <script>
        $('#contentside').removeData('col-md-9')
        $('#contentside').addClass('col-md-12');
        $(document).ready(function () {
            $('#rightside').remove();
        });
    </script>
</asp:Content>
