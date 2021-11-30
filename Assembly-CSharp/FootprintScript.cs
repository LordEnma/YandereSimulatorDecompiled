using System;
using UnityEngine;

// Token: 0x020002CD RID: 717
public class FootprintScript : MonoBehaviour
{
	// Token: 0x0600149A RID: 5274 RVA: 0x000C9DB0 File Offset: 0x000C7FB0
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

	// Token: 0x0400201E RID: 8222
	public YandereScript Yandere;

	// Token: 0x0400201F RID: 8223
	public Texture Footprint;

	// Token: 0x04002020 RID: 8224
	public Texture Flower;
}
