using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IClientService
    {
        public Client Store(Client client);
        public List<Client> GetAll();
        public Client GetById(string id);
        public Client Update(string id, Client client);
        public string Delete(string id);
    }
}
