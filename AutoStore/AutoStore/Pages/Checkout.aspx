<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" 
    Inherits="AutoStore.Pages.Checkout"
    MasterPageFile="~/Pages/Store.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContent" runat="server">
    <div id="content">

        <div id="checkoutForm" class="checkout" runat="server">
            <h2>Оформити замовлення</h2>
            Будь ласка, введіть свої дані, і ми відправимо Ваш товар прямо зараз!

        <div id="errors" data-valmsg-summary="true">
            <ul>
                <li style="display:none"></li>
            </ul>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
        </div>

            <h3>Замовник</h3>
            <div>
                <label for="name">Імя:</label>
                <SX:VInput Property="Name" runat="server" />
            </div>

            <h3>Адреса доставки</h3>
            <div>
                <label for="line">Адреса:</label>
                <SX:VInput Property="Line" runat="server" />
            </div>
                 
            <div>
                <label for="city">Місто:</label>
                <SX:VInput Property="City" runat="server" />
            </div>

            <h3>Деталі замовлення</h3>
            <input type="checkbox" id="giftwrap" name="giftwrap" value="true" />
            Використовувати подарункову упаковку?
        
        <p class="actButtons">
            <button class="actButtons" type="submit">Обробити замовлення</button>
        </p>
        </div>
        <div id="checkoutMessage" runat="server">
            <h2>Дякуємо!</h2>
            Дякуємо що вибрали наш магазин! Ми постараємося максимально швидко відправити ваше замовлення   
        </div>
    </div>
</asp:Content>
