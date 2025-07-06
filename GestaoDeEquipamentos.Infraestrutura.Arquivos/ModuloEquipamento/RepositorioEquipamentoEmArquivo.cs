using GestaoDeEquipamentos.Dominio.ModuloEquipamento;
using GestaoDeEquipamentos.Dominio.ModuloFabricante;
using GestaoDeEquipamentos.Infraestrutura.Arquivos.Compartilhado;
using GestaoDeEquipamentos.Infraestrutura.Compartilhado;

namespace GestaoDeEquipamentos.Infraestrutura.Arquivos.ModuloChamado;

public class RepositorioEquipamentoEmArquivo : RepositorioBaseEmArquivo<Equipamento>
{
    public RepositorioEquipamentoEmArquivo(ContextoDados contexto) : base(contexto)
    {
    }

    protected override List<Equipamento> ObterRegistros()
    {
        return contexto.Equipamentos;
    }
}
