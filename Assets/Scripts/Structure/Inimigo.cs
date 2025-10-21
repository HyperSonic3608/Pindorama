public class Inimigo : Agente
{
    public Inimigo(string nome, Personagem.Classe classe, Personagem.Tipo tipo, Arma arma) : base(nome, classe, tipo, arma) {}

    public Inimigo(Personagem personagem, Arma arma) : base(personagem, arma) {}

    public void IA()
	{

	}
}

