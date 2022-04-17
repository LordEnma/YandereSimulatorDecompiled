using System;
using UnityEngine;

// Token: 0x0200041D RID: 1053
public class SciFiToolScript : MonoBehaviour
{
	// Token: 0x06001C8A RID: 7306 RVA: 0x0014E40F File Offset: 0x0014C60F
	private void Start()
	{
		this.Target = this.Student.StudentManager.ToolTarget;
	}

	// Token: 0x06001C8B RID: 7307 RVA: 0x0014E427 File Offset: 0x0014C627
	private void Update()
	{
		if ((double)Vector3.Distance(this.Tip.position, this.Target.position) < 0.1)
		{
			this.Sparks.Play();
			return;
		}
		this.Sparks.Stop();
	}

	// Token: 0x040032D7 RID: 13015
	public StudentScript Student;

	// Token: 0x040032D8 RID: 13016
	public ParticleSystem Sparks;

	// Token: 0x040032D9 RID: 13017
	public Transform Target;

	// Token: 0x040032DA RID: 13018
	public Transform Tip;
}
