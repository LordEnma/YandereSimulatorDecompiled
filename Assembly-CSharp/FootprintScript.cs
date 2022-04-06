using System;
using UnityEngine;

// Token: 0x020002D3 RID: 723
public class FootprintScript : MonoBehaviour
{
	// Token: 0x060014C0 RID: 5312 RVA: 0x000CC3D0 File Offset: 0x000CA5D0
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

	// Token: 0x04002085 RID: 8325
	public YandereScript Yandere;

	// Token: 0x04002086 RID: 8326
	public Texture Footprint;

	// Token: 0x04002087 RID: 8327
	public Texture Flower;
}
