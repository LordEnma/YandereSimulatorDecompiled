using System;
using UnityEngine;

// Token: 0x02000399 RID: 921
[Serializable]
public class Phase
{
	// Token: 0x06001A5D RID: 6749 RVA: 0x00119F2A File Offset: 0x0011812A
	public Phase(PhaseOfDay type)
	{
		this.type = type;
	}

	// Token: 0x17000494 RID: 1172
	// (get) Token: 0x06001A5E RID: 6750 RVA: 0x00119F39 File Offset: 0x00118139
	public PhaseOfDay Type
	{
		get
		{
			return this.type;
		}
	}

	// Token: 0x04002B72 RID: 11122
	[SerializeField]
	private PhaseOfDay type;
}
