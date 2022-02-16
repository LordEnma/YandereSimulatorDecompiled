using System;
using UnityEngine;

// Token: 0x02000415 RID: 1045
public class SciFiTabletScript : MonoBehaviour
{
	// Token: 0x06001C58 RID: 7256 RVA: 0x0014B23A File Offset: 0x0014943A
	private void Start()
	{
		this.Holograms = this.Student.StudentManager.Holograms;
	}

	// Token: 0x06001C59 RID: 7257 RVA: 0x0014B254 File Offset: 0x00149454
	private void Update()
	{
		if ((double)Vector3.Distance(this.Finger.position, base.transform.position) < 0.1)
		{
			if (!this.Updated)
			{
				this.Holograms.UpdateHolograms();
				this.Updated = true;
				return;
			}
		}
		else
		{
			this.Updated = false;
		}
	}

	// Token: 0x0400324B RID: 12875
	public StudentScript Student;

	// Token: 0x0400324C RID: 12876
	public HologramScript Holograms;

	// Token: 0x0400324D RID: 12877
	public Transform Finger;

	// Token: 0x0400324E RID: 12878
	public bool Updated;
}
