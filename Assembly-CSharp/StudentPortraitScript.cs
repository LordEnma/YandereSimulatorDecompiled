using System;
using UnityEngine;

// Token: 0x02000454 RID: 1108
public class StudentPortraitScript : MonoBehaviour
{
	// Token: 0x06001DBD RID: 7613 RVA: 0x0016BB8B File Offset: 0x00169D8B
	private void Start()
	{
		this.DeathShadow.SetActive(false);
		this.PrisonBars.SetActive(false);
		this.Panties.SetActive(false);
		this.Friend.SetActive(false);
	}

	// Token: 0x040037AB RID: 14251
	public GameObject DeathShadow;

	// Token: 0x040037AC RID: 14252
	public GameObject PrisonBars;

	// Token: 0x040037AD RID: 14253
	public GameObject Panties;

	// Token: 0x040037AE RID: 14254
	public GameObject Friend;

	// Token: 0x040037AF RID: 14255
	public UITexture Portrait;
}
