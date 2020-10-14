<%@ Page Title="" Language="C#" MasterPageFile="~/manage/Admin.Master" AutoEventWireup="true" CodeBehind="councildetail.aspx.cs" Inherits="PublicCouncilBackEnd.manage.WebForm11" %>
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
        <div class="card-header">
            Ətraflı
        </div>
        <div class="card-body">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-12 col-md-6">
                        <div class="form-group">
                            <label for="managelayout_inputISACTIVE">Aktivlik</label>
                            <asp:DropDownList ID="inputISACTIVE" runat="server" CssClass="form-control">
                                <asp:ListItem Value="0">Xeyr</asp:ListItem>
                                <asp:ListItem Value="1">Bəli</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-12 col-md-6">
                        <div class="form-group">
                            <label for="managelayput_inputMembershipType">Üzvlük tipi</label>
                            <asp:DropDownList ID="inputMembershipType" runat="server" CssClass="form-control">
                                <asp:ListItem Value="admin">Admin</asp:ListItem>
                                <asp:ListItem Value="moderator">Moderator</asp:ListItem>
                                <asp:ListItem Value="user">User</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-12 col-md-6">
                        <div class="form-group">
                            <label for="mainlayout_inputLoginName">Login</label>
                            <asp:TextBox ID="inputLoginName" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-12 col-md-6">
                        <div class="form-group">
                            <label for="mainlayout_inputPassword">Şifrə</label>
                            <asp:TextBox ID="inputPassword" runat="server" CssClass="form-control" TextMode="Password">

                            </asp:TextBox>
                        </div>
                    </div>
                    <div class="col-12 col-md-6">
                        <div class="form-group">
                            <label for="mainlayout_inputName">Ad</label>
                            <asp:TextBox ID="inputName" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-12 col-md-6">
                        <div class="form-group">
                            <label for="mainlayout_inputSurname">Soyad</label>
                            <asp:TextBox ID="inputSurname" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-12 col-md-6">
                        <div class="form-group">
                            <label for="mainlayout_inputPCname">İctimai şuranın adı</label>
                            <asp:TextBox ID="inputPCname" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-12 col-md-6">
                        <div class="form-group">
                            <label for="mainlayout_inputPCdomain">İctimai şuranın domain adı</label>
                            <asp:TextBox ID="inputPCdomain" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-12 col-md-6">
                        <div class="form-group">
                            <label for="mainlayout_inputEmail">İctimai şuranın e-poçt ünvanı</label>
                            <asp:TextBox ID="inputEmail" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-12 col-md-6">
                        <div class="form-group">
                            <label for="mainlayout_inputWeb">İctimai şuranın veb ünvanı</label>
                            <asp:TextBox ID="inputWeb" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-12 col-md-6">
                        <div class="form-group">
                            <label for="mainlayout_inputMobile">Mobil</label>
                            <asp:TextBox ID="inputMobile" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-12 col-md-6">
                        <div class="form-group">
                            <label for="mainlayout_inputTelephone">Telefon</label>
                            <asp:TextBox ID="inputTelephone" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-12 col-md-6">
                        <div class="form-group">
                            <label for="mainlayout_categorySelect">Kateqoriya</label>
                            <asp:DropDownList ID="categorySelect" runat="server" CssClass="form-control">
                                <asp:ListItem Value="pcucep">
                                Mərkəzi icra hakimiyyət yanında ictimai şuralar
                                </asp:ListItem>
                                <asp:ListItem Value="pculealsgb">
                                 Yerli icra hakimiyyəti və yerli özünüidarəetmə orqanları yanında ictimai şuralar
                                </asp:ListItem>
                                <asp:ListItem Value="other">
                                 Digər
                                </asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-12 col-md-6">
                        <div class="form-group">
                            <label for="mainlayout_inputCity">Şəhər</label>
                            <asp:DropDownList ID="inputCity" runat="server" CssClass="form-control">
                                <asp:ListItem Value="15">Ağcabədi</asp:ListItem>
                                <asp:ListItem Value="16">Ağdam</asp:ListItem>
                                <asp:ListItem Value="13">Ağdaş</asp:ListItem>
                                <asp:ListItem Value="14">Ağsu</asp:ListItem>
                                <asp:ListItem Value="17">Akstafa</asp:ListItem>
                                <asp:ListItem Value="18">Astara</asp:ListItem>
                                <asp:ListItem Value="19">Babək</asp:ListItem>
                                <asp:ListItem Value="11">Bakı ( Binəqədi )</asp:ListItem>
                                <asp:ListItem Value="5">Bakı ( Nərimanov )</asp:ListItem>
                                <asp:ListItem Value="6">Bakı ( Nəsimi )</asp:ListItem>
                                <asp:ListItem Value="2">Bakı ( Nizami )</asp:ListItem>
                                <asp:ListItem Value="4">Bakı ( Qaradağ )</asp:ListItem>
                                <asp:ListItem Value="7">Bakı ( Sabunçu )</asp:ListItem>
                                <asp:ListItem Value="10">Bakı ( Səbayıl )</asp:ListItem>
                                <asp:ListItem Value="8">Bakı ( Suraxanı )</asp:ListItem>
                                <asp:ListItem Value="1">Bakı ( Xətai ) </asp:ListItem>
                                <asp:ListItem Value="3">Bakı ( Xəzər )</asp:ListItem>
                                <asp:ListItem Value="9">Bakı ( Yasamal )</asp:ListItem>
                                <asp:ListItem Value="20">Balakən</asp:ListItem>
                                <asp:ListItem Value="21">Beyləqan</asp:ListItem>
                                <asp:ListItem Value="23">Bərdə</asp:ListItem>
                                <asp:ListItem Value="22">Bilasuvar</asp:ListItem>
                                <asp:ListItem Value="25">Cəbrayıl</asp:ListItem>
                                <asp:ListItem Value="24">Cəlilabad</asp:ListItem>
                                <asp:ListItem Value="26">Culfa</asp:ListItem>
                                <asp:ListItem Value="27">Daşkəsən</asp:ListItem>
                                <asp:ListItem Value="28">Dəvəçi</asp:ListItem>
                                <asp:ListItem Value="63">Əlibayramlı</asp:ListItem>
                                <asp:ListItem Value="29">Füzuli</asp:ListItem>
                                <asp:ListItem Value="33">Gədəbəy</asp:ListItem>
                                <asp:ListItem Value="30">Gəncə</asp:ListItem>
                                <asp:ListItem Value="31">Goranboy</asp:ListItem>
                                <asp:ListItem Value="32">Göyçay</asp:ListItem>
                                <asp:ListItem Value="34">Horadiz</asp:ListItem>
                                <asp:ListItem Value="35">İmişli</asp:ListItem>
                                <asp:ListItem Value="36">İsmayıllı</asp:ListItem>
                                <asp:ListItem Value="37">Kəlbəcər</asp:ListItem>
                                <asp:ListItem Value="38">Kürdəmir</asp:ListItem>
                                <asp:ListItem Value="39">Laçın</asp:ListItem>
                                <asp:ListItem Value="41">Lerik</asp:ListItem>
                                <asp:ListItem Value="40">Lənkəran</asp:ListItem>
                                <asp:ListItem Value="42">Masallı</asp:ListItem>
                                <asp:ListItem Value="44">Mərəzə</asp:ListItem>
                                <asp:ListItem Value="43">Mingəçevir</asp:ListItem>
                                <asp:ListItem Value="46">Naxçıvan</asp:ListItem>
                                <asp:ListItem Value="45">Neftçala</asp:ListItem>
                                <asp:ListItem Value="47">Oğuz</asp:ListItem>
                                <asp:ListItem Value="48">Ordubad</asp:ListItem>
                                <asp:ListItem Value="51">Qax</asp:ListItem>
                                <asp:ListItem Value="49">Qazax</asp:ListItem>
                                <asp:ListItem Value="50">Qazıməmməd</asp:ListItem>
                                <asp:ListItem Value="52">Qəbələ</asp:ListItem>
                                <asp:ListItem Value="53">Quba</asp:ListItem>
                                <asp:ListItem Value="55">Qubadlı</asp:ListItem>
                                <asp:ListItem Value="54">Qusar</asp:ListItem>
                                <asp:ListItem Value="56">Saatlı</asp:ListItem>
                                <asp:ListItem Value="57">Sabirabad</asp:ListItem>
                                <asp:ListItem Value="72">Şahbuz</asp:ListItem>
                                <asp:ListItem Value="73">Şamaxı</asp:ListItem>
                                <asp:ListItem Value="58">Sədərək</asp:ListItem>
                                <asp:ListItem Value="75">Şəki</asp:ListItem>
                                <asp:ListItem Value="59">Səlyan</asp:ListItem>
                                <asp:ListItem Value="76">Şəmkir</asp:ListItem>
                                <asp:ListItem Value="74">Şərur</asp:ListItem>
                                <asp:ListItem Value="60">Siyəzən</asp:ListItem>
                                <asp:ListItem Value="77">Şuşa</asp:ListItem>
                                <asp:ListItem Value="61">Tərtər</asp:ListItem>
                                <asp:ListItem Value="62">Tovuz</asp:ListItem>
                                <asp:ListItem Value="64">Ucar</asp:ListItem>
                                <asp:ListItem Value="65">Xaçmaz</asp:ListItem>
                                <asp:ListItem Value="66">Xanlar</asp:ListItem>
                                <asp:ListItem Value="67">Yardımlı</asp:ListItem>
                                <asp:ListItem Value="68">Yevlax</asp:ListItem>
                                <asp:ListItem Value="69">Zaqatala</asp:ListItem>
                                <asp:ListItem Value="70">Zəngilan</asp:ListItem>
                                <asp:ListItem Value="71">Zərdab</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-12">
                        <div class="container-fluid" style="padding: 0!important">
                            <div class="row">
                                <div class="col-6">
                                    <asp:Image ID="logoImage" runat="server" CssClass="w-100" ImageUrl="~/Images/social-media-image.png" />
                                </div>
                                <div class="col-6">
                                    <asp:FileUpload ID="logoFile" runat="server" accept=".png,.jpeg,.jpg,.tif" />
                                    <div class="container-fluid">
                                        <div class="row">
                                            <div class="col-12">
                                                <input class="form-control" type="text" value="fayl seçilməyib" id="customFile">
                                            </div>
                                            <div class="col-12 text-right">
                                                <button class="btn btn-facebook" id="btnFile">Fayl yüklə</button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-12">
                        <div class="text-center py-md-3">
                            <asp:Button ID="btnConfirm" runat="server" CssClass="btn btn-success btn-round" Text="Təsdiqlə" OnClick="btnConfirm_Click" />
                        </div>
                        <asp:Literal ID="errorLiteral" runat="server"></asp:Literal>
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
