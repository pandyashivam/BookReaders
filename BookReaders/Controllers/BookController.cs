using BookReaders.Models;
using BookReaders.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReaders.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository = null;
        public BookController(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<ViewResult> GetAllBooks(string Searching)
        {
            string SearchResult = Searching;
            var data = await _bookRepository.GetAllBooks();
            if (string.IsNullOrEmpty(SearchResult))
            {
                return View(data);
            }
            return View( data.Where(x => x.Title.ToLower().Contains(SearchResult) || x.Author.ToLower().Contains(SearchResult) || x.Category.ToLower().Contains(SearchResult)).ToList());  
        }

        public async Task<ViewResult> GetBook(int id)
        {
            var data = await _bookRepository.GetBookById(id);
            return View(data);
        }

        public async Task<ViewResult> BuyBook(int id)
        {
            var data = await _bookRepository.GetBookBuyById(id);
            return View(data);
        }

        [Authorize(Roles ="Admin")]
        public ViewResult AddNewBook(bool isSuccess = false)
        {
            ViewBag.IsSuccess = isSuccess;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddNewBook(BookModel bookModel)
        {
           int id =await _bookRepository.AddNewBook(bookModel);
            if (id > 0)
            {
                return RedirectToAction(nameof(AddNewBook), new { isSuccess = true });
            }
            return View();
        }
    }
}
