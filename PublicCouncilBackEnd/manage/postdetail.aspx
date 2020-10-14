<%@ Page Title="" Language="C#" MasterPageFile="~/manage/Admin.Master" AutoEventWireup="true" CodeBehind="postdetail.aspx.cs" Inherits="PublicCouncilBackEnd.manage.WebForm3" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        img{
            display:block;
            width:100%;
        }
        .content {
            margin: 0 !important;
        }

        #managelayout_inpFile,
        #managelayout_subFile,
        #managelayout_labelTime,
        #managelayout__docsupload,
        #managelayout_subImgUpload {
            display: none;
        }
    </style>
    <script src="/scripts/ckeditor/ckeditor.js"></script>
    <script src="/scripts/ckfinder/ckfinder.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="managelayout" runat="server">

    <div class="card my-md-2">
        <!-- Postdetail header case -->
        <div class="card-header">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-6">
                        <p class="h3">Yeni post</p>
                    </div>
                    <div class="col-6 text-right">
                        <asp:LinkButton ID="back" runat="server" CssClass="btn btn-danger btn-sm" OnClick="back_Click">
                            Geri
                        </asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
        <!-- Post deatil body case -->
        <div class="card-body">
            <div class="container-fluid" style="padding: 0!important;">

                <div class="row">
                    <div class="col-12">
                        <div class="form-group">
                            <label for="managelayout_pcSelectList">Təşkilat</label>
                            <asp:DropDownList ID="pcSelectList" runat="server" CssClass="form-control" DataSourceID="SqlDataSource1" DataTextField="PC_NAME" DataValueField="USER_ID"></asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:pc %>" SelectCommand="SELECT USER_ID, PC_NAME FROM PC_USERS WHERE (ISACTIVE = @ISACTIVE) AND (ISDELETE = @ISDELETE)">
                                <SelectParameters>
                                    <asp:QueryStringParameter Name="ISACTIVE" QueryStringField="true" Type="Boolean" DefaultValue="true" />
                                    <asp:QueryStringParameter Name="ISDELETE" QueryStringField="false" Type="Boolean" DefaultValue="false" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </div>
                    </div>
                </div>

                <!-- Category and subcategory -->
                <asp:UpdatePanel ID="NAVPANEL" runat="server" class="row">
                    <ContentTemplate>
                        <div class="col">
                            <div class="form-group">
                                <label for="managelayout_category_list" class="h4 text-primary">Kateqoriya</label>
                                <asp:DropDownList ID="category_list" runat="server" CssClass="form-control" OnSelectedIndexChanged="category_list_SelectedIndexChanged" AutoPostBack="true">
                                </asp:DropDownList>
                            </div>

                        </div>
                        <div class="col">
                            <div class="form-group">
                                <label for="managelayout_subcategory_list" class="h4 text-primary">Alt kateqoriya</label>
                                  <asp:DropDownList ID="subcategory_list" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
              
                <!-- Type  and date -->
                <div class="row">
                    <div class="col">
                        <div class="form-group">
                            <label for="managelayout_type_list" class="h4 text-primary">Bölmə</label>
                            <asp:DropDownList ID="type_list" runat="server" CssClass="form-control">
                                <asp:ListItem Value="main">Əsas</asp:ListItem>
                                <asp:ListItem Value="rightupper">Sağ yuxarı</asp:ListItem>
                                <asp:ListItem Value="rightlower">Sağ aşağı</asp:ListItem>
                                <asp:ListItem Value="latestpost">son xəbərlər</asp:ListItem>
                                <asp:ListItem Value="simple">Sadə</asp:ListItem>
                            </asp:DropDownList>
                        </div>

                    </div>
                    <div class="col">
                        <div class="form-group">
                            <label for="managelayout_post_date" class="h4 text-primary">Tarix</label>
                            <div class="form-group">
                                  <asp:Label ID="labelTime" runat="server" Text=""></asp:Label>
                               
                                <asp:TextBox ID="post_date" runat="server" CssClass="datetimepicker form-control" ></asp:TextBox>

                            </div>
                        </div>
                    </div>
                </div>

                <!-- Seo , post title and post content -->
                <div class="row">
                    <div class="col-12 border mb-2">
                        <div class="form-group">
                            <label for="" class="h4 text-primary">Bölmə</label>
                            <div class="nav-wrapper">
                                <ul class="nav nav-pills nav-fill flex-column flex-md-row"
                                    id="tabs-icons-text" role="tablist">
                                    <li class="nav-item">
                                        <a class="nav-link mb-sm-3 mb-md-0 active"
                                            id="tabs-icons-text-1-tab" data-toggle="tab"
                                            href="#lang-az" role="tab"
                                            aria-controls="tabs-icons-text-1"
                                            aria-selected="true">Az</a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link mb-sm-3 mb-md-0"
                                            id="tabs-icons-text-2-tab" data-toggle="tab"
                                            href="#lang-en" role="tab"
                                            aria-controls="tabs-icons-text-2"
                                            aria-selected="false">En</a>
                                    </li>

                                </ul>
                            </div>
                            <div class="card shadow">
                                <div class="card-body p-0">
                                    <div class="tab-content" id="myTabContent">
                                        <div class="tab-pane fade show active"
                                            id="lang-az" role="tabpanel"
                                            aria-labelledby="tabs-icons-text-1-tab">

                                            <div class="form-group">
                                                <label for="managelayout_postseo_az"class="h4 text-primary">SEO Başlıq:Az</label>
                                                <asp:TextBox ID="postseo_az" runat="server" CssClass="form-control mb-2"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label for="" class="h4 text-primary"> Post Başlıq:Az </label>
                                                <CKEditor:CKEditorControl ID="posttitle_az" runat="server" Height="100px"></CKEditor:CKEditorControl>
                                            </div>
                                            <div class="form-group ">
                                                <label for="managelayout_az_view" class="h4 text-primary">
                                                    Saytda görsənsin:Az
                                                </label>
                                                <asp:DropDownList ID="az_view" runat="server" CssClass="form-control w-10 my-2">
                                                    <asp:ListItem Value="yes">Bəli</asp:ListItem>
                                                    <asp:ListItem Value="no">Xeyr</asp:ListItem>
                                                </asp:DropDownList>
                                                 <CKEditor:CKEditorControl ID="post_az" runat="server" Height="300px"></CKEditor:CKEditorControl>
                                            </div>

                                        </div>
                                        <div class="tab-pane fade" id="lang-en"
                                            role="tabpanel"
                                            aria-labelledby="tabs-icons-text-2-tab">
                                            <div class="form-group">
                                                <label for="managelayout_postseo_en" class="h4 text-primary">SEO Başlıq:En</label>
                                                <asp:TextBox ID="postseo_en" runat="server" CssClass="form-control mb-2"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label for="managelayout_posttitle_en" class="h4 text-primary">Post Başlıq:En</label>
                                                <CKEditor:CKEditorControl ID="posttitle_en" runat="server"></CKEditor:CKEditorControl>
                                            </div>
                                            <div class="form-group ">
                                                <label for="managelayout_en_view" class="h4 text-primary">
                                                    Saytda görsənsin:En
                                                </label>
                                                <asp:DropDownList ID="en_view" runat="server" CssClass="form-control w-10 my-2">
                                                    <asp:ListItem Value="yes">Bəli</asp:ListItem>
                                                    <asp:ListItem Value="no">Xeyr</asp:ListItem>
                                                </asp:DropDownList>
                                                <CKEditor:CKEditorControl ID="post_en" runat="server" Height="300px"></CKEditor:CKEditorControl>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <!--  Main and sub images -->
                <div class="row">
                    <div class="col-12 border mb-2">
                        <div class="form-group">
                            <label for="" class="h4 text-primary">Şəkil</label>
                            <div class="nav-wrapper">
                                <ul class="nav nav-pills nav-fill flex-column flex-md-row"
                                    id="tabs-icons-text" role="tablist">
                                    <li class="nav-item">
                                        <a class="nav-link mb-sm-3 mb-md-0 active"
                                            id="tabs-icons-text-1-tab" data-toggle="tab"
                                            href="#mainimg" role="tab"
                                            aria-controls="tabs-icons-text-1"
                                            aria-selected="true">Əsas</a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link mb-sm-3 mb-md-0"
                                            id="tabs-icons-text-2-tab" data-toggle="tab"
                                            href="#subimgs" role="tab"
                                            aria-controls="tabs-icons-text-2"
                                            aria-selected="false">Alt</a>
                                    </li>

                                </ul>
                            </div>
                            <div class="card shadow">
                                <div class="card-body p-0">
                                    <div class="tab-content" id="myTabContent">
                                        <div class="tab-pane fade show active"
                                            id="mainimg" role="tabpanel"
                                            aria-labelledby="tabs-icons-text-1-tab">

                                            <div class="container-fluid"
                                                style="padding: 0 !important;">
                                                <div class="row">
                                                    <div class="col-6">
                                                        <asp:Image ID="mainimage" runat="server" ImageAlign="Middle" ImageUrl="~/Images/social-media-image.png" CssClass="w-100" />
                                                    </div>
                                                    <div class="col-6 text-right">
                                                        <asp:FileUpload ID="inpFile" runat="server" accept=".png,.jpeg,.jpg,.tif" />
                                                        <input class="form-control" type="text" value="fayl seçilməyib" id="customFile">
                                                        <button class="btn btn-facebook my-2" id="btnFile">Fayl yüklə</button>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                        <div class="tab-pane fade" id="subimgs" role="tabpanel" aria-labelledby="tabs-icons-text-2-tab">
                                            <div class="container-fluid" style="padding: 0 !important;">
                                                <div class="row">
                                                    <div class="col-6">
                                                        <asp:UpdatePanel ID="SubImagesUpdatePanel" runat="server" class="table-responsive">
                                                            <ContentTemplate>
                                                                <asp:GridView
                                                                    ID="subImageList"
                                                                    runat="server"
                                                                    CssClass="table"
                                                                    OnPageIndexChanging="subImageList_PageIndexChanging"
                                                                    OnRowCreated="subImageList_RowCreated"
                                                                    PageSize="5" AllowPaging="True"
                                                                    AutoGenerateColumns="False"
                                                                    GridLines="None">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="#" HeaderText="#"></asp:BoundField>
                                                                        <asp:BoundField DataField="DATA_ID" HeaderText="DATA_ID">
                                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="65%" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="USER_ID" HeaderText="USER_ID"></asp:BoundField>
                                                                        <asp:BoundField DataField="POST_SERIAL" HeaderText="POST_SERIAL"></asp:BoundField>
                                                                        <asp:BoundField DataField="POST_IMG_NAME" HeaderText="POST_IMG_NAME"></asp:BoundField>

                                                                        <asp:ImageField
                                                                            DataImageUrlField="POST_IMG_NAME"
                                                                            DataImageUrlFormatString="~/images/subimages/{0}"
                                                                            HeaderText="Şəkil">
                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="25%"></ItemStyle>
                                                                        </asp:ImageField>

                                                                        <asp:CommandField SelectText="Seç" ShowSelectButton="True" ButtonType="Button">
                                                                            <ControlStyle ForeColor="White" CssClass="btn btn-primary btn-sm" />
                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="32px" />
                                                                        </asp:CommandField>
                                                                        <asp:TemplateField ShowHeader="False">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton
                                                                                    ID="deletePostSubImage"
                                                                                    runat="server"
                                                                                    OnClientClick="return confirm('Silməyə əminsiz?');"
                                                                                    OnClick="deletePostSubImage_Click" CausesValidation="False"
                                                                                    CommandName="Delete"
                                                                                    Text="Sil"></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                            <ControlStyle CssClass="btn btn-danger btn-sm w-25" />
                                                                        </asp:TemplateField>

                                                                    </Columns>
                                                                </asp:GridView>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </div>
                                                    <div class="col-6">
                                                        <asp:FileUpload ID="subImgUpload" runat="server" accept=".png,.jpeg,.jpg,.tif" AllowMultiple="true" />
                                                        <input class="form-control" type="text" value="fayl seçilməyib" id="customFileSub">
                                                        <div class="text-right my-2">
                                                            <button class="btn btn-facebook" id="btnFileSub">Fayl yüklə</button>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- Video and Video Galery -->
                <div class="row">
                    <div class="col-12 border mb-2">
                        <div class="form-group">
                            <label for="" class="h4 text-primary">Video</label>
                            <div class="nav-wrapper">
                                <ul class="nav nav-pills nav-fill flex-column flex-md-row"
                                    id="tabs-icons-text" role="tablist">
                                    <li class="nav-item">
                                        <a class="nav-link mb-sm-3 mb-md-0 active" id="tabs-icons-text-1-tab" data-toggle="tab" href="#mainvideo" role="tab" aria-controls="tabs-icons-text-1" aria-selected="true">
                                            Video
                                        </a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link mb-sm-3 mb-md-0" id="tabs-icons-text-2-tab" data-toggle="tab" href="#videogalery" role="tab" aria-controls="tabs-icons-text-2" aria-selected="false">
                                            Video Galery
                                        </a>
                                    </li>

                                </ul>
                            </div>
                            <div class="card shadow">
                                <div class="card-body p-0">
                                    <div class="tab-content" id="myTabContent">
                                        <div class="tab-pane fade show active" id="mainvideo" role="tabpanel" aria-labelledby="tabs-icons-text-1-tab">
                                            <div class="container-fluid" style="padding: 0 !important;">
                                                <div class="row">
                                                    <div class="col-6">
                                                        <div class="form-group">
                                                            <label for="adminLayout_mainvideo_frame">IFRAME</label>
                                                            <asp:TextBox ID="mainvideo_frame" runat="server" CssClass="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-6">
                                                        <div class="form-group">
                                                            <label for="adminLayout_mainvideo_title">Video başlıq</label>
                                                            <asp:TextBox ID="mainvideo_title" runat="server" CssClass="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="tab-pane fade" id="videogalery" role="tabpanel" aria-labelledby="tabs-icons-text-2-tab">
                                            <asp:UpdatePanel ID="VideoGaleryUpdatePanel" runat="server" class="container-fluid" style="padding:0!important">
                                                <ContentTemplate>
                                                    <div class="row">
                                                        <div class="col-12 col-md-6">
                                                            <asp:ListBox
                                                                ID="videogalery_list"
                                                                runat="server"
                                                                CssClass="form-control"
                                                                OnSelectedIndexChanged="videogalery_list_SelectedIndexChanged"
                                                                Width="100%"
                                                                Height="100%"
                                                                AutoPostBack="true"></asp:ListBox>
                                                            <asp:Button ID="videogaleryitemdelete" runat="server" CssClass="btn btn-danger btn-sm my-2" Text="Sil" OnClick="videogaleryitemdelete_Click" />
                                                        </div>
                                                        <div class="col-12 col-md-6">
                                                            <asp:TextBox ID="videogalery_text" runat="server" CssClass="form-control"></asp:TextBox>
                                                            <asp:Button ID="videogalery_add" runat="server" Text="Add" CssClass="btn btn-primary btn-sm" OnClick="videogalery_add_Click" />
                                                            <asp:Button ID="videogalery_edit" runat="server" Text="Dəyiş" CssClass="btn btn-warning btn-sm my-2" OnClick="videogalery_edit_Click" />
                                                        </div>
                                                    </div>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- Documents -->
                <div class="row">
                    <div class="col-12 border mb-2">
                        <div class="form-group">
                            <label for="" class="h4 text-primary">Bölmə</label>
                            <div class="nav-wrapper">
                                <ul class="nav nav-pills nav-fill flex-column flex-md-row" id="tabs-icons-text" role="tablist">
                                    <li class="nav-item">
                                        <a class="nav-link mb-sm-3 mb-md-0 active" id="tabs-icons-text-1-tab" data-toggle="tab" href="#documents" role="tab" aria-controls="tabs-icons-text-1" aria-selected="true">Sənəd
                                        </a>
                                    </li>
                                </ul>
                            </div>
                            <div class="card shadow">
                                <div class="card-body p-0">
                                    <div class="tab-content" id="myTabContent">
                                        <div class="tab-pane fade show active" id="documents" role="tabpanel" aria-labelledby="tabs-icons-text-1-tab">
                                            <div class="conatiner-fluid" style="padding: 0!important">
                                                <div class="row">
                                                    <div class="col-12 col-md-6">
                                                        <div class="form-group text-left">
                                                            <label class="text-info" for="adminLayout_DOCS_LIST">Sənədlər</label>
                                                            <asp:UpdatePanel ID="DOCSUPDATEPANEL" runat="server">
                                                                <ContentTemplate>
                                                                    <div class="table-responsive">
                                                                        <asp:GridView
                                                                            ID="post_docs_list"
                                                                            runat="server"
                                                                            AutoGenerateColumns="False"
                                                                            GridLines="None"
                                                                            ForeColor="#333333"
                                                                            CssClass="table"
                                                                            Width="100%"
                                                                            AllowPaging="True"
                                                                            OnRowCreated="post_docs_list_RowCreated"
                                                                            OnPageIndexChanging="post_docs_list_PageIndexChanging" PageSize="5">
                                                                            <Columns>
                                                                                <asp:BoundField DataField="#" HeaderText="#"></asp:BoundField>
                                                                                <asp:BoundField DataField="DOC_ID" HeaderText="DOC_ID"></asp:BoundField>
                                                                                <asp:BoundField DataField="DOC_DEFAULTNAME" HeaderText="Sənədin adı"></asp:BoundField>
                                                                                <asp:BoundField DataField="USER_ID" HeaderText="USER_ID"></asp:BoundField>
                                                                                <asp:BoundField DataField="POST_SERIAL" HeaderText="POST_SERIAL"></asp:BoundField>
                                                                                <asp:TemplateField ShowHeader="False">
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="deletePostDocs"
                                                                                            runat="server" OnClientClick="return confirm('Silməyə əminsiz?'); "
                                                                                            OnClick="deletePostDocs_Click"
                                                                                            CausesValidation="False"
                                                                                            CommandName="Delete"
                                                                                            Text="Sil"></asp:LinkButton>
                                                                                    </ItemTemplate>
                                                                                    <ControlStyle CssClass="btn btn-danger btn-sm" />
                                                                                </asp:TemplateField>
                                                                            </Columns>

                                                                            <PagerSettings Mode="NumericFirstLast" />

                                                                        </asp:GridView>
                                                                    </div>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </div>
                                                    </div>
                                                    <div class="col-12 col-md-6">
                                                        <asp:FileUpload ID="_docsupload" runat="server" AllowMultiple="true" accept=".pdf,.doc,.docx,.xls,.rtf" />
                                                        <input class="form-control" type="text" value="fayl" id="customFiles">
                                                        <div class="text-right my-2">
                                                            <button class="btn btn-facebook" id="btnFiles">Əlavə et</button>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                 <!-- Apply -->
                <div class="row">
                    <div class="col-12 text-center my-2">
                        <asp:Button ID="postConfirm" runat="server" Text="Təsdiq et" CssClass="btn btn-round btn-success" OnClick="postConfirm_Click" />
                    </div>
                </div>

            </div>
        </div>
    </div>

    <script>
        $(function () {
            $('.datetimepicker').datetimepicker({
                format: 'DD/MM/YYYY HH:mm',
                icons: {
                    time: "fa fa-clock",
                    date: "fa fa-calendar-day",
                    up: "fa fa-chevron-up",
                    down: "fa fa-chevron-down",
                    previous: 'fa fa-chevron-left',
                    next: 'fa fa-chevron-right',
                    today: 'fa fa-screenshot',
                    clear: 'fa fa-trash',
                    close: 'fa fa-remove'
                }
            });
        });
    </script>
    <script>
        document.addEventListener("DOMContentLoaded", () => {
            let newsDate = document.getElementById("managelayout_post_date");
            let hiddenDate = document.getElementById("managelayout_labelTime");
            newsDate.value = hiddenDate.innerText;

        });
    </script>
    <script>
        document.addEventListener("DOMContentLoaded", function () {

            const inputFile = document.getElementById("managelayout_inpFile");
            const customFile = document.getElementById("customFile");
            const buttonFile = document.getElementById("btnFile");

            const inputFileSub = document.getElementById("managelayout_subImgUpload");
            const customFileSub = document.getElementById("customFileSuv");
            const buttonFileSub = document.getElementById("btnFileSub");


            const inputFiles = document.getElementById("managelayout__docsupload");
            const customFiles = document.getElementById("customFiles");
            const buttonFiles = document.getElementById("btnFiles");

            let mainimg = document.getElementById("managelayout_mainimage");

            buttonFile.addEventListener("click", function (e) {
                e.preventDefault();
                inputFile.click();
            });
            inputFile.addEventListener("change", function () {
                const file = this.files[0];
                if (file) {
                    customFile.value = inputFile.value.match(/[\/\\]([\w\d\s\.\-\(\)]+)$/);
                    const reader = new FileReader();
                    reader.addEventListener("load", function () {
                        mainimg.setAttribute("src", this.result);
                    });
                    reader.readAsDataURL(file);
                }
                else {
                    customFile.value = "fayl seçilməyib";
                    mainimg.src = null;
                }
            });

            buttonFileSub.addEventListener("click", function (e) {
                e.preventDefault();
                inputFileSub.click();
            });

            buttonFiles.addEventListener("click", function (e) {
                e.preventDefault();
                inputFiles.click();
            });
        });
    </script>
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
