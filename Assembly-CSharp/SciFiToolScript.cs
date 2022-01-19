using System;
using UnityEngine;

// Token: 0x02000416 RID: 1046
public class SciFiToolScript : MonoBehaviour
{
	// Token: 0x06001C54 RID: 7252 RVA: 0x0014A9CF File Offset: 0x00148BCF
	private void Start()
	{
		this.Target = this.Student.StudentManager.ToolTarget;
	}

	// Token: 0x06001C55 RID: 7253 RVA: 0x0014A9E7 File Offset: 0x00148BE7
	private void Update()
	{
		if ((double)Vector3.Distance(this.Tip.position, this.Target.position) < 0.1)
		{
			this.Sparks.Play();
			return;
		}
		this.Sparks.Stop();
	}

	// Token: 0x04003243 RID: 12867
	public StudentScript Student;

	// Token: 0x04003244 RID: 12868
	public ParticleSystem Sparks;

	// Token: 0x04003245 RID: 12869
	public Transform Target;

	// Token: 0x04003246 RID: 12870
	public Transform Tip;
}
