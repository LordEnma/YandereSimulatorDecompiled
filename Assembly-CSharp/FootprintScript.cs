using System;
using UnityEngine;

// Token: 0x020002D2 RID: 722
public class FootprintScript : MonoBehaviour
{
	// Token: 0x060014BA RID: 5306 RVA: 0x000CC2C8 File Offset: 0x000CA4C8
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

	// Token: 0x04002083 RID: 8323
	public YandereScript Yandere;

	// Token: 0x04002084 RID: 8324
	public Texture Footprint;

	// Token: 0x04002085 RID: 8325
	public Texture Flower;
}
