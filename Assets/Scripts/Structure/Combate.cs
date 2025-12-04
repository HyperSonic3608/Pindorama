public class Combate
{
	public int turno { get; private set; }

    public void defineTurno(int turno)
	{
		this.turno = turno;
	}

	public void realizarAcao(Agente realizador, Agente alvo, Dado dado, int acaoIndex, int ordemIndex)
	{
		if (realizador is Aliado)
        {
            ((Aliado)realizador).Controle(alvo, dado, acaoIndex, ordemIndex);
        }
		else
		{
			((Inimigo)realizador).IA(alvo, dado);
		}
		defineTurno(1);
	}

}

