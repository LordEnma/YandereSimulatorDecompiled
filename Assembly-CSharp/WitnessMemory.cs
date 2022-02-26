using System;
using UnityEngine;

// Token: 0x020002B6 RID: 694
[Serializable]
public class WitnessMemory
{
	// Token: 0x06001459 RID: 5209 RVA: 0x000C62D8 File Offset: 0x000C44D8
	public WitnessMemory()
	{
		this.memories = new float[Enum.GetValues(typeof(WitnessMemoryType)).Length];
		for (int i = 0; i < this.memories.Length; i++)
		{
			this.memories[i] = float.PositiveInfinity;
		}
		this.memorySpan = 1800f;
	}

	// Token: 0x0600145A RID: 5210 RVA: 0x000C6335 File Offset: 0x000C4535
	public bool Remembers(WitnessMemoryType type)
	{
		return this.memories[(int)type] < this.memorySpan;
	}

	// Token: 0x0600145B RID: 5211 RVA: 0x000C6347 File Offset: 0x000C4547
	public void Refresh(WitnessMemoryType type)
	{
		this.memories[(int)type] = 0f;
	}

	// Token: 0x0600145C RID: 5212 RVA: 0x000C6358 File Offset: 0x000C4558
	public void Tick(float dt)
	{
		for (int i = 0; i < this.memories.Length; i++)
		{
			this.memories[i] += dt;
		}
	}

	// Token: 0x04001F41 RID: 8001
	[SerializeField]
	private float[] memories;

	// Token: 0x04001F42 RID: 8002
	[SerializeField]
	private float memorySpan;

	// Token: 0x04001F43 RID: 8003
	private const float LongMemorySpan = 28800f;

	// Token: 0x04001F44 RID: 8004
	private const float MediumMemorySpan = 7200f;

	// Token: 0x04001F45 RID: 8005
	private const float ShortMemorySpan = 1800f;

	// Token: 0x04001F46 RID: 8006
	private const float VeryShortMemorySpan = 120f;
}
