namespace DotNet_Design_Patterns_Vol2.Chapter_06.AssociationTableMapping
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public DateOnly PublishDate { get; set; }
        public ICollection<Author> Authors { get; set; } = new List<Author>();
    }
    public class Author
    {
        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
