using System;
using UnityEngine;

// Token: 0x020002B4 RID: 692
[Serializable]
public class WitnessMemory
{
	// Token: 0x0600144B RID: 5195 RVA: 0x000C5870 File Offset: 0x000C3A70
	public WitnessMemory()
	{
		this.memories = new float[Enum.GetValues(typeof(WitnessMemoryType)).Length];
		for (int i = 0; i < this.memories.Length; i++)
		{
			this.memories[i] = float.PositiveInfinity;
		}
		this.memorySpan = 1800f;
	}

	// Token: 0x0600144C RID: 5196 RVA: 0x000C58CD File Offset: 0x000C3ACD
	public bool Remembers(WitnessMemoryType type)
	{
		return this.memories[(int)type] < this.memorySpan;
	}

	// Token: 0x0600144D RID: 5197 RVA: 0x000C58DF File Offset: 0x000C3ADF
	public void Refresh(WitnessMemoryType type)
	{
		this.memories[(int)type] = 0f;
	}

	// Token: 0x0600144E RID: 5198 RVA: 0x000C58F0 File Offset: 0x000C3AF0
	public void Tick(float dt)
	{
		for (int i = 0; i < this.memories.Length; i++)
		{
			this.memories[i] += dt;
		}
	}

	// Token: 0x04001F2B RID: 7979
	[SerializeField]
	private float[] memories;

	// Token: 0x04001F2C RID: 7980
	[SerializeField]
	private float memorySpan;

	// Token: 0x04001F2D RID: 7981
	private const float LongMemorySpan = 28800f;

	// Token: 0x04001F2E RID: 7982
	private const float MediumMemorySpan = 7200f;

	// Token: 0x04001F2F RID: 7983
	private const float ShortMemorySpan = 1800f;

	// Token: 0x04001F30 RID: 7984
	private const float VeryShortMemorySpan = 120f;
}
