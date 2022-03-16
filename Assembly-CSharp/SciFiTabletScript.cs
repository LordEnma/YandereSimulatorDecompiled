using System;
using UnityEngine;

// Token: 0x02000417 RID: 1047
public class SciFiTabletScript : MonoBehaviour
{
	// Token: 0x06001C70 RID: 7280 RVA: 0x0014D092 File Offset: 0x0014B292
	private void Start()
	{
		this.Holograms = this.Student.StudentManager.Holograms;
	}

	// Token: 0x06001C71 RID: 7281 RVA: 0x0014D0AC File Offset: 0x0014B2AC
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

	// Token: 0x040032A5 RID: 12965
	public StudentScript Student;

	// Token: 0x040032A6 RID: 12966
	public HologramScript Holograms;

	// Token: 0x040032A7 RID: 12967
	public Transform Finger;

	// Token: 0x040032A8 RID: 12968
	public bool Updated;
}
