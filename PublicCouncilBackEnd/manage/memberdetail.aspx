<%@ Page Title="" Language="C#" MasterPageFile="~/manage/Admin.Master" AutoEventWireup="true" CodeBehind="memberdetail.aspx.cs" Inherits="PublicCouncilBackEnd.manage.WebForm14" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #managelayout_fileMember {
            display: none;
        }
    </style>
    <script src="/scripts/ckeditor/ckeditor.js" async="async"></script>
    <script src="/scripts/ckfinder/ckfinder.js" async="async"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="managelayout" runat="server">

    <div class="card mt-2">
        <div class="card-header">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-6">
                        <p class="h3 m-0">Üzv</p>
                    </div>
                    <div class="col-6 text-right">
                        <asp:LinkButton ID="back" runat="server" CssClass="btn btn-danger btn-sm" OnClick="back_Click">
                            Geri
                        </asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>

        <div class="card-body">
            <div class="container-fluid" style="padding: 0 !important">

                <%--Member order number--%>
                <asp:Panel ID="MEMBER_ORDER_BLOCK" runat="server" CssClass="row">
                    <div class="col-12">
                        <div class="form-group">
                            <label for="managelayout_inputOrderNumber">Sira nömrəsi</label>
                            <asp:TextBox ID="memberOrderNumber" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                </asp:Panel>

                <div class="row">
                    <div class="col-12">
                        <div class="nav-wrapper">
                            <ul class="nav nav-pills nav-fill flex-column flex-md-row" id="tabs-icons-text" role="tablist">
                                <li class="nav-item">
                                    <a class="nav-link mb-sm-3 mb-md-0 active" id="tabs-icons-text-1-tab" data-toggle="tab" href="#tabs-icons-text-1" role="tab" aria-controls="tabs-icons-text-1" aria-selected="true">Az</a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link mb-sm-3 mb-md-0" id="tabs-icons-text-2-tab" data-toggle="tab" href="#tabs-icons-text-2" role="tab" aria-controls="tabs-icons-text-2" aria-selected="false">En</a>
                                </li>
                            </ul>
                        </div>
                        <div class="tab-content shadow-sm" id="myTabContent">
                            <div class="tab-pane fade show active" id="tabs-icons-text-1" role="tabpanel" aria-labelledby="tabs-icons-text-1-tab">
                                <div class="container-fluid" style="padding: 0 !important">
                                    <div class="row">
                                        <div class="col-6">
                                            <div class="form-group">
                                                <label for="managelayout_memberName">Ad</label>
                                                <asp:TextBox ID="memberName" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-6">
                                            <div class="form-group">
                                                <label for="managelayout_memberSurname">Soyad</label>
                                                <asp:TextBox ID="memberSurname" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-6">
                                            <div class="form-group">
                                                <label for="managelayout_memberFname">Ata adı</label>
                                                <asp:TextBox ID="memberFname" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-6">
                                            <div class="form-group">
                                                <label for="managelayout_memberPosition">Vəzifə</label>
                                                <asp:TextBox ID="memberPosition" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-12">
                                            <div class="form-group">
                                                <label>Haqqında</label>
                                                <CKEditor:CKEditorControl ID="memberDetail" runat="server" Height="300px"></CKEditor:CKEditorControl>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="tab-pane fade" id="tabs-icons-text-2" role="tabpanel" aria-labelledby="tabs-icons-text-2-tab">
                                <div class="container-fluid" style="padding: 0 !important">
                                    <div class="row">
                                        <div class="col-6">
                                            <div class="form-group">
                                                <label for="managelayout_memberName">Ad</label>
                                                <asp:TextBox ID="memberName_En" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-6">
                                            <div class="form-group">
                                                <label for="managelayout_memberSurname">Soyad</label>
                                                <asp:TextBox ID="memberSurname_En" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-6">
                                            <div class="form-group">
                                                <label for="managelayout_memberFname">Ata adı</label>
                                                <asp:TextBox ID="memberFname_En" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-6">
                                            <div class="form-group">
                                                <label for="managelayout_memberPosition">Vəzifə</label>
                                                <asp:TextBox ID="memberPosition_En" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-12">
                                            <div class="form-group">
                                                <label>Haqqında</label>
                                                <CKEditor:CKEditorControl ID="memberDetail_En" runat="server" Height="300px"></CKEditor:CKEditorControl>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>

                <%-- Member Image --%>
                <div class="row">
                    <div class="col-12">
                        <div class="form-group">
                            <div class="container-fluid" style="padding: 0 !important">
                                <div class="row">
                                    <div class="col-6">
                                        <asp:Image ID="memberImage" runat="server" ImageAlign="Middle" ImageUrl="~/Images/social-media-image.png" CssClass="w-100" />
                                    </div>
                                    <div class="col-6 text-right">
                                        <asp:FileUpload ID="fileMember" runat="server" accept=".png,.jpeg,.jpg,.tif" />
                                        <input class="form-control" type="text" value="fayl seçilməyib" id="customFileMember">
                                        <button class="btn btn-facebook my-2" id="btnFileMember">Fayl yüklə</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <%-- Confirm button --%>
                <div class="row">
                    <div class="col-12">
                        <div class="text-center my-2">
                            <asp:Button ID="btnConfirm" runat="server" Text="Əlavə et" CssClass="btn btn-success btn-round" OnClick="btnConfirm_Click" />
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>

    <script>
        document.addEventListener("DOMContentLoaded", function () {
            document.getElementById("sidenav-main").remove();
            document.getElementById("top-nav").remove();
            viewImage("managelayout_memberImage", "managelayout_fileMember", "customFileMember", "btnFileMember");
        });
    </script>

</asp:Content>
