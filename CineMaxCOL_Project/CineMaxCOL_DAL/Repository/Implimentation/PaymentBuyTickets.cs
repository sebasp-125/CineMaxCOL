using System;
using System.Threading.Tasks;
using CineMaxCOL_DAL.Repository.Interface;
using CineMaxCOL_Entity;
using Microsoft.EntityFrameworkCore;

namespace CineMaxCOL_DAL.Repository.Implimentation
{
    public class PaymentBuyTickets<T> : IPaymentBuyTickets<T> where T : class
    {
        private readonly DbSet<T> _dbset;
        private readonly CineMaxColContext _context;

        public PaymentBuyTickets(CineMaxColContext context)
        {
            _context = context;
            _dbset = _context.Set<T>();
        }

        public async Task<bool> MakeSomethingRegisterUsServices(T t)
        {
            try
            {
                await _dbset.AddAsync(t);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }


        //This is a specially fuction, It's about user information when heir is LogIn.
        //Just is for the user LogIn asociate information...
        public async Task<Tarjeta> BringInformationLogInUser(int iduser)
        {
            try
            {
                return await _context.Tarjetas
                    .Include(x => x.IdUsuarioNavigation)
                    .Where(t => t.IdUsuario == iduser)
                    .FirstOrDefaultAsync() ?? new Tarjeta();
            }
            catch
            {
                return new Tarjeta();
            }
        }

    }
}
