using System;
using UnityEngine;

// Token: 0x02000397 RID: 919
[Serializable]
public class Phase
{
	// Token: 0x06001A53 RID: 6739 RVA: 0x0011935A File Offset: 0x0011755A
	public Phase(PhaseOfDay type)
	{
		this.type = type;
	}

	// Token: 0x17000493 RID: 1171
	// (get) Token: 0x06001A54 RID: 6740 RVA: 0x00119369 File Offset: 0x00117569
	public PhaseOfDay Type
	{
		get
		{
			return this.type;
		}
	}

	// Token: 0x04002B5F RID: 11103
	[SerializeField]
	private PhaseOfDay type;
}
