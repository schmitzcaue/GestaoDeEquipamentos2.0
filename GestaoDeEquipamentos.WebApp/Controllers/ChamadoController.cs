using GestaoDeEquipamentos.Dominio.ModuloChamado;
using GestaoDeEquipamentos.Dominio.ModuloEquipamento;
using GestaoDeEquipamentos.Dominio.ModuloFabricante;
using GestaoDeEquipamentos.Infraestrutura.Arquivos.Compartilhado;
using GestaoDeEquipamentos.Infraestrutura.Arquivos.ModuloChamado;
using Microsoft.AspNetCore.Mvc;

namespace GestaoDeEquipamentos.WebApp.Controllers;


public class ChamadoController : Controller
{
    private RepositorioChamadoEmArquivo repositorioChamado;

    public ChamadoController()
    {
        ContextoDados contexto = new ContextoDados(true);
        repositorioChamado = new RepositorioChamadoEmArquivo(contexto);
    }

    public IActionResult Index()
    {
        List<Chamado> chamados = repositorioChamado.SelecionarRegistros();

        return View(chamados);
    }

    [HttpGet]
    public IActionResult Cadastrar()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Cadastrar(string Titulo, string Descricao, DateTime DataAbertura, Equipamento Equipamento)
    {
        Chamado novoChamado = new Chamado(Titulo, Descricao, DataAbertura, Equipamento);

        repositorioChamado.CadastrarRegistro(novoChamado);

        return RedirectToAction("Index");
    }
}