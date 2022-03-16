using System;
using UnityEngine;

// Token: 0x0200039B RID: 923
[Serializable]
public class Phase
{
	// Token: 0x06001A7A RID: 6778 RVA: 0x0011BD5E File Offset: 0x00119F5E
	public Phase(PhaseOfDay type)
	{
		this.type = type;
	}

	// Token: 0x17000497 RID: 1175
	// (get) Token: 0x06001A7B RID: 6779 RVA: 0x0011BD6D File Offset: 0x00119F6D
	public PhaseOfDay Type
	{
		get
		{
			return this.type;
		}
	}

	// Token: 0x04002BCB RID: 11211
	[SerializeField]
	private PhaseOfDay type;
}
