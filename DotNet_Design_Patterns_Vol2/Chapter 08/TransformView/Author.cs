﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet_Design_Patterns_Vol2.Chapter_08.TransformView
{
    public class AuthorTransformer
    {
        public string Transform(List<Author> authors)
        {
            StringBuilder sb = new();
            sb.AppendLine("<html>");
            sb.AppendLine("<head>");
            sb.AppendLine("<body>");
            sb.AppendLine("<table>");
            sb.AppendLine("<tr>");

            foreach (var item in typeof(Author).GetProperties())
            {
                sb.AppendLine($"<td>{item.Name}</td>");
            }
            sb.AppendLine("</tr>");
            foreach (var item in authors)
            {
                sb.AppendLine("<tr>");
                sb.Append($"<td>{item.FirstName}</td>");
                sb.Append($"<td>{item.LastName}</td>");
                sb.Append($"<td>{item.BooksCount}</td>");
                sb.AppendLine("</tr>");
            }
            sb.AppendLine("</table>");
            sb.AppendLine("</body>");
            sb.Append("</html>");
            return sb.ToString();
        }
    }
    public class Author
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int BooksCount { get; set; }
    }
    public class DatabaseGateway
    {
        public List<Author> GetAuthors()
        {
            return new List<Author>()
            {
                new Author
                {
                    FirstName="Vahid",
                    LastName="Farahmandian",
                    BooksCount=2
                },
                new Author
                {
                    FirstName="Ali",
                    LastName="Rahimi",
                    BooksCount=1
                },
                new Author
                {
                    FirstName="Hassan",
                    LastName="Abbasi",
                    BooksCount=3
                }
            };
        }
    }
}
