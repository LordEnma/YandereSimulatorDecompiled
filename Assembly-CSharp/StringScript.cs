using System;
using UnityEngine;

// Token: 0x02000450 RID: 1104
public class StringScript : MonoBehaviour
{
	// Token: 0x06001D4E RID: 7502 RVA: 0x001603B3 File Offset: 0x0015E5B3
	private void Start()
	{
		if (this.ArrayID == 0)
		{
			this.Target.position = this.Origin.position;
		}
	}

	// Token: 0x06001D4F RID: 7503 RVA: 0x001603D4 File Offset: 0x0015E5D4
	private void Update()
	{
		this.String.position = this.Origin.position;
		this.String.LookAt(this.Target);
		this.String.localScale = new Vector3(this.String.localScale.x, this.String.localScale.y, Vector3.Distance(this.Origin.position, this.Target.position) * 0.5f);
	}

	// Token: 0x040035DB RID: 13787
	public Transform Origin;

	// Token: 0x040035DC RID: 13788
	public Transform Target;

	// Token: 0x040035DD RID: 13789
	public Transform String;

	// Token: 0x040035DE RID: 13790
	public int ArrayID;
}
