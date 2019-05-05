<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CartView.aspx.cs" Inherits="AutoStore.Pages.CartView"
    MasterPageFile="~/Pages/Store.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContent" runat="server">
    
    <div id="content">
        <h2>Ваш кошик</h2>
        <table id="cartTable">
            <thead>
                <tr>
                    <th>Кількість автомобілів</th>
                    <th>Марка</th>
                    <th>Ціна</th>
                    <th>Загальна вартість</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="Repeater1" ItemType="AutoStore.Models.CartLine"
                    SelectMethod="GetCartLines" runat="server" EnableViewState="false">
                    <ItemTemplate>
                        <tr>
                            <td><%# Item.Quantity %></td>
                            <td><%# Item.Auto.Brand %></td>
                            <td><%# Item.Auto.Price.ToString("c")%></td>
                            <td><%# ((Item.Quantity * Item.Auto.Price).ToString("c"))%></td>
                            <td>
                                <button type="submit" class="actionButtons" name="remove"
                                    value="<%#Item.Auto.AutoId %>">
                                    Видалити
                                </button>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
            <tfoot>
                <tr>
                    <td colspan="3">Разом:</td>
                    <td><%= CartTotal.ToString("c") %></td>
                </tr>
            </tfoot>
        </table>
        <p class="actionButtons">
            <a href="<%= ReturnUrl %>">Продовжити покупки</a>
            <a href="<%= CheckoutUrl %>">Оформити замовлення</a>
        </p>
    </div>
</asp:Content>
