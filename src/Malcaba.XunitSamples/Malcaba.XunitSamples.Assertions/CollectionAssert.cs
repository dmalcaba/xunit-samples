using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Malcaba.XunitSamples.Assertions
{
    public class CollectionAssert
    {
        private readonly ITestOutputHelper _output;

        public CollectionAssert(ITestOutputHelper output)
        {
            _output = output;
        }

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

        [Fact]
        public void GetBookTest3()
        {
            var repo = new BookRepository();
            var result = repo.GetBookByAuthor("Stephen King");

            Assert.NotEmpty(result);

            _output.WriteLine("Test that the Titles are in the expected order.");
            
            Assert.Collection(result.Select(x => x.Title),
                    item => Assert.Equal("Cujo", item),
                    item => Assert.Equal("Mr. Mercedes", item)
                );

            // normally you would only have one assert per test 
            // for demo purpose only
            _output.WriteLine("Test that the Author name contains 'King'.");

            Assert.All(result,
                    item => item.Author.Contains("King")
                );
        }

        [Fact]
        public void GetBookTest4()
        {
            var repo = new BookRepository();

            var result = repo.GetBookByAuthor("Stephen King");
            var expectedBooks = repo.GetBookByAuthor("Stephen King");

            // Although the results are actually the same
            // It will not be equal using the default comparer

            Assert.NotEqual(expectedBooks, result);

            // See AssertWith extension method below;
            result.AssertWith(expectedBooks, (e, a) =>
            {
                Assert.Equal(e.Id, a.Id);
                Assert.Equal(e.Author, e.Author);
                Assert.Equal(e.Title, e.Title);
            });
        }

        [Fact]
        public void CompareTwoCollections()
        {
            string[] collection1 = { "one", "two", "three" };
            var collection2 = new List<string> { "one", "two", "three" };

            Assert.Equal(collection1, collection2.ToArray());
        }

        [Fact]
        public void CompareTwoCollections2()
        {
            var collection1 = new Dictionary<int, string>
            {
                { 1, "one" },
                { 2, "two" },
                { 3, "three" }
            };

            var collection2 = new Dictionary<int, string>
            {
                { 1, "one" },
                { 2, "two" },
                { 3, "three" }
            };

            Assert.Equal(collection1, collection2);

            var collection3 = new Dictionary<int, string>
            {
                { 1, "one" },
                { 2, "two" },
                { 4, "four" }
            };

            Assert.NotEqual(collection1, collection3);

        }

    }

    public static class TestExtensions
    {
        public static void AssertWith<TExpected, TActual>(this IEnumerable<TActual> actual, IEnumerable<TExpected> expected, Action<TExpected, TActual> inspector)
        {
            Assert.Collection(actual, expected.Select(e => (Action<TActual>)(a => inspector(e, a))).ToArray());
        }
    }

    public class BookRepository
    {
        public List<Book> GetBookByAuthor(string author)
        {
            return Books
                .Where(x => x.Author == author)
                .OrderBy(x => x.Title)
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
