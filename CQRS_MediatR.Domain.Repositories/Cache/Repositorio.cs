using CQRS_MediatR.Domain.ValueObjects;
using System.Collections.Generic;
using System.Linq;

namespace CQRS_MediatR.Domain.Repositories.Cache
{
    internal static class Repositorio
    {
        private static List<Pessoa> CACHE;

        public static List<Pessoa> Listar()
        {
            if (CACHE != null) return CACHE;

            CACHE = new List<Pessoa>();

            var joao = new Pessoa(new NomeCompleto("João", "da Silva"), 
                                  new CPF("123456789"),
                                  new Email("joao@email.com"));
            var enderecosJoao = new List<Endereco>();
            enderecosJoao.Add(new Endereco(Endereco.TipoEndereco.Residencial, "Rua", "das Alamedas", "123"));
            joao.AdicionarEnderecos(enderecosJoao);
            CACHE.Add(joao);

            var maria = new Pessoa(new NomeCompleto("Maria", "de Almeira"),
                      new CPF("987654321"),
                      new Email("joao@email.com"));
            var enderecosMaria = new List<Endereco>();
            enderecosMaria.Add(new Endereco(Endereco.TipoEndereco.Comercial, "Rua", "das avenidas", "456"));
            maria.AdicionarEnderecos(enderecosMaria);
            CACHE.Add(maria);

            return CACHE;
        }

        public static void Inserir(Pessoa pessoa)
        {
            if (CACHE == null) Listar();

            CACHE.Add(pessoa);
        }

        public static void Atualizar(Pessoa pessoa)
        {
            if (CACHE == null) Listar();

            var pessoaExistente = CACHE.FirstOrDefault(p => p.Id.Equals(pessoa.Id));
            CACHE.Remove(pessoaExistente);

            Inserir(pessoa);
        }
    }
}
