using System;
using UnityEngine;

// Token: 0x0200039E RID: 926
[Serializable]
public class Phase
{
	// Token: 0x06001A8F RID: 6799 RVA: 0x0011CDDA File Offset: 0x0011AFDA
	public Phase(PhaseOfDay type)
	{
		this.type = type;
	}

	// Token: 0x17000498 RID: 1176
	// (get) Token: 0x06001A90 RID: 6800 RVA: 0x0011CDE9 File Offset: 0x0011AFE9
	public PhaseOfDay Type
	{
		get
		{
			return this.type;
		}
	}

	// Token: 0x04002BF4 RID: 11252
	[SerializeField]
	private PhaseOfDay type;
}
