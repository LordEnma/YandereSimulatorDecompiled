using System;
using UnityEngine;

// Token: 0x0200035C RID: 860
public class LowPolyStudentScript : MonoBehaviour
{
	// Token: 0x060019A1 RID: 6561 RVA: 0x00104E97 File Offset: 0x00103097
	private void Start()
	{
		if (this.Student.StudentManager == null)
		{
			base.enabled = false;
		}
	}

	// Token: 0x060019A2 RID: 6562 RVA: 0x00104EB4 File Offset: 0x001030B4
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

	// Token: 0x04002913 RID: 10515
	public StudentScript Student;

	// Token: 0x04002914 RID: 10516
	public Renderer TeacherMesh;

	// Token: 0x04002915 RID: 10517
	public Renderer MyMesh;
}
