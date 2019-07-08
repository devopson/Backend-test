using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Arguments.Base
{
    public class PessoaResponseBase
    {
        public PessoaResponseBase()
        { }

        public object result { get; set; }

        public IPessoaService pessoaService { get; set; }
    }
}
