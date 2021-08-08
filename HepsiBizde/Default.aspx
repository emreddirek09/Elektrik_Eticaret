<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HepsiBizde.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BdElektrik E-Ticaret</title>
    <link rel="preconnect" href="https://fonts.gstatic.com" />
    <link href="https://fonts.googleapis.com/css2?family=Nunito:wght@300;400;600;700;800&display=swap" rel="stylesheet" />
    <link rel="icon" type="image/x-icon" href="assets/favicon.ico" />
    <link href="css/styles.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
    <link href="css/DropDown.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="row container-fluid text-center py-4" id="denemediv1" runat="server" visible="false">
            <div class="col-12">
                <h5 style="background-color: gainsboro">
                    <asp:Label ID="Label1" runat="server" Text="Mağazada Ara"></asp:Label></h5>
            </div>
            <div class="col-11">
                <asp:TextBox ID="TxtSearch" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col-1">
                <asp:Button ID="Btn_Ara" CssClass="btn btn-success" runat="server" Text="ARA" />
            </div>
        </div>
        <div id="page-content-wrapper">
            <nav class="navbar navbar-expand-lg navbar-light bg-light border-bottom">
                <a href="Default.aspx">
                    <img style="max-width: 180px" src="assets/logo.png" /></a> &emsp; &emsp;
                <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation"><span class="navbar-toggler-icon"></span></button>
                <asp:DropDownList ID="DropDownList1Urün" AutoPostBack="true" Width="300" OnSelectedIndexChanged="DropDownList1Urün_SelectedIndexChanged" CssClass="sdropbtn form-control container " runat="server">
                    <asp:ListItem Value="-1">Ürünler</asp:ListItem>
                </asp:DropDownList>
                &emsp;
                <asp:Button ID="Kampanyalar" OnClick="Kampanyalar_Click" Width="300" CssClass="dropbtn form-control " runat="server" ForeColor="Red" Text="Kampanyalar" />
                <%--<asp:DropDownList ID="DropDownList2Kampanya" Width="300" autopostback="true" CssClass="form-control container" BackColor="#f0f0f0" runat="server">
                    <asp:ListItem Value="-1">Kampanyalar</asp:ListItem>
                </asp:DropDownList>--%>
                <div class="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul class="navbar-nav ml-auto mt-2 mt-lg-0">
                        <asp:LinkButton ID="LinkButton1" runat="server" CssClass="p-2" OnClick="BtnSerach_Click">
                <i class="fa fa-search"></i></asp:LinkButton>
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
            <div id="carouselExampleIndicators" class="carousel slide" data-ride="carousel">
                <ol class="carousel-indicators">
                    <li data-target="#carouselExampleIndicators" data-slide-to="0" class="active"></li>
                    <li data-target="#carouselExampleIndicators" data-slide-to="1"></li>
                    <li data-target="#carouselExampleIndicators" data-slide-to="2"></li>
                    <li data-target="#carouselExampleIndicators" data-slide-to="3"></li>
                </ol>
                <div class="carousel-inner">
                    <div class="carousel-item active">
                        <img class="d-block w-100" src="dosyalar/Slider/1.png" alt="1 slide" />
                    </div>
                    <div class="carousel-item">
                        <img class="d-block w-100" src="dosyalar/Slider/2.png" alt="2 slide" />
                    </div>
                    <div class="carousel-item">
                        <img class="d-block w-100" src="dosyalar/Slider/4.png" alt="3 slide" />
                    </div>
                    <div class="carousel-item">
                        <img class="d-block w-100" src="dosyalar/Slider/5.png" alt="4 slide" />
                    </div>
                </div>
                <a class="carousel-control-prev" href="#carouselExampleIndicators" role="button" data-slide="prev">
                    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                    <span class="sr-only">Previous</span>
                </a>
                <a class="carousel-control-next" href="#carouselExampleIndicators" role="button" data-slide="next">
                    <span class="carousel-control-next-icon" aria-hidden="true"></span>
                    <span class="sr-only">Next</span>
                </a>
            </div>
            <div class="DefaultBaslik">
                <h2>Kampanyalı Ürünler</h2>
            </div>
            <div class="DefaultUrunler row p-4 ">
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <div class=" col-lg-3 col-md-6 col-sm-12 text-center">
                            <div class="card" style="width: 440px; height: 600px !important">
                                <a href="Homepage.aspx?KategoriId=<%# Eval("KategoriId")%>">
                                    <img style="width: 435px; height: 435px !important" src="<%# Eval("UrunResim")%>" class="card-img-top zoom" />
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
            <div class="DefaultBaslik">
                <h2>İndirim Fırsatları</h2>
            </div>
            <div class="row text-center" style="background-color: aliceblue">
                <asp:Repeater ID="Repeater2" runat="server">
                    <ItemTemplate>
                        <div class="zoomm col-lg-12 col-md-12 col-sm-12 text-black-50">
                            <div class="bg-image hover-overlay ripple">
                                <a href="Kampanyalar.aspx">
                                    <img src="<%# Eval("KampanyaBanner")%>" style="max-width: 100%; height: auto" class="img-fluid" /></a>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div class="row text-center">
                <asp:Repeater ID="Repeater3" runat="server">
                    <ItemTemplate>
                        <div class=" col-lg-4 col-md-12 col-sm-12">
                            <div class="bg-image hover-overlay ripple">
                                <a href="Homepage.aspx?KategoriId=<%# Eval("KategoriId")%>">
                                    <img style="width: 335px; height: 335px !important" src="<%# Eval("UrunResim")%>" class="card-img-top zoom" />
                                </a>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div class="DefaultBaslik">
                <h2>Son Eklenen Ürünler</h2>
            </div>
            <div class="DefaultUrunler row p-4">
                <asp:Repeater ID="RepeaterUrunler" runat="server">
                    <ItemTemplate>
                        <div class="col-lg-3 col-md-6 col-sm-12 text-center">
                            <div class="card" style="width: 440px; height: 600px !important">
                                <a href="Homepage.aspx?KategoriId=<%# Eval("KategoriId")%>">
                                    <img style="width: 435px; height: 435px !important" src="<%# Eval("UrunResim")%>" class="card-img-top zoom" />
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
            <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.5.0/css/font-awesome.min.css" />
            <a href="https://wa.me/+905352808161?text=UrulerHakkindaBilgiAlmakIstiyorum" class="float" target="_blank">
                <i class="fa fa-whatsapp my-float"></i>
            </a>
        </div>
    </form>
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.6.0/dist/js/bootstrap.bundle.min.js"></script>
    <script src="css/scripts.js"></script>
    <script>
        $('.carousel').carousel({
            interval: 4000
        })
    </script>
    <link href="css/widgets/WP.css" rel="stylesheet" />
    <section class="">
        <!-- Footer -->
        <footer class="text-center text-white" style="background-color: #0a4275;">
            <!-- Grid container -->
            <div class="container p-4 pb-0">
                <!-- Section: CTA -->
                <section class="">
                    <p class="d-flex justify-content-center align-items-center">
                        <span class="me-3">Register for free</span>
                        <button type="button" class="btn btn-outline-light btn-rounded">
                            Sign up!
                        </button>
                    </p>
                </section>
                <!-- Section: CTA -->
            </div>
            <!-- Grid container -->

            <!-- Copyright -->
            <div class="text-center p-3" style="background-color: rgba(0, 0, 0, 0.2);">
                © 2021 Copyright:
      <a class="text-white" href="https://mdbootstrap.com/">Emre Direk</a>
            </div>
            <!-- Copyright -->
        </footer>
        <!-- Footer -->
    </section>
</body>

</html>
