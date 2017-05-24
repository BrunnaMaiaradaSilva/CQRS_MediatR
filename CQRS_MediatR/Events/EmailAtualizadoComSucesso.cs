using MediatR;

namespace CQRS_MediatR.Events
{
    public class EmailAtualizadoComSucesso : IRequestHandler<Domain.Events.EmailAtualizadoComSucesso>
    {
        public void Handle(Domain.Events.EmailAtualizadoComSucesso message)
        {
            //Dispara e-mail alertando a modificação
        }
    }
}
