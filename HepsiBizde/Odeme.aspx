<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="Odeme.aspx.cs" Inherits="HepsiBizde.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="containeer">
        <div class="row">
            <div style="margin:0 auto;text-align:center;" class="col-md-6">
               <b> Kayıt Ol </b> 
                <br />
                İsim ve Soyisim
                <asp:TextBox CssClass="form-control" ID="adsoyad" runat="server" />
                <asp:RequiredFieldValidator ValidationGroup="valkayit" ErrorMessage="İsim Giriniz Lütfen" ControlToValidate="adsoyad" runat="server" />
                <br />
                E-Mail Adresiniz
                <asp:TextBox CssClass="form-control" ID="mail" runat="server" />
                <asp:RequiredFieldValidator ForeColor="red" ValidationGroup="valkayit" ErrorMessage="E-Mail Adresi Zorunlu" ControlToValidate="mail" runat="server" />
                <br />
                Şifre
                <asp:TextBox CssClass="form-control" ID="sifre" TextMode="Password" runat="server" />
                <asp:RequiredFieldValidator ValidationGroup="valkayit" ErrorMessage="Şifre Giriniz" ControlToValidate="sifre" runat="server" />
                <br />
                Telefon No 
                <asp:TextBox CssClass="form-control" ID="tel" runat="server" />
                <asp:RequiredFieldValidator ValidationGroup="valkayit" ErrorMessage="Telefon No Zorunlu" ControlToValidate="tel" runat="server" />
                <br />
                Adres
                <asp:TextBox CssClass="form-control" ID="adres" runat="server" />
                <asp:RequiredFieldValidator ValidationGroup="valkayit" ErrorMessage="Adres Zorunlu" ControlToValidate="adres" runat="server" />
                <br />
                <asp:Button CssClass="btn btn-warning m-2" ValidationGroup="valkayit" OnClick="Unnamed_Click" Text="Kayıt Ol" runat="server" />
            </div>
            <div style="margin:0 auto;text-align:center;" class="col-md-6">
               <b>Müşteri Giriş Ekranı</b> 
                <br />
                E-Mail Adresiniz
                <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" />
                Şifre
                <asp:TextBox CssClass="form-control" ID="TextBox3" TextMode="Password" runat="server" />
                <asp:Button CssClass="btn btn-warning m-2" OnClick="Unnamed_Click2" Text="Login" runat="server" />
            </div>
            <br />
            </div>
        <div class="row">
            <div class="col-md-6">
                <div class="alert alert-info w-100">
                    <div class="container">
                        <asp:Label Text="Ödeme Yapmak için lütfen giriş yapınız ya da Kayıt Olunuz" ID="UyariLabel" runat="server" />
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <h4 class="d-flex justify-content-between align-items-center mb-3">
                    <span class="text-muted">Siparişleriniz</span>
                    <span class="badge badge-secondary badge-pill">
                        <asp:Label Text="0" ID="Countlabel" runat="server" /></span> adet ürün
                </h4>
                <ul class="list-group mb-3">
                    <asp:Repeater ID="siparisler" runat="server">
                        <ItemTemplate>
                            <li class="list-group-item d-flex justify-content-between lh-condensed">
                                <div>
                                    <h6 class="my-0"><%# Eval("Name")%></h6>
                                </div>
                            </li>

                        </ItemTemplate>
                    </asp:Repeater>
                    <li class="list-group-item d-flex justify-content-between lh-condensed">
                        <div>
                            <h6 class="my-0">Toplam</h6>
                        </div>
                        <span class="text-muted">
                            <asp:Label Font-Bold="true" Text="0" ID="toplampara" runat="server" /></span> TL
                    </li>
                </ul>

            </div>

        </div>
        <div class="row" runat="server" id="OdemeDiv" visible="false">
            <div class="col-md-12">
                <h3>Ödeme Kısmı</h3>
            </div>
            <div class="col-md-6">
                <div class="row">
                    <div class="col-md-12 mb-3">
                        <label>Kart Sahibi Ad Soyad</label>
                        <asp:TextBox runat="server" class="form-control" ID="ccname" placeholder="NAME AND SURNAME" />
                  
                          <asp:RequiredFieldValidator ValidationGroup="kartgrup" ForeColor="red" ErrorMessage="kart sahibi zorunlu" ControlToValidate="ccname" runat="server" />
                        <small class="text-muted">Full name as displayed on card</small>
                        <div class="invalid-feedback">
                            Name on card is required
                        </div>
                    </div>
                    <div class="col-md-12 mb-3">
                        <label for="cc-number">Kart Numarası</label>
                        <asp:TextBox runat="server" class="form-control"  ID="ccnumber" placeholder="0000-0000-0000-0000" />
                  
                          <asp:RequiredFieldValidator  ForeColor="red" ValidationGroup="kartgrup" ErrorMessage="kart numarsı zorunlu" ControlToValidate="ccnumber" runat="server" />
                        <div class="invalid-feedback">
                            Credit card number is required
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-md-12">
                <asp:Button class="btn btn-primary btn-lg btn-block" ValidationGroup="kartgrup" OnClick="Unnamed_Click1" Text="Ödeme İşlemini Tamamla" runat="server" />
            </div>

        </div>
    </div>
    <div id="islemdiv" runat="server" visible="false" class="alert alert-warning w-100" role="alert">
        Teşekkürler Ödemeniz Başarıyla Alındı <a class="btn btn-primary" href="Homepage.aspx">Anasayfaya dönmek için tıklayınız</a>
    </div>
</asp:Content>
