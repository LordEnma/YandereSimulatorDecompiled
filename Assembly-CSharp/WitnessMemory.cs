using System;
using UnityEngine;

[Serializable]
public class WitnessMemory
{
	[SerializeField]
	private float[] memories;

	[SerializeField]
	private float memorySpan;

	private const float LongMemorySpan = 28800f;

	private const float MediumMemorySpan = 7200f;

	private const float ShortMemorySpan = 1800f;

	private const float VeryShortMemorySpan = 120f;

	public WitnessMemory()
	{
		memories = new float[Enum.GetValues(typeof(WitnessMemoryType)).Length];
		for (int i = 0; i < memories.Length; i++)
		{
			memories[i] = float.PositiveInfinity;
		}
		memorySpan = 1800f;
	}

	public bool Remembers(WitnessMemoryType type)
	{
		return memories[(int)type] < memorySpan;
	}

	public void Refresh(WitnessMemoryType type)
	{
		memories[(int)type] = 0f;
	}

	public void Tick(float dt)
	{
		for (int i = 0; i < memories.Length; i++)
		{
			memories[i] += dt;
		}
	}
}
