using UnityEditor.Animations;
using UnityEngine;

public class Dado
{
	public enum Tipo
	{
		SeisLados = 6,
		VinteLados = 20
	}

	public Tipo tipo { get; private set; }
	public int valor { get; private set; }

	public Dado(Tipo tipo)
	{
		this.tipo = tipo;
	}
	public void rolarDado()
	{
		valor = Random.Range(1, (int)tipo + 1);
	}

}

