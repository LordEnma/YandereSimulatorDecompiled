using System;
using UnityEngine;

// Token: 0x0200041F RID: 1055
public class SciFiToolScript : MonoBehaviour
{
	// Token: 0x06001C98 RID: 7320 RVA: 0x0014FB87 File Offset: 0x0014DD87
	private void Start()
	{
		this.Target = this.Student.StudentManager.ToolTarget;
	}

	// Token: 0x06001C99 RID: 7321 RVA: 0x0014FB9F File Offset: 0x0014DD9F
	private void Update()
	{
		if ((double)Vector3.Distance(this.Tip.position, this.Target.position) < 0.1)
		{
			this.Sparks.Play();
			return;
		}
		this.Sparks.Stop();
	}

	// Token: 0x04003303 RID: 13059
	public StudentScript Student;

	// Token: 0x04003304 RID: 13060
	public ParticleSystem Sparks;

	// Token: 0x04003305 RID: 13061
	public Transform Target;

	// Token: 0x04003306 RID: 13062
	public Transform Tip;
}
