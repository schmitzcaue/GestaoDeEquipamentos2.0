//using GestaoDeEquipamentos.Dominio.ModuloEquipamento;
//using GestaoDeEquipamentos.Infraestrutura.Arquivos.Compartilhado;
//using GestaoDeEquipamentos.Infraestrutura.Arquivos.ModuloChamado;
////using GestaoDeEquipamentos.Infraestrutura.Arquivos.ModuloEquipamento;
//using Microsoft.AspNetCore.Mvc;

//namespace GestaoDeEquipamentos.WebApp.Controllers;

//public class EquipamentoController : Controller
//{
//    private RepositorioEquipamentoEmArquivo repositorioEquipamento;

//    public EquipamentoController()
//    {
//        ContextoDados contexto = new ContextoDados(true);
//        repositorioEquipamento = new RepositorioEquipamentoEmArquivo(contexto);
//    }

//    public IActionResult Index()
//    {
//        List<Equipamento> fabricantes = repositorioEquipamento.SelecionarRegistros();

//        return View(fabricantes);
//    }


//    public IActionResult Cadastrar()
//    {
//        return View();
//    }

//    [HttpPost]
//    public IActionResult Cadastrar(string nome, decimal PrecoAquisicao, string NumeroSerie)
//    {
//        Equipamento novoEquipamento = new Equipamento(nome, PrecoAquisicao, NumeroSerie);

//        repositorioEquipamento.CadastrarRegistro(novoEquipamento);

//        return RedirectToAction(nameof(Index));
//    }

//    public IActionResult Editar(int id)
//    {
//        Equipamento equipamentoSelecionado = repositorioEquipamento.SelecionarRegistroPorId(id);

//        if (equipamentoSelecionado == null)
//            return RedirectToAction(nameof(Index));

//        return View(equipamentoSelecionado);
//    }

//    [HttpPost]
//    public IActionResult Editar(int id, string nome, decimal PrecoAquisicao, string NumeroSerie)
//    {
//        Equipamento equipamentoEditado = new Equipamento(nome, PrecoAquisicao, NumeroSerie);

//        bool edicaoConluida = repositorioEquipamento.EditarRegistro(id, equipamentoEditado);

//        if (!edicaoConluida)
//        {
//            equipamentoEditado.Id = id;

//            return View(equipamentoEditado);
//        }

//        return RedirectToAction(nameof(Index));
//    }

//    public IActionResult Excluir(int id)
//    {
//        Equipamento equipamentoSelecionado = repositorioEquipamento.SelecionarRegistroPorId(id);

//        if (equipamentoSelecionado == null)
//            return RedirectToAction(nameof(Index));

//        return View(equipamentoSelecionado);
//    }

//    [HttpPost]
//    public IActionResult ExcluirConfirmado(int id)
//    {
//        repositorioEquipamento.ExcluirRegistro(id);

//        return RedirectToAction(nameof(Index));
//    }
//}