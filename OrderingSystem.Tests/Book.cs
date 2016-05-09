using System.Collections.Generic;
using OrderingSystem.Domain;

namespace OrderingSystem.Tests
{
    public class Book : Entity<Book>
    {
        public string Title { get; set; }
        public string Publisher { get; set; }
        public int YearOfPublication { get; set; }
        public IEnumerable<Author> Authors { get; set; }
    }

    public class Author : Entity<Author>
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public IEnumerable<Book> Books { get; set; }
    }
}