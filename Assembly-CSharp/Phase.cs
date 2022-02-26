using System;
using UnityEngine;

// Token: 0x0200039B RID: 923
[Serializable]
public class Phase
{
	// Token: 0x06001A6F RID: 6767 RVA: 0x0011AE76 File Offset: 0x00119076
	public Phase(PhaseOfDay type)
	{
		this.type = type;
	}

	// Token: 0x17000496 RID: 1174
	// (get) Token: 0x06001A70 RID: 6768 RVA: 0x0011AE85 File Offset: 0x00119085
	public PhaseOfDay Type
	{
		get
		{
			return this.type;
		}
	}

	// Token: 0x04002B8C RID: 11148
	[SerializeField]
	private PhaseOfDay type;
}
