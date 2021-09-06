<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="KampayaliUrunler.aspx.cs" Inherits="HepsiBizde.WebForm9" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="row">
        <asp:Repeater ID="ProductRepeater" runat="server">
            <ItemTemplate>
                <div id='<%# Eval("UrunKampanyaId")%>' class="col-md-3">
                    <div class="card">
                        <img class="card-img-top img-fluid" style="height:250px!important" src='<%# Eval("UrunResim")%>' alt="Card image cap">
                        <div  style="height:300px!important" class="card-body">
                            <h5 class="card-title"><%# Eval("UrunAd")%></h5>
                            <p class="card-text"><%# Eval("UrunAciklama")%></p>
                            <p class="card-text"><%# Eval("KategoriAd")%> / <%# Eval("MarkaAdi")%></p>
                            <p class="text-primary font-weight-bold">
                              <s style="color:red"> <%# String.Format("{0:c}", Eval("UrunIndirimFiyat"))%></s>  <%# String.Format("{0:c}", Eval("UrunFiyat"))%>
                               </p>
                        </div>
                        <%-- <div style="margin:0 auto;text-align:center;">
                                <asp:LinkButton  CssClass="btn btn-warning mb-4" Text='Sepete Ekle' CommandName='<%# Eval("UrunAd")%>' OnClick="Unnamed_Click" CommandArgument='<%# Eval("UrunId")%>' runat="server" />
                            </div>--%>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
