using CineMaxCOL_Entity;

namespace CineMaxCOL_DAL.Repository.Interface
{
    public interface IPaymentBuyTickets<T> where T : class
    {
        //Here is everithing related about Buy or Shopping Tickes
        //All relacionated Payment/BuyTickets
        Task<bool> MakeSomethingRegisterUsServices(T t);

        //This method is for unic and speaclly action, it's need a imporntatn information. 
        Task<Reserva> MakingUpReservaUsServices(Reserva reserva);

        //This is a specially fuction, It's about user information when heir is LogIn.
        //Just is for the user LogIn asociate information...
        Task<Tarjetum> BringInformationLogInUser(int iduser);

        Task<T> BringInformationLaterRegisterOurServices(T t);

    }
}