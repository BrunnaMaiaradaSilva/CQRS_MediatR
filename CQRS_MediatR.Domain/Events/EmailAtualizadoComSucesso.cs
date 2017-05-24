using MediatR;
using System;

namespace CQRS_MediatR.Domain.Events
{
    public class EmailAtualizadoComSucesso : IRequest
    {
        public string NomePessoa { get; set; }
        public string NovoEmail { get; set; }
        public DateTime DataHora { get; set; } = DateTime.Now;
    }
}
