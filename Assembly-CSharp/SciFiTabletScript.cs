using System;
using UnityEngine;

// Token: 0x0200041D RID: 1053
public class SciFiTabletScript : MonoBehaviour
{
	// Token: 0x06001C92 RID: 7314 RVA: 0x0014FA22 File Offset: 0x0014DC22
	private void Start()
	{
		this.Holograms = this.Student.StudentManager.Holograms;
	}

	// Token: 0x06001C93 RID: 7315 RVA: 0x0014FA3C File Offset: 0x0014DC3C
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

	// Token: 0x040032FB RID: 13051
	public StudentScript Student;

	// Token: 0x040032FC RID: 13052
	public HologramScript Holograms;

	// Token: 0x040032FD RID: 13053
	public Transform Finger;

	// Token: 0x040032FE RID: 13054
	public bool Updated;
}
