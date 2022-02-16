using System;
using UnityEngine;

// Token: 0x020002D0 RID: 720
public class FootprintScript : MonoBehaviour
{
	// Token: 0x060014AB RID: 5291 RVA: 0x000CB1BC File Offset: 0x000C93BC
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

	// Token: 0x04002055 RID: 8277
	public YandereScript Yandere;

	// Token: 0x04002056 RID: 8278
	public Texture Footprint;

	// Token: 0x04002057 RID: 8279
	public Texture Flower;
}
