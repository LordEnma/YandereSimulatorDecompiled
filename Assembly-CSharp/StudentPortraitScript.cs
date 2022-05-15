using System;
using UnityEngine;

// Token: 0x0200045E RID: 1118
public class StudentPortraitScript : MonoBehaviour
{
	// Token: 0x06001E0C RID: 7692 RVA: 0x0017219B File Offset: 0x0017039B
	private void Start()
	{
		this.DeathShadow.SetActive(false);
		this.PrisonBars.SetActive(false);
		this.Panties.SetActive(false);
		this.Friend.SetActive(false);
	}

	// Token: 0x04003887 RID: 14471
	public GameObject DeathShadow;

	// Token: 0x04003888 RID: 14472
	public GameObject PrisonBars;

	// Token: 0x04003889 RID: 14473
	public GameObject Panties;

	// Token: 0x0400388A RID: 14474
	public GameObject Friend;

	// Token: 0x0400388B RID: 14475
	public UITexture Portrait;
}
