using System;
using UnityEngine;

// Token: 0x02000399 RID: 921
[Serializable]
public class Phase
{
	// Token: 0x06001A5D RID: 6749 RVA: 0x0011A02E File Offset: 0x0011822E
	public Phase(PhaseOfDay type)
	{
		this.type = type;
	}

	// Token: 0x17000494 RID: 1172
	// (get) Token: 0x06001A5E RID: 6750 RVA: 0x0011A03D File Offset: 0x0011823D
	public PhaseOfDay Type
	{
		get
		{
			return this.type;
		}
	}

	// Token: 0x04002B73 RID: 11123
	[SerializeField]
	private PhaseOfDay type;
}
