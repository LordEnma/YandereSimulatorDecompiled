using System;
using UnityEngine;

// Token: 0x020004EB RID: 1259
public class YanvaniaTeleportEffectScript : MonoBehaviour
{
	// Token: 0x060020F6 RID: 8438 RVA: 0x001E7460 File Offset: 0x001E5660
	private void Start()
	{
		this.FirstBeam.material.color = new Color(this.FirstBeam.material.color.r, this.FirstBeam.material.color.g, this.FirstBeam.material.color.b, 0f);
		this.SecondBeam.material.color = new Color(this.SecondBeam.material.color.r, this.SecondBeam.material.color.g, this.SecondBeam.material.color.b, 0f);
		this.FirstBeam.transform.localScale = new Vector3(0f, this.FirstBeam.transform.localScale.y, 0f);
		this.SecondBeamParent.transform.localScale = new Vector3(this.SecondBeamParent.transform.localScale.x, 0f, this.SecondBeamParent.transform.localScale.z);
	}

	// Token: 0x060020F7 RID: 8439 RVA: 0x001E7597 File Offset: 0x001E5797
	private void Update()
	{
	}

	// Token: 0x04004875 RID: 18549
	public YanvaniaDraculaScript Dracula;

	// Token: 0x04004876 RID: 18550
	public Transform SecondBeamParent;

	// Token: 0x04004877 RID: 18551
	public Renderer SecondBeam;

	// Token: 0x04004878 RID: 18552
	public Renderer FirstBeam;

	// Token: 0x04004879 RID: 18553
	public bool InformedDracula;

	// Token: 0x0400487A RID: 18554
	public float Timer;
}
