using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IClientRepository
    {
        public Task<Client> StoreAsync(Client client);
        public Task<List<Client>> GetAllAsync();
        public Task<bool> IsCustomer(string email);
        public Task<Client> GetByIdSync(string id);
        public Task<Client> UpdateAsync(string id, Client client);
        public Task<bool> DeleteAsync(string id);
    }
}
