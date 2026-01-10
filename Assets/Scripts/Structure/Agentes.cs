public abstract class Agente
{
	protected Personagem personagem;
	public Arma arma { get; protected set; }
	protected float vidaMaxima;
	public float vida { get; protected set; }
	public bool jogouNesseTurno { get; private set; }
	// protected EfeitosStatus efeitos;
	public Personagem.Tipo tipo { get { return personagem.tipo; } }

	public Agente(string nome, Personagem.Classe classe, Personagem.Tipo tipo, Arma arma) : this(new Personagem(nome, classe, tipo), arma) { }

	public Agente(Personagem personagem, Arma arma) : this()
	{
		this.personagem = personagem;
		this.arma = arma;
		jogouNesseTurno = false;
	}

	private Agente()
	{
		vida = vidaMaxima = 50;
	}

	// public void adicionarEfeito(EfeitosStatus.Tipos tipoEfeito)
	// {
	// 	efeitos.adicionarEfeito(tipoEfeito);
	// }

	// public void retirarEfeito(EfeitosStatus.Tipos tipoEfeito)
	// {
	// 	efeitos.retirarEfeito(tipoEfeito);
	// }

	public void TomarDano(float dano)
	{
		vida = ((vida - dano) > 0) ? vida - dano : 0;
	}

	public void SetJogouNesseTurno(bool jogou){
		jogouNesseTurno = jogou;
	}

	public void aplicarCura(float opcaoIndex, Dado dado)
	{
		int cura;
		switch (opcaoIndex)
		{
			case 0:
				cura = 10;
				break;
			case 1:
				cura = 5;
				break;
			case 2:
				cura = 3;
				break;
			default:
				cura = 0;
				break;
		}
		
        float chanceDeDesvio = 75 - (dado.valor * 12.5f);

        if (UnityEngine.Random.Range(1, 101) > chanceDeDesvio)
		vida = ((vida + cura) < vidaMaxima) ? vida + cura : vidaMaxima;
	}
}

