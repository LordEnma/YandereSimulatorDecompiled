using System;
using UnityEngine;

// Token: 0x0200045B RID: 1115
public class StudentPortraitScript : MonoBehaviour
{
	// Token: 0x06001DEE RID: 7662 RVA: 0x0016F833 File Offset: 0x0016DA33
	private void Start()
	{
		this.DeathShadow.SetActive(false);
		this.PrisonBars.SetActive(false);
		this.Panties.SetActive(false);
		this.Friend.SetActive(false);
	}

	// Token: 0x04003849 RID: 14409
	public GameObject DeathShadow;

	// Token: 0x0400384A RID: 14410
	public GameObject PrisonBars;

	// Token: 0x0400384B RID: 14411
	public GameObject Panties;

	// Token: 0x0400384C RID: 14412
	public GameObject Friend;

	// Token: 0x0400384D RID: 14413
	public UITexture Portrait;
}
