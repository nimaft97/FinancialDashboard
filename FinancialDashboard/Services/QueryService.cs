using FinancialDashboard.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FinancialDashboard.Services
{
    public class QueryService
    {
        private AppDbContext _context;
        private static readonly HttpClient client = new HttpClient();


        public QueryService()
        {
            // initialize the database context
            _context = new AppDbContext();
            _context.Database.EnsureCreated();
            client.Timeout = TimeSpan.FromMinutes(10);  // Increase timeout duration
        }

        public string AddRecord(decimal value, string description, Category category, DateTime date)
        {
            var transaction = new Transaction
            {
                Value = value,
                Description = description,
                Category = category,
                Date = date
            };

            // update db context
            _context.Transactions.Add(transaction);
            _context.SaveChanges();

            return $"Record added: value {value}, description {description}, category {category}, date {date.ToShortDateString()}";
        }

        public async Task<string> GetSqlQueryFromLLM(string naturalLanguageQuery)
        {
            try
            {
                var content = new StringContent("{\"text\":\"" + naturalLanguageQuery + "\"}", Encoding.UTF8, "application/json");

                // Make the request to the Python LLM service
                // var response = await client.PostAsync("http://localhost:5000/generate_sql", content);
                var response = await client.PostAsync("http://localhost:5000/generate_sql", content).ConfigureAwait(false);


                // Check if response is successful
                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                    return null;
                }

                // Read the content when ready
                var responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Response received: {responseBody}");

                // Parse the JSON response and extract the SQL query
                var responseJson = JsonSerializer.Deserialize<JsonElement>(responseBody);
                var sqlQuery = responseJson.GetProperty("sql_query").GetString();

                return sqlQuery;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }


        public string ExecuteSql(string naturalLanguageQuery)
        {
            try
            {
                // Step 1: Convert natural language query to SQL query using LLM service
                string sqlQuery = GetSqlQueryFromLLM(naturalLanguageQuery).Result;
                // Step 2: Display the SQL query for QA purposes
                Console.WriteLine("Generated SQL Query: " + sqlQuery);

                var result = _context.Transactions.FromSqlRaw(sqlQuery).ToList();
                return result.Count > 0 ? string.Join("\n", result.Select(r => $"{r.TransactionID}: {r.Description} - {r.Value}")) : "No records found.";
            }
            catch(Exception ex)
            {
                return $"Error executing query: {ex.Message}";
            }
        }
    }
}
