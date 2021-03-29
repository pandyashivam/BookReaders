using BookReaders.Data;
using BookReaders.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReaders.Repository
{
    public class BookRepository
    {
        private readonly BookStoreContext _context = null;

        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }
        public async Task<int> AddNewBook(BookModel model)
        {
            var newBook = new Books() {
                Title = model.Title,
                Author = model.Author,
                Language = model.Language,
                Category = model.Category,
                Pages = model.Pages,
                Price = model.Price,
                Description = model.Description,
                ImageUrl = model.ImageUrl

            };

            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();

            return newBook.Id;

        }

        public async Task<List<BookModel>> GetAllBooks()
        {
            var books = new List<BookModel>();
            var allbooks = await _context.Books.ToListAsync();
            if (allbooks?.Any() == true)
            {
                foreach (var book in allbooks)
                {
                    books.Add(new BookModel()
                    {
                        Id = book.Id,
                        Title = book.Title,
                        Author = book.Author,
                        Language = book.Language,
                        Category = book.Category,
                        Pages = book.Pages,
                        Price = book.Price,
                        Description = book.Description,
                        ImageUrl = book.ImageUrl

                    });
                }
            }
            return books;

        }

        public async Task<BookModel> GetBookById(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                var bookDetails = new BookModel()
                {  
                    Id = book.Id,
                    Title = book.Title,
                    Author = book.Author,
                    Language = book.Language,
                    Category = book.Category,
                    Pages = book.Pages,
                    Price = book.Price,
                    Description = book.Description,
                    ImageUrl = book.ImageUrl
                };

                return bookDetails;
            }
            return null;
        }

        public async Task<BookModel> GetBookBuyById(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                var bookDetails = new BookModel()
                {
                    Id = book.Id,
                    Title = book.Title,
                    Author = book.Author,
                    Language = book.Language,
                    Category = book.Category,
                    Pages = book.Pages,
                    Price = book.Price,
                    Description = book.Description,
                    ImageUrl = book.ImageUrl
                };

                return bookDetails;
            }
            return null;
        }
    }
}
