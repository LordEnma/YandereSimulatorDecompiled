using System;
using UnityEngine;

// Token: 0x020002B2 RID: 690
[Serializable]
public class WitnessMemory
{
	// Token: 0x0600143F RID: 5183 RVA: 0x000C48DC File Offset: 0x000C2ADC
	public WitnessMemory()
	{
		this.memories = new float[Enum.GetValues(typeof(WitnessMemoryType)).Length];
		for (int i = 0; i < this.memories.Length; i++)
		{
			this.memories[i] = float.PositiveInfinity;
		}
		this.memorySpan = 1800f;
	}

	// Token: 0x06001440 RID: 5184 RVA: 0x000C4939 File Offset: 0x000C2B39
	public bool Remembers(WitnessMemoryType type)
	{
		return this.memories[(int)type] < this.memorySpan;
	}

	// Token: 0x06001441 RID: 5185 RVA: 0x000C494B File Offset: 0x000C2B4B
	public void Refresh(WitnessMemoryType type)
	{
		this.memories[(int)type] = 0f;
	}

	// Token: 0x06001442 RID: 5186 RVA: 0x000C495C File Offset: 0x000C2B5C
	public void Tick(float dt)
	{
		for (int i = 0; i < this.memories.Length; i++)
		{
			this.memories[i] += dt;
		}
	}

	// Token: 0x04001EFF RID: 7935
	[SerializeField]
	private float[] memories;

	// Token: 0x04001F00 RID: 7936
	[SerializeField]
	private float memorySpan;

	// Token: 0x04001F01 RID: 7937
	private const float LongMemorySpan = 28800f;

	// Token: 0x04001F02 RID: 7938
	private const float MediumMemorySpan = 7200f;

	// Token: 0x04001F03 RID: 7939
	private const float ShortMemorySpan = 1800f;

	// Token: 0x04001F04 RID: 7940
	private const float VeryShortMemorySpan = 120f;
}
