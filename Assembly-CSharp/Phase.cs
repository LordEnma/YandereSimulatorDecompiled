using System;
using UnityEngine;

// Token: 0x02000397 RID: 919
[Serializable]
public class Phase
{
	// Token: 0x06001A55 RID: 6741 RVA: 0x00119636 File Offset: 0x00117836
	public Phase(PhaseOfDay type)
	{
		this.type = type;
	}

	// Token: 0x17000494 RID: 1172
	// (get) Token: 0x06001A56 RID: 6742 RVA: 0x00119645 File Offset: 0x00117845
	public PhaseOfDay Type
	{
		get
		{
			return this.type;
		}
	}

	// Token: 0x04002B63 RID: 11107
	[SerializeField]
	private PhaseOfDay type;
}
