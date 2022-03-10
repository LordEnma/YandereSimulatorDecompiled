using System;
using UnityEngine;

// Token: 0x0200039B RID: 923
[Serializable]
public class Phase
{
	// Token: 0x06001A70 RID: 6768 RVA: 0x0011B24E File Offset: 0x0011944E
	public Phase(PhaseOfDay type)
	{
		this.type = type;
	}

	// Token: 0x17000496 RID: 1174
	// (get) Token: 0x06001A71 RID: 6769 RVA: 0x0011B25D File Offset: 0x0011945D
	public PhaseOfDay Type
	{
		get
		{
			return this.type;
		}
	}

	// Token: 0x04002BA2 RID: 11170
	[SerializeField]
	private PhaseOfDay type;
}
