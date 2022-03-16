using System;
using UnityEngine;

// Token: 0x02000458 RID: 1112
public class StudentPortraitScript : MonoBehaviour
{
	// Token: 0x06001DE4 RID: 7652 RVA: 0x0016E9E3 File Offset: 0x0016CBE3
	private void Start()
	{
		this.DeathShadow.SetActive(false);
		this.PrisonBars.SetActive(false);
		this.Panties.SetActive(false);
		this.Friend.SetActive(false);
	}

	// Token: 0x0400382A RID: 14378
	public GameObject DeathShadow;

	// Token: 0x0400382B RID: 14379
	public GameObject PrisonBars;

	// Token: 0x0400382C RID: 14380
	public GameObject Panties;

	// Token: 0x0400382D RID: 14381
	public GameObject Friend;

	// Token: 0x0400382E RID: 14382
	public UITexture Portrait;
}
