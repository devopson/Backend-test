using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ValueObjects
{
    public class Email: Notifiable
    {

        public Email(string email)
        {
            EnderecoEmail = email;

            new AddNotifications<Email>(this)
                .IfNotEmail(x => x.EnderecoEmail, "Email invalido");
        }

        public string EnderecoEmail { get; set; }
    }
}
