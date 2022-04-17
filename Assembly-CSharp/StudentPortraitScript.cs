using System;
using UnityEngine;

// Token: 0x0200045C RID: 1116
public class StudentPortraitScript : MonoBehaviour
{
	// Token: 0x06001DFB RID: 7675 RVA: 0x00170193 File Offset: 0x0016E393
	private void Start()
	{
		this.DeathShadow.SetActive(false);
		this.PrisonBars.SetActive(false);
		this.Panties.SetActive(false);
		this.Friend.SetActive(false);
	}

	// Token: 0x04003858 RID: 14424
	public GameObject DeathShadow;

	// Token: 0x04003859 RID: 14425
	public GameObject PrisonBars;

	// Token: 0x0400385A RID: 14426
	public GameObject Panties;

	// Token: 0x0400385B RID: 14427
	public GameObject Friend;

	// Token: 0x0400385C RID: 14428
	public UITexture Portrait;
}
