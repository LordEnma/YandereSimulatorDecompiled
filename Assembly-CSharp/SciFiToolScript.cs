using System;
using UnityEngine;

// Token: 0x02000412 RID: 1042
public class SciFiToolScript : MonoBehaviour
{
	// Token: 0x06001C41 RID: 7233 RVA: 0x0014826F File Offset: 0x0014646F
	private void Start()
	{
		this.Target = this.Student.StudentManager.ToolTarget;
	}

	// Token: 0x06001C42 RID: 7234 RVA: 0x00148287 File Offset: 0x00146487
	private void Update()
	{
		if ((double)Vector3.Distance(this.Tip.position, this.Target.position) < 0.1)
		{
			this.Sparks.Play();
			return;
		}
		this.Sparks.Stop();
	}

	// Token: 0x04003206 RID: 12806
	public StudentScript Student;

	// Token: 0x04003207 RID: 12807
	public ParticleSystem Sparks;

	// Token: 0x04003208 RID: 12808
	public Transform Target;

	// Token: 0x04003209 RID: 12809
	public Transform Tip;
}
