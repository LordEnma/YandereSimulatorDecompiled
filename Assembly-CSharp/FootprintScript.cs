using System;
using UnityEngine;

// Token: 0x020002D1 RID: 721
public class FootprintScript : MonoBehaviour
{
	// Token: 0x060014B7 RID: 5303 RVA: 0x000CC08C File Offset: 0x000CA28C
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

	// Token: 0x0400207E RID: 8318
	public YandereScript Yandere;

	// Token: 0x0400207F RID: 8319
	public Texture Footprint;

	// Token: 0x04002080 RID: 8320
	public Texture Flower;
}
