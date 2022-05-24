using System;
using UnityEngine;

// Token: 0x020004EB RID: 1259
public class YanvaniaTeleportEffectScript : MonoBehaviour
{
	// Token: 0x060020F7 RID: 8439 RVA: 0x001E79C8 File Offset: 0x001E5BC8
	private void Start()
	{
		this.FirstBeam.material.color = new Color(this.FirstBeam.material.color.r, this.FirstBeam.material.color.g, this.FirstBeam.material.color.b, 0f);
		this.SecondBeam.material.color = new Color(this.SecondBeam.material.color.r, this.SecondBeam.material.color.g, this.SecondBeam.material.color.b, 0f);
		this.FirstBeam.transform.localScale = new Vector3(0f, this.FirstBeam.transform.localScale.y, 0f);
		this.SecondBeamParent.transform.localScale = new Vector3(this.SecondBeamParent.transform.localScale.x, 0f, this.SecondBeamParent.transform.localScale.z);
	}

	// Token: 0x060020F8 RID: 8440 RVA: 0x001E7AFF File Offset: 0x001E5CFF
	private void Update()
	{
	}

	// Token: 0x0400487E RID: 18558
	public YanvaniaDraculaScript Dracula;

	// Token: 0x0400487F RID: 18559
	public Transform SecondBeamParent;

	// Token: 0x04004880 RID: 18560
	public Renderer SecondBeam;

	// Token: 0x04004881 RID: 18561
	public Renderer FirstBeam;

	// Token: 0x04004882 RID: 18562
	public bool InformedDracula;

	// Token: 0x04004883 RID: 18563
	public float Timer;
}
