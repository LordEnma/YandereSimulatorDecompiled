using System;
using UnityEngine;

// Token: 0x02000451 RID: 1105
public class StudentPortraitScript : MonoBehaviour
{
	// Token: 0x06001DAD RID: 7597 RVA: 0x00169D6F File Offset: 0x00167F6F
	private void Start()
	{
		this.DeathShadow.SetActive(false);
		this.PrisonBars.SetActive(false);
		this.Panties.SetActive(false);
		this.Friend.SetActive(false);
	}

	// Token: 0x04003783 RID: 14211
	public GameObject DeathShadow;

	// Token: 0x04003784 RID: 14212
	public GameObject PrisonBars;

	// Token: 0x04003785 RID: 14213
	public GameObject Panties;

	// Token: 0x04003786 RID: 14214
	public GameObject Friend;

	// Token: 0x04003787 RID: 14215
	public UITexture Portrait;
}
