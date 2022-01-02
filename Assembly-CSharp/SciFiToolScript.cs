using System;
using UnityEngine;

// Token: 0x02000413 RID: 1043
public class SciFiToolScript : MonoBehaviour
{
	// Token: 0x06001C4B RID: 7243 RVA: 0x00148F53 File Offset: 0x00147153
	private void Start()
	{
		this.Target = this.Student.StudentManager.ToolTarget;
	}

	// Token: 0x06001C4C RID: 7244 RVA: 0x00148F6B File Offset: 0x0014716B
	private void Update()
	{
		if ((double)Vector3.Distance(this.Tip.position, this.Target.position) < 0.1)
		{
			this.Sparks.Play();
			return;
		}
		this.Sparks.Stop();
	}

	// Token: 0x04003238 RID: 12856
	public StudentScript Student;

	// Token: 0x04003239 RID: 12857
	public ParticleSystem Sparks;

	// Token: 0x0400323A RID: 12858
	public Transform Target;

	// Token: 0x0400323B RID: 12859
	public Transform Tip;
}
