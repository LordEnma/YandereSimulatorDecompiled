using System;
using UnityEngine;

// Token: 0x0200045D RID: 1117
public class StudentPortraitScript : MonoBehaviour
{
	// Token: 0x06001E03 RID: 7683 RVA: 0x001710AF File Offset: 0x0016F2AF
	private void Start()
	{
		this.DeathShadow.SetActive(false);
		this.PrisonBars.SetActive(false);
		this.Panties.SetActive(false);
		this.Friend.SetActive(false);
	}

	// Token: 0x0400386A RID: 14442
	public GameObject DeathShadow;

	// Token: 0x0400386B RID: 14443
	public GameObject PrisonBars;

	// Token: 0x0400386C RID: 14444
	public GameObject Panties;

	// Token: 0x0400386D RID: 14445
	public GameObject Friend;

	// Token: 0x0400386E RID: 14446
	public UITexture Portrait;
}
