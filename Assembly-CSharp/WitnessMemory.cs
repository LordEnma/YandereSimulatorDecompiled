using System;
using UnityEngine;

// Token: 0x020002B4 RID: 692
[Serializable]
public class WitnessMemory
{
	// Token: 0x0600144A RID: 5194 RVA: 0x000C54E4 File Offset: 0x000C36E4
	public WitnessMemory()
	{
		this.memories = new float[Enum.GetValues(typeof(WitnessMemoryType)).Length];
		for (int i = 0; i < this.memories.Length; i++)
		{
			this.memories[i] = float.PositiveInfinity;
		}
		this.memorySpan = 1800f;
	}

	// Token: 0x0600144B RID: 5195 RVA: 0x000C5541 File Offset: 0x000C3741
	public bool Remembers(WitnessMemoryType type)
	{
		return this.memories[(int)type] < this.memorySpan;
	}

	// Token: 0x0600144C RID: 5196 RVA: 0x000C5553 File Offset: 0x000C3753
	public void Refresh(WitnessMemoryType type)
	{
		this.memories[(int)type] = 0f;
	}

	// Token: 0x0600144D RID: 5197 RVA: 0x000C5564 File Offset: 0x000C3764
	public void Tick(float dt)
	{
		for (int i = 0; i < this.memories.Length; i++)
		{
			this.memories[i] += dt;
		}
	}

	// Token: 0x04001F23 RID: 7971
	[SerializeField]
	private float[] memories;

	// Token: 0x04001F24 RID: 7972
	[SerializeField]
	private float memorySpan;

	// Token: 0x04001F25 RID: 7973
	private const float LongMemorySpan = 28800f;

	// Token: 0x04001F26 RID: 7974
	private const float MediumMemorySpan = 7200f;

	// Token: 0x04001F27 RID: 7975
	private const float ShortMemorySpan = 1800f;

	// Token: 0x04001F28 RID: 7976
	private const float VeryShortMemorySpan = 120f;
}
