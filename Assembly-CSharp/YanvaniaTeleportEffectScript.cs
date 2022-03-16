using System;
using UnityEngine;

// Token: 0x020004E4 RID: 1252
public class YanvaniaTeleportEffectScript : MonoBehaviour
{
	// Token: 0x060020C5 RID: 8389 RVA: 0x001E20C0 File Offset: 0x001E02C0
	private void Start()
	{
		this.FirstBeam.material.color = new Color(this.FirstBeam.material.color.r, this.FirstBeam.material.color.g, this.FirstBeam.material.color.b, 0f);
		this.SecondBeam.material.color = new Color(this.SecondBeam.material.color.r, this.SecondBeam.material.color.g, this.SecondBeam.material.color.b, 0f);
		this.FirstBeam.transform.localScale = new Vector3(0f, this.FirstBeam.transform.localScale.y, 0f);
		this.SecondBeamParent.transform.localScale = new Vector3(this.SecondBeamParent.transform.localScale.x, 0f, this.SecondBeamParent.transform.localScale.z);
	}

	// Token: 0x060020C6 RID: 8390 RVA: 0x001E21F7 File Offset: 0x001E03F7
	private void Update()
	{
	}

	// Token: 0x040047F1 RID: 18417
	public YanvaniaDraculaScript Dracula;

	// Token: 0x040047F2 RID: 18418
	public Transform SecondBeamParent;

	// Token: 0x040047F3 RID: 18419
	public Renderer SecondBeam;

	// Token: 0x040047F4 RID: 18420
	public Renderer FirstBeam;

	// Token: 0x040047F5 RID: 18421
	public bool InformedDracula;

	// Token: 0x040047F6 RID: 18422
	public float Timer;
}
