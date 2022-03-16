using System;
using UnityEngine;

// Token: 0x02000419 RID: 1049
public class SciFiToolScript : MonoBehaviour
{
	// Token: 0x06001C76 RID: 7286 RVA: 0x0014D1F7 File Offset: 0x0014B3F7
	private void Start()
	{
		this.Target = this.Student.StudentManager.ToolTarget;
	}

	// Token: 0x06001C77 RID: 7287 RVA: 0x0014D20F File Offset: 0x0014B40F
	private void Update()
	{
		if ((double)Vector3.Distance(this.Tip.position, this.Target.position) < 0.1)
		{
			this.Sparks.Play();
			return;
		}
		this.Sparks.Stop();
	}

	// Token: 0x040032AD RID: 12973
	public StudentScript Student;

	// Token: 0x040032AE RID: 12974
	public ParticleSystem Sparks;

	// Token: 0x040032AF RID: 12975
	public Transform Target;

	// Token: 0x040032B0 RID: 12976
	public Transform Tip;
}
