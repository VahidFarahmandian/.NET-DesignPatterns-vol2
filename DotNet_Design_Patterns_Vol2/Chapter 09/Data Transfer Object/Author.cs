using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet_Design_Patterns_Vol2.Chapter_09.Data_Transfer_Object
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Book> Books { get; set; }
    }
    public class AuthorDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Status { get; set; }
        public ICollection<BookDTO> Books { get; set; }
    }
    public static class AuthorAssembler
    {
        public static Author ToModel(this AuthorDTO dto)
        {
            return new Author
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                IsActive = dto.Status == "Active" ? true : false,
                Books = dto.Books.Select(x => x.ToModel()).ToList()
            };
        }
        public static AuthorDTO ToDTO(this Author model)
        {
            return new AuthorDTO
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Status = model.IsActive ? "Active" : "Deactive",
                Books = model.Books.Select(x => x.ToDTO()).ToList()
            };
        }
        private static Book ToModel(this BookDTO dto)
        {
            return new Book
            {
                Title = dto.Title,
                Language = dto.Language
            };
        }
        private static BookDTO ToDTO(this Book model)
        {
            return new BookDTO
            {
                Title = model.Title,
                Language = model.Language
            };
        }
    }

    public class BookDTO
    {
        public string Title { get; set; }
        public string Language { get; set; }
    }
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Language { get; set; }
    }
}
