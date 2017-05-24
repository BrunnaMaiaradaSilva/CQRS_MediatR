using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS_MediatR.Domain.ValueObjects
{
    public class NomeCompleto
    {
        public string Nome { get; }
        public string Sobrenome { get; }

        public NomeCompleto(string nome, string sobrenome)
        {
            this.Nome = nome;
            this.Sobrenome = sobrenome;
        }

        public override string ToString() 
            => $"{this.Nome} {this.Sobrenome}".TrimEnd();
    }
}
