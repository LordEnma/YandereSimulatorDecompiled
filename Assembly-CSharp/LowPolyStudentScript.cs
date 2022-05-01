using System;
using UnityEngine;

// Token: 0x0200035B RID: 859
public class LowPolyStudentScript : MonoBehaviour
{
	// Token: 0x0600199A RID: 6554 RVA: 0x0010448B File Offset: 0x0010268B
	private void Start()
	{
		if (this.Student.StudentManager == null)
		{
			base.enabled = false;
		}
	}

	// Token: 0x0600199B RID: 6555 RVA: 0x001044A8 File Offset: 0x001026A8
	private void Update()
	{
		if ((float)this.Student.StudentManager.LowDetailThreshold > 0f)
		{
			if (this.Student.Prompt.DistanceSqr > (float)this.Student.StudentManager.LowDetailThreshold)
			{
				if (!this.MyMesh.enabled)
				{
					this.Student.MyRenderer.enabled = false;
					this.MyMesh.enabled = true;
					return;
				}
			}
			else if (this.MyMesh.enabled)
			{
				if (!(this.Student.EightiesTeacherAttacher != null) || !this.Student.EightiesTeacherAttacher.activeInHierarchy || this.Student.StudentID == 90)
				{
					this.Student.MyRenderer.enabled = true;
				}
				this.MyMesh.enabled = false;
				return;
			}
		}
		else if (this.MyMesh.enabled)
		{
			this.Student.MyRenderer.enabled = true;
			this.MyMesh.enabled = false;
		}
	}

	// Token: 0x040028FB RID: 10491
	public StudentScript Student;

	// Token: 0x040028FC RID: 10492
	public Renderer TeacherMesh;

	// Token: 0x040028FD RID: 10493
	public Renderer MyMesh;
}
