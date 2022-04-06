using System;
using UnityEngine;

// Token: 0x0200041B RID: 1051
public class SciFiTabletScript : MonoBehaviour
{
	// Token: 0x06001C80 RID: 7296 RVA: 0x0014DE9A File Offset: 0x0014C09A
	private void Start()
	{
		this.Holograms = this.Student.StudentManager.Holograms;
	}

	// Token: 0x06001C81 RID: 7297 RVA: 0x0014DEB4 File Offset: 0x0014C0B4
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

	// Token: 0x040032C4 RID: 12996
	public StudentScript Student;

	// Token: 0x040032C5 RID: 12997
	public HologramScript Holograms;

	// Token: 0x040032C6 RID: 12998
	public Transform Finger;

	// Token: 0x040032C7 RID: 12999
	public bool Updated;
}
