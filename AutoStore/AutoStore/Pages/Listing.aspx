<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Listing.aspx.cs" Inherits="AutoStore.Pages.Listing"
    MasterPageFile="~/Pages/Store.Master" %>
<%@ Import Namespace="System.Web.Routing" %>

<asp:Content ContentPlaceHolderID="bodyContent" runat="server">
    
    <div id="content">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Pictures/merin.jpg" Width="300" Height="240" />
        <asp:Image ID="Image2" runat="server" ImageUrl="~/Pictures/becha.jpg" Width="300" Height="240" />
        <asp:Image ID="Image3" runat="server" ImageUrl="~/Pictures/cruzak.jpg" Width="400" Height="240" />      

        <asp:Repeater ItemType="AutoStore.Models.Auto"
            SelectMethod="GetAutos" runat="server">
            <ItemTemplate>
                <div class="item">
                    <h3><%# Item.Brand %></h3>
                    <%# Item.Description %>
                    <h4><%# Item.Price.ToString("c") %></h4>
                    <button name="add" type="submit" value="<%# Item.AutoId %>">
                        Додати в кошик
                    </button>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <asp:Image ID="Image4" runat="server" ImageUrl="~/Pictures/sprinter.jpg" Width="300" Height="240" />
        <asp:Image ID="Image5" runat="server" ImageUrl="~/Pictures/crafter.jpg" Width="300" Height="240" />
        <asp:Image ID="Image6" runat="server" ImageUrl="~/Pictures/transit.jpg" Width="320" Height="240" />  
    </div>

    <div class="pager">
        <%
            for (int i = 1; i <= MaxPage; i++)
            {
                string category = (string)Page.RouteData.Values["category"]
                    ?? Request.QueryString["category"];
                
                string path = RouteTable.Routes.GetVirtualPath(null, null,
                    new RouteValueDictionary() { {"category", category}, { "page", i } }).VirtualPath;
                Response.Write(
                    String.Format("<a href='{0}' {1}>{2}</a>",
                        path, i == CurrentPage ? "class='selected'" : "", i));
            }
        %>
    </div>

</asp:Content>
