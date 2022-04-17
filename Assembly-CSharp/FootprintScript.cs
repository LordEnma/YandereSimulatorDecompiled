using System;
using UnityEngine;

// Token: 0x020002D3 RID: 723
public class FootprintScript : MonoBehaviour
{
	// Token: 0x060014C2 RID: 5314 RVA: 0x000CC598 File Offset: 0x000CA798
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

	// Token: 0x04002087 RID: 8327
	public YandereScript Yandere;

	// Token: 0x04002088 RID: 8328
	public Texture Footprint;

	// Token: 0x04002089 RID: 8329
	public Texture Flower;
}
