using System;
using UnityEngine;

// Token: 0x02000451 RID: 1105
public class StudentPortraitScript : MonoBehaviour
{
	// Token: 0x06001DAF RID: 7599 RVA: 0x0016A1BB File Offset: 0x001683BB
	private void Start()
	{
		this.DeathShadow.SetActive(false);
		this.PrisonBars.SetActive(false);
		this.Panties.SetActive(false);
		this.Friend.SetActive(false);
	}

	// Token: 0x0400378A RID: 14218
	public GameObject DeathShadow;

	// Token: 0x0400378B RID: 14219
	public GameObject PrisonBars;

	// Token: 0x0400378C RID: 14220
	public GameObject Panties;

	// Token: 0x0400378D RID: 14221
	public GameObject Friend;

	// Token: 0x0400378E RID: 14222
	public UITexture Portrait;
}
