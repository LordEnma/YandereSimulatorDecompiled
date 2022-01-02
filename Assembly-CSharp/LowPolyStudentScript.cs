using System;
using UnityEngine;

// Token: 0x02000356 RID: 854
public class LowPolyStudentScript : MonoBehaviour
{
	// Token: 0x06001967 RID: 6503 RVA: 0x001012F7 File Offset: 0x000FF4F7
	private void Start()
	{
		if (this.Student.StudentManager == null)
		{
			base.enabled = false;
		}
	}

	// Token: 0x06001968 RID: 6504 RVA: 0x00101314 File Offset: 0x000FF514
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

	// Token: 0x04002876 RID: 10358
	public StudentScript Student;

	// Token: 0x04002877 RID: 10359
	public Renderer TeacherMesh;

	// Token: 0x04002878 RID: 10360
	public Renderer MyMesh;
}
