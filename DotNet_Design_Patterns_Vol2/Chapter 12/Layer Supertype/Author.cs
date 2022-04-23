namespace DotNet_Design_Patterns_Vol2.Chapter_12.Layer_Supertype
{
    public abstract class BaseModel
    {
        public int Id { get; set; }
    }
    public class Author : BaseModel
    {
        public string FirstName { get; set; }
    }
}
