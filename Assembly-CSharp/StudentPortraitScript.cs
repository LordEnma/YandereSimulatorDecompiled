using System;
using UnityEngine;

// Token: 0x02000454 RID: 1108
public class StudentPortraitScript : MonoBehaviour
{
	// Token: 0x06001DBC RID: 7612 RVA: 0x0016B727 File Offset: 0x00169927
	private void Start()
	{
		this.DeathShadow.SetActive(false);
		this.PrisonBars.SetActive(false);
		this.Panties.SetActive(false);
		this.Friend.SetActive(false);
	}

	// Token: 0x040037A5 RID: 14245
	public GameObject DeathShadow;

	// Token: 0x040037A6 RID: 14246
	public GameObject PrisonBars;

	// Token: 0x040037A7 RID: 14247
	public GameObject Panties;

	// Token: 0x040037A8 RID: 14248
	public GameObject Friend;

	// Token: 0x040037A9 RID: 14249
	public UITexture Portrait;
}
