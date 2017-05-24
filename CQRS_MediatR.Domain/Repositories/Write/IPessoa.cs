using CQRS_MediatR.Domain.ValueObjects;
using System;

namespace CQRS_MediatR.Domain.Repositories.Write
{
    public interface IPessoa
    {
        Pessoa Inserir(Pessoa pessoa);
        Pessoa Atualizar(Pessoa pessoa);
    }
}