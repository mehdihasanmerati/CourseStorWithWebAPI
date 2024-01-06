using CourseStor.Models.Orders.Dto;
using CourseStor.Models.Orders.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CourseStor.DAL.Frameworks
{
    public static class OrderQueryExtension
    {
        public static IQueryable<Order> WhereOverOrder(this IQueryable<Order> orders,int id)
        {

            if (!string.IsNullOrEmpty(id.ToString()))
                orders = orders.Where(c => c.Id.ToString().Contains(id.ToString()));
            return orders;
                
        }

        public static async Task<List<OrderQueryResult>> ToOrderQueryAsync(this IQueryable<Order> orders)
        {
            return await orders.Select(c=> new OrderQueryResult
            {
                Id = c.Id,
                Name = c.Name,
                Price = c.Price,
                CustomerEmail = c.CustomerEmail,
                CreateOrder = c.CreateOrder,
            }).ToListAsync();
        }

    }
}
