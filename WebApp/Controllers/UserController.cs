using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using AutoMapper;
using Contract.Contracts;
using Library.Model.Models;
using Library.WebPr.ViewModels;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    [Authorize(Roles = "reader")]
    public class UserController : BaseApiController
    {
        private readonly IRepository<Book> _bookRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<BookShelf> _bookShelfrepository; 

        public UserController(IRepository<Book> bookRepository, IRepository<User> userRepository, IRepository<BookShelf> bookShelfrepository)
        {
            _bookRepository = bookRepository;
            _userRepository = userRepository;
            _bookShelfrepository = bookShelfrepository;
        }

        [HttpGet]
        public HttpResponseMessage GetAllMyBooks(bool isMyBook = true)
        {
            var items = _bookRepository.GetAll()
                .Include(x => x.BookShelf)
                .Include(x => x.Reader);

            var resultList = isMyBook ? items.Where(x => x.Reader.Username == HttpContext.Current.User.Identity.Name).ToList() 
                : items.Where(x => x.Reader== null).ToList();
            
            return Request.CreateResponse(HttpStatusCode.OK, Mapper.Map<IEnumerable<Book>, IEnumerable<BookViewModel>>(resultList));
        }

        [HttpPut]
        public HttpResponseMessage TakeBook(string id)
        {
            var guid = Guid.Parse(id);
            var book = _bookRepository.GetAll().Include(x=>x.BookShelf).FirstOrDefault(x=>x.Id == guid);
           
            book.BookShelf = null;
            var user = _userRepository.GetAll().FirstOrDefault(x => x.Username == HttpContext.Current.User.Identity.Name);
            book.Reader = user;

            
            SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, "ok");
        }

        [HttpPost]
        public HttpResponseMessage ReturnBook(string id)
        {
            var guid = Guid.Parse(id);
            var book = _bookRepository.GetAll().Include(x => x.Reader).FirstOrDefault(x => x.Id == guid);

            book.Reader = null;
            book.BookShelf = _bookShelfrepository.GetAll().FirstOrDefault();

            SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, "ok");
        }

    }
}
