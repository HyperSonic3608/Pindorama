using UnityEngine;

public class Arma : Item
{
    public enum Tipo
    {
        Físico = 0,
        ArcoFlecha = 10,
        Faca = 11,
        Lanca = 12,
        Zarabatana = 13
    }

    public Tipo tipo { get; private set; }
    // private EfeitosArma efeitos;
    private float dano;

    public Arma(Tipo tipo, Raridade raridade) : base(raridade)
    {
        this.tipo = tipo;
        dano = (float)tipo * (0.25f * (float)raridade + 0.75f);
        // EfeitosArma.Tipos e = (EfeitosArma.Tipos)3;
        // efeitos = new EfeitosArma(raridade, ew);
    }

    public bool aplicarDano(Agente agente, Dado dado)
    {
        float chanceDeDesvio = 75 - (dado.valor * 12.5f);

        if (Random.Range(1, 101) > chanceDeDesvio)
        {
            // float danoFinal = efeitos.aplicarEfeito(agente, danoBase);
            agente.tomarDano(dano);
            return true;
        }
        else
        {
            return false;
        }
    }
}