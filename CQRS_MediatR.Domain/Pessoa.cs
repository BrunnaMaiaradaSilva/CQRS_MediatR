using CQRS_MediatR.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace CQRS_MediatR.Domain
{
    public class Pessoa
    {
        public Guid Id { get; private set; }
        public NomeCompleto Nome { get; private set; }
        public CPF CPF { get; private set; }
        public Email Email { get; private set; }

        private List<Endereco> _enderecos;
        public IReadOnlyCollection<Endereco> Enderecos => _enderecos;

        public Pessoa(Guid id, NomeCompleto nome, CPF cpf, Email email)
        {
            this.Id = id;
            this.Nome = nome;
            this.CPF = cpf;
            this.Email = email;

            this._enderecos = new List<Endereco>();
        }

        public Pessoa(NomeCompleto nome, CPF cpf, Email email) : this(Guid.NewGuid(), nome, cpf, email)
        {
        }

        public void MudaEmail(Email novoEmail)
        {
            this.Email = novoEmail;
        }

        public void AdicionarEnderecos(IReadOnlyCollection<Endereco> enderecos)
            => this._enderecos.AddRange(enderecos);

        public void AdicionarEndereco(Endereco endereco)
            => this._enderecos.Add(endereco);

        
    }
}
