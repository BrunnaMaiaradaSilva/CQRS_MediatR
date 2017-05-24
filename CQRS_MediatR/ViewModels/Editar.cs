using System.Collections.Generic;

namespace CQRS_MediatR.ViewModels
{
    public class Editar
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public List<string> Enderecos { get; set; }
        public string NovoEmail { get; set; }
    }
}
