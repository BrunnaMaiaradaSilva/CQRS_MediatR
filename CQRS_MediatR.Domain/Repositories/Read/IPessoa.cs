using System;
using System.Collections.Generic;

namespace CQRS_MediatR.Domain.Repositories.Read
{
    public interface IPessoa
    {
        IReadOnlyCollection<Pessoa> Listar();
        Pessoa ObterPorId(Guid id);
    }
}
