using System;
using UnityEngine;

// Token: 0x020004EA RID: 1258
public class YanvaniaTeleportEffectScript : MonoBehaviour
{
	// Token: 0x060020EC RID: 8428 RVA: 0x001E5E10 File Offset: 0x001E4010
	private void Start()
	{
		this.FirstBeam.material.color = new Color(this.FirstBeam.material.color.r, this.FirstBeam.material.color.g, this.FirstBeam.material.color.b, 0f);
		this.SecondBeam.material.color = new Color(this.SecondBeam.material.color.r, this.SecondBeam.material.color.g, this.SecondBeam.material.color.b, 0f);
		this.FirstBeam.transform.localScale = new Vector3(0f, this.FirstBeam.transform.localScale.y, 0f);
		this.SecondBeamParent.transform.localScale = new Vector3(this.SecondBeamParent.transform.localScale.x, 0f, this.SecondBeamParent.transform.localScale.z);
	}

	// Token: 0x060020ED RID: 8429 RVA: 0x001E5F47 File Offset: 0x001E4147
	private void Update()
	{
	}

	// Token: 0x0400484E RID: 18510
	public YanvaniaDraculaScript Dracula;

	// Token: 0x0400484F RID: 18511
	public Transform SecondBeamParent;

	// Token: 0x04004850 RID: 18512
	public Renderer SecondBeam;

	// Token: 0x04004851 RID: 18513
	public Renderer FirstBeam;

	// Token: 0x04004852 RID: 18514
	public bool InformedDracula;

	// Token: 0x04004853 RID: 18515
	public float Timer;
}
