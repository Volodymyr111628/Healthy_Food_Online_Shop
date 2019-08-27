using Microsoft.EntityFrameworkCore;
using ShopData.Models;
using System;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace ShopData
{
    public class Context:DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Element> Elements { get; set; }
        public DbSet<Basket> Basket { get; set; }
    }
}
