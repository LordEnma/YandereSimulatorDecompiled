using System;
using UnityEngine;

// Token: 0x0200039E RID: 926
[Serializable]
public class Phase
{
	// Token: 0x06001A8F RID: 6799 RVA: 0x0011CE0E File Offset: 0x0011B00E
	public Phase(PhaseOfDay type)
	{
		this.type = type;
	}

	// Token: 0x17000498 RID: 1176
	// (get) Token: 0x06001A90 RID: 6800 RVA: 0x0011CE1D File Offset: 0x0011B01D
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
