using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Shop.Infrastructure.Persistent.Dapper
{
    public class DapperContext
    {
        private readonly string _connectionString;

        public DapperContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);

        public string Sellers = "[seller].Sellers";
        public string Inventories = "[seller].Inventories";
        public string UserAddress = "[user].Addresses";
        public string OrderItems = "[order].Items";
        public string Products = "[product].Products";
    }
}