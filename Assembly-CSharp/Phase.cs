using System;
using UnityEngine;

// Token: 0x02000396 RID: 918
[Serializable]
public class Phase
{
	// Token: 0x06001A4B RID: 6731 RVA: 0x00118B1A File Offset: 0x00116D1A
	public Phase(PhaseOfDay type)
	{
		this.type = type;
	}

	// Token: 0x17000493 RID: 1171
	// (get) Token: 0x06001A4C RID: 6732 RVA: 0x00118B29 File Offset: 0x00116D29
	public PhaseOfDay Type
	{
		get
		{
			return this.type;
		}
	}

	// Token: 0x04002B35 RID: 11061
	[SerializeField]
	private PhaseOfDay type;
}
