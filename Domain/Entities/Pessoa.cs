using Domain.Entities.Base;
using Domain.ValueObjects;
using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    public class Pessoa: EntityBase
    {
        public Pessoa()
        {
        }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string CPF { get; set; }

        public string Telefone { get; set; }

        public string Endereco { get; set; }

    }
}
