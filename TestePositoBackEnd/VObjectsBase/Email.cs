using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.VObjectsBase
{
    public class Email : Notifiable
    {
        public Email(string email)
        {
            Endereco = email;

            new AddNotifications<Email>(this)
                .IfNotEmail(x => x.Endereco, "Email invalido");
        }

        public string Endereco { get; set; }
    }
}
