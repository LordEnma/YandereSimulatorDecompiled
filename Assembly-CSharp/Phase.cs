using System;
using UnityEngine;

// Token: 0x0200039E RID: 926
[Serializable]
public class Phase
{
	// Token: 0x06001A87 RID: 6791 RVA: 0x0011C56A File Offset: 0x0011A76A
	public Phase(PhaseOfDay type)
	{
		this.type = type;
	}

	// Token: 0x17000497 RID: 1175
	// (get) Token: 0x06001A88 RID: 6792 RVA: 0x0011C579 File Offset: 0x0011A779
	public PhaseOfDay Type
	{
		get
		{
			return this.type;
		}
	}

	// Token: 0x04002BE3 RID: 11235
	[SerializeField]
	private PhaseOfDay type;
}
