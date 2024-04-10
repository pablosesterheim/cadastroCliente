using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public  class PublicPlaceService : IPublicPlaceService
    {
        private readonly IPublicPlaceRepository _repository;

        PublicPlaceService(IPublicPlaceRepository repository)
        {
            _repository = repository;
        }   

        public PublicPlace Store(PublicPlace publicPlace)
        {
            return _repository.StoreAsync(publicPlace).GetAwaiter().GetResult();
        }
    }
}
