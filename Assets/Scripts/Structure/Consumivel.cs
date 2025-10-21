using UnityEngine;

public class Consumivel : Item
{
    private EfeitosConsumivel efeitos;
    private float danoBase;

    public Consumivel(Raridade raridade) : base(raridade)
    {
        efeitos = new EfeitosConsumivel();
    }

    public bool aplicarDano(Agente agente, Dado dado)
    {
        float chanceDeDesvio = 75 - (dado.valor * 12.5f);

        if (Random.Range(1, 101) > chanceDeDesvio)
        {
            float danoFinal = efeitos.aplicarEfeito(agente);
            agente.tomarDano(danoFinal);
            return true;
        }
        else
        {
            return false;
        }
    }
}