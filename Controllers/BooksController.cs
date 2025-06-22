using Microsoft.AspNetCore.Mvc;
using BookLibraryExam.Models;
using System.Collections.Generic;
using System.Linq;

namespace BookLibraryExam.Controllers
{
    public class BooksController : Controller
    {
        private static List<Book> books = new();
        public IActionResult Index()
        {
            return View(books);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                book.Id = books.Count > 0 ? books.Max(b => b.Id) + 1 : 1;
                books.Add(book);
                return RedirectToAction("Index");
            }
            return View(book);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }
        [HttpPost]
        public IActionResult Edit(Book updatedBook)
        {
            if (ModelState.IsValid)
            {
                var book = books.FirstOrDefault(b => b.Id == updatedBook.Id);
                if (book == null)
                {
                    return NotFound();
                }
                book.Title = updatedBook.Title;
                book.Author = updatedBook.Author;
                book.ISBN = updatedBook.ISBN;
                book.PublicationYear = updatedBook.PublicationYear;
                return RedirectToAction("Index");
            }
            return View(updatedBook);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            books.Remove(book);
            return RedirectToAction("Index");
        }
    }
}