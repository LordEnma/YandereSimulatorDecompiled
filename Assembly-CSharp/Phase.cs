using System;
using UnityEngine;

[Serializable]
public class Phase
{
	[SerializeField]
	private PhaseOfDay type;

	public PhaseOfDay Type
	{
		get
		{
			return type;
		}
	}

	public Phase(PhaseOfDay type)
	{
		this.type = type;
	}
}
