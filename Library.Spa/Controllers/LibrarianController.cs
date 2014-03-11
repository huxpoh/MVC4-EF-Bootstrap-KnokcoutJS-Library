using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Contract.Contracts;
using Library.EF_DataLayer;
using Library.EF_DataLayer.Repositories;
using Library.Model.Models;
using Library.Spa.ViewModels;

namespace Library.Spa.Controllers
{
    public class LibrarianController : ApiController
    {
        private readonly IRepository<Book> _repository;

        public LibrarianController()
        {
            _repository = new EfRepository<Book>(new LibraryContext());
        }

        [HttpGet]
        public HttpResponseMessage GetAllBooks()
        {
            var items = _repository.GetAll();

            var viewModels = Mapper.Map<IEnumerable<Book>, IEnumerable<BookViewModel>>(items);

            return Request.CreateResponse(HttpStatusCode.OK, viewModels);
        }

        [HttpPost]
        public HttpResponseMessage Create(BookViewModel viewModel)
        {
            var item = Mapper.Map<BookViewModel, Book>(viewModel);

            try
            {
                _repository.Insert(item);
                _repository.SaveChanges();
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.ExpectationFailed);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPut]
        public HttpResponseMessage Update(BookViewModel bookViewModel)
        {
            var item = Mapper.Map<BookViewModel, Book>(bookViewModel);

            try
            {
                _repository.Update(item);
                _repository.SaveChanges();
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.ExpectationFailed);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }


        [HttpDelete]
        public HttpResponseMessage Delete(string bookid)
        {
            try
            {
                _repository.Delete(bookid);
                _repository.SaveChanges();
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.ExpectationFailed);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}