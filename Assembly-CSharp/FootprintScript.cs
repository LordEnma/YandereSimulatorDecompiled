using System;
using UnityEngine;

// Token: 0x020002D4 RID: 724
public class FootprintScript : MonoBehaviour
{
	// Token: 0x060014C8 RID: 5320 RVA: 0x000CCDC0 File Offset: 0x000CAFC0
	private void Start()
	{
		if (this.Yandere.Schoolwear == 0 || this.Yandere.Schoolwear == 2 || (this.Yandere.ClubAttire && this.Yandere.Club == ClubType.MartialArts) || this.Yandere.Hungry || this.Yandere.LucyHelmet.activeInHierarchy)
		{
			base.GetComponent<Renderer>().material.mainTexture = this.Footprint;
		}
		if (GameGlobals.CensorBlood)
		{
			base.GetComponent<Renderer>().material.mainTexture = this.Flower;
			base.transform.localScale = new Vector3(0.2f, 0.2f, 1f);
		}
	}

	// Token: 0x04002097 RID: 8343
	public YandereScript Yandere;

	// Token: 0x04002098 RID: 8344
	public Texture Footprint;

	// Token: 0x04002099 RID: 8345
	public Texture Flower;

	// Token: 0x0400209A RID: 8346
	public int StudentBloodID;
}
