<%@ Page Title="" Language="C#" MasterPageFile="~/manage/Admin.Master" AutoEventWireup="true" CodeBehind="logodetail.aspx.cs" Inherits="PublicCouncilBackEnd.manage.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #managelayout_logoFile {
            display: none;
        }

        #managelayout_logoActive {
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
                        <p class="h3">Yeni Logo</p>
                    </div>
                    <div class="col-6 text-right">
                        <asp:LinkButton ID="logodetail_back" runat="server" CssClass="btn btn-danger btn-sm" OnClick="logodetail_back_Click">
                            Geri
                        </asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
        <!-- Logo deatil body case -->
        <div class="card-body">
            <div class="container-fluid" style="padding: 0!important;">

                <!-- logo name  -->
                <div class="row mb-2">
                    <div class="col-12">
                        <div class="form-roup">
                            <label for="managelayout_logoName" class="h3">Logo ad</label>
                            <asp:TextBox ID="logoName" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>

                 <!-- logo image and file input  -->
                <div class="row mb-2">
                    <div class="col-6">
                        <asp:Image ID="logoImage" runat="server" CssClass="w-100" />
                    </div>
                    <div class="col-6">
                        <asp:FileUpload ID="logoFile" runat="server" accept=".png,.jpeg,.jpg,.tif" />
                        <div class="container-fluid">
                            <div class="row">
                                <div class="col-12">
                                    <input class="form-control" type="text" value="fayl seçilməyib" id="customFile">
                                </div>
                                <div class="col-12">
                                    <button class="btn btn-facebook" id="btnFile">Fayl yüklə</button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                 <!-- logo Apply  -->
                <div class="row">
                    <div class="col-12 text-center my-2">
                        <asp:Button ID="logoConfirm" runat="server" Text="Təsdiq et" CssClass="btn btn-round btn-success" OnClick="logoConfirm_Click" />
                    </div>
                </div>

            </div>
        </div>
    </div>

    <script>
        document.addEventListener("DOMContentLoaded", function () {

            const inputFile = document.getElementById("managelayout_logoFile");
            const customFile = document.getElementById("customFile");
            const buttonFile = document.getElementById("btnFile");

            let mainimg = document.getElementById("managelayout_logoImage");

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
