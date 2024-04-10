using Domain.Contexts;
using Domain.Interfaces.Repositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace Data
{
    public class ClientRepository : IClientRepository
    {
        public async Task<Client> StoreAsync(Client client)
        {
            try
            {
                if(client == null) { 
                    throw new ArgumentNullException("Argumentos inválidos");
                }

                using var context = new AppDbContext();
                await context.Clients.AddAsync(client);
                await context.SaveChangesAsync();

                return client;
            }catch (Exception ex) {
                throw new Exception("ERRO:" + ex.Message);
            }
        }

        public async Task<List<Client>> GetAllAsync()
        {
            try
            {
                using var context = new AppDbContext();
                var clients = await context.Clients.ToListAsync();
                return clients;
            }
            catch (Exception ex)
            {
                throw new Exception("ERRO:" + ex.Message);
            }
        }

        public async Task<bool> IsCustomer(string email)
        {
            try
            {
                using var context = new AppDbContext();
                var client = await context.Clients.FirstOrDefaultAsync(x => x.Email == email);
                if(client == null)
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("ERRO:" + ex.Message);
            }
        }

        public async Task<Client> GetByIdSync(string id)
        {
            try
            {
                using var context = new AppDbContext();
                var client = await context.Clients.FirstOrDefaultAsync(x => x.Id == id);

                return client;
            }
            catch (Exception ex)
            {
                throw new Exception("ERRO:" + ex.Message);
            }
        }

        public async Task<Client> UpdateAsync(string id, Client client)
        {
            try
            {
                using var context = new AppDbContext();
                if (client == null)
                {
                    throw new ArgumentNullException(nameof(client));
                }

                var clientUpdate = await GetByIdSync(id);

                clientUpdate.Name = client.Name;

                context.Clients.Update(clientUpdate);

                await context.SaveChangesAsync();

                return clientUpdate;

            }
            catch (Exception ex)
            {
                throw new Exception("ERRO:" + ex.Message);
            }
        }

        public async Task<bool> DeleteAsync(string id)
        {
            try
            {
                using var context = new AppDbContext();

                var client = await GetByIdSync(id);

                context.Remove(client);

                await context.SaveChangesAsync();

                return true;

            }
            catch (Exception ex)
            {
                throw new Exception("ERRO:" + ex.Message);
            }
        }
    }
}
