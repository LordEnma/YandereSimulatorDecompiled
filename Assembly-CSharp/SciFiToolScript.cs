using System;
using UnityEngine;

// Token: 0x0200041E RID: 1054
public class SciFiToolScript : MonoBehaviour
{
	// Token: 0x06001C91 RID: 7313 RVA: 0x0014EC17 File Offset: 0x0014CE17
	private void Start()
	{
		this.Target = this.Student.StudentManager.ToolTarget;
	}

	// Token: 0x06001C92 RID: 7314 RVA: 0x0014EC2F File Offset: 0x0014CE2F
	private void Update()
	{
		if ((double)Vector3.Distance(this.Tip.position, this.Target.position) < 0.1)
		{
			this.Sparks.Play();
			return;
		}
		this.Sparks.Stop();
	}

	// Token: 0x040032E6 RID: 13030
	public StudentScript Student;

	// Token: 0x040032E7 RID: 13031
	public ParticleSystem Sparks;

	// Token: 0x040032E8 RID: 13032
	public Transform Target;

	// Token: 0x040032E9 RID: 13033
	public Transform Tip;
}
