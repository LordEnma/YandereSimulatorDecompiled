using System;
using UnityEngine;

// Token: 0x020002CF RID: 719
public class FootprintScript : MonoBehaviour
{
	// Token: 0x060014A6 RID: 5286 RVA: 0x000CB0C8 File Offset: 0x000C92C8
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

	// Token: 0x04002050 RID: 8272
	public YandereScript Yandere;

	// Token: 0x04002051 RID: 8273
	public Texture Footprint;

	// Token: 0x04002052 RID: 8274
	public Texture Flower;
}
