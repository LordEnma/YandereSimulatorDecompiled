using System;
using UnityEngine;

// Token: 0x0200041F RID: 1055
public class SciFiToolScript : MonoBehaviour
{
	// Token: 0x06001C97 RID: 7319 RVA: 0x0014F8CB File Offset: 0x0014DACB
	private void Start()
	{
		this.Target = this.Student.StudentManager.ToolTarget;
	}

	// Token: 0x06001C98 RID: 7320 RVA: 0x0014F8E3 File Offset: 0x0014DAE3
	private void Update()
	{
		if ((double)Vector3.Distance(this.Tip.position, this.Target.position) < 0.1)
		{
			this.Sparks.Play();
			return;
		}
		this.Sparks.Stop();
	}

	// Token: 0x040032FB RID: 13051
	public StudentScript Student;

	// Token: 0x040032FC RID: 13052
	public ParticleSystem Sparks;

	// Token: 0x040032FD RID: 13053
	public Transform Target;

	// Token: 0x040032FE RID: 13054
	public Transform Tip;
}
