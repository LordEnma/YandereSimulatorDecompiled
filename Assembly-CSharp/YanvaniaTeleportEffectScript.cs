using System;
using UnityEngine;

// Token: 0x020004DA RID: 1242
public class YanvaniaTeleportEffectScript : MonoBehaviour
{
	// Token: 0x06002081 RID: 8321 RVA: 0x001DC2C0 File Offset: 0x001DA4C0
	private void Start()
	{
		this.FirstBeam.material.color = new Color(this.FirstBeam.material.color.r, this.FirstBeam.material.color.g, this.FirstBeam.material.color.b, 0f);
		this.SecondBeam.material.color = new Color(this.SecondBeam.material.color.r, this.SecondBeam.material.color.g, this.SecondBeam.material.color.b, 0f);
		this.FirstBeam.transform.localScale = new Vector3(0f, this.FirstBeam.transform.localScale.y, 0f);
		this.SecondBeamParent.transform.localScale = new Vector3(this.SecondBeamParent.transform.localScale.x, 0f, this.SecondBeamParent.transform.localScale.z);
	}

	// Token: 0x06002082 RID: 8322 RVA: 0x001DC3F7 File Offset: 0x001DA5F7
	private void Update()
	{
	}

	// Token: 0x0400472D RID: 18221
	public YanvaniaDraculaScript Dracula;

	// Token: 0x0400472E RID: 18222
	public Transform SecondBeamParent;

	// Token: 0x0400472F RID: 18223
	public Renderer SecondBeam;

	// Token: 0x04004730 RID: 18224
	public Renderer FirstBeam;

	// Token: 0x04004731 RID: 18225
	public bool InformedDracula;

	// Token: 0x04004732 RID: 18226
	public float Timer;
}
