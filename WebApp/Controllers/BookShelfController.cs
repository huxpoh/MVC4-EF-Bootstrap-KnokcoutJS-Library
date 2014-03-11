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
    [Authorize(Roles = "librarian")]
    public class ShelfController : ApiController
    {
        private readonly IRepository<BookShelf> _shelfRepository;
        private readonly IRepository<Storage> _storRepository;

        public ShelfController(IRepository<BookShelf> shelfRepository, IRepository<Storage> storRepository)
        {
            _shelfRepository = shelfRepository;
            _storRepository = storRepository;
        }

        [HttpGet]
        public HttpResponseMessage GetAllShelfs()
        {
            var items = _shelfRepository.GetAll().Include(x => x.Storage).ToList();
            items.Reverse();

            return Request.CreateResponse(HttpStatusCode.OK, Mapper.Map<IEnumerable<BookShelf>, IEnumerable<BookShelfViewModel>>(items));
        }

        [HttpPost]
        public HttpResponseMessage AddShelf(BookShelfViewModel viewModel)
        {
            var bookShelf = Mapper.Map<BookShelfViewModel, BookShelf>(viewModel);

            bookShelf.Storage = _storRepository.GetById(viewModel.StorageId);
            _shelfRepository.Insert(bookShelf);
            _shelfRepository.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK,"ok");
        }

        [HttpPut]
        public HttpResponseMessage UpdateShelf(BookShelfViewModel viewModel)
        {
            var bookShelf = _shelfRepository.GetById(viewModel.Id);
            Mapper.Map(viewModel, bookShelf);
            bookShelf.Storage = _storRepository.GetById(viewModel.StorageId);
            _shelfRepository.Update(bookShelf);
            _shelfRepository.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK,"ok");
        }

        [HttpDelete]
        public HttpResponseMessage DeleteShelf(string guid)
        {
            var bookSlf = _shelfRepository.GetById(Guid.Parse(guid));
            bookSlf.Storage = null;
            _shelfRepository.SaveChanges();

            _shelfRepository.Delete(bookSlf);
            _shelfRepository.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK,"ok");
        }
    }
}
