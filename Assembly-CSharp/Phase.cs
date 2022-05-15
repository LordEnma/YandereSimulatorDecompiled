using System;
using UnityEngine;

// Token: 0x0200039F RID: 927
[Serializable]
public class Phase
{
	// Token: 0x06001A95 RID: 6805 RVA: 0x0011D73E File Offset: 0x0011B93E
	public Phase(PhaseOfDay type)
	{
		this.type = type;
	}

	// Token: 0x17000499 RID: 1177
	// (get) Token: 0x06001A96 RID: 6806 RVA: 0x0011D74D File Offset: 0x0011B94D
	public PhaseOfDay Type
	{
		get
		{
			return this.type;
		}
	}

	// Token: 0x04002C06 RID: 11270
	[SerializeField]
	private PhaseOfDay type;
}
