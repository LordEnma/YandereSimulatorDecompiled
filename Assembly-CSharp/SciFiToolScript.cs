using System;
using UnityEngine;

// Token: 0x02000418 RID: 1048
public class SciFiToolScript : MonoBehaviour
{
	// Token: 0x06001C67 RID: 7271 RVA: 0x0014BE17 File Offset: 0x0014A017
	private void Start()
	{
		this.Target = this.Student.StudentManager.ToolTarget;
	}

	// Token: 0x06001C68 RID: 7272 RVA: 0x0014BE2F File Offset: 0x0014A02F
	private void Update()
	{
		if ((double)Vector3.Distance(this.Tip.position, this.Target.position) < 0.1)
		{
			this.Sparks.Play();
			return;
		}
		this.Sparks.Stop();
	}

	// Token: 0x04003263 RID: 12899
	public StudentScript Student;

	// Token: 0x04003264 RID: 12900
	public ParticleSystem Sparks;

	// Token: 0x04003265 RID: 12901
	public Transform Target;

	// Token: 0x04003266 RID: 12902
	public Transform Tip;
}
