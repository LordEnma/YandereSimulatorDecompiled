using System;
using UnityEngine;

// Token: 0x020004DD RID: 1245
public class YanvaniaTeleportEffectScript : MonoBehaviour
{
	// Token: 0x06002092 RID: 8338 RVA: 0x001DE1D0 File Offset: 0x001DC3D0
	private void Start()
	{
		this.FirstBeam.material.color = new Color(this.FirstBeam.material.color.r, this.FirstBeam.material.color.g, this.FirstBeam.material.color.b, 0f);
		this.SecondBeam.material.color = new Color(this.SecondBeam.material.color.r, this.SecondBeam.material.color.g, this.SecondBeam.material.color.b, 0f);
		this.FirstBeam.transform.localScale = new Vector3(0f, this.FirstBeam.transform.localScale.y, 0f);
		this.SecondBeamParent.transform.localScale = new Vector3(this.SecondBeamParent.transform.localScale.x, 0f, this.SecondBeamParent.transform.localScale.z);
	}

	// Token: 0x06002093 RID: 8339 RVA: 0x001DE307 File Offset: 0x001DC507
	private void Update()
	{
	}

	// Token: 0x04004753 RID: 18259
	public YanvaniaDraculaScript Dracula;

	// Token: 0x04004754 RID: 18260
	public Transform SecondBeamParent;

	// Token: 0x04004755 RID: 18261
	public Renderer SecondBeam;

	// Token: 0x04004756 RID: 18262
	public Renderer FirstBeam;

	// Token: 0x04004757 RID: 18263
	public bool InformedDracula;

	// Token: 0x04004758 RID: 18264
	public float Timer;
}
