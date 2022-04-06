using System;
using UnityEngine;

// Token: 0x0200041D RID: 1053
public class SciFiToolScript : MonoBehaviour
{
	// Token: 0x06001C86 RID: 7302 RVA: 0x0014DFFF File Offset: 0x0014C1FF
	private void Start()
	{
		this.Target = this.Student.StudentManager.ToolTarget;
	}

	// Token: 0x06001C87 RID: 7303 RVA: 0x0014E017 File Offset: 0x0014C217
	private void Update()
	{
		if ((double)Vector3.Distance(this.Tip.position, this.Target.position) < 0.1)
		{
			this.Sparks.Play();
			return;
		}
		this.Sparks.Stop();
	}

	// Token: 0x040032CC RID: 13004
	public StudentScript Student;

	// Token: 0x040032CD RID: 13005
	public ParticleSystem Sparks;

	// Token: 0x040032CE RID: 13006
	public Transform Target;

	// Token: 0x040032CF RID: 13007
	public Transform Tip;
}
