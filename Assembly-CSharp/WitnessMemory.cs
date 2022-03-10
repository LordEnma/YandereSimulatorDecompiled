using System;
using UnityEngine;

// Token: 0x020002B6 RID: 694
[Serializable]
public class WitnessMemory
{
	// Token: 0x06001459 RID: 5209 RVA: 0x000C6424 File Offset: 0x000C4624
	public WitnessMemory()
	{
		this.memories = new float[Enum.GetValues(typeof(WitnessMemoryType)).Length];
		for (int i = 0; i < this.memories.Length; i++)
		{
			this.memories[i] = float.PositiveInfinity;
		}
		this.memorySpan = 1800f;
	}

	// Token: 0x0600145A RID: 5210 RVA: 0x000C6481 File Offset: 0x000C4681
	public bool Remembers(WitnessMemoryType type)
	{
		return this.memories[(int)type] < this.memorySpan;
	}

	// Token: 0x0600145B RID: 5211 RVA: 0x000C6493 File Offset: 0x000C4693
	public void Refresh(WitnessMemoryType type)
	{
		this.memories[(int)type] = 0f;
	}

	// Token: 0x0600145C RID: 5212 RVA: 0x000C64A4 File Offset: 0x000C46A4
	public void Tick(float dt)
	{
		for (int i = 0; i < this.memories.Length; i++)
		{
			this.memories[i] += dt;
		}
	}

	// Token: 0x04001F4A RID: 8010
	[SerializeField]
	private float[] memories;

	// Token: 0x04001F4B RID: 8011
	[SerializeField]
	private float memorySpan;

	// Token: 0x04001F4C RID: 8012
	private const float LongMemorySpan = 28800f;

	// Token: 0x04001F4D RID: 8013
	private const float MediumMemorySpan = 7200f;

	// Token: 0x04001F4E RID: 8014
	private const float ShortMemorySpan = 1800f;

	// Token: 0x04001F4F RID: 8015
	private const float VeryShortMemorySpan = 120f;
}
