using System;
using UnityEngine;

// Token: 0x02000410 RID: 1040
public class SciFiTabletScript : MonoBehaviour
{
	// Token: 0x06001C3B RID: 7227 RVA: 0x0014810A File Offset: 0x0014630A
	private void Start()
	{
		this.Holograms = this.Student.StudentManager.Holograms;
	}

	// Token: 0x06001C3C RID: 7228 RVA: 0x00148124 File Offset: 0x00146324
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

	// Token: 0x040031FE RID: 12798
	public StudentScript Student;

	// Token: 0x040031FF RID: 12799
	public HologramScript Holograms;

	// Token: 0x04003200 RID: 12800
	public Transform Finger;

	// Token: 0x04003201 RID: 12801
	public bool Updated;
}
