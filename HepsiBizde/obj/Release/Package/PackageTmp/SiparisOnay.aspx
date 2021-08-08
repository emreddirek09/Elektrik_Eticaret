<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetim.Master" AutoEventWireup="true" CodeBehind="SiparisOnay.aspx.cs" Inherits="HepsiBizde.WebForm7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <h2>Sipariş Onay Sayfası</h2>
            <div class="col-md-12">
                <table class="table table-hover">
                    <tr>
                        <td>ID</td>
                        <td>MÜŞTERİ İSİM</td>
                        <td>DATE</td>
                        <td>TOPLAM ÖDEME</td>
                        <td>Ürünler</td>
                        <td>İşlem</td>
                    </tr>
                    <asp:Repeater ID="OrdersRepeater" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%# Eval("SiparisId")%></td>
                                <td><%# Eval("KullaniciAdSoyad")%><br />
                                    <%# Eval("KullaniciAdres")%>
                                </td>
                                <td><%# Eval("SiparisTarih")%></td>
                                <td><%# String.Format("{0:c}", Eval("SiparisFiyat"))%>
                                </td>
                                <td><%# Eval("Urünler")%></td>
                                <td>
                                    <asp:linkbutton OnClientClick="return confirm('Seçilen Siparişi Onaylamak istiyor musunuz ?');" OnClick="Unnamed_Click" alt="Siparişi Onaylamak İçin Tıklayınız." text="Sipariş Onay" CommandArgument='<%# Eval("SiparisId")%>' CssClass="btn btn-dark" runat="server"></asp:linkbutton>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
