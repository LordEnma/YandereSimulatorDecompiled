using System;
using UnityEngine;

// Token: 0x0200041D RID: 1053
public class SciFiTabletScript : MonoBehaviour
{
	// Token: 0x06001C91 RID: 7313 RVA: 0x0014F766 File Offset: 0x0014D966
	private void Start()
	{
		this.Holograms = this.Student.StudentManager.Holograms;
	}

	// Token: 0x06001C92 RID: 7314 RVA: 0x0014F780 File Offset: 0x0014D980
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

	// Token: 0x040032F3 RID: 13043
	public StudentScript Student;

	// Token: 0x040032F4 RID: 13044
	public HologramScript Holograms;

	// Token: 0x040032F5 RID: 13045
	public Transform Finger;

	// Token: 0x040032F6 RID: 13046
	public bool Updated;
}
