using System;
using UnityEngine;

// Token: 0x0200045C RID: 1116
public class StudentPortraitScript : MonoBehaviour
{
	// Token: 0x06001DF5 RID: 7669 RVA: 0x0016FB83 File Offset: 0x0016DD83
	private void Start()
	{
		this.DeathShadow.SetActive(false);
		this.PrisonBars.SetActive(false);
		this.Panties.SetActive(false);
		this.Friend.SetActive(false);
	}

	// Token: 0x0400384C RID: 14412
	public GameObject DeathShadow;

	// Token: 0x0400384D RID: 14413
	public GameObject PrisonBars;

	// Token: 0x0400384E RID: 14414
	public GameObject Panties;

	// Token: 0x0400384F RID: 14415
	public GameObject Friend;

	// Token: 0x04003850 RID: 14416
	public UITexture Portrait;
}
