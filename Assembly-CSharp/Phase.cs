using System;
using UnityEngine;

// Token: 0x0200039E RID: 926
[Serializable]
public class Phase
{
	// Token: 0x06001A8B RID: 6795 RVA: 0x0011C872 File Offset: 0x0011AA72
	public Phase(PhaseOfDay type)
	{
		this.type = type;
	}

	// Token: 0x17000498 RID: 1176
	// (get) Token: 0x06001A8C RID: 6796 RVA: 0x0011C881 File Offset: 0x0011AA81
	public PhaseOfDay Type
	{
		get
		{
			return this.type;
		}
	}

	// Token: 0x04002BEB RID: 11243
	[SerializeField]
	private PhaseOfDay type;
}
