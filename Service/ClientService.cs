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
    public class ClientService : IClientService
    {
        private readonly IClientRepository _repository;
        public ClientService(IClientRepository repository)
        {
            _repository = repository;
        }
        public Client Store(Client client)
        {
            if (_repository.IsCustomer(client.Email).GetAwaiter().GetResult())
            {
                throw new Exception("E-mail já cadastrado");
            }

            client.Id = Guid.NewGuid().ToString();

            return _repository.StoreAsync(client).GetAwaiter().GetResult();
        }

        public List<Client> GetAll()
        {
            return _repository.GetAllAsync().GetAwaiter().GetResult();
        }

        public Client GetById(string id)
        {
            var client = _repository.GetByIdSync(id).GetAwaiter().GetResult();
            if(client == null)
            {
                throw new Exception("Cliente não cadastrado");
            }
            return client;
        }

        public Client Update(string id, Client client)
        {
            return _repository.UpdateAsync(id, client).GetAwaiter().GetResult();
        }

        public string Delete(string id)
        {
            if (_repository.DeleteAsync(id).GetAwaiter().GetResult())
            {
                return "Cliente deletado com sucesso";
            }

            return "Houve um erro ao deletar o cliente";
        }
    }
}
