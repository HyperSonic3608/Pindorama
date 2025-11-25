using UnityEngine;

public abstract class Item
{
	public enum Raridade
	{
		Normal = 1,
		Raro,
		Lendário,
	}

	public Raridade raridade { get; protected set; }

	public Item(Raridade raridade)
	{
		this.raridade = raridade;
	}
}

