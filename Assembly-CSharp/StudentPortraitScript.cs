using System;
using UnityEngine;

// Token: 0x02000456 RID: 1110
public class StudentPortraitScript : MonoBehaviour
{
	// Token: 0x06001DD1 RID: 7633 RVA: 0x0016CE1B File Offset: 0x0016B01B
	private void Start()
	{
		this.DeathShadow.SetActive(false);
		this.PrisonBars.SetActive(false);
		this.Panties.SetActive(false);
		this.Friend.SetActive(false);
	}

	// Token: 0x040037CA RID: 14282
	public GameObject DeathShadow;

	// Token: 0x040037CB RID: 14283
	public GameObject PrisonBars;

	// Token: 0x040037CC RID: 14284
	public GameObject Panties;

	// Token: 0x040037CD RID: 14285
	public GameObject Friend;

	// Token: 0x040037CE RID: 14286
	public UITexture Portrait;
}
