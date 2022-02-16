using System;
using UnityEngine;

// Token: 0x02000455 RID: 1109
public class StudentPortraitScript : MonoBehaviour
{
	// Token: 0x06001DC8 RID: 7624 RVA: 0x0016C397 File Offset: 0x0016A597
	private void Start()
	{
		this.DeathShadow.SetActive(false);
		this.PrisonBars.SetActive(false);
		this.Panties.SetActive(false);
		this.Friend.SetActive(false);
	}

	// Token: 0x040037BA RID: 14266
	public GameObject DeathShadow;

	// Token: 0x040037BB RID: 14267
	public GameObject PrisonBars;

	// Token: 0x040037BC RID: 14268
	public GameObject Panties;

	// Token: 0x040037BD RID: 14269
	public GameObject Friend;

	// Token: 0x040037BE RID: 14270
	public UITexture Portrait;
}
