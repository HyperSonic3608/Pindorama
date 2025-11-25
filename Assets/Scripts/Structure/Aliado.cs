public class Aliado : Agente
{
    public Aliado(string nome, Personagem.Classe classe, Personagem.Tipo tipo, Arma arma) : base(nome, classe, tipo, arma) {}

    public Aliado(Personagem personagem, Arma arma) : base(personagem, arma) {}

    public void controle()
    {

    }
}