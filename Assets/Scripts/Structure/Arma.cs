using System;
using System.Reflection;

public class Arma : Item
{
    public enum Tipo
    {
        [Ataques(5, 8, 10)] Físico = 0,
        [Ataques(20, 0, 0)] ArcoFlecha = 10,
        [Ataques(10, 0, 0)] Faca = 11,
        [Ataques(15, 0, 0)] Lanca = 12,
        [Ataques(0, 0, 0)] Zarabatana = 13
    }

    class Ataques : Attribute
    {
        public int[] attacksDamage { get; private set; } =  new int[3];
        internal Ataques(int attack1, int attack2, int attack3)
        {
            attacksDamage[0] = attack1;
            attacksDamage[1] = attack2;
            attacksDamage[2] = attack3;
        }

        public static Ataques GetAttr(Tipo t)
        {
            return (Ataques)GetCustomAttribute(ForValue(t), typeof(Ataques));
        }

        private static MemberInfo ForValue(Tipo p)
        {
            return typeof(Tipo).GetField(Enum.GetName(typeof(Tipo), p));
        }

    }

    public Tipo tipo { get; private set; }
    // private EfeitosArma efeitos;
    private float[] danos;

    public Arma(Tipo tipo, Raridade raridade) : base(raridade)
    {
        this.tipo = tipo;
        this.danos = new float[3];
        for (int i = 0; i < Ataques.GetAttr(tipo).attacksDamage.Length; i++)
        {
            danos[i] = Ataques.GetAttr(tipo).attacksDamage[i] * (0.25f * (float)raridade + 0.75f);
        }
        // EfeitosArma.Tipos e = (EfeitosArma.Tipos)3;
        // efeitos = new EfeitosArma(raridade, ew);
    }

    public bool aplicarDano(Agente agente, Dado dado, int danoIndex)
    {
        float chanceDeDesvio = 75 - (dado.valor * 12.5f);

        if (UnityEngine.Random.Range(1, 101) > chanceDeDesvio)
        {
            // float danoFinal = efeitos.aplicarEfeito(agente, danoBase);
            agente.TomarDano(danos[danoIndex]);
            return true;
        }
        else
        {
            return false;
        }
    }
}