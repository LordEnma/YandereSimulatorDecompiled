using System;
using UnityEngine;

// Token: 0x02000357 RID: 855
public class LowPolyStudentScript : MonoBehaviour
{
	// Token: 0x0600196E RID: 6510 RVA: 0x00101DBF File Offset: 0x000FFFBF
	private void Start()
	{
		if (this.Student.StudentManager == null)
		{
			base.enabled = false;
		}
	}

	// Token: 0x0600196F RID: 6511 RVA: 0x00101DDC File Offset: 0x000FFFDC
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

	// Token: 0x04002887 RID: 10375
	public StudentScript Student;

	// Token: 0x04002888 RID: 10376
	public Renderer TeacherMesh;

	// Token: 0x04002889 RID: 10377
	public Renderer MyMesh;
}
