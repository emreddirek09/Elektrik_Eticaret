<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetim.Master" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="HepsiBizde.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <b>Save Products </b>
            <div class="col-md-12">
                Product Name
                <asp:TextBox CssClass="form-control border-info" ID="productname" runat="server" />
                <asp:RequiredFieldValidator SetFocusOnError="true" Display="Dynamic" ErrorMessage="Zorunlu Alan" Font-Bold="true" BackColor="Red" ForeColor="Wheat" ValidationGroup="g1" ControlToValidate="productname" runat="server" />
                <br />
                Image
                <asp:FileUpload CssClass="form-control border-danger" ID="FileUpload1" runat="server" />
                <br />
                Select Category
                <asp:DropDownList DataTextField="KategoriAd" DataValueField="KategoriId" ID="CategoryDropdown" CssClass="form-control" runat="server">
                    <asp:ListItem Value="-1">Kategori Seçiniz..</asp:ListItem>

                </asp:DropDownList>
                <br />

                Select Kampanya
                <asp:DropDownList DataTextField="KampanyaAd" DataValueField="KampanyaAd" ID="DropDownListKampanya" CssClass="form-control" runat="server">
                    <asp:ListItem Value="-1">Kampanya Seçiniz..</asp:ListItem>

                </asp:DropDownList>
                <br />
                Select Brand
                <asp:DropDownList DataTextField="MarkaAdi" DataValueField="MarkaId" ID="BrandDropdown" CssClass="form-control" runat="server">
                    <asp:ListItem Value="-1">Marka Seçiniz..</asp:ListItem>

                </asp:DropDownList>
                <br />
                Description
                <asp:TextBox class="form-control border-info" ID="productdesc" runat="server" />
                <asp:RequiredFieldValidator SetFocusOnError="true" Display="Dynamic" ForeColor="Wheat" ValidationGroup="g1" ErrorMessage="Zorunlu Alan" Font-Bold="true" BackColor="Red" ControlToValidate="productdesc" runat="server" />
                <br />
                Price(TL)
 
                <asp:TextBox class="form-control border-info" ID="productprice" runat="server" />
                <asp:RequiredFieldValidator SetFocusOnError="true" Display="Dynamic" ForeColor="Wheat" ErrorMessage="Zorunlu Alan" Font-Bold="true" BackColor="Red" ValidationGroup="g1" ControlToValidate="productprice" runat="server" />
                <br />
                <br />
                Discounted Price(TL)
 
                <asp:TextBox class="form-control border-info" ID="discountedproductprice" runat="server" />
                <asp:RequiredFieldValidator SetFocusOnError="true" Display="Dynamic" ForeColor="Wheat" ErrorMessage="Zorunlu Alan" Font-Bold="true" BackColor="Red" ValidationGroup="g1" ControlToValidate="productprice" runat="server" />
                <br />
                <asp:Button Text="Save" ValidationGroup="g1" ID="savebutton" OnClick="UrunKaydedildi_Click" class="btn btn-dark" runat="server" />
                <asp:Button Text="Apply" ID="updatebutton" Visible="false" OnClick="Unnamed_Click5" class="btn btn-primary" runat="server" />
                <a class="btn btn-danger" href="AddProduct.aspx">Cancel</a>
            </div>
            <div class="col-md-12">
                <h3>All Products </h3>
                <br />
                <div style="height: 400px; overflow-y: scroll;">
                    <center>
                    <table class="table table-hover  border border-danger">
                        <thead>
                            <tr>
                                <th>
                                    Image
                                </th>
                                <th>
                                    ID
                                </th>
                                <th>
                                    Name and Desc
                                </th>
                                   <th>
                                    Brand and Category
                                </th>
                                <th>
                                    Process
                                </th>
                                
                            </tr>
                        </thead>
                        <asp:repeater ID="productRepeater" runat="server">
                            <itemtemplate>
                                <tr>
                                   
                                     <td>  <asp:image Width="80" Height="80" imageurl= '<%# Eval("UrunResim")%>' runat="server" /><br />
                                        <%# String.Format("{0:c}", Eval("UrunFiyat"))%>
                                     </td>

                            <td>#<%# Eval("UrunId")%></td>

                            <td>
                                <%# Eval("UrunAd")%> <br /> <%# Eval("UrunAciklama")%>
                            </td>
                                    <td>
                                         <%# Eval("KategoriAd")%> <br /> <%# Eval("MarkaAdi")%>

                                    </td>
                            <td>
                                <asp:linkbutton OnClientClick="return confirm('Seçilen ürünü güncellemek istiyor musunuz ?');" OnClick="Update_Click" text="update" CommandArgument='<%# Eval("UrunId")%>' CssClass="btn btn-dark" runat="server"></asp:linkbutton>
                                 or 
                                <asp:linkbutton text="delete" OnClick="Unnamed_Click3" CommandArgument='<%# Eval("UrunId")%>' OnClientClick="return confirm('Ürün Silinecek Emin Misiniz ?');"  CssClass="btn btn-dark" runat="server" /></td>
                            </tr>
                            </itemtemplate>
                        </asp:repeater>
                       
                    </table>
                        </center>
                </div>
            </div>

            <div class="col-md-4 border border-dark">
                <br />
                <b>Add Category</b><br />
                Category Name
            <input type="text" class="form-control border-info" id="CategoryName" runat="server" />
                <asp:RequiredFieldValidator SetFocusOnError="true" Display="Dynamic" ForeColor="Wheat" ErrorMessage="Zorunlu Alan" Font-Bold="true" BackColor="Red" ValidationGroup="g2" ControlToValidate="CategoryName" runat="server" />
                <br />
                <asp:Button ValidationGroup="g2" ID="KayitButton" OnClick="KategoriKayit_Click" Text="Save" class="btn btn-info" runat="server" />
            </div>

            <div class="col-md-4 border border-dark">
                <br />
                <b>Add Kampanya</b><br />
                Kampaya Name
                <input type="text" class="form-control border-info" id="KampanyaAdi" runat="server" /> 
                 Kampaya Banner
                <asp:FileUpload CssClass="form-control border-danger" ID="KampanyaBanner" runat="server" />
                <br />
                <asp:Button  ID="AddKampanya" OnClick="AddKampanya_Click" Text="Save" class="btn btn-success" runat="server" />
            </div>

            <div class="col-md-4 border border-dark">
                <br />
                <b>Brand </b>
                <br />
                Brand Name
            <input type="text" class="form-control border-info" id="BrandName" runat="server" />
                <asp:RequiredFieldValidator SetFocusOnError="true" Display="Dynamic" ForeColor="Wheat" ErrorMessage="Zorunlu Alan" Font-Bold="true" BackColor="Red" ValidationGroup="g3" ControlToValidate="BrandName" runat="server" />
                <asp:Button ValidationGroup="g3" Text="Save" OnClick="MarkaKayit_Click" class="btn btn-warning my-2" runat="server" />
                <br />

            </div>

        </div>
        <div class="row">
            <div class="col-md-4 border border-warning">
                <h3>Categories</h3>
                <div style="height: 400px; overflow-y: scroll;">
                    <center>
                    <table class="table table-hover">
                        <thead>
                            <tr>
                                <th>ID
                                </th>
                                <th>Name
                                </th>
                                <th>Process
                                </th>
                                
                            </tr>
                        </thead>
                        <asp:repeater ID="Categories" runat="server">
                            <itemtemplate>
                                <tr>
                            <td>#<%# Eval("KategoriId")%></td>
                            <td><%# Eval("KategoriAd")%></td>
                            <td><asp:linkbutton text="delete" OnClick="Unnamed_Click2" OnClientClick="return confirm('Kategori Silinecek Emin Misiniz ?');"  CommandArgument='<%# Eval("KategoriId")%>' CssClass="btn btn-dark" runat="server" /></td>
                            </tr>
                            </itemtemplate>
                        </asp:repeater>
                       
                    </table>

                        </center>
                </div>
            </div>


            <div class="col-md-4 border border-success">
                <h3>Kampyanya</h3>
                <br />
                <div style="height: 400px; overflow-y: scroll;">
                    <center>
                    <table class="table table-hover">
                        <thead>
                            <tr>
                                <th>ID
                                </th>
                                <th>Name
                                </th>
                                <th>Banner
                                </th>
                                <th>Process
                                </th>
                                
                            </tr>
                        </thead>
                        <asp:repeater ID="Repeater2Kampanya" runat="server">
                            <itemtemplate>
                                <tr>
                            <td><%# Eval("KampanyaId")%></td>
                            <td><%# Eval("KampanyaAd")%></td>
                            <td>  <asp:image Width="70" Height="70" imageurl= '<%# Eval("KampanyaBanner")%>' runat="server" /><br />
                            <td><asp:linkbutton OnClientClick="return confirm('Marka Silinecek Emin Misiniz ?');" text="delete" OnClick="Unnamed_Click1" CommandArgument='<%# Eval("KampanyaId")%>' CssClass="btn btn-dark" runat="server" /></td>
                            </tr>
                            </itemtemplate>
                        </asp:repeater>
                       
                    </table>

                        </center>
                </div>
            </div>

            <div class="col-md-4 border border-success">
                <h3>Brands</h3>
                <br />
                <div style="height: 400px; overflow-y: scroll;">
                    <center>
                    <table class="table table-hover">
                        <thead>
                            <tr>
                                <th>ID
                                </th>
                                <th>Name
                                </th>
                                <th>Process
                                </th>
                                
                            </tr>
                        </thead>
                        <asp:repeater ID="Repeater1" runat="server">
                            <itemtemplate>
                                <tr>
                            <td>#<%# Eval("MarkaId")%></td>
                            <td><%# Eval("MarkaAdi")%></td>
                            <td><asp:linkbutton OnClientClick="return confirm('Marka Silinecek Emin Misiniz ?');" text="delete" OnClick="Unnamed_Click1" CommandArgument='<%# Eval("MarkaId")%>' CssClass="btn btn-dark" runat="server" /></td>
                            </tr>
                            </itemtemplate>
                        </asp:repeater>
                       
                    </table>

                        </center>
                </div>
            </div>


        </div>
    </div>
</asp:Content>
