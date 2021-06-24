﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HepsiBizde.Default" %>

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
                    <a href="Default.aspx"><img style="max-width: 180px" src="assets/logo.png" /></a>
                    <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation"><span class="navbar-toggler-icon"></span></button>
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
                <div class="container-fluid">
                    <h1> DENEME SAYFASI</h1>

                </div>
            </div>
    </form>
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.6.0/dist/js/bootstrap.bundle.min.js"></script>
    <script src="css/scripts.js"></script>
</body>
</html>