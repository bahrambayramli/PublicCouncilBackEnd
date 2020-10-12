<%@ Page Title="" 
    Language="C#" 
    MasterPageFile="~/Main.Master"
    AutoEventWireup="true"
    CodeBehind="register.aspx.cs" 
    Inherits="PublicCouncilBackEnd.WebForm11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainlayout" runat="server">

    <section class="site-register">
        <div class="container-fluid">
            <div class="row">
                <div class="col-12 col-md-6">
                    <div class="form-group">
                        <label for="mainlayout_inputLoginName">Login</label>
                        <asp:TextBox ID="inputLoginName" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="col-12 col-md-6">
                    <div class="form-group">
                        <label for="mainlayout_inputPassword">Şifrə</label>
                        <asp:TextBox ID="inputPassword" runat="server" CssClass="form-control"></asp:TextBox>
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
