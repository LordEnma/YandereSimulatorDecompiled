using System;
using UnityEngine;

// Token: 0x0200035B RID: 859
public class LowPolyStudentScript : MonoBehaviour
{
	// Token: 0x06001996 RID: 6550 RVA: 0x00103F8B File Offset: 0x0010218B
	private void Start()
	{
		if (this.Student.StudentManager == null)
		{
			base.enabled = false;
		}
	}

	// Token: 0x06001997 RID: 6551 RVA: 0x00103FA8 File Offset: 0x001021A8
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

	// Token: 0x040028F2 RID: 10482
	public StudentScript Student;

	// Token: 0x040028F3 RID: 10483
	public Renderer TeacherMesh;

	// Token: 0x040028F4 RID: 10484
	public Renderer MyMesh;
}
