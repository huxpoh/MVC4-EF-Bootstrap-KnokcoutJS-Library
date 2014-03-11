using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Contract.Contracts;
using Library.Model.Models;
using Library.WebPr.ViewModels;

namespace WebApp.Controllers
{
    //[Authorize]
    public class BookController : ApiController
    {
        private readonly IRepository<Book> _bookRepository;
        private readonly IRepository<BookShelf> _bookShelfRepository;

        public BookController(IRepository<Book> bookRepository, IRepository<BookShelf> bookShelfRepository)
        {
            _bookRepository = bookRepository;
            _bookShelfRepository = bookShelfRepository;
        }

        [HttpGet]
        public HttpResponseMessage GetAllBooks()
        {
            var items = _bookRepository.GetAll().Include(x=>x.BookShelf).ToList();
            items.Reverse();
            return Request.CreateResponse(HttpStatusCode.OK, Mapper.Map<IEnumerable<Book>, IEnumerable<BookViewModel>>(items));
        }

        [HttpPost]
        public HttpResponseMessage AddBook(BookViewModel viewModel)
        {
            var book = Mapper.Map<BookViewModel, Book>(viewModel);
            
            book.PublishDate = DateTime.UtcNow;
            book.BookShelf = _bookShelfRepository.GetById(viewModel.BookShelfId);
            _bookRepository.Insert(book);
            _bookRepository.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, Mapper.Map<Book, BookViewModel>(book));
        }

        [HttpPut]
        public HttpResponseMessage UpdateBook(BookViewModel viewModel)
        {
            var book = _bookRepository.GetById(viewModel.Id);
            Mapper.Map(viewModel,book);

            book.BookShelf = _bookShelfRepository.GetById(viewModel.BookShelfId);
            _bookRepository.Update(book);
            _bookShelfRepository.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK,"ok");
        }

        [HttpDelete]
        public HttpResponseMessage DeleteBook(string guid)
        {
            _bookRepository.Delete(guid);
            _bookRepository.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK,"ok");
        }
    }
}