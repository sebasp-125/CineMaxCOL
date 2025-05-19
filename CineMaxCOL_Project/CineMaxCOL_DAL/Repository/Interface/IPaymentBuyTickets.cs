using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CineMaxCOL_Entity;

namespace CineMaxCOL_DAL.Repository.Interface
{
    public interface IPaymentBuyTickets<T> where T : class
    {
        //Here is everithing related about Buy or Shopping Tickes
        //All relacionated Payment/BuyTickets
        Task<bool> MakeSomethingRegisterUsServices(T t);

        //This is a specially fuction, It's about user information when heir is LogIn.
        //Just is for the user LogIn asociate information...
        Task<Tarjeta> BringInformationLogInUser(int iduser);
    }
}