using System;
using UnityEngine;

// Token: 0x020002B2 RID: 690
[Serializable]
public class Stance
{
	// Token: 0x06001446 RID: 5190 RVA: 0x000C54A8 File Offset: 0x000C36A8
	public Stance(StanceType initialStance)
	{
		this.current = initialStance;
		this.previous = initialStance;
	}

	// Token: 0x17000368 RID: 872
	// (get) Token: 0x06001447 RID: 5191 RVA: 0x000C54BE File Offset: 0x000C36BE
	// (set) Token: 0x06001448 RID: 5192 RVA: 0x000C54C6 File Offset: 0x000C36C6
	public StanceType Current
	{
		get
		{
			return this.current;
		}
		set
		{
			this.previous = this.current;
			this.current = value;
		}
	}

	// Token: 0x17000369 RID: 873
	// (get) Token: 0x06001449 RID: 5193 RVA: 0x000C54DB File Offset: 0x000C36DB
	public StanceType Previous
	{
		get
		{
			return this.previous;
		}
	}

	// Token: 0x04001F1B RID: 7963
	[SerializeField]
	private StanceType current;

	// Token: 0x04001F1C RID: 7964
	[SerializeField]
	private StanceType previous;
}
