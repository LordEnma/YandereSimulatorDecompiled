using System;
using UnityEngine;

// Token: 0x0200041C RID: 1052
public class SciFiToolScript : MonoBehaviour
{
	// Token: 0x06001C80 RID: 7296 RVA: 0x0014DD1B File Offset: 0x0014BF1B
	private void Start()
	{
		this.Target = this.Student.StudentManager.ToolTarget;
	}

	// Token: 0x06001C81 RID: 7297 RVA: 0x0014DD33 File Offset: 0x0014BF33
	private void Update()
	{
		if ((double)Vector3.Distance(this.Tip.position, this.Target.position) < 0.1)
		{
			this.Sparks.Play();
			return;
		}
		this.Sparks.Stop();
	}

	// Token: 0x040032C9 RID: 13001
	public StudentScript Student;

	// Token: 0x040032CA RID: 13002
	public ParticleSystem Sparks;

	// Token: 0x040032CB RID: 13003
	public Transform Target;

	// Token: 0x040032CC RID: 13004
	public Transform Tip;
}
