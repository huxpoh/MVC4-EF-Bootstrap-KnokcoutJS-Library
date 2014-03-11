using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Contract.Contracts;
using Library.Model.Models;
using Library.Web.ViewModels;

namespace WebApp.Controllers
{
    //[Authorize(Roles = "librarian")]
    public class StorageController : ApiController
    {
        private readonly IRepository<Storage> _repository;

        public StorageController(IRepository<Storage> repository)
        {
            _repository = repository;
        }

        public HttpResponseMessage GetAllStorages()
        {
            var storages = _repository.GetAll();
            var storagesViewModel = Mapper.Map<IEnumerable<Storage>, IEnumerable<StorageViewModel>>(storages);

            return Request.CreateResponse(HttpStatusCode.OK, storagesViewModel);
        }

        [HttpDelete]
        public HttpResponseMessage DeleteStorage(string guid)
        {
            _repository.Delete(guid);
            _repository.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, guid);
        }

        [HttpPost]
        public HttpResponseMessage AddStorage(StorageViewModel viewModel)
        {
            var sotrage = Mapper.Map<StorageViewModel, Storage>(viewModel);

            _repository.Insert(sotrage);
            _repository.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, Mapper.Map<Storage, StorageViewModel>(sotrage));
        }

        [HttpPut]
        public HttpResponseMessage UpdateStorage(StorageViewModel viewModel)
        {
            var storage = Mapper.Map<StorageViewModel, Storage>(viewModel);

            _repository.Update(storage);
            _repository.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, Mapper.Map<Storage, StorageViewModel>(storage));
        }
    }
}
