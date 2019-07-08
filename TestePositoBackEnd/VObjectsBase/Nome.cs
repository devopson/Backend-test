using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.VObjectsBase
{
    public class Nome : Notifiable
    {
        public Nome(string primeiroNome)
        {
            PrimeiroNome = primeiroNome;
            //SegundoNome = segundoNome;

            new AddNotifications<Nome>(this)
                //.IfNullOrInvalidLength(x => x.PrimeiroNome, 2, 100, "Primeiro nome deve conter entre 2 e 100 caracteres")
                .IfNullOrInvalidLength(x => x.PrimeiroNome, 2, 100, "Segundo nome deve conter entre 2 e 100 caracteres");
        }

        public string PrimeiroNome { get; set; }

        //public string SegundoNome { get; set; }
    }
}
