<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CartSummary.ascx.cs" 
    Inherits="AutoStore.Controls.CartSummary" %>

<div id="cartSummary">
    <span class="caption">
        <b>В кошику</b>
        <span id="csQuantity" runat="server"></span> товарів:
        <span id="csTotal" runat="server"></span>
    </span>
    <a id="csLink" runat="server">Кошик</a>
</div>
