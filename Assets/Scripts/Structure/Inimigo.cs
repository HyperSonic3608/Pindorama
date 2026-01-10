using UnityEngine;

public class Inimigo : Agente
{
    public Inimigo(string nome, Personagem.Classe classe, Personagem.Tipo tipo, Arma arma) : base(nome, classe, tipo, arma) {}

    public Inimigo(Personagem personagem, Arma arma) : base(personagem, arma) {}

    public (int, int) IA(Agente agente, Dado dado)
        {
        // int acaoIndex = Random.Range(0,2);
        int opcaoIndex = Random.Range(0,3);
        // switch (acaoIndex)
        // {
        //     case 0:
                arma.aplicarDano(agente, dado, opcaoIndex);
        //         break;
        //     case 1:
        //         aplicarCura(opcaoIndex);
        //         break;
        //     default:
        //         break;
        // }
        return (0, opcaoIndex);
	}
}

