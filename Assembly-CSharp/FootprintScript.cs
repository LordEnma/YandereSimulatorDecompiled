using System;
using UnityEngine;

// Token: 0x020002CE RID: 718
public class FootprintScript : MonoBehaviour
{
	// Token: 0x060014A1 RID: 5281 RVA: 0x000CA79C File Offset: 0x000C899C
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

	// Token: 0x04002041 RID: 8257
	public YandereScript Yandere;

	// Token: 0x04002042 RID: 8258
	public Texture Footprint;

	// Token: 0x04002043 RID: 8259
	public Texture Flower;
}
