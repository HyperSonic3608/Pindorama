using UnityEngine;

public class Arma : Item
{
    public enum Tipo
    {
        Físico = 0,
        ArcoFlecha,
        Faca,
        Lanca,
        Zarabatana
    }

    private Tipo tipo;
    private EfeitosArma efeitos;
    private float danoBase;

    public Arma(Tipo tipo, Raridade raridade) : base(raridade)
    {
        this.tipo = tipo;
        EfeitosArma.Tipos e = (EfeitosArma.Tipos)3;
        efeitos = new EfeitosArma(raridade, e);
    }

    public bool aplicarDano(Agente agente, Dado dado)
    {
        float chanceDeDesvio = 75 - (dado.valor * 12.5f);

        if (Random.Range(1, 101) > chanceDeDesvio)
        {
            float danoFinal = efeitos.aplicarEfeito(agente, danoBase);
            agente.tomarDano(danoFinal);
            return true;
        }
        else
        {
            return false;
        }
    }
}