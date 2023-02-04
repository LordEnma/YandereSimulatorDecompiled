using System;
using UnityEngine;

[Serializable]
public abstract class Entity
{
	[SerializeField]
	private GenderType gender;

	[SerializeField]
	private DeathType deathType;

	public GenderType Gender => gender;

	public DeathType DeathType
	{
		get
		{
			return deathType;
		}
		set
		{
			deathType = value;
		}
	}

	public abstract EntityType EntityType { get; }

	public Entity(GenderType gender)
	{
		this.gender = gender;
		deathType = DeathType.None;
	}
}
