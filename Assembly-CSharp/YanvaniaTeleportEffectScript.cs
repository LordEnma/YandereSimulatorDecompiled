using System;
using UnityEngine;

// Token: 0x020004DA RID: 1242
public class YanvaniaTeleportEffectScript : MonoBehaviour
{
	// Token: 0x0600207E RID: 8318 RVA: 0x001DBCD0 File Offset: 0x001D9ED0
	private void Start()
	{
		this.FirstBeam.material.color = new Color(this.FirstBeam.material.color.r, this.FirstBeam.material.color.g, this.FirstBeam.material.color.b, 0f);
		this.SecondBeam.material.color = new Color(this.SecondBeam.material.color.r, this.SecondBeam.material.color.g, this.SecondBeam.material.color.b, 0f);
		this.FirstBeam.transform.localScale = new Vector3(0f, this.FirstBeam.transform.localScale.y, 0f);
		this.SecondBeamParent.transform.localScale = new Vector3(this.SecondBeamParent.transform.localScale.x, 0f, this.SecondBeamParent.transform.localScale.z);
	}

	// Token: 0x0600207F RID: 8319 RVA: 0x001DBE07 File Offset: 0x001DA007
	private void Update()
	{
	}

	// Token: 0x04004724 RID: 18212
	public YanvaniaDraculaScript Dracula;

	// Token: 0x04004725 RID: 18213
	public Transform SecondBeamParent;

	// Token: 0x04004726 RID: 18214
	public Renderer SecondBeam;

	// Token: 0x04004727 RID: 18215
	public Renderer FirstBeam;

	// Token: 0x04004728 RID: 18216
	public bool InformedDracula;

	// Token: 0x04004729 RID: 18217
	public float Timer;
}
