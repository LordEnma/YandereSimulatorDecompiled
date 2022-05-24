using System;
using UnityEngine;

// Token: 0x0200045E RID: 1118
public class StudentPortraitScript : MonoBehaviour
{
	// Token: 0x06001E0D RID: 7693 RVA: 0x0017252B File Offset: 0x0017072B
	private void Start()
	{
		this.DeathShadow.SetActive(false);
		this.PrisonBars.SetActive(false);
		this.Panties.SetActive(false);
		this.Friend.SetActive(false);
	}

	// Token: 0x0400388F RID: 14479
	public GameObject DeathShadow;

	// Token: 0x04003890 RID: 14480
	public GameObject PrisonBars;

	// Token: 0x04003891 RID: 14481
	public GameObject Panties;

	// Token: 0x04003892 RID: 14482
	public GameObject Friend;

	// Token: 0x04003893 RID: 14483
	public UITexture Portrait;
}
