using DotNet_Design_Patterns_Vol2.Chapter_04.RowDataGateway;
using System.Data.SqlClient;

namespace DotNet_Design_Patterns_Vol2.Chapter_06.EmbeddedValue
{
    public class Publisher
    {
        public int PublisherId { get; set; }
        public string Name { get; set; }
        public Address AddressInfo { get; set; }
        public async Task<Publisher> FindAsync(int publisherId)
        {
            var reader = await new SqlCommand($"" +
                $"SELECT * " +
                $"FROM Publisher " +
                $"WHERE ID = {publisherId}", DB.Connection).ExecuteReaderAsync();
            reader.Read();
            Publisher result = new()
            {
                PublisherId = (int)reader["Id"],
                Name = (string)reader["Name"],
                AddressInfo = new Address
                {
                    Country = (string)reader["Country"],
                    Province = (string)reader["Province"],
                    City = (string)reader["City"],
                    Street = (string)reader["Street"]
                }
            };
            return result;
        }
    }
    public class Address
    {
        public string Country { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
    }

}
