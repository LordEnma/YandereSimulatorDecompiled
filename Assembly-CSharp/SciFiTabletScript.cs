using System;
using UnityEngine;

// Token: 0x02000416 RID: 1046
public class SciFiTabletScript : MonoBehaviour
{
	// Token: 0x06001C61 RID: 7265 RVA: 0x0014BCB2 File Offset: 0x00149EB2
	private void Start()
	{
		this.Holograms = this.Student.StudentManager.Holograms;
	}

	// Token: 0x06001C62 RID: 7266 RVA: 0x0014BCCC File Offset: 0x00149ECC
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

	// Token: 0x0400325B RID: 12891
	public StudentScript Student;

	// Token: 0x0400325C RID: 12892
	public HologramScript Holograms;

	// Token: 0x0400325D RID: 12893
	public Transform Finger;

	// Token: 0x0400325E RID: 12894
	public bool Updated;
}
