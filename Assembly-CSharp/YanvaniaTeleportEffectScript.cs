using System;
using UnityEngine;

// Token: 0x020004E8 RID: 1256
public class YanvaniaTeleportEffectScript : MonoBehaviour
{
	// Token: 0x060020D3 RID: 8403 RVA: 0x001E38FC File Offset: 0x001E1AFC
	private void Start()
	{
		this.FirstBeam.material.color = new Color(this.FirstBeam.material.color.r, this.FirstBeam.material.color.g, this.FirstBeam.material.color.b, 0f);
		this.SecondBeam.material.color = new Color(this.SecondBeam.material.color.r, this.SecondBeam.material.color.g, this.SecondBeam.material.color.b, 0f);
		this.FirstBeam.transform.localScale = new Vector3(0f, this.FirstBeam.transform.localScale.y, 0f);
		this.SecondBeamParent.transform.localScale = new Vector3(this.SecondBeamParent.transform.localScale.x, 0f, this.SecondBeamParent.transform.localScale.z);
	}

	// Token: 0x060020D4 RID: 8404 RVA: 0x001E3A33 File Offset: 0x001E1C33
	private void Update()
	{
	}

	// Token: 0x04004822 RID: 18466
	public YanvaniaDraculaScript Dracula;

	// Token: 0x04004823 RID: 18467
	public Transform SecondBeamParent;

	// Token: 0x04004824 RID: 18468
	public Renderer SecondBeam;

	// Token: 0x04004825 RID: 18469
	public Renderer FirstBeam;

	// Token: 0x04004826 RID: 18470
	public bool InformedDracula;

	// Token: 0x04004827 RID: 18471
	public float Timer;
}
