public class Aliado : Agente
{
    public Aliado(string nome, Personagem.Classe classe, Personagem.Tipo tipo, Arma arma) : base(nome, classe, tipo, arma) { }

    public Aliado(Personagem personagem, Arma arma) : base(personagem, arma) { }

    public void Controle(Agente agente, Dado dado, int acaoIndex, int opcaoIndex)
    {
        switch (acaoIndex)
        {
            case 0:
                arma.aplicarDano(agente, dado, opcaoIndex);
                break;
            case 1:
                agente.aplicarCura(opcaoIndex, dado);
                break;
            default:
                break;
        }
    }
}