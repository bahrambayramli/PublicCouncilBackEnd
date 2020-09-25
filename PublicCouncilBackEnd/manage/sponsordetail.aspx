<%@ Page Title="" Language="C#" MasterPageFile="~/manage/Admin.Master" AutoEventWireup="true" CodeBehind="sponsordetail.aspx.cs" Inherits="PublicCouncilBackEnd.manage.WebForm9" %>
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
                        <asp:LinkButton ID="sponsordetail_back" runat="server" CssClass="btn btn-danger btn-sm" OnClick="sponsordetail_back_Click">
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
                    <div class="col-6">
                        <div class="form-roup">
                            <label for="managelayout_sponsorname" class="h3">Logo ad</label>
                            <asp:TextBox ID="sponsorname" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-6">
                        <div class="form-roup">
                            <label for="managelayout_sponsorLink" class="h3">Logo ad</label>
                            <asp:TextBox ID="sponsorLink" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <!-- logo image and file input  -->
                <div class="row mb-2">
                    <div class="col-6">
                        <asp:Image ID="sponsorImage" runat="server" CssClass="w-100" ImageUrl="~/Images/social-media-image.png" />
                    </div>
                    <div class="col-6">
                        <asp:FileUpload ID="sponsorFile" runat="server" accept=".png,.jpeg,.jpg,.tif" />
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
                        <asp:Button ID="sponsorConfirm" runat="server" Text="Təsdiq et" CssClass="btn btn-round btn-success" OnClick="sponsorConfirm_Click" />
                    </div>
                </div>

            </div>
        </div>
    </div>

    <script>
        document.addEventListener("DOMContentLoaded", function () {

            const inputFile = document.getElementById("managelayout_sponsorFile");
            const customFile = document.getElementById("customFile");
            const buttonFile = document.getElementById("btnFile");

            let mainimg = document.getElementById("managelayout_sponsorImage");

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
