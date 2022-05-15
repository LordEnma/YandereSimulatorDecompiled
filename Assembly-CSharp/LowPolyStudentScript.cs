using System;
using UnityEngine;

// Token: 0x0200035C RID: 860
public class LowPolyStudentScript : MonoBehaviour
{
	// Token: 0x060019A0 RID: 6560 RVA: 0x00104C93 File Offset: 0x00102E93
	private void Start()
	{
		if (this.Student.StudentManager == null)
		{
			base.enabled = false;
		}
	}

	// Token: 0x060019A1 RID: 6561 RVA: 0x00104CB0 File Offset: 0x00102EB0
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

	// Token: 0x0400290C RID: 10508
	public StudentScript Student;

	// Token: 0x0400290D RID: 10509
	public Renderer TeacherMesh;

	// Token: 0x0400290E RID: 10510
	public Renderer MyMesh;
}
