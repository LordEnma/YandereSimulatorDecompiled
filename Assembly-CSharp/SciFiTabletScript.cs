using System;
using UnityEngine;

// Token: 0x02000414 RID: 1044
public class SciFiTabletScript : MonoBehaviour
{
	// Token: 0x06001C4E RID: 7246 RVA: 0x0014A86A File Offset: 0x00148A6A
	private void Start()
	{
		this.Holograms = this.Student.StudentManager.Holograms;
	}

	// Token: 0x06001C4F RID: 7247 RVA: 0x0014A884 File Offset: 0x00148A84
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

	// Token: 0x0400323B RID: 12859
	public StudentScript Student;

	// Token: 0x0400323C RID: 12860
	public HologramScript Holograms;

	// Token: 0x0400323D RID: 12861
	public Transform Finger;

	// Token: 0x0400323E RID: 12862
	public bool Updated;
}
