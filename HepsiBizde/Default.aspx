<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HepsiBizde.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BdElektrik E-Ticaret</title>
    <link rel="preconnect" href="https://fonts.gstatic.com">
    <link href="https://fonts.googleapis.com/css2?family=Nunito:wght@300;400;600;700;800&display=swap" rel="stylesheet">
    <link rel="icon" type="image/x-icon" href="assets/favicon.ico" />
    <link href="css/styles.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
</head>
<body>
    <form id="form1" runat="server">
        <div id="page-content-wrapper">
            <nav class="navbar navbar-expand-lg navbar-light bg-light border-bottom">
                <a href="Default.aspx">
                    <img style="max-width: 180px" src="assets/logo.png" /></a>
                <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation"><span class="navbar-toggler-icon"></span></button>
                <asp:DropDownList ID="DropDownList1Urün" AutoPostBack="true" Width="300" OnSelectedIndexChanged="DropDownList1Urün_SelectedIndexChanged" CssClass="form-control container" BackColor="#f0f0f0" runat="server">
                    <asp:ListItem Value="-1">Ürünler</asp:ListItem>
                </asp:DropDownList>
                <asp:Button ID="Kampanyalar" OnClick="Kampanyalar_Click" Width="300" CssClass="form-control container" BackColor="#f0f0f0" runat="server" Text="Kampanyalar" />
                <%--<asp:DropDownList ID="DropDownList2Kampanya" Width="300" autopostback="true" CssClass="form-control container" BackColor="#f0f0f0" runat="server">
                    <asp:ListItem Value="-1">Kampanyalar</asp:ListItem>
                </asp:DropDownList>--%>
                <div class="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul class="navbar-nav ml-auto mt-2 mt-lg-0">
                        <li class="nav-item dropdown">
                            <a class="nav-link" id="navbarDropdown1" href="#" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                <asp:Label Text="Hoşgeldiniz " ID="Adsoyad" runat="server" /></a>
                            <div runat="server" id="cikisbutton" class="dropdown-menu dropdown-menu-right" aria-labelledby="navbarDropdown1">
                                <asp:Button Text="Giriş" ID="giris" OnClick="giris_Click" class="dropdown-item bg-light" runat="server" />
                                <asp:Button Text="Çıkış" OnClick="logout" class="dropdown-item bg-danger" runat="server" />
                            </div>
                        </li>
                        <li class="nav-item dropdown">
                            <a class="nav-link " id="navbarDropdown" href="#" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                <i class="fa fa-shopping-bag" style="color: red; font-size: x-large"><sup>
                                    <asp:Label ID="sup" runat="server"></asp:Label></sup></i>
                            </a>
                            <div class="dropdown-menu dropdown-menu-right" aria-labelledby="navbarDropdown">
                                <asp:Repeater ID="basketlist" runat="server">
                                    <ItemTemplate>
                                        <a class="dropdown-item bg-light" href="#">
                                            <%# Eval("Name")%></a>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <asp:Button class="dropdown-item bg-success text-white" OnClick="Unnamed_Click" Text="Ödeme Yap" runat="server" />
                                <asp:Button class="dropdown-item bg-danger text-white" OnClick="Unnamed_Click1" Text="Sepeti Temizle" runat="server" />
                            </div>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="Login.aspx"><i class="fa  fa-unlock-alt" style="color: cornflowerblue; font-size: x-large"></i></a>
                        </li>
                    </ul>
                </div>
            </nav>
            <h2 style="background-color: lightgray" class="p-1 text-center">Kampanyalı Ürünler</h2>
            <div class="row p-4 " style="background-color: lightgray">
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <div class="col-lg-3 col-md-4 col-sm-6 text-center">
                            <div class="card" style="width: 340px; height: 500px !important">
                                <a href="Homepage.aspx?KategoriId=<%# Eval("KategoriId")%>">
                                    <img style="width: 335px; height: 335px !important" src="<%# Eval("UrunResim")%>" class="card-img-top" />
                                </a>
                                <div class="card-body">
                                    <p class="card-text"><%# Eval("UrunAciklama")%></p>
                                    <p class="text-primary font-weight-bold">
                                        <s style="color: red"><%# String.Format("{0:c}", Eval("UrünIndirimFiyat"))%></s>  <%# String.Format("{0:c}", Eval("UrunFiyat"))%>
                                    </p>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <br />
            <div class="row text-center" style="background-color: aliceblue">
                <asp:Repeater ID="Repeater2" runat="server">
                    <ItemTemplate>
                        <div class="col-lg-12 col-md-12 col-sm-12 text-black-50">
                            <div class="bg-image hover-overlay ripple">
                              <h2>  <p class="card-text"><%# Eval("KampanyaAd")%></p></h2>
                                <img src="<%# Eval("KampanyaBanner")%>" style="max-width: 100%; height: auto" class="img-fluid" />
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <br />
            <div class="row text-center">
                <asp:Repeater ID="Repeater3" runat="server">
                    <ItemTemplate>
                        <div class="col-lg-6 col-md-12 col-sm-12">
                            <div class="bg-image hover-overlay ripple">
                                <p class="card-text" style="background-color:burlywood"><%# Eval("UrunAciklama")%></p>
                               <a href="Homepage.aspx?KategoriId=<%# Eval("KategoriId")%>">
                                    <img style="width: 335px; height: 335px !important" src="<%# Eval("UrunResim")%>" class="card-img-top" />
                                </a>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <br />
            
            <h2 style="background-color: lightgray" class="p-1 text-center">Son Eklenen Ürünler</h2>
            <div class="row p-4" style="background-color: lightgray">
                <asp:Repeater ID="RepeaterUrunler" runat="server">
                    <ItemTemplate>
                        <div class="col-lg-4 col-md-6 col-sm-12 text-center">
                            <div class="card" style="width: 340px; height: 500px !important">
                                <a href="Homepage.aspx?KategoriId=<%# Eval("KategoriId")%>">
                                    <img style="width: 335px; height: 335px !important" src="<%# Eval("UrunResim")%>" class="card-img-top" />
                                </a>
                                <div class="card-body">
                                    <p class="card-text"><%# Eval("UrunAciklama")%></p>
                                    <p class="text-primary font-weight-bold">
                                        <%# String.Format("{0:c}", Eval("UrunFiyat"))%>
                                    </p>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </form>
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.6.0/dist/js/bootstrap.bundle.min.js"></script>
    <script src="css/scripts.js"></script>
</body>
</html>
