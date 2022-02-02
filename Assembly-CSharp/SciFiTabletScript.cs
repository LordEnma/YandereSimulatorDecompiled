using System;
using UnityEngine;

// Token: 0x02000414 RID: 1044
public class SciFiTabletScript : MonoBehaviour
{
	// Token: 0x06001C4F RID: 7247 RVA: 0x0014AC9E File Offset: 0x00148E9E
	private void Start()
	{
		this.Holograms = this.Student.StudentManager.Holograms;
	}

	// Token: 0x06001C50 RID: 7248 RVA: 0x0014ACB8 File Offset: 0x00148EB8
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

	// Token: 0x04003241 RID: 12865
	public StudentScript Student;

	// Token: 0x04003242 RID: 12866
	public HologramScript Holograms;

	// Token: 0x04003243 RID: 12867
	public Transform Finger;

	// Token: 0x04003244 RID: 12868
	public bool Updated;
}
