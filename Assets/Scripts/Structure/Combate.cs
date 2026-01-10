using System.Collections.Generic;

public class Combate
{
	public int turno { get; private set; }
	public List<Aliado> aliados;
	public List<Inimigo> inimigos;

	public Combate()
	{
		aliados = new List<Aliado>();
		inimigos = new List<Inimigo>();
	}

	public void defineTurno(int turno)
	{
		this.turno = turno;
	}

	public void realizarAcao(Agente realizador, Agente alvo, Dado dado, int acaoIndex, int ordemIndex)
	{
		if (realizador is Aliado)
		{
			((Aliado)realizador).Controle(alvo, dado, acaoIndex, ordemIndex);

			foreach (Aliado aliado in aliados)
			{
				if (!aliado.jogouNesseTurno)
				{
					defineTurno(1);
					return;
				}
			}

			foreach (Inimigo inimigo in inimigos)
			{
				inimigo.SetJogouNesseTurno(false);
			}

			defineTurno(-1);
		}
		else
		{
			((Inimigo)realizador).IA(alvo, dado);

			foreach (Inimigo inimigo in inimigos)
			{
				if (!inimigo.jogouNesseTurno)
				{
					defineTurno(-1);
					return;
				}
			}

			foreach (Aliado aliado in aliados)
			{
				aliado.SetJogouNesseTurno(false);
			}

			defineTurno(1);
		}
	}

}

