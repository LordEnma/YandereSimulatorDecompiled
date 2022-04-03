using System;
using UnityEngine;

// Token: 0x02000453 RID: 1107
public class StringScript : MonoBehaviour
{
	// Token: 0x06001D58 RID: 7512 RVA: 0x00160FFB File Offset: 0x0015F1FB
	private void Start()
	{
		if (this.ArrayID == 0)
		{
			this.Target.position = this.Origin.position;
		}
	}

	// Token: 0x06001D59 RID: 7513 RVA: 0x0016101C File Offset: 0x0015F21C
	private void Update()
	{
		this.String.position = this.Origin.position;
		this.String.LookAt(this.Target);
		this.String.localScale = new Vector3(this.String.localScale.x, this.String.localScale.y, Vector3.Distance(this.Origin.position, this.Target.position) * 0.5f);
	}

	// Token: 0x040035F8 RID: 13816
	public Transform Origin;

	// Token: 0x040035F9 RID: 13817
	public Transform Target;

	// Token: 0x040035FA RID: 13818
	public Transform String;

	// Token: 0x040035FB RID: 13819
	public int ArrayID;
}
