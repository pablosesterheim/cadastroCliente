using Domain.Contexts;
using Domain.Interfaces.Repositories;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class PublicPlaceRepository : IPublicPlaceRepository
    {
        public async Task<PublicPlace> StoreAsync(PublicPlace publicPlace)
        {
            try
            {
                if (publicPlace == null)
                {
                    throw new ArgumentNullException("Argumentos inválidos");
                }

                using var context = new AppDbContext();
                await context.PublicPlace.AddAsync(publicPlace);
                await context.SaveChangesAsync();

                return publicPlace;
            }
            catch (Exception ex)
            {
                throw new Exception("ERRO:" + ex.Message);
            }
        }
    }
}
