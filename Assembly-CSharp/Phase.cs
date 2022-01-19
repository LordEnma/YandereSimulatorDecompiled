using System;
using UnityEngine;

// Token: 0x02000399 RID: 921
[Serializable]
public class Phase
{
	// Token: 0x06001A5C RID: 6748 RVA: 0x00119AE6 File Offset: 0x00117CE6
	public Phase(PhaseOfDay type)
	{
		this.type = type;
	}

	// Token: 0x17000494 RID: 1172
	// (get) Token: 0x06001A5D RID: 6749 RVA: 0x00119AF5 File Offset: 0x00117CF5
	public PhaseOfDay Type
	{
		get
		{
			return this.type;
		}
	}

	// Token: 0x04002B6C RID: 11116
	[SerializeField]
	private PhaseOfDay type;
}
