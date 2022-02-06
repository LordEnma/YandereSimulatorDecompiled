using System;
using UnityEngine;

// Token: 0x02000416 RID: 1046
public class SciFiToolScript : MonoBehaviour
{
	// Token: 0x06001C57 RID: 7255 RVA: 0x0014B09F File Offset: 0x0014929F
	private void Start()
	{
		this.Target = this.Student.StudentManager.ToolTarget;
	}

	// Token: 0x06001C58 RID: 7256 RVA: 0x0014B0B7 File Offset: 0x001492B7
	private void Update()
	{
		if ((double)Vector3.Distance(this.Tip.position, this.Target.position) < 0.1)
		{
			this.Sparks.Play();
			return;
		}
		this.Sparks.Stop();
	}

	// Token: 0x0400324D RID: 12877
	public StudentScript Student;

	// Token: 0x0400324E RID: 12878
	public ParticleSystem Sparks;

	// Token: 0x0400324F RID: 12879
	public Transform Target;

	// Token: 0x04003250 RID: 12880
	public Transform Tip;
}
