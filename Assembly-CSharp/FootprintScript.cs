using System;
using UnityEngine;

// Token: 0x020002CE RID: 718
public class FootprintScript : MonoBehaviour
{
	// Token: 0x060014A1 RID: 5281 RVA: 0x000CA554 File Offset: 0x000C8754
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

	// Token: 0x0400203E RID: 8254
	public YandereScript Yandere;

	// Token: 0x0400203F RID: 8255
	public Texture Footprint;

	// Token: 0x04002040 RID: 8256
	public Texture Flower;
}
