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
                      <a href="https://google.com/"> <img class="card-img-top img-fluid" style="height:250px!important" src='<%# Eval("KampanyaBanner")%>' alt="Card image cap"></a> 
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
