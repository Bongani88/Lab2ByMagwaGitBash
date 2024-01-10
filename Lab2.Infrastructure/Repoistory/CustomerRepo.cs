using Dapper;
using Lab2.CommonModules.Interface;
using Lab2.CommonModules.Entity;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Numerics;

namespace Lab2.Infrastructure.Repoistory
{
    public class CustomerRepo : ICustomer

    {
        string connectionString = "Server =.\\SQLEXPRESS;Initial Catalog=ConnectionToLab2;Integrated Security=True;Encrypt=False;";
        //include the a constructor
        public async Task<bool> Add(Customer customer)
        {
            try
            {
               

                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var sql = "INSERT INTO dbo.Customer (customerID, firstName, lastName, email, phone, address)" +
                        " VALUES (@customerID, @firstName, @lastName, @email, @phone, @address)";
                    var values = new
                    {
                        customerID = customer.customerID,
                        firstName = customer.firstName,
                        lastName = customer.lastName,
                        email = customer.email,
                        phone = customer.phone,
                        address = customer.address,
                    };
                    var query = await connection.ExecuteAsync(sql,values);
                    return query > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Add method: {ex.Message}");
            }
            return false;
        }


        public async Task<List<Customer>> Get(Customer customer)
        {
            try
            {
               
                using (var connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    var sql = "SELECT * FROM dbo.Customer";
                    var rowsAffected = await connection.QueryAsync<Customer>(sql, customer);
                    return rowsAffected.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Update method: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> Update(Customer customer)
        {
            try
            {
               
                using (var connection = new SqlConnection(connectionString))
                {
                    var sql = "UPDATE dbo.Customer SET firstName = @firstName, lastName = @lastName, email = @email, phone = @phone, address = @address WHERE customerID = @customerID";
                    var values = new
                    {
                        customerID = customer.customerID,
                        firstName = customer.firstName,
                        lastName = customer.lastName,
                        email = customer.email,
                        phone = customer.phone,
                        address = customer.address,

                    };
                    var rowsAffected = await connection.ExecuteAsync(sql, values);
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Update method: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> Delete(int customerID)
        {
            try

            {

                using (var connection = new SqlConnection(connectionString))

                {

                    await connection.OpenAsync();

                    var sql = "DELETE FROM dbo.Customer WHERE customerID = @customerID";

                    var rowsAffected = await connection.ExecuteAsync(sql, new { customerID = customerID });

                    return rowsAffected > 0;

                }

            }
            catch (Exception ex)

            {

                Console.WriteLine($"Error in Delete method: {ex.Message}");

                return false;

            }
        }
    }
}
