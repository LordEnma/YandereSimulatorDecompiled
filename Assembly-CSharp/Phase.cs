using System;
using UnityEngine;

[Serializable]
public class Phase
{
	[SerializeField]
	private PhaseOfDay type;

	public PhaseOfDay Type => type;

	public Phase(PhaseOfDay type)
	{
		this.type = type;
	}
}
