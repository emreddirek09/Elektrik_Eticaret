<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetim.Master" AutoEventWireup="true" CodeBehind="OrderStatistics.aspx.cs" Inherits="HepsiBizde.WebForm4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <h2>All Orders Income</h2>
            <div class="col-md-12">
                <table class="table table-hover">
                    <tr>
                        <td>ID</td>
                        <td>MÜŞTERİ İSİM</td>
                        <td>DATE</td>
                        <td>TOPLAM ÖDEME</td>
                        <td>ÜRÜNLER</td>
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
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
            <div class="col-md-12">
                Toplam Gelir 
                <asp:Label ID="Income" Text="" runat="server" />
            </div>
        </div>
    </div>
</asp:Content>
