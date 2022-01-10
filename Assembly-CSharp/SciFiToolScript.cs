using System;
using UnityEngine;

// Token: 0x02000415 RID: 1045
public class SciFiToolScript : MonoBehaviour
{
	// Token: 0x06001C52 RID: 7250 RVA: 0x001492C7 File Offset: 0x001474C7
	private void Start()
	{
		this.Target = this.Student.StudentManager.ToolTarget;
	}

	// Token: 0x06001C53 RID: 7251 RVA: 0x001492DF File Offset: 0x001474DF
	private void Update()
	{
		if ((double)Vector3.Distance(this.Tip.position, this.Target.position) < 0.1)
		{
			this.Sparks.Play();
			return;
		}
		this.Sparks.Stop();
	}

	// Token: 0x0400323E RID: 12862
	public StudentScript Student;

	// Token: 0x0400323F RID: 12863
	public ParticleSystem Sparks;

	// Token: 0x04003240 RID: 12864
	public Transform Target;

	// Token: 0x04003241 RID: 12865
	public Transform Tip;
}
