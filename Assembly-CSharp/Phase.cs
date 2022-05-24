using System;
using UnityEngine;

// Token: 0x0200039F RID: 927
[Serializable]
public class Phase
{
	// Token: 0x06001A96 RID: 6806 RVA: 0x0011D96E File Offset: 0x0011BB6E
	public Phase(PhaseOfDay type)
	{
		this.type = type;
	}

	// Token: 0x17000499 RID: 1177
	// (get) Token: 0x06001A97 RID: 6807 RVA: 0x0011D97D File Offset: 0x0011BB7D
	public PhaseOfDay Type
	{
		get
		{
			return this.type;
		}
	}

	// Token: 0x04002C0D RID: 11277
	[SerializeField]
	private PhaseOfDay type;
}
