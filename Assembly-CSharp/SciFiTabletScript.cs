using System;
using UnityEngine;

// Token: 0x02000411 RID: 1041
public class SciFiTabletScript : MonoBehaviour
{
	// Token: 0x06001C43 RID: 7235 RVA: 0x001489E6 File Offset: 0x00146BE6
	private void Start()
	{
		this.Holograms = this.Student.StudentManager.Holograms;
	}

	// Token: 0x06001C44 RID: 7236 RVA: 0x00148A00 File Offset: 0x00146C00
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

	// Token: 0x04003229 RID: 12841
	public StudentScript Student;

	// Token: 0x0400322A RID: 12842
	public HologramScript Holograms;

	// Token: 0x0400322B RID: 12843
	public Transform Finger;

	// Token: 0x0400322C RID: 12844
	public bool Updated;
}
