using System;
using UnityEngine;

// Token: 0x020004E9 RID: 1257
public class YanvaniaTeleportEffectScript : MonoBehaviour
{
	// Token: 0x060020DB RID: 8411 RVA: 0x001E3E2C File Offset: 0x001E202C
	private void Start()
	{
		this.FirstBeam.material.color = new Color(this.FirstBeam.material.color.r, this.FirstBeam.material.color.g, this.FirstBeam.material.color.b, 0f);
		this.SecondBeam.material.color = new Color(this.SecondBeam.material.color.r, this.SecondBeam.material.color.g, this.SecondBeam.material.color.b, 0f);
		this.FirstBeam.transform.localScale = new Vector3(0f, this.FirstBeam.transform.localScale.y, 0f);
		this.SecondBeamParent.transform.localScale = new Vector3(this.SecondBeamParent.transform.localScale.x, 0f, this.SecondBeamParent.transform.localScale.z);
	}

	// Token: 0x060020DC RID: 8412 RVA: 0x001E3F63 File Offset: 0x001E2163
	private void Update()
	{
	}

	// Token: 0x04004826 RID: 18470
	public YanvaniaDraculaScript Dracula;

	// Token: 0x04004827 RID: 18471
	public Transform SecondBeamParent;

	// Token: 0x04004828 RID: 18472
	public Renderer SecondBeam;

	// Token: 0x04004829 RID: 18473
	public Renderer FirstBeam;

	// Token: 0x0400482A RID: 18474
	public bool InformedDracula;

	// Token: 0x0400482B RID: 18475
	public float Timer;
}
