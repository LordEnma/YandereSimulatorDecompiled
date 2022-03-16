using System;
using UnityEngine;

// Token: 0x020002B6 RID: 694
[Serializable]
public class WitnessMemory
{
	// Token: 0x0600145C RID: 5212 RVA: 0x000C6894 File Offset: 0x000C4A94
	public WitnessMemory()
	{
		this.memories = new float[Enum.GetValues(typeof(WitnessMemoryType)).Length];
		for (int i = 0; i < this.memories.Length; i++)
		{
			this.memories[i] = float.PositiveInfinity;
		}
		this.memorySpan = 1800f;
	}

	// Token: 0x0600145D RID: 5213 RVA: 0x000C68F1 File Offset: 0x000C4AF1
	public bool Remembers(WitnessMemoryType type)
	{
		return this.memories[(int)type] < this.memorySpan;
	}

	// Token: 0x0600145E RID: 5214 RVA: 0x000C6903 File Offset: 0x000C4B03
	public void Refresh(WitnessMemoryType type)
	{
		this.memories[(int)type] = 0f;
	}

	// Token: 0x0600145F RID: 5215 RVA: 0x000C6914 File Offset: 0x000C4B14
	public void Tick(float dt)
	{
		for (int i = 0; i < this.memories.Length; i++)
		{
			this.memories[i] += dt;
		}
	}

	// Token: 0x04001F5A RID: 8026
	[SerializeField]
	private float[] memories;

	// Token: 0x04001F5B RID: 8027
	[SerializeField]
	private float memorySpan;

	// Token: 0x04001F5C RID: 8028
	private const float LongMemorySpan = 28800f;

	// Token: 0x04001F5D RID: 8029
	private const float MediumMemorySpan = 7200f;

	// Token: 0x04001F5E RID: 8030
	private const float ShortMemorySpan = 1800f;

	// Token: 0x04001F5F RID: 8031
	private const float VeryShortMemorySpan = 120f;
}
