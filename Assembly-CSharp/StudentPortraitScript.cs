using System;
using UnityEngine;

// Token: 0x02000453 RID: 1107
public class StudentPortraitScript : MonoBehaviour
{
	// Token: 0x06001DBA RID: 7610 RVA: 0x0016AADB File Offset: 0x00168CDB
	private void Start()
	{
		this.DeathShadow.SetActive(false);
		this.PrisonBars.SetActive(false);
		this.Panties.SetActive(false);
		this.Friend.SetActive(false);
	}

	// Token: 0x0400379E RID: 14238
	public GameObject DeathShadow;

	// Token: 0x0400379F RID: 14239
	public GameObject PrisonBars;

	// Token: 0x040037A0 RID: 14240
	public GameObject Panties;

	// Token: 0x040037A1 RID: 14241
	public GameObject Friend;

	// Token: 0x040037A2 RID: 14242
	public UITexture Portrait;
}
