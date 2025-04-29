using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CineMaxCOL_BILL.Helpers;
using CineMaxCOL_DAL.Repository.Interface;
using CineMaxCOL_Entity;
using Microsoft.EntityFrameworkCore;

namespace CineMaxCOL_BILL.Service
{
    public class AuthService
    {
        private readonly IRepository<Usuario> _Repository;
        private readonly CineMaxColContext _context;
        public AuthService(IRepository<Usuario> Repository, CineMaxColContext context)
        {
            _Repository = Repository;
            _context = context;
        }
        public async Task<(bool isValid, List<Claim> claims)> ValidateUser(string email, string password)
        {
            var passwordHasheada = PasswordHasher.HashPassword(password);

            var user = await _context.Usuarios
                .Include(u => u.IdRolNavigation)
                .FirstOrDefaultAsync(u => u.Email == email && u.Password == passwordHasheada);

            if (user != null)
            {
                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.FullName),
            new Claim(ClaimTypes.Email, user.Email ?? ""),
            new Claim(ClaimTypes.Role, user.IdRolNavigation.TipoRol ?? "Cliente")
        };
                return (true, claims);
            }

            return (false, new List<Claim>());
        }


        public async Task<bool> RegisterUser(Usuario usuario)
        {
            try
            {
                if (string.IsNullOrEmpty(usuario.Password))
                    return false;

                var passwordHasheada = PasswordHasher.HashPassword(usuario.Password);
                Console.WriteLine(passwordHasheada);

                var newUser = new Usuario
                {
                    IdMunicipio = usuario.IdMunicipio,
                    FullName = usuario.FullName,
                    Dni = usuario.Dni,
                    Email = usuario.Email,
                    Password = passwordHasheada,
                };

                return await _Repository.Add(newUser);
            }
            catch
            {
                return false;
            }
        }


    }
}