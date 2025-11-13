public abstract class Agente
{
	protected Personagem personagem;
	public Arma arma { get; protected set; }
	protected float vida;
	protected EfeitosStatus efeitos;
	public Personagem.Tipo tipo { get { return personagem.tipo; } }

	public Agente(string nome, Personagem.Classe classe, Personagem.Tipo tipo, Arma arma) : this(new Personagem(nome, classe, tipo), arma) {}

	public Agente(Personagem personagem, Arma arma) : this()
    {
		this.personagem = personagem;
		this.arma = arma;
    }

	private Agente()
    {
		vida = 100;
    }

	public void adicionarEfeito(EfeitosStatus.Tipos tipoEfeito)
	{
		efeitos.adicionarEfeito(tipoEfeito);
	}

	public void retirarEfeito(EfeitosStatus.Tipos tipoEfeito)
	{
		efeitos.retirarEfeito(tipoEfeito);
	}

	public void tomarDano(float dano)
	{
		vida = ((vida - dano) > 0) ? vida - dano : 0;
	}
}

