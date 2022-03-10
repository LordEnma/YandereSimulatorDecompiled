using System;
using UnityEngine;

// Token: 0x02000418 RID: 1048
public class SciFiToolScript : MonoBehaviour
{
	// Token: 0x06001C69 RID: 7273 RVA: 0x0014C353 File Offset: 0x0014A553
	private void Start()
	{
		this.Target = this.Student.StudentManager.ToolTarget;
	}

	// Token: 0x06001C6A RID: 7274 RVA: 0x0014C36B File Offset: 0x0014A56B
	private void Update()
	{
		if ((double)Vector3.Distance(this.Tip.position, this.Target.position) < 0.1)
		{
			this.Sparks.Play();
			return;
		}
		this.Sparks.Stop();
	}

	// Token: 0x04003279 RID: 12921
	public StudentScript Student;

	// Token: 0x0400327A RID: 12922
	public ParticleSystem Sparks;

	// Token: 0x0400327B RID: 12923
	public Transform Target;

	// Token: 0x0400327C RID: 12924
	public Transform Tip;
}
