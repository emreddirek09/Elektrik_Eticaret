<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="KampayaliUrunler.aspx.cs" Inherits="HepsiBizde.WebForm8" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h5>En Kaliteli Ürünler Kampanyalı Fiyatlarla </h5><br />
    <div class="row">
        <asp:Repeater ID="RepeaterKampanya" runat="server">
            <ItemTemplate>
                <div class="col-md-6">
                    <div class="card">
                        <div  style="height:50px!important" class="card-body">
                            <h5 class="card-title"><%# Eval("KampanyaAd")%></h5>                            
                        </div>
                         <a id="login" href="#" runat="server" onserverclick="login_ServerClick"> <img class="card-img-top img-fluid" style="height:250px!important" src='<%# Eval("KampanyaBanner")%>' alt="Card image cap"></a> 
                    <%-- <a href="Homepage.aspx?UrünKampanyaId=<%# Eval("UrünKampanyaId")%>"> <img class="card-img-top img-fluid" style="height:250px!important" src='<%# Eval("KampanyaBanner")%>' alt="Card image cap"></a> --%>
                      <asp:LinkButton ID="incele" title="İncelemek İçin Tıklayınız" CssClass="fa fa-search" runat="server" OnClick="incele_Click" CommandArgument='<%#Eval("KampanyaId") %>'>İncele</asp:LinkButton>
                      <%--  <asp:HyperLink Target="_blank" CssClass="btn btn-success" alt="Detaylı Ürün İncelemesi için.." NavigateUrl='<%# Eval("UrünKampanyaId","~/Homepage.aspx?Urunler.UrünKampanyaId={0}") %>' runat="server" Text="İncele" />                                                                                                                            --%>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
