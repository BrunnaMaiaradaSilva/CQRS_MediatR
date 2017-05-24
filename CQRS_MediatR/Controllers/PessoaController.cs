using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace CQRS_MediatR.Controllers
{
    public class PessoaController : Controller
    {
        private readonly IMediator _mediator;
        private readonly Domain.Repositories.Read.IPessoa _repositorioLeitura;
        public PessoaController(IMediator mediator,
                                Domain.Repositories.Read.IPessoa repositorioLeitura)
        {
            this._mediator = mediator;
            this._repositorioLeitura = repositorioLeitura;
        }

        public IActionResult Index()
        {
            var pessoas = this._repositorioLeitura.Listar();
            return View(pessoas);
        }

        [HttpGet]
        public IActionResult Editar(Guid id)
        {
            var pessoa = this._repositorioLeitura.ObterPorId(id);
            var viewModel = new ViewModels.Editar
            {
                Nome = pessoa.Nome.ToString(),
                Email = pessoa.Email.ToString(),
                Enderecos = pessoa.Enderecos?.Select(e => e.ToString())?.ToList()
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Editar(Guid id, ViewModels.Editar viewModel)
        {
            var pessoa = this._repositorioLeitura.ObterPorId(id);
            this._mediator.Send(new Domain.Commands.NovoEmail(id, new Domain.ValueObjects.Email(viewModel.NovoEmail)));

            return RedirectToAction("Index");
        }
    }
}