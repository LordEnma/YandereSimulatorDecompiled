using System;
using UnityEngine;

// Token: 0x020004DF RID: 1247
public class YanvaniaTeleportEffectScript : MonoBehaviour
{
	// Token: 0x060020A7 RID: 8359 RVA: 0x001DF780 File Offset: 0x001DD980
	private void Start()
	{
		this.FirstBeam.material.color = new Color(this.FirstBeam.material.color.r, this.FirstBeam.material.color.g, this.FirstBeam.material.color.b, 0f);
		this.SecondBeam.material.color = new Color(this.SecondBeam.material.color.r, this.SecondBeam.material.color.g, this.SecondBeam.material.color.b, 0f);
		this.FirstBeam.transform.localScale = new Vector3(0f, this.FirstBeam.transform.localScale.y, 0f);
		this.SecondBeamParent.transform.localScale = new Vector3(this.SecondBeamParent.transform.localScale.x, 0f, this.SecondBeamParent.transform.localScale.z);
	}

	// Token: 0x060020A8 RID: 8360 RVA: 0x001DF8B7 File Offset: 0x001DDAB7
	private void Update()
	{
	}

	// Token: 0x04004775 RID: 18293
	public YanvaniaDraculaScript Dracula;

	// Token: 0x04004776 RID: 18294
	public Transform SecondBeamParent;

	// Token: 0x04004777 RID: 18295
	public Renderer SecondBeam;

	// Token: 0x04004778 RID: 18296
	public Renderer FirstBeam;

	// Token: 0x04004779 RID: 18297
	public bool InformedDracula;

	// Token: 0x0400477A RID: 18298
	public float Timer;
}
