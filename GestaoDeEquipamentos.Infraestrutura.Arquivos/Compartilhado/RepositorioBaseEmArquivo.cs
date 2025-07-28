﻿using GestaoDeEquipamentos.Dominio.Compartilhado;
using GestaoDeEquipamentos.Infraestrutura.Arquivos.Compartilhado;

namespace GestaoDeEquipamentos.Infraestrutura.Compartilhado;

public abstract class RepositorioBaseEmArquivo<Tipo> where Tipo : EntidadeBase<Tipo>
{
    protected ContextoDados contexto;

    protected List<Tipo> registros;
    protected int contadorIds = 0;



    protected RepositorioBaseEmArquivo(ContextoDados contexto)
    {
        this.contexto = contexto;

        this.registros = ObterRegistros();


        int maiorId = 0;

        foreach (Tipo registro in registros)
        {
            if (registro.Id > contadorIds)
                maiorId = registro.Id;
        }

        contadorIds = maiorId;
    }

    public void CadastrarRegistro(Tipo novoRegistro)
    {
        novoRegistro.Id = ++contadorIds;

        registros.Add(novoRegistro);

        contexto.Salvar();
    }

    public bool EditarRegistro(int idSelecionado, Tipo registroAtualizado)
    {
        Tipo registroSelecionado = SelecionarRegistroPorId(idSelecionado);

        if (registroSelecionado is null)
            return false;

        registroSelecionado.AtualizarRegistro(registroAtualizado);

        contexto.Salvar();

        return true;
    }

    public bool ExcluirRegistro(int idSelecionado)
    {
        Tipo registroSelecionado = SelecionarRegistroPorId(idSelecionado);

        if (registroSelecionado is null)
            return false;

        registros.Remove(registroSelecionado);

        contexto.Salvar();

        return true;
    }

    public List<Tipo> SelecionarRegistros()
    {
        return registros;
    }

    public Tipo SelecionarRegistroPorId(int idSelecionado)
    {
        foreach (Tipo registro in registros)
        {
            if (registro.Id.Equals(idSelecionado))
                return registro;
        }

        return null;
    }

    protected abstract List<Tipo> ObterRegistros();
}