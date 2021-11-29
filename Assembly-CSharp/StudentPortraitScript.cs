using System;
using UnityEngine;

// Token: 0x02000450 RID: 1104
public class StudentPortraitScript : MonoBehaviour
{
	// Token: 0x06001DA5 RID: 7589 RVA: 0x0016929B File Offset: 0x0016749B
	private void Start()
	{
		this.DeathShadow.SetActive(false);
		this.PrisonBars.SetActive(false);
		this.Panties.SetActive(false);
		this.Friend.SetActive(false);
	}

	// Token: 0x04003757 RID: 14167
	public GameObject DeathShadow;

	// Token: 0x04003758 RID: 14168
	public GameObject PrisonBars;

	// Token: 0x04003759 RID: 14169
	public GameObject Panties;

	// Token: 0x0400375A RID: 14170
	public GameObject Friend;

	// Token: 0x0400375B RID: 14171
	public UITexture Portrait;
}
