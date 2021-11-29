using System;
using UnityEngine;

// Token: 0x02000449 RID: 1097
public class StringScript : MonoBehaviour
{
	// Token: 0x06001D15 RID: 7445 RVA: 0x0015A8F3 File Offset: 0x00158AF3
	private void Start()
	{
		if (this.ArrayID == 0)
		{
			this.Target.position = this.Origin.position;
		}
	}

	// Token: 0x06001D16 RID: 7446 RVA: 0x0015A914 File Offset: 0x00158B14
	private void Update()
	{
		this.String.position = this.Origin.position;
		this.String.LookAt(this.Target);
		this.String.localScale = new Vector3(this.String.localScale.x, this.String.localScale.y, Vector3.Distance(this.Origin.position, this.Target.position) * 0.5f);
	}

	// Token: 0x0400351D RID: 13597
	public Transform Origin;

	// Token: 0x0400351E RID: 13598
	public Transform Target;

	// Token: 0x0400351F RID: 13599
	public Transform String;

	// Token: 0x04003520 RID: 13600
	public int ArrayID;
}
