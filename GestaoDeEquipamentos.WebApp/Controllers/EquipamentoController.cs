using GestaoDeEquipamentos.Dominio.ModuloEquipamento;
using GestaoDeEquipamentos.Infraestrutura.Arquivos.Compartilhado;
using GestaoDeEquipamentos.Infraestrutura.Arquivos.ModuloChamado;
//using GestaoDeEquipamentos.Infraestrutura.Arquivos.ModuloEquipamento;
using Microsoft.AspNetCore.Mvc;

namespace GestaoDeEquipamentos.WebApp.Controllers;

public class EquipamentoController : Controller
{
    private RepositorioEquipamentoEmArquivo repositorioEquipamento;

    public EquipamentoController()
    {
        ContextoDados contexto = new ContextoDados(true);
        repositorioEquipamento = new RepositorioEquipamentoEmArquivo(contexto);
    }

    public IActionResult Index()
    {
        List<Equipamento> equipamentos = repositorioEquipamento.SelecionarRegistros();

        return View(equipamentos);
    }

    [HttpGet]
    public IActionResult Cadastrar()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Cadastrar(string nome, string email, string telefone)
    {
        Equipamento novoEquipamento = new Equipamento(nome, email, telefone);

        repositorioEquipamento.CadastrarRegistro(novoEquipamento);

        return RedirectToAction("Index");
    }
}