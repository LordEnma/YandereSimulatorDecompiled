using System;
using UnityEngine;

// Token: 0x02000414 RID: 1044
public class SciFiTabletScript : MonoBehaviour
{
	// Token: 0x06001C4F RID: 7247 RVA: 0x0014ADA2 File Offset: 0x00148FA2
	private void Start()
	{
		this.Holograms = this.Student.StudentManager.Holograms;
	}

	// Token: 0x06001C50 RID: 7248 RVA: 0x0014ADBC File Offset: 0x00148FBC
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

	// Token: 0x04003242 RID: 12866
	public StudentScript Student;

	// Token: 0x04003243 RID: 12867
	public HologramScript Holograms;

	// Token: 0x04003244 RID: 12868
	public Transform Finger;

	// Token: 0x04003245 RID: 12869
	public bool Updated;
}
