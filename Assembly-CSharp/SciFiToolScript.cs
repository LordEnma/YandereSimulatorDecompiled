using System;
using UnityEngine;

// Token: 0x02000416 RID: 1046
public class SciFiToolScript : MonoBehaviour
{
	// Token: 0x06001C55 RID: 7253 RVA: 0x0014AE03 File Offset: 0x00149003
	private void Start()
	{
		this.Target = this.Student.StudentManager.ToolTarget;
	}

	// Token: 0x06001C56 RID: 7254 RVA: 0x0014AE1B File Offset: 0x0014901B
	private void Update()
	{
		if ((double)Vector3.Distance(this.Tip.position, this.Target.position) < 0.1)
		{
			this.Sparks.Play();
			return;
		}
		this.Sparks.Stop();
	}

	// Token: 0x04003249 RID: 12873
	public StudentScript Student;

	// Token: 0x0400324A RID: 12874
	public ParticleSystem Sparks;

	// Token: 0x0400324B RID: 12875
	public Transform Target;

	// Token: 0x0400324C RID: 12876
	public Transform Tip;
}
