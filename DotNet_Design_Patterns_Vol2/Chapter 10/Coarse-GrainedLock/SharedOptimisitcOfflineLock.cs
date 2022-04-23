using DotNet_Design_Patterns_Vol2.Chapter_04.RowDataGateway;
using System.Data;
using System.Data.SqlClient;

namespace DotNet_Design_Patterns_Vol2.Chapter_10.Coarse_GrainedLock
{
    public class Version
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime Modified { get; set; }
        public Version(int id, int value, string modifiedBy, DateTime modified)
        {
            Id = id;
            Value = value;
            ModifiedBy = modifiedBy;
            Modified = modified;
        }
        public static async Task<Version> FindAsync(int id)
        {
            //IdentityMap.GetVersion(id); Try to get version from cache using Identity Map;
            Version version = null;
            if (version == null)
            {
                version = await LoadAsync(id);
            }
            return version;

        }
        private static async Task<Version> LoadAsync(int id)
        {
            Version version = null;
            var result = await new SqlCommand($"" +
                $"SELECT * " +
                $"FROM version " +
                $"WHERE Id ={id}", DB.Connection).ExecuteReaderAsync();
            if (result.Read())
            {
                version = new(
                    (int)result["Id"],
                    (int)result["Value"],
                    (string)result["ModifiedBy"],
                    (DateTime)result["Modified"]);
                //put version in cahce IdentityMap.Put(version);
            }
            else
            {
                throw new DBConcurrencyException($"verison {id} not found!");
            }
            return version;
        }
        public static Version Create()
        {
            Version version = new(
                1, //Get Next Id
                0, //Initial version number
                "Session1", //modified by
                DateTime.Now);//modification datetime
            return version;
        }

        public async void Insert()
        {
            await new SqlCommand($"" +
                $"INSERT INTO " +
                $"version " +
                $"VALUES({Id},{Value},'{ModifiedBy}','{Modified}')", DB.Connection)
                .ExecuteNonQueryAsync();
            //put version in cahce IdentityMap.Put(version);
        }
        public async void Delete()
        {
            var effectedRowCount = await new SqlCommand($"" +
                $"DELETE FROM version " +
                $"WHERE Id = {Id}", DB.Connection)
                .ExecuteNonQueryAsync();
            if (effectedRowCount == 0)
            {
                throw new DBConcurrencyException($"verison {Id} not found!");
            }
        }
        public async void Increment()
        {
            //if(!Locked()){
            var effectedRowCount = await new SqlCommand($"" +
                 $"UPDATE version " +
                 $"SET " +
                 $"Value = {Value}," +
                 $"ModifiedBy='{ModifiedBy}'," +
                 $"Modified='{Modified}' " +
                 $"WHERE Id = {Id}", DB.Connection)
                 .ExecuteNonQueryAsync();
            if (effectedRowCount == 0)
            {
                throw new DBConcurrencyException($"verison {Id} not found!");
            }
            Value++;
            //}
        }
    }
    public interface IAggregate { }
    public abstract class BaseEntity
    {
        public Version Version { get; set; }
        protected BaseEntity(Version version) => this.Version = version;
    }
    public class Author : BaseEntity, IAggregate
    {
        public string Name { get; set; }
        public List<Address> Addresses { get; set; } = new List<Address>();
        public Author(Version version, string name) : base(version)
        {
            Name = name;
        }
        public Author AddAuthor(string name) => new Author(Version.Create(), name);
        public Address AddAdress(string street)
        {
            Address address = new Address(Version, street);
            Addresses.Add(address);
            return address;
        }
    }
    public class Address : BaseEntity
    {
        public string Street { get; set; }
        public Address(Version version, string street) : base(version) => this.Street = street;
    }

    public abstract class AbstractMapper
    {
        public void Insert(BaseEntity entity) => entity.Version.Increment();
        public void Update(BaseEntity entity) => entity.Version.Increment();
        public void Delete(BaseEntity entity) => entity.Version.Increment();
    }
    public class AuthorMapper : AbstractMapper
    {
        public new void Delete(BaseEntity entity)
        {
            Author author = (Author)entity;
            //delete addresses
            //delete author
            base.Delete(entity);
            author.Version.Delete();
        }
    }
}
