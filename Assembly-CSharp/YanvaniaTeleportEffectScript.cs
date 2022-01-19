using System;
using UnityEngine;

// Token: 0x020004DD RID: 1245
public class YanvaniaTeleportEffectScript : MonoBehaviour
{
	// Token: 0x0600208E RID: 8334 RVA: 0x001DD930 File Offset: 0x001DBB30
	private void Start()
	{
		this.FirstBeam.material.color = new Color(this.FirstBeam.material.color.r, this.FirstBeam.material.color.g, this.FirstBeam.material.color.b, 0f);
		this.SecondBeam.material.color = new Color(this.SecondBeam.material.color.r, this.SecondBeam.material.color.g, this.SecondBeam.material.color.b, 0f);
		this.FirstBeam.transform.localScale = new Vector3(0f, this.FirstBeam.transform.localScale.y, 0f);
		this.SecondBeamParent.transform.localScale = new Vector3(this.SecondBeamParent.transform.localScale.x, 0f, this.SecondBeamParent.transform.localScale.z);
	}

	// Token: 0x0600208F RID: 8335 RVA: 0x001DDA67 File Offset: 0x001DBC67
	private void Update()
	{
	}

	// Token: 0x04004748 RID: 18248
	public YanvaniaDraculaScript Dracula;

	// Token: 0x04004749 RID: 18249
	public Transform SecondBeamParent;

	// Token: 0x0400474A RID: 18250
	public Renderer SecondBeam;

	// Token: 0x0400474B RID: 18251
	public Renderer FirstBeam;

	// Token: 0x0400474C RID: 18252
	public bool InformedDracula;

	// Token: 0x0400474D RID: 18253
	public float Timer;
}
