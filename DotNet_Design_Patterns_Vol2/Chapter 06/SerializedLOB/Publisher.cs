using DotNet_Design_Patterns_Vol2.Chapter_04.RowDataGateway;
using Newtonsoft.Json;
using System.Data.SqlClient;

namespace DotNet_Design_Patterns_Vol2.Chapter_06.SerializedLOB
{
    public class Publisher
    {
        public int PublisherId { get; set; }
        public string Name { get; set; }
        public ICollection<Category> Categories { get; set; }

        public async Task<bool> AddAsync(Publisher publisher)
        {
            return (await new SqlCommand($"" +
              $"INSERT INTO Publisher " +
              $"(Name, Categories) VALUES " +
              $" N'{publisher.Name}', N'{JsonConvert.SerializeObject(publisher.Categories)}'", DB.Connection).ExecuteNonQueryAsync()) > 0;
        }
        public ICollection<Category> GetCategories(string serializedCategories) => JsonConvert.DeserializeObject<ICollection<Category>>(serializedCategories);

    }
    public class Category
    {
        public string Title { get; set; }
        public ICollection<Category> SubSet { get; set; }
    }
}
