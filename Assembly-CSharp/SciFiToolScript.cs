using System;
using UnityEngine;

// Token: 0x02000416 RID: 1046
public class SciFiToolScript : MonoBehaviour
{
	// Token: 0x06001C55 RID: 7253 RVA: 0x0014AF07 File Offset: 0x00149107
	private void Start()
	{
		this.Target = this.Student.StudentManager.ToolTarget;
	}

	// Token: 0x06001C56 RID: 7254 RVA: 0x0014AF1F File Offset: 0x0014911F
	private void Update()
	{
		if ((double)Vector3.Distance(this.Tip.position, this.Target.position) < 0.1)
		{
			this.Sparks.Play();
			return;
		}
		this.Sparks.Stop();
	}

	// Token: 0x0400324A RID: 12874
	public StudentScript Student;

	// Token: 0x0400324B RID: 12875
	public ParticleSystem Sparks;

	// Token: 0x0400324C RID: 12876
	public Transform Target;

	// Token: 0x0400324D RID: 12877
	public Transform Tip;
}
