using System;

public class Personagem
{
	public enum Classe
	{
		Indigena,
		Colonizador,
		Animal,
		Espirito
	}

	public enum Tipo
	{
		Mediano = 0,
		Pequeno,
		Bruto,
		Alcance,
		Xama,
		Crianca = 10,
		Cobra = 100,
		Onca,
		Espirito = 1000
	}

	public string nome { get; protected set; }
	public Classe classe { get; protected set; }
	public Tipo tipo { get; protected set; }

	public Personagem(string nome, Classe classe, Tipo tipo)
	{
		this.nome = nome;
		this.classe = classe;
		switch (classe)
		{
			case Classe.Indigena:
				this.tipo = (int)tipo > 10 ? Tipo.Mediano : tipo;
				break;

			case Classe.Colonizador:
				this.tipo = (int)tipo >= 10 ? Tipo.Mediano : tipo;
				break;

			case Classe.Animal:
				this.tipo = (int)tipo == 100 ? Tipo.Cobra : Tipo.Onca;
				break;

			case Classe.Espirito:
				this.tipo = Tipo.Espirito;
				break;

			default:
				break;
		}
	}
}


