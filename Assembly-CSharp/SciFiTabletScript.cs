using System;
using UnityEngine;

// Token: 0x0200041B RID: 1051
public class SciFiTabletScript : MonoBehaviour
{
	// Token: 0x06001C84 RID: 7300 RVA: 0x0014E2AA File Offset: 0x0014C4AA
	private void Start()
	{
		this.Holograms = this.Student.StudentManager.Holograms;
	}

	// Token: 0x06001C85 RID: 7301 RVA: 0x0014E2C4 File Offset: 0x0014C4C4
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

	// Token: 0x040032CF RID: 13007
	public StudentScript Student;

	// Token: 0x040032D0 RID: 13008
	public HologramScript Holograms;

	// Token: 0x040032D1 RID: 13009
	public Transform Finger;

	// Token: 0x040032D2 RID: 13010
	public bool Updated;
}
