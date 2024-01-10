using Dapper;
using Lab2.CommonModules.Entity;
using Lab2.CommonModules.Interface;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Infrastructure.Repoistory
{
    public class OrderRepo : IOrder
    {
        public async Task<bool> Add(Order order)
        {
            try
            {
                var connectionString = "connection";

                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var sql = "INSERT INTO dbo.Order (orderID,customerID,date, totalAmount) VALUES (@orderID,@customerID,@date,@totalAmount)";
                    var rowsAffected = await connection.ExecuteAsync(sql, order);
                    return rowsAffected > 0;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Update method: {ex.Message}");
                return false;

            }
        }

        public async Task<bool> Delete(Order order)
        {
            try
            {
                var connectionString = "connection";
                using (var connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    var sql = "DELETE FROM dbo.Order WHERE orderID = @orderID";
                    var rowsAffected = await connection.ExecuteAsync(sql, new { orderID = order.orderID });
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Delete method: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> Get(Order order)
        {
            try
            {
                var connectionString = "connection";
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var sql = "SELECT * FROM dbo.Order"; //udate table name to correspond with the server names
                    var rowsAffected = await connection.ExecuteAsync(sql, order);
                    return rowsAffected > 0;

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Update method: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> Update(Order order)
        {
            try
            {
                var connectionString = "connection";
                using (var connection = new SqlConnection(connectionString))
                {
                    var sql = "UPDATE dbo.Order SET orderID = @orderID, customerID = @customerID, date = @date, totalAmount = @totalAmount";
                    var rowsAffected = await connection.ExecuteAsync(sql, order);
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Update method: {ex.Message}");
                return false;
            }
        }   
    }
}
