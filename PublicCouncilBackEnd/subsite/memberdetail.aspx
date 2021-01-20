<%@ Page Title="" Language="C#" MasterPageFile="~/subsite/Subdomain.Master" AutoEventWireup="true" CodeBehind="memberdetail.aspx.cs" Inherits="PublicCouncilBackEnd.subsite.WebForm11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="sublayout" runat="server">
    
    <div class="container-fluid">
        <div class="row">
                  <div class="col-12 col-md-5">
                        <div class="member-about">
                             <asp:Image ID="memberImage" runat="server" CssClass="d-block w-100" />
                              <div class="member-wrapper">
                                    <div class="member-position">
                                         <asp:Literal ID="memberPosition" runat="server"></asp:Literal>
                                    </div>
                                    <div class="member-info">
                                         <asp:Literal ID="memberNameSurname" runat="server"></asp:Literal>
                                    </div>
                              </div>
                        </div>
                  </div>
                  <div class="col-12 col-md-7">
                        <div class="member-detail">
                              <p class="m-0">
                                     <asp:Literal ID="memberDetail" runat="server"></asp:Literal>
                              </p>
                        </div>
                  </div>
            </div>
    </div>
    <script src="/scripts/subsite.js"></script>
</asp:Content>
