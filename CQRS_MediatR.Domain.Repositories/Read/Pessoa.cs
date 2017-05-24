using System;
using System.Collections.Generic;
using System.Linq;

namespace CQRS_MediatR.Domain.Repositories.Read
{
    public class Pessoa : IPessoa
    {
        public IReadOnlyCollection<Domain.Pessoa> Listar()
            => Cache.Repositorio.Listar();

        public Domain.Pessoa ObterPorId(Guid id)
        {
            var todos = Cache.Repositorio.Listar();
            return todos.FirstOrDefault(p => p.Id.Equals(id));
        }
    }
}