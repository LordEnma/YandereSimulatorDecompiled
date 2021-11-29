using System;
using UnityEngine;

// Token: 0x020004D8 RID: 1240
public class YanvaniaTeleportEffectScript : MonoBehaviour
{
	// Token: 0x0600206D RID: 8301 RVA: 0x001DA59C File Offset: 0x001D879C
	private void Start()
	{
		this.FirstBeam.material.color = new Color(this.FirstBeam.material.color.r, this.FirstBeam.material.color.g, this.FirstBeam.material.color.b, 0f);
		this.SecondBeam.material.color = new Color(this.SecondBeam.material.color.r, this.SecondBeam.material.color.g, this.SecondBeam.material.color.b, 0f);
		this.FirstBeam.transform.localScale = new Vector3(0f, this.FirstBeam.transform.localScale.y, 0f);
		this.SecondBeamParent.transform.localScale = new Vector3(this.SecondBeamParent.transform.localScale.x, 0f, this.SecondBeamParent.transform.localScale.z);
	}

	// Token: 0x0600206E RID: 8302 RVA: 0x001DA6D3 File Offset: 0x001D88D3
	private void Update()
	{
	}

	// Token: 0x040046E5 RID: 18149
	public YanvaniaDraculaScript Dracula;

	// Token: 0x040046E6 RID: 18150
	public Transform SecondBeamParent;

	// Token: 0x040046E7 RID: 18151
	public Renderer SecondBeam;

	// Token: 0x040046E8 RID: 18152
	public Renderer FirstBeam;

	// Token: 0x040046E9 RID: 18153
	public bool InformedDracula;

	// Token: 0x040046EA RID: 18154
	public float Timer;
}
