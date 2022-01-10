using System;
using UnityEngine;

// Token: 0x020004DC RID: 1244
public class YanvaniaTeleportEffectScript : MonoBehaviour
{
	// Token: 0x0600208C RID: 8332 RVA: 0x001DCC60 File Offset: 0x001DAE60
	private void Start()
	{
		this.FirstBeam.material.color = new Color(this.FirstBeam.material.color.r, this.FirstBeam.material.color.g, this.FirstBeam.material.color.b, 0f);
		this.SecondBeam.material.color = new Color(this.SecondBeam.material.color.r, this.SecondBeam.material.color.g, this.SecondBeam.material.color.b, 0f);
		this.FirstBeam.transform.localScale = new Vector3(0f, this.FirstBeam.transform.localScale.y, 0f);
		this.SecondBeamParent.transform.localScale = new Vector3(this.SecondBeamParent.transform.localScale.x, 0f, this.SecondBeamParent.transform.localScale.z);
	}

	// Token: 0x0600208D RID: 8333 RVA: 0x001DCD97 File Offset: 0x001DAF97
	private void Update()
	{
	}

	// Token: 0x04004741 RID: 18241
	public YanvaniaDraculaScript Dracula;

	// Token: 0x04004742 RID: 18242
	public Transform SecondBeamParent;

	// Token: 0x04004743 RID: 18243
	public Renderer SecondBeam;

	// Token: 0x04004744 RID: 18244
	public Renderer FirstBeam;

	// Token: 0x04004745 RID: 18245
	public bool InformedDracula;

	// Token: 0x04004746 RID: 18246
	public float Timer;
}
