using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Malcaba.XunitSamples.Assertions
{
    public class CollectionAssert
    {
        [Fact]
        public void GetBookTest1()
        {
            var repo = new BookRepository();
            var result = repo.GetBookByAuthor("Lee Child");

            Assert.Single(result);
        }

        [Fact]
        public void GetBookTest2()
        {
            var repo = new BookRepository();
            var result = repo.GetBookByAuthor("John Grisham");

            Assert.Empty(result);
        }
    }

    public class BookRepository
    {
        public List<Book> GetBookByAuthor(string author)
        {
            return Books
                .Where(x => x.Author == author)
                .ToList();
        }

        public List<Book> Books => new List<Book>
        {
            new Book
            {
                Id = 1,
                Author = "Stephen King",
                Title = "Mr. Mercedes"
            },
            new Book
            {
                Id = 2,
                Author = "Stephen King",
                Title = "Cujo"
            },
            new Book
            {
                Id = 3,
                Author = "Lee Child",
                Title = "Make Me"
            }
        };

    }

    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
    }
}
