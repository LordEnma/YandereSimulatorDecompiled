using System;
using UnityEngine;

// Token: 0x02000414 RID: 1044
public class SciFiTabletScript : MonoBehaviour
{
	// Token: 0x06001C51 RID: 7249 RVA: 0x0014AF3A File Offset: 0x0014913A
	private void Start()
	{
		this.Holograms = this.Student.StudentManager.Holograms;
	}

	// Token: 0x06001C52 RID: 7250 RVA: 0x0014AF54 File Offset: 0x00149154
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

	// Token: 0x04003245 RID: 12869
	public StudentScript Student;

	// Token: 0x04003246 RID: 12870
	public HologramScript Holograms;

	// Token: 0x04003247 RID: 12871
	public Transform Finger;

	// Token: 0x04003248 RID: 12872
	public bool Updated;
}
