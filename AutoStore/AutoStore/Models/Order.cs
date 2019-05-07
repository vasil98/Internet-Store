using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AutoStore.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        [Required(ErrorMessage = "Введіть будь-ласка своє імя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Вкажіть будь-ласка адресу даставки")]
        public string Line { get; set; }

        [Required(ErrorMessage = "Вкажіть будь-ласка місто, куди потрібно доставити зазамовлення")]
        public string City { get; set; }
        public bool GiftWrap { get; set; }
        public bool Dispatched { get; set; }
        public virtual List<OrderLine> OrderLines { get; set; }
    }

    public class OrderLine
    {
        public int OrderLineId { get; set; }
        public Order Order { get; set; }
        public Auto Auto { get; set; }
        public int Quantity { get; set; }
    }

}
