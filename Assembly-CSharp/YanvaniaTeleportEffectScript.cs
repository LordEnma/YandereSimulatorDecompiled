using System;
using UnityEngine;

// Token: 0x020004E9 RID: 1257
public class YanvaniaTeleportEffectScript : MonoBehaviour
{
	// Token: 0x060020E2 RID: 8418 RVA: 0x001E4888 File Offset: 0x001E2A88
	private void Start()
	{
		this.FirstBeam.material.color = new Color(this.FirstBeam.material.color.r, this.FirstBeam.material.color.g, this.FirstBeam.material.color.b, 0f);
		this.SecondBeam.material.color = new Color(this.SecondBeam.material.color.r, this.SecondBeam.material.color.g, this.SecondBeam.material.color.b, 0f);
		this.FirstBeam.transform.localScale = new Vector3(0f, this.FirstBeam.transform.localScale.y, 0f);
		this.SecondBeamParent.transform.localScale = new Vector3(this.SecondBeamParent.transform.localScale.x, 0f, this.SecondBeamParent.transform.localScale.z);
	}

	// Token: 0x060020E3 RID: 8419 RVA: 0x001E49BF File Offset: 0x001E2BBF
	private void Update()
	{
	}

	// Token: 0x04004838 RID: 18488
	public YanvaniaDraculaScript Dracula;

	// Token: 0x04004839 RID: 18489
	public Transform SecondBeamParent;

	// Token: 0x0400483A RID: 18490
	public Renderer SecondBeam;

	// Token: 0x0400483B RID: 18491
	public Renderer FirstBeam;

	// Token: 0x0400483C RID: 18492
	public bool InformedDracula;

	// Token: 0x0400483D RID: 18493
	public float Timer;
}
