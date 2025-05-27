using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CineMaxColDal.DBContext;
using CineMaxColDal.Interfaces;

namespace CineMaxColDal.Implementación
{
    public class UnitOfWork(CineMaxColContext dbcontext) : IUnitOfWork
    {
        private readonly CineMaxColContext _dbcontext = dbcontext;
        private readonly IPeliculas? _peliculasRepository; 
        private readonly IMunicipios? _municipioRepository;
        private readonly ICineComidas? _cineComidasRepository;
        private readonly ICategorias? _categoriaRepository;
        private readonly IComidas? _comidasRepository;
        private readonly ICloudinaryR? _cloudinaryRepository;
        private readonly IPromociones? _promocionesRepository;

        public IPeliculas Peliculas => _peliculasRepository ?? new Peliculas(_dbcontext);
        public ICineComidas CineComidas => _cineComidasRepository ?? new CineComidas(_dbcontext);
        public IMunicipios Municipios => _municipioRepository ?? new Municipios(_dbcontext);
        public IComidas Comidas => _comidasRepository ?? new Comidas(_dbcontext);

        public ICategorias CategoriasComida => _categoriaRepository ?? new CategoriasComida(_dbcontext);

        public ICloudinaryR CloudinaryR => _cloudinaryRepository ?? new CloudinaryR(_dbcontext);
        public IPromociones Promociones => _promocionesRepository ?? new Promociones(_dbcontext);

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            _dbcontext.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
           await _dbcontext.SaveChangesAsync();
        }
    }
}