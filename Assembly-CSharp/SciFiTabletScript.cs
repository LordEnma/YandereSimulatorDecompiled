using System;
using UnityEngine;

// Token: 0x02000416 RID: 1046
public class SciFiTabletScript : MonoBehaviour
{
	// Token: 0x06001C63 RID: 7267 RVA: 0x0014C1EE File Offset: 0x0014A3EE
	private void Start()
	{
		this.Holograms = this.Student.StudentManager.Holograms;
	}

	// Token: 0x06001C64 RID: 7268 RVA: 0x0014C208 File Offset: 0x0014A408
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

	// Token: 0x04003271 RID: 12913
	public StudentScript Student;

	// Token: 0x04003272 RID: 12914
	public HologramScript Holograms;

	// Token: 0x04003273 RID: 12915
	public Transform Finger;

	// Token: 0x04003274 RID: 12916
	public bool Updated;
}
