using System;
using UnityEngine;

// Token: 0x02000413 RID: 1043
public class SciFiToolScript : MonoBehaviour
{
	// Token: 0x06001C49 RID: 7241 RVA: 0x00148B4B File Offset: 0x00146D4B
	private void Start()
	{
		this.Target = this.Student.StudentManager.ToolTarget;
	}

	// Token: 0x06001C4A RID: 7242 RVA: 0x00148B63 File Offset: 0x00146D63
	private void Update()
	{
		if ((double)Vector3.Distance(this.Tip.position, this.Target.position) < 0.1)
		{
			this.Sparks.Play();
			return;
		}
		this.Sparks.Stop();
	}

	// Token: 0x04003231 RID: 12849
	public StudentScript Student;

	// Token: 0x04003232 RID: 12850
	public ParticleSystem Sparks;

	// Token: 0x04003233 RID: 12851
	public Transform Target;

	// Token: 0x04003234 RID: 12852
	public Transform Tip;
}
