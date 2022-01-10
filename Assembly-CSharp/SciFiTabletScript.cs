using System;
using UnityEngine;

// Token: 0x02000413 RID: 1043
public class SciFiTabletScript : MonoBehaviour
{
	// Token: 0x06001C4C RID: 7244 RVA: 0x00149162 File Offset: 0x00147362
	private void Start()
	{
		this.Holograms = this.Student.StudentManager.Holograms;
	}

	// Token: 0x06001C4D RID: 7245 RVA: 0x0014917C File Offset: 0x0014737C
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

	// Token: 0x04003236 RID: 12854
	public StudentScript Student;

	// Token: 0x04003237 RID: 12855
	public HologramScript Holograms;

	// Token: 0x04003238 RID: 12856
	public Transform Finger;

	// Token: 0x04003239 RID: 12857
	public bool Updated;
}
