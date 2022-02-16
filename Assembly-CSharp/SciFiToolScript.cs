using System;
using UnityEngine;

// Token: 0x02000417 RID: 1047
public class SciFiToolScript : MonoBehaviour
{
	// Token: 0x06001C5E RID: 7262 RVA: 0x0014B39F File Offset: 0x0014959F
	private void Start()
	{
		this.Target = this.Student.StudentManager.ToolTarget;
	}

	// Token: 0x06001C5F RID: 7263 RVA: 0x0014B3B7 File Offset: 0x001495B7
	private void Update()
	{
		if ((double)Vector3.Distance(this.Tip.position, this.Target.position) < 0.1)
		{
			this.Sparks.Play();
			return;
		}
		this.Sparks.Stop();
	}

	// Token: 0x04003253 RID: 12883
	public StudentScript Student;

	// Token: 0x04003254 RID: 12884
	public ParticleSystem Sparks;

	// Token: 0x04003255 RID: 12885
	public Transform Target;

	// Token: 0x04003256 RID: 12886
	public Transform Tip;
}
