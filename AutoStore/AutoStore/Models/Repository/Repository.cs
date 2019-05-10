using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AutoStore.Models.Repository
{
    public class Repository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Auto> Autos
        {
            get
            {
                return context.Autos;
            }
        }
        // читання даних із таблиці Orders
        public IEnumerable<Order> Orders
        {
            get
            {
                return context.Orders.Include(o => o.OrderLines.Select(ol => ol.Auto));
            }
        }
        public void SaveOrder(Order order)
        {
            if (order.OrderId == 0)
            {
                order = context.Orders.Add(order);

                foreach (OrderLine line in order.OrderLines)
                {
                    context.Entry(line.Auto).State = EntityState.Modified;
                }

            }
            else
            {
                Order dbOrder = context.Orders.Find(order.OrderId);
                if (dbOrder != null)
                {
                    dbOrder.Name = order.Name;
                    dbOrder.Line = order.Line;
                    dbOrder.City = order.City;
                    dbOrder.GiftWrap = order.GiftWrap;
                    dbOrder.Dispatched = order.Dispatched;
                }
            }
            context.SaveChanges();
        }

        public void SaveAuto(Auto auto)
        {
            if (auto.AutoId == 0)
            {
                auto = context.Autos.Add(auto);
            }
            else
            {
                Auto dbAuto = context.Autos.Find(auto.AutoId);
                if (dbAuto != null)
                {
                    dbAuto.Brand = auto.Brand;
                    dbAuto.Description = auto.Description;
                    dbAuto.Price = auto.Price;
                    dbAuto.Category = auto.Category;
                }
            }
            context.SaveChanges();
        }
        public void DeleteAuto(Auto auto)
        {
            IEnumerable<Order> orders = context.Orders
                .Include(o => o.OrderLines.Select(ol => ol.Auto))
                .Where(o => o.OrderLines
                    .Count(ol => ol.Auto.AutoId == auto.AutoId) > 0)
                .ToArray();

            foreach (Order order in orders)
            {
                context.Orders.Remove(order);
            }
            context.Autos.Remove(auto);
            context.SaveChanges();
        }

    }
}
