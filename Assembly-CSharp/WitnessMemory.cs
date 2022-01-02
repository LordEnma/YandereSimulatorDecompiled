using System;
using UnityEngine;

// Token: 0x020002B3 RID: 691
[Serializable]
public class WitnessMemory
{
	// Token: 0x06001446 RID: 5190 RVA: 0x000C52AC File Offset: 0x000C34AC
	public WitnessMemory()
	{
		this.memories = new float[Enum.GetValues(typeof(WitnessMemoryType)).Length];
		for (int i = 0; i < this.memories.Length; i++)
		{
			this.memories[i] = float.PositiveInfinity;
		}
		this.memorySpan = 1800f;
	}

	// Token: 0x06001447 RID: 5191 RVA: 0x000C5309 File Offset: 0x000C3509
	public bool Remembers(WitnessMemoryType type)
	{
		return this.memories[(int)type] < this.memorySpan;
	}

	// Token: 0x06001448 RID: 5192 RVA: 0x000C531B File Offset: 0x000C351B
	public void Refresh(WitnessMemoryType type)
	{
		this.memories[(int)type] = 0f;
	}

	// Token: 0x06001449 RID: 5193 RVA: 0x000C532C File Offset: 0x000C352C
	public void Tick(float dt)
	{
		for (int i = 0; i < this.memories.Length; i++)
		{
			this.memories[i] += dt;
		}
	}

	// Token: 0x04001F22 RID: 7970
	[SerializeField]
	private float[] memories;

	// Token: 0x04001F23 RID: 7971
	[SerializeField]
	private float memorySpan;

	// Token: 0x04001F24 RID: 7972
	private const float LongMemorySpan = 28800f;

	// Token: 0x04001F25 RID: 7973
	private const float MediumMemorySpan = 7200f;

	// Token: 0x04001F26 RID: 7974
	private const float ShortMemorySpan = 1800f;

	// Token: 0x04001F27 RID: 7975
	private const float VeryShortMemorySpan = 120f;
}
