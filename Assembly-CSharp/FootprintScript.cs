using System;
using UnityEngine;

// Token: 0x020002D3 RID: 723
public class FootprintScript : MonoBehaviour
{
	// Token: 0x060014C6 RID: 5318 RVA: 0x000CCA2C File Offset: 0x000CAC2C
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

	// Token: 0x04002090 RID: 8336
	public YandereScript Yandere;

	// Token: 0x04002091 RID: 8337
	public Texture Footprint;

	// Token: 0x04002092 RID: 8338
	public Texture Flower;
}
