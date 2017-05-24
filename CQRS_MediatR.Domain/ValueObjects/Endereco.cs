using System;

namespace CQRS_MediatR.Domain.ValueObjects
{
    public class Endereco
    {
        public Guid Id { get; private set; }
        public TipoEndereco Tipo { get; set; }
        public string TipoLogradouro { get; set; }
        public string Logradourdo { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }

        public Endereco(Guid id, TipoEndereco tipo, string tipoLogradouro, string logradouro, string numero, string complemento = "")
        {
            this.Id = id;
            this.Tipo = tipo;
            this.TipoLogradouro = tipoLogradouro;
            this.TipoLogradouro = logradouro;
            this.Numero = numero;
            this.Complemento = complemento;
        }

        public Endereco(TipoEndereco tipo, string tipoLogradouro, string logradouro, string numero, string complemento = "")
            : this(Guid.NewGuid(), tipo, tipoLogradouro, logradouro, numero, complemento)
        {


        }

        public override string ToString()
            => $"{this.Tipo}: {this.TipoLogradouro} {this.Logradourdo} número {this.Numero}";

        public enum TipoEndereco
        {
            Residencial,
            Comercial
        }
    }
}
