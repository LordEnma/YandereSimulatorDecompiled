using System;
using UnityEngine;

// Token: 0x020004DE RID: 1246
public class YanvaniaTeleportEffectScript : MonoBehaviour
{
	// Token: 0x0600209E RID: 8350 RVA: 0x001DEBA0 File Offset: 0x001DCDA0
	private void Start()
	{
		this.FirstBeam.material.color = new Color(this.FirstBeam.material.color.r, this.FirstBeam.material.color.g, this.FirstBeam.material.color.b, 0f);
		this.SecondBeam.material.color = new Color(this.SecondBeam.material.color.r, this.SecondBeam.material.color.g, this.SecondBeam.material.color.b, 0f);
		this.FirstBeam.transform.localScale = new Vector3(0f, this.FirstBeam.transform.localScale.y, 0f);
		this.SecondBeamParent.transform.localScale = new Vector3(this.SecondBeamParent.transform.localScale.x, 0f, this.SecondBeamParent.transform.localScale.z);
	}

	// Token: 0x0600209F RID: 8351 RVA: 0x001DECD7 File Offset: 0x001DCED7
	private void Update()
	{
	}

	// Token: 0x04004765 RID: 18277
	public YanvaniaDraculaScript Dracula;

	// Token: 0x04004766 RID: 18278
	public Transform SecondBeamParent;

	// Token: 0x04004767 RID: 18279
	public Renderer SecondBeam;

	// Token: 0x04004768 RID: 18280
	public Renderer FirstBeam;

	// Token: 0x04004769 RID: 18281
	public bool InformedDracula;

	// Token: 0x0400476A RID: 18282
	public float Timer;
}
