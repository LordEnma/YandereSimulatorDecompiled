using System;
using UnityEngine;

// Token: 0x020004DD RID: 1245
public class YanvaniaTeleportEffectScript : MonoBehaviour
{
	// Token: 0x06002094 RID: 8340 RVA: 0x001DE4E8 File Offset: 0x001DC6E8
	private void Start()
	{
		this.FirstBeam.material.color = new Color(this.FirstBeam.material.color.r, this.FirstBeam.material.color.g, this.FirstBeam.material.color.b, 0f);
		this.SecondBeam.material.color = new Color(this.SecondBeam.material.color.r, this.SecondBeam.material.color.g, this.SecondBeam.material.color.b, 0f);
		this.FirstBeam.transform.localScale = new Vector3(0f, this.FirstBeam.transform.localScale.y, 0f);
		this.SecondBeamParent.transform.localScale = new Vector3(this.SecondBeamParent.transform.localScale.x, 0f, this.SecondBeamParent.transform.localScale.z);
	}

	// Token: 0x06002095 RID: 8341 RVA: 0x001DE61F File Offset: 0x001DC81F
	private void Update()
	{
	}

	// Token: 0x04004759 RID: 18265
	public YanvaniaDraculaScript Dracula;

	// Token: 0x0400475A RID: 18266
	public Transform SecondBeamParent;

	// Token: 0x0400475B RID: 18267
	public Renderer SecondBeam;

	// Token: 0x0400475C RID: 18268
	public Renderer FirstBeam;

	// Token: 0x0400475D RID: 18269
	public bool InformedDracula;

	// Token: 0x0400475E RID: 18270
	public float Timer;
}
