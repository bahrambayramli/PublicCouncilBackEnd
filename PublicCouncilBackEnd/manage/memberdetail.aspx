<%@ Page Title="" Language="C#" MasterPageFile="~/manage/Admin.Master" AutoEventWireup="true" CodeBehind="memberdetail.aspx.cs" Inherits="PublicCouncilBackEnd.manage.WebForm14" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #managelayout_fileMember{
            display: none;
        }     
    </style>
        <script src="/scripts/ckeditor/ckeditor.js"></script>
    <script src="/scripts/ckfinder/ckfinder.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="managelayout" runat="server">
    <div class="card mt-2">
        <div class="card-header">
            <p class="m-0 h3"></p>
        </div>
        <div class="card-body">
            <div class="container-fluid">
                <%--Member full name --%>
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
                </div>
                <%-- Member about --%>
                <div class="row">
                    <div class="col-12">
                          <CKEditor:CKEditorControl ID="memberDetail" runat="server" Height="300px"></CKEditor:CKEditorControl>
                    </div>
                </div>
                <%-- Member Image --%>
                <div class="row">
                    <div class="container-fluid" style="padding: 0 !important;">
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
            document.getElementById("sidenav-main").style.display = "none";
            document.getElementById("top-nav").style.display = "none";
            viewImage("managelayout_memberImage", "managelayout_fileMember", "customFileMember", "btnFileMember")
        });
    </script>
</asp:Content>
