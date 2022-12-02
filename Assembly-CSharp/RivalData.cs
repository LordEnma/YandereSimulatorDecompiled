using System;
using UnityEngine;

[Serializable]
public class RivalData
{
	[SerializeField]
	private int week;

	public int Week
	{
		get
		{
			return week;
		}
	}

	public RivalData(int week)
	{
		this.week = week;
	}
}
