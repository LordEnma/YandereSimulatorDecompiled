using System;
using UnityEngine;

// Token: 0x0200041A RID: 1050
public class SciFiTabletScript : MonoBehaviour
{
	// Token: 0x06001C7A RID: 7290 RVA: 0x0014DBB6 File Offset: 0x0014BDB6
	private void Start()
	{
		this.Holograms = this.Student.StudentManager.Holograms;
	}

	// Token: 0x06001C7B RID: 7291 RVA: 0x0014DBD0 File Offset: 0x0014BDD0
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

	// Token: 0x040032C1 RID: 12993
	public StudentScript Student;

	// Token: 0x040032C2 RID: 12994
	public HologramScript Holograms;

	// Token: 0x040032C3 RID: 12995
	public Transform Finger;

	// Token: 0x040032C4 RID: 12996
	public bool Updated;
}
