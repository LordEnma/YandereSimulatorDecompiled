using System;
using UnityEngine;

// Token: 0x02000411 RID: 1041
public class SciFiTabletScript : MonoBehaviour
{
	// Token: 0x06001C45 RID: 7237 RVA: 0x00148DEE File Offset: 0x00146FEE
	private void Start()
	{
		this.Holograms = this.Student.StudentManager.Holograms;
	}

	// Token: 0x06001C46 RID: 7238 RVA: 0x00148E08 File Offset: 0x00147008
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

	// Token: 0x04003230 RID: 12848
	public StudentScript Student;

	// Token: 0x04003231 RID: 12849
	public HologramScript Holograms;

	// Token: 0x04003232 RID: 12850
	public Transform Finger;

	// Token: 0x04003233 RID: 12851
	public bool Updated;
}
