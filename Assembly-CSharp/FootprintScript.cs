using System;
using UnityEngine;

// Token: 0x020002D1 RID: 721
public class FootprintScript : MonoBehaviour
{
	// Token: 0x060014B4 RID: 5300 RVA: 0x000CBAA0 File Offset: 0x000C9CA0
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
		UnityEngine.Object.Destroy(this);
	}

	// Token: 0x04002064 RID: 8292
	public YandereScript Yandere;

	// Token: 0x04002065 RID: 8293
	public Texture Footprint;

	// Token: 0x04002066 RID: 8294
	public Texture Flower;
}
