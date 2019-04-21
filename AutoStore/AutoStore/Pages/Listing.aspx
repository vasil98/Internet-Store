<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Listing.aspx.cs" Inherits="AutoStore.Pages.Listing"
    MasterPageFile="~/Pages/Store.Master" %>

<asp:Content ContentPlaceHolderID="bodyContent" runat="server">

    <div id="content">        
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Pictures/merin.jpg" Width="300" Height="240" />
        <asp:Image ID="Image2" runat="server" ImageUrl="~/Pictures/becha.jpg" Width="300" Height="240" />
        <asp:Image ID="Image3" runat="server" ImageUrl="~/Pictures/cruzak.jpg" Width="400" Height="240" />      
        <%
            foreach (AutoStore.Models.Auto auto in GetAutos())
            {
                Response.Write(String.Format(@"
                        <div class='item'>
                            <h3>{0}</h3>
                            {1}
                            <h4>{2:c}</h4>
                        </div>",
                        auto.Brand, auto.Description, auto.Price));
            }
        %>
        <asp:Image ID="Image4" runat="server" ImageUrl="~/Pictures/sprinter.jpg" Width="300" Height="240" />
        <asp:Image ID="Image5" runat="server" ImageUrl="~/Pictures/crafter.jpg" Width="300" Height="240" />
        <asp:Image ID="Image6" runat="server" ImageUrl="~/Pictures/transit.jpg" Width="340" Height="240" />
    </div>
    <div class="pager">
        <%
            for (int i = 1; i <= MaxPage; i++)
            {
                Response.Write(
                    String.Format("<a href='/Pages/Listing.aspx?page={0}' {1}>{2}</a>",
                        i, i == CurrentPage ? "class='selected'" : "", i));
            }
        %>
    </div>
</asp:Content>
