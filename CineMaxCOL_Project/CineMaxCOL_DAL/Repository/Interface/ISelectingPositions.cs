using CineMaxCOL_Entity;

namespace CineMaxCOL_DAL.Repository.Interface
{
    public interface ISelectingPositions<T> where T : class
    {
        Task<Funcion> SelectedFuncionAndMoreThings(string salaId , string idFuncion , string identificador);
    }
}