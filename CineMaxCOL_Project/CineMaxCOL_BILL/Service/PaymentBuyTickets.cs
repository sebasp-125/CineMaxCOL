using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CineMaxCOL_DAL.UnitOfWork.Interface;
using CineMaxCOL_Entity;

namespace CineMaxCOL_BILL.Service
{
    public class PaymentBuyTickets
    {
        private readonly IUnitOfWork _Unit;
        public PaymentBuyTickets(IUnitOfWork Unit)
        {
            _Unit = Unit;
        }
        public async Task<bool> RegisterCardUsServices(Tarjeta tarjeta)
        {
            var respose = await _Unit._UnitPaymentBuyTicktes<Tarjeta>().MakeSomethingRegisterUsServices(tarjeta);
            if (!respose)
            {
                return false;
            }
            return true;
        }

        public async Task<Tarjeta> BringInformationLogInUserServices(int iduser)
        {
            var service = _Unit._UnitPaymentBuyTicktes<Tarjeta>();

            if (service == null)
            {
                return new Tarjeta();
            }
            var response = await service.BringInformationLogInUser(iduser);
            if (response == null)
            {
                return new Tarjeta();
            }
            return response;
        }


        //This is a rule or Services, which will for a save PAyMethod but will aplicate in other moment. 18/05/2025
        public async Task<bool> SavePayMethod(TipoPago tipoPago)
        {
            var respose = await _Unit._UnitPaymentBuyTicktes<TipoPago>().MakeSomethingRegisterUsServices(tipoPago);
            if (!respose)
            {
                return false;
            }
            return true;
        }

    }
}