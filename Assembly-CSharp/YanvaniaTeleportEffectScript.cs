using System;
using UnityEngine;

// Token: 0x020004E0 RID: 1248
public class YanvaniaTeleportEffectScript : MonoBehaviour
{
	// Token: 0x060020AD RID: 8365 RVA: 0x001E0158 File Offset: 0x001DE358
	private void Start()
	{
		this.FirstBeam.material.color = new Color(this.FirstBeam.material.color.r, this.FirstBeam.material.color.g, this.FirstBeam.material.color.b, 0f);
		this.SecondBeam.material.color = new Color(this.SecondBeam.material.color.r, this.SecondBeam.material.color.g, this.SecondBeam.material.color.b, 0f);
		this.FirstBeam.transform.localScale = new Vector3(0f, this.FirstBeam.transform.localScale.y, 0f);
		this.SecondBeamParent.transform.localScale = new Vector3(this.SecondBeamParent.transform.localScale.x, 0f, this.SecondBeamParent.transform.localScale.z);
	}

	// Token: 0x060020AE RID: 8366 RVA: 0x001E028F File Offset: 0x001DE48F
	private void Update()
	{
	}

	// Token: 0x04004792 RID: 18322
	public YanvaniaDraculaScript Dracula;

	// Token: 0x04004793 RID: 18323
	public Transform SecondBeamParent;

	// Token: 0x04004794 RID: 18324
	public Renderer SecondBeam;

	// Token: 0x04004795 RID: 18325
	public Renderer FirstBeam;

	// Token: 0x04004796 RID: 18326
	public bool InformedDracula;

	// Token: 0x04004797 RID: 18327
	public float Timer;
}
