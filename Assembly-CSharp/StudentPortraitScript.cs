using System;
using UnityEngine;

// Token: 0x02000454 RID: 1108
public class StudentPortraitScript : MonoBehaviour
{
	// Token: 0x06001DC1 RID: 7617 RVA: 0x0016C023 File Offset: 0x0016A223
	private void Start()
	{
		this.DeathShadow.SetActive(false);
		this.PrisonBars.SetActive(false);
		this.Panties.SetActive(false);
		this.Friend.SetActive(false);
	}

	// Token: 0x040037B1 RID: 14257
	public GameObject DeathShadow;

	// Token: 0x040037B2 RID: 14258
	public GameObject PrisonBars;

	// Token: 0x040037B3 RID: 14259
	public GameObject Panties;

	// Token: 0x040037B4 RID: 14260
	public GameObject Friend;

	// Token: 0x040037B5 RID: 14261
	public UITexture Portrait;
}
