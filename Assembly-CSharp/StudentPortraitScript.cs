using System;
using UnityEngine;

// Token: 0x02000456 RID: 1110
public class StudentPortraitScript : MonoBehaviour
{
	// Token: 0x06001DD4 RID: 7636 RVA: 0x0016D3F3 File Offset: 0x0016B5F3
	private void Start()
	{
		this.DeathShadow.SetActive(false);
		this.PrisonBars.SetActive(false);
		this.Panties.SetActive(false);
		this.Friend.SetActive(false);
	}

	// Token: 0x040037E1 RID: 14305
	public GameObject DeathShadow;

	// Token: 0x040037E2 RID: 14306
	public GameObject PrisonBars;

	// Token: 0x040037E3 RID: 14307
	public GameObject Panties;

	// Token: 0x040037E4 RID: 14308
	public GameObject Friend;

	// Token: 0x040037E5 RID: 14309
	public UITexture Portrait;
}
