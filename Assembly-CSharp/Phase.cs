using System;
using UnityEngine;

// Token: 0x0200039A RID: 922
[Serializable]
public class Phase
{
	// Token: 0x06001A66 RID: 6758 RVA: 0x0011A462 File Offset: 0x00118662
	public Phase(PhaseOfDay type)
	{
		this.type = type;
	}

	// Token: 0x17000496 RID: 1174
	// (get) Token: 0x06001A67 RID: 6759 RVA: 0x0011A471 File Offset: 0x00118671
	public PhaseOfDay Type
	{
		get
		{
			return this.type;
		}
	}

	// Token: 0x04002B7C RID: 11132
	[SerializeField]
	private PhaseOfDay type;
}
