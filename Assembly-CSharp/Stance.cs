using System;
using UnityEngine;

[Serializable]
public class Stance
{
	[SerializeField]
	private StanceType current;

	[SerializeField]
	private StanceType previous;

	public StanceType Current
	{
		get
		{
			return current;
		}
		set
		{
			previous = current;
			current = value;
		}
	}

	public StanceType Previous => previous;

	public Stance(StanceType initialStance)
	{
		current = initialStance;
		previous = initialStance;
	}
}
