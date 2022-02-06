using System;
using UnityEngine;

// Token: 0x02000399 RID: 921
[Serializable]
public class Phase
{
	// Token: 0x06001A5F RID: 6751 RVA: 0x0011A146 File Offset: 0x00118346
	public Phase(PhaseOfDay type)
	{
		this.type = type;
	}

	// Token: 0x17000495 RID: 1173
	// (get) Token: 0x06001A60 RID: 6752 RVA: 0x0011A155 File Offset: 0x00118355
	public PhaseOfDay Type
	{
		get
		{
			return this.type;
		}
	}

	// Token: 0x04002B76 RID: 11126
	[SerializeField]
	private PhaseOfDay type;
}
