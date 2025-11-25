using UnityEngine;

public class Consumivel : Item
{
    // private EfeitosConsumivel efeitos;
    private float danoBase;

    public Consumivel(Raridade raridade) : base(raridade)
    {
        // efeitos = new EfeitosConsumivel();
    }

    public bool aplicarEfeito(Agente agente)
    {
        return false;
    }
}