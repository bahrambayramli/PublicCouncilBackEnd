<%@ Page Title="" 
    Language="C#"
    MasterPageFile="~/manage/Admin.Master" 
    AutoEventWireup="true" 
    CodeBehind="partnerdetail.aspx.cs" 
    Inherits="PublicCouncilBackEnd.manage.WebForm7" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <style>
        #managelayout_partnerFile {
            display: none;
        }

        #managelayout_partnerActive {
            width: 30px;
            height: 30px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="managelayout" runat="server">

    <div class="card my-md-2">
        <!-- Logo header case -->
        <div class="card-header">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-6">
                        <p class="h3">Yeni Tərəfdaş</p>
                    </div>
                    <div class="col-6 text-right">
                        <asp:LinkButton ID="partnerdetail_back" runat="server" CssClass="btn btn-danger btn-sm" OnClick="partnerdetail_back_Click">
                            Geri
                        </asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
        <!-- Partner deatil body case -->
        <div class="card-body">
            <div class="container-fluid" style="padding: 0!important;">

                <!-- Partner name  -->
                <div class="row mb-2">
                    <div class="col-6">
                        <div class="form-roup">
                            <label for="managelayout_partnername" class="h3">Tərəfdaş ad</label>
                            <asp:TextBox ID="partnername" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-6">
                        <div class="form-roup">
                            <label for="managelayout_partnerLink" class="h3">Tərəfdaş link</label>
                            <asp:TextBox ID="partnerLink" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <!-- Partner image and file input  -->
                <div class="row mb-2">
                    <div class="col-6">
                        <asp:Image ID="partnerImage" runat="server" CssClass="w-100" ImageUrl="~/Images/social-media-image.png" />
                    </div>
                    <div class="col-6">
                        <asp:FileUpload ID="partnerFile" runat="server" accept=".png,.jpeg,.jpg,.tif" />
                        <div class="container-fluid">
                            <div class="row">
                                <div class="col-12">
                                    <input class="form-control" type="text" value="fayl seçilməyib" id="customFile">
                                </div>
                                <div class="col-12 text-right py-2">
                                    <button class="btn btn-facebook" id="btnFile">Fayl yüklə</button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- logo Apply  -->
                <div class="row">
                    <div class="col-12 text-center my-2">
                        <asp:Button ID="partnerConfirm" runat="server" Text="Təsdiq et" CssClass="btn btn-round btn-success" OnClick="partnerConfirm_Click" />
                    </div>
                </div>

            </div>
        </div>
    </div>

    <script>
        document.addEventListener("DOMContentLoaded", function () {

            const inputFile = document.getElementById("managelayout_partnerFile");
            const customFile = document.getElementById("customFile");
            const buttonFile = document.getElementById("btnFile");

            let mainimg = document.getElementById("managelayout_partnerImage");

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
        });
    </script>
</asp:Content>
