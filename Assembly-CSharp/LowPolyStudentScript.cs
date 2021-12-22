using System;
using UnityEngine;

// Token: 0x02000356 RID: 854
public class LowPolyStudentScript : MonoBehaviour
{
	// Token: 0x06001965 RID: 6501 RVA: 0x00101037 File Offset: 0x000FF237
	private void Start()
	{
		if (this.Student.StudentManager == null)
		{
			base.enabled = false;
		}
	}

	// Token: 0x06001966 RID: 6502 RVA: 0x00101054 File Offset: 0x000FF254
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

	// Token: 0x04002872 RID: 10354
	public StudentScript Student;

	// Token: 0x04002873 RID: 10355
	public Renderer TeacherMesh;

	// Token: 0x04002874 RID: 10356
	public Renderer MyMesh;
}
