using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoStore.Models
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public void AddItem(Auto auto, int quantity)
        {
            CartLine line = lineCollection
                .Where(p => p.Auto.AutoId == auto.AutoId)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Auto = auto,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(Auto auto)
        {
            lineCollection.RemoveAll(l => l.Auto.AutoId == auto.AutoId);
        }

        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e => (decimal)e.Auto.Price * e.Quantity);
        }

        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<CartLine> Lines
        {
            get
            {
                return lineCollection;
            }
        }
    }

    public class CartLine
    {
        public Auto Auto { get; set; }
        public int Quantity { get; set; }
    }

}
