using System;
using UnityEngine;

// Token: 0x0200039D RID: 925
[Serializable]
public class Phase
{
	// Token: 0x06001A81 RID: 6785 RVA: 0x0011C3BE File Offset: 0x0011A5BE
	public Phase(PhaseOfDay type)
	{
		this.type = type;
	}

	// Token: 0x17000497 RID: 1175
	// (get) Token: 0x06001A82 RID: 6786 RVA: 0x0011C3CD File Offset: 0x0011A5CD
	public PhaseOfDay Type
	{
		get
		{
			return this.type;
		}
	}

	// Token: 0x04002BE0 RID: 11232
	[SerializeField]
	private PhaseOfDay type;
}
