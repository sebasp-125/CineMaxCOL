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
        public async Task<bool> RegisterCardUsServices(Tarjetum tarjeta)
        {
            var respose = await _Unit._UnitPaymentBuyTicktes<Tarjetum>().MakeSomethingRegisterUsServices(tarjeta);
            if (!respose)
            {
                return false;
            }
            return true;
        }

        public async Task<Reserva> RegisterReservaServices(Reserva reserva)
        {
            var respose = await _Unit._UnitPaymentBuyTicktes<Reserva>().MakingUpReservaUsServices(reserva);
            if (respose == null)
            {
                return null;
            }
            return respose;
        }

        public async Task<bool> RegisterPagoServices(Pago pago)
        {
            var respose = await _Unit._UnitPaymentBuyTicktes<Pago>().MakeSomethingRegisterUsServices(pago);
            if (!respose)
            {
                return false;
            }
            return true;
        }

        public async Task<Tarjetum> BringInformationLogInUserServices_Card(int? iduser)
        {
            var service = _Unit._UnitPaymentBuyTicktes<Tarjetum>();

            if (service == null)
            {
                return new Tarjetum();
            }
            var response = await service.BringInformationLogInUser(iduser.Value);
            if (response == null)
            {
                return new Tarjetum();
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