using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ValueObjects
{
    public class Nome: Notifiable
    {
        protected Nome()
        {

        }
        public Nome(string nomeCompleto)
        {
            NomeCompleto = nomeCompleto;
            //SegundoNome = segundoNome;

            new AddNotifications<Nome>(this)
                .IfNullOrInvalidLength(x => x.NomeCompleto, 2, 100, "Nome deve conter de 2 a 200 caracteres");
                //.IfNullOrInvalidLength(x => x.SegundoNome, 2, 100, "Nome deve conter de 2 a 200 caracteres");
        }

        public string NomeCompleto { get; private set; }
    }
}
