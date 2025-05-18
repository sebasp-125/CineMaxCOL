using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using CineMaxCOL_DAL.Repository.Interface;
using CineMaxCOL_Entity;
using Microsoft.EntityFrameworkCore;

namespace CineMaxCOL_DAL.Repository.Implimentation
{
    public class SendEmail : ISendEmail
    {
        private readonly CineMaxColContext _context;
        private string schemaSendEmail;

        public SendEmail(CineMaxColContext context)
        {
            _context = context;
        }

        public async Task<bool> ExtractInformationAboutEmail()
        {
            try
            {
                var ExtracInformatio = await _context.ConfiguracionEmails
                            .Where(c => c.Recurso == "Servicio_Correo")
                            .ToListAsync();

                var configDic = ExtracInformatio.ToDictionary(x => x.Propiedad.ToLower(), x => x.Valor);

                var correoRemitent = configDic["correo"];
                var clave = configDic["clave"];
                var alias = configDic["alias"];
                var host = configDic["host"];
                var puerto = int.Parse(configDic["puerto"]);

                var credenciales = new NetworkCredential(correoRemitent, clave);
                using (var correo = new MailMessage())
                using (var clienteServidor = new SmtpClient(host, puerto))
                {
                    correo.From = new MailAddress(correoRemitent, alias);
                    correo.Subject = "Confirmación de reserva de boletos";
                    correo.Body = "hOLA Q";
                    correo.IsBodyHtml = true;
                    correo.To.Add(new MailAddress("sp6027193@gmail.com"));

                    // //Most of the changes are in this section, such as Body and Subject. This has a dynamic operation because this project will be used by more people.

                    clienteServidor.Credentials = credenciales;
                    clienteServidor.DeliveryMethod = SmtpDeliveryMethod.Network;
                    clienteServidor.UseDefaultCredentials = false;
                    clienteServidor.EnableSsl = true;

                    await clienteServidor.SendMailAsync(correo);
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error Repository : " + e.Message);
                Console.WriteLine("Error Repository : " + e);
                return false;
            }
        }
    }
}