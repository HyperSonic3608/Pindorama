using System;

public class EfeitosStatus
{
    [Flags]
    public enum Tipos
    {
        Nenhum = 0b_0000,
        Paralisado = 0b_0001,
        Queimando = 0b_0010,
        Envenenado = 0b_0100,
        Molhado = 0b_1000,
    }

    public Tipos efeitos { get; private set; }


    public void adicionarEfeito(Tipos tipo)
    {
        efeitos |= tipo;
    }

    public void retirarEfeito(Tipos tipo)
    {
        efeitos = ((efeitos & tipo) == tipo) ? efeitos ^ tipo : efeitos;
    }


}

public class EfeitosArma
{
    [Flags]
    public enum Tipos
    {
        Nenhum = 0b_0000_0000,
        Terra = 0b_0000_0001,
        Veneno = 0b_0000_0010,
        Fogo = 0b_0000_0100,
        Agua = 0b_0001_0000,
        Choque = 0b_0010_0000,
    }

    public Tipos efeitos { get; private set; }

    public EfeitosArma(Item.Raridade raridade, Tipos efeitos)
    {
        this.efeitos = efeitos;
    }

    public void adicionarEfeito(Tipos tipo)
    {
        efeitos |= tipo;
    }

    public void retirarEfeito(Tipos tipo)
    {
        efeitos = ((efeitos & tipo) == tipo) ? efeitos ^ tipo : efeitos;
    }

    public float aplicarEfeito(Agente agente, float dano)
    {
        float danoFinal = dano;

        if ((efeitos & Tipos.Terra) == Tipos.Terra)
        {
            danoFinal *= 1f;
        }
        if ((efeitos & Tipos.Veneno) == Tipos.Veneno)
        {
            agente.adicionarEfeito(EfeitosStatus.Tipos.Envenenado);
        }
        if ((efeitos & Tipos.Fogo) == Tipos.Fogo)
        {
            agente.adicionarEfeito(EfeitosStatus.Tipos.Queimando);
        }
        if ((efeitos & Tipos.Agua) == Tipos.Agua)
        {
            agente.adicionarEfeito(EfeitosStatus.Tipos.Molhado);
        }
        if ((efeitos & Tipos.Choque) == Tipos.Choque)
        {
            agente.adicionarEfeito(EfeitosStatus.Tipos.Paralisado);
        }

        return danoFinal;
    }
}

public class EfeitosConsumivel
{
    internal float aplicarEfeito(Agente agente)
    {
        throw new NotImplementedException();
    }
}