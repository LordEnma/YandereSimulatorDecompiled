using System;
using UnityEngine;

// Token: 0x020004DD RID: 1245
public class YanvaniaTeleportEffectScript : MonoBehaviour
{
	// Token: 0x06002097 RID: 8343 RVA: 0x001DE6EC File Offset: 0x001DC8EC
	private void Start()
	{
		this.FirstBeam.material.color = new Color(this.FirstBeam.material.color.r, this.FirstBeam.material.color.g, this.FirstBeam.material.color.b, 0f);
		this.SecondBeam.material.color = new Color(this.SecondBeam.material.color.r, this.SecondBeam.material.color.g, this.SecondBeam.material.color.b, 0f);
		this.FirstBeam.transform.localScale = new Vector3(0f, this.FirstBeam.transform.localScale.y, 0f);
		this.SecondBeamParent.transform.localScale = new Vector3(this.SecondBeamParent.transform.localScale.x, 0f, this.SecondBeamParent.transform.localScale.z);
	}

	// Token: 0x06002098 RID: 8344 RVA: 0x001DE823 File Offset: 0x001DCA23
	private void Update()
	{
	}

	// Token: 0x0400475C RID: 18268
	public YanvaniaDraculaScript Dracula;

	// Token: 0x0400475D RID: 18269
	public Transform SecondBeamParent;

	// Token: 0x0400475E RID: 18270
	public Renderer SecondBeam;

	// Token: 0x0400475F RID: 18271
	public Renderer FirstBeam;

	// Token: 0x04004760 RID: 18272
	public bool InformedDracula;

	// Token: 0x04004761 RID: 18273
	public float Timer;
}
