using CQRS_MediatR.Domain.ValueObjects;
using MediatR;
using System;
using System.Threading.Tasks;

namespace CQRS_MediatR.Domain.Commands
{
    public class NovoEmail : IRequest
    {
        public Guid IdPessoa { get; }
        public Email Email { get; }
        public NovoEmail(Guid idPessoa, Email email)
        {
            this.IdPessoa = idPessoa;
            this.Email = email;
        }
    }

    public class NovoEmailHandler : IRequestHandler<NovoEmail>
    {
        private readonly IMediator _mediator;
        private readonly Repositories.Write.IPessoa _repositorioEscrita;
        private readonly Repositories.Read.IPessoa _repositorioLeitura;

        public NovoEmailHandler(IMediator mediator,
                                Repositories.Write.IPessoa repositorioEscrita,
                                Repositories.Read.IPessoa repositorioLeitura)
        {
            this._mediator = mediator;
            this._repositorioEscrita = repositorioEscrita;
            this._repositorioLeitura = repositorioLeitura;
        }

        public void Handle(NovoEmail message)
        {
            var pessoaExistente = this._repositorioLeitura.ObterPorId(message.IdPessoa);

            //Efetua Validações de duplicidade de email, etc...

            pessoaExistente.MudaEmail(message.Email);

            this._repositorioEscrita.Atualizar(pessoaExistente);

            this._mediator.Send(new Events.EmailAtualizadoComSucesso
            {
                NovoEmail = message.Email.ToString(),
                NomePessoa = pessoaExistente.Nome.ToString()
            });
        }
    }
}
