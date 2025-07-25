using System;
using System.Threading.Tasks;
using Azure;
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
        public async Task<Tarjetum> BringInformationLogInUser(int iduser)
        {
            try
            {
                return await _context.Tarjeta
                    .Include(x => x.IdUsuarioNavigation)
                    .Where(t => t.IdUsuario == iduser)
                    .FirstOrDefaultAsync() ?? new Tarjetum();
            }
            catch
            {
                return new Tarjetum();
            }
        }

        public async Task<Reserva> MakingUpReservaUsServices(Reserva reserva)
        {
            try
            {
                var response = await _context.Reservas.AddAsync(reserva);
                await _context.SaveChangesAsync();
                return response.Entity;
            }
            catch
            {
                return new Reserva();
            }
        }

    //Registrar modelos cuando necesistes que retorne la informacion registrada
        public async Task<T> BringInformationLaterRegisterOurServices(T t)
        {
            try
            {
                await _dbset.AddAsync(t);
                await _context.SaveChangesAsync();
                return t;
            }
            catch
            {
                return null;
            }
        }
    }
}
