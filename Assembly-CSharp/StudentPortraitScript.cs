using System;
using UnityEngine;

// Token: 0x02000454 RID: 1108
public class StudentPortraitScript : MonoBehaviour
{
	// Token: 0x06001DBF RID: 7615 RVA: 0x0016BE53 File Offset: 0x0016A053
	private void Start()
	{
		this.DeathShadow.SetActive(false);
		this.PrisonBars.SetActive(false);
		this.Panties.SetActive(false);
		this.Friend.SetActive(false);
	}

	// Token: 0x040037AE RID: 14254
	public GameObject DeathShadow;

	// Token: 0x040037AF RID: 14255
	public GameObject PrisonBars;

	// Token: 0x040037B0 RID: 14256
	public GameObject Panties;

	// Token: 0x040037B1 RID: 14257
	public GameObject Friend;

	// Token: 0x040037B2 RID: 14258
	public UITexture Portrait;
}
