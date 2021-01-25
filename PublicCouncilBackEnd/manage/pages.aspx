<%@ Page Title="" Language="C#" MasterPageFile="~/manage/Admin.Master" AutoEventWireup="true" CodeBehind="pages.aspx.cs" Inherits="PublicCouncilBackEnd.manage.WebForm12" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="/scripts/ckeditor/ckeditor.js"></script>
    <script src="/scripts/ckfinder/ckfinder.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="managelayout" runat="server">

    <div class="card card-nav-tabs card-plain mt-2">
        <div class="card-header">
            <div class="nav-tabs-navigation">
                <div class="nav-tabs-wrapper">
                    <ul class="nav nav-tabs" data-tabs="tabs">
                        <li class="nav-item">
                            <a class="nav-link active" href="#aboutus" data-toggle="tab">Haqqımızda</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#contactus" data-toggle="tab">Əlaqə</a>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
        <div class="card-body">
            <div class="tab-content bg-white text-center">
                <div class="tab-pane active" id="aboutus">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-12">
                                <div class="form-group">
                                    <label>Haqqımızda - AZ</label>
                                     <CKEditor:CKEditorControl ID="CKEditorAboutUsAz" runat="server" Height="300px" />
                                </div>
                                <div class="form-group">
                                    <label>Haqqımızda - EN</label>
                                    <CKEditor:CKEditorControl ID="CKEditorAboutUsEn" runat="server" Height="300px" />
                                </div>
                            </div>
                            <div class="col-12 pt-md-4">
                                <asp:Button ID="btnABOUTUS_SAVE" runat="server" CssClass="btn btn-primary btn-round" Text="Yadda saxla" OnClick="btnABOUTUS_SAVE_Click" />
                            </div>
                        </div>
                    </div>
                </div>

                <div class="tab-pane" id="contactus">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-12">
                                <div class="form-group">
                                    <label>Əlaqə - AZ</label>
                                    <CKEditor:CKEditorControl ID="CKEditorContactUsAz" runat="server" Height="300px"></CKEditor:CKEditorControl>
                                </div>
                                <div class="form-group">
                                    <label>Əlaqə - AZ</label>
                                    <CKEditor:CKEditorControl ID="CKEditorContactUsEn" runat="server" Height="300px"></CKEditor:CKEditorControl>
                                </div>
                            </div>
                            <div class="col-12 pt-md-4">
                                <asp:Button ID="btnCONTACTUS_SAVE" runat="server" CssClass="btn btn-success btn-round" Text="Yadda saxla" OnClick="btnCONTACTUS_SAVE_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    
    <script>
        document.addEventListener("DOMContentLoaded", function (event) {
            let editor = CKEDITOR.replace('CKEditorControl1');
            CKFinder.setupCKEditor(editor, './js/ckfinder/');
        });
        CKEDITOR.replace('CKEditorControl1', {
            htmlEncodeOutput: true
        });
    </script>

</asp:Content>
