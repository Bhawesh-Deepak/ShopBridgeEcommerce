using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShopBridge.Core.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopBridge.Core.Entities.Common
{
    public class ShopBridgeContext:DbContext
    {
        private readonly string _connectionString;

        public ShopBridgeContext() { }
        public ShopBridgeContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetSection("ConnectionStrings:DefaultConnection").Value;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        public virtual DbSet<ProductModel> ProductModels { get; set; }


    }
}
