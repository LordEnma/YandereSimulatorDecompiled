using System;
using UnityEngine;

// Token: 0x0200041C RID: 1052
public class SciFiTabletScript : MonoBehaviour
{
	// Token: 0x06001C8B RID: 7307 RVA: 0x0014EAE6 File Offset: 0x0014CCE6
	private void Start()
	{
		this.Holograms = this.Student.StudentManager.Holograms;
	}

	// Token: 0x06001C8C RID: 7308 RVA: 0x0014EB00 File Offset: 0x0014CD00
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

	// Token: 0x040032DE RID: 13022
	public StudentScript Student;

	// Token: 0x040032DF RID: 13023
	public HologramScript Holograms;

	// Token: 0x040032E0 RID: 13024
	public Transform Finger;

	// Token: 0x040032E1 RID: 13025
	public bool Updated;
}
