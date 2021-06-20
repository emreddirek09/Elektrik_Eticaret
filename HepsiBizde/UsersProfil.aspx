<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="UsersProfil.aspx.cs" Inherits="HepsiBizde.WebForm6" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="d-flex p-4">
        <div class="bg-light border-right">
            <div class="list-group text-center">
                <i class="fa fa-info" style="color: grey; font-size: x-large">
                    <asp:Button ID="Button1" CssClass="btn-outline-secondary" OnClick="Button1_Click" runat="server" Text="Bilgilerim" /></i><br />
                <i class="fa fa-shopping-cart" style="color: darkgreen; font-size: x-large">
                    <asp:Button ID="Button2" CssClass="btn-outline-success" OnClick="Button2_Click" runat="server" Text="Siparişler" /></i><br />
                <i class="fa fa-key" style="color: orange; font-size: x-large">
                    <asp:Button ID="Button3" CssClass="btn-outline-warning" OnClick="Button3_Click" runat="server" Text="Şifre Değiştir" /></i><br />
                <i class="fa fa-sign-out" style="color: red; font-size: x-large">
                    <asp:Button ID="Button4" CssClass="btn-outline-primary" runat="server" Text="Çıkış" /></i>
            </div>
        </div>
        <div class="col-9">
            <div class="container-fluid" id="denemediv1" runat="server" visible="false">
                <div class="text-center">
                    <h3>Profil Bilgileri</h3>
                </div>

                <div class="form-group row">
                    <label for="colFormLabelSm" class="col-sm-2 col-form-label">İsim</label>
                    <div class="col-sm-10">
                        <input class="form-control" id="txt_isim" runat="server">
                    </div>
                </div>
                <div class="form-group row">
                    <label for="colFormLabel" class="col-sm-2 col-form-label">E-Mail</label>
                    <div class="col-sm-10">
                        <input type="email" class="form-control" id="txt_mail" runat="server">
                    </div>
                </div>
                <div class="form-group row">
                    <label for="colFormLabelLg" class="col-sm-2 col-form-label">Telefon</label>
                    <div class="col-sm-10">
                        <input type="email" class="form-control" id="txt_telefon" runat="server">
                    </div>
                </div>
                <div class="form-group row">
                    <label for="colFormLabelLg" class="col-sm-2 col-form-label">Adres</label>
                    <div class="col-sm-10">
                        <input type="email" class="form-control" id="txt_adres" runat="server">
                    </div>
                </div>
                <div class="form-group row">
                    <asp:Button ID="BilgileriGüncelle" CssClass=" btn btn-danger" runat="server" Text="Güncelle" />
                </div>

            </div>
            <div class="container-fluid" id="denemediv2" runat="server" visible="false">
                dsadadasd2
            </div>

            <div class="container-fluid" id="denemediv3" runat="server" visible="false">
                <div class="text-center">
                    <h3>Şifre Güncelle</h3>
                </div>

                <div class="form-group row">
                    <label for="colFormLabelSm" class="col-sm-2 col-form-label">Mevcut Şifre</label>
                    <div class="col-sm-10">
                        <input class="form-control" id="txt_mevcutSifre" runat="server">
                    </div>
                </div>
                <div class="form-group row">
                    <label for="colFormLabel" class="col-sm-2 col-form-label">Yeni Şifre</label>
                    <div class="col-sm-10">
                        <input type="email" class="form-control" id="txt_yeniSifre" runat="server">
                    </div>
                </div>
                <div class="form-group row">
                    <label for="colFormLabelLg" class="col-sm-2 col-form-label">Yeni Şifre Onay</label>
                    <div class="col-sm-10">
                        <input type="email" class="form-control" id="txt_yeniSifreOnay" runat="server">
                    </div>
                </div>                
                <div class="form-group row">
                    <asp:Button ID="SifreGüncele" CssClass=" btn btn-success" runat="server" Text="Güncelle" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>
