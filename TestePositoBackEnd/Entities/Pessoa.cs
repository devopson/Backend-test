using Domain.Entities.Base;
using Domain.VObjectsBase;

namespace Domain.Entities
{
    public class Pessoa : BaseEntity
    {
        public Pessoa()
        {
        }

        //public Pessoa(Nome nome)
        //{
        //    Nome = nome;
        //    //Email = email;

        //    AddNotifications(nome);
        //}

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Cpf { get; set; }

        public string Telefone { get; set; }

        public string Endereco { get; set; }
    }
}
