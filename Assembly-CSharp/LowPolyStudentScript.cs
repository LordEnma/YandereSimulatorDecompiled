using System;
using UnityEngine;

// Token: 0x02000357 RID: 855
public class LowPolyStudentScript : MonoBehaviour
{
	// Token: 0x0600196C RID: 6508 RVA: 0x00101BF7 File Offset: 0x000FFDF7
	private void Start()
	{
		if (this.Student.StudentManager == null)
		{
			base.enabled = false;
		}
	}

	// Token: 0x0600196D RID: 6509 RVA: 0x00101C14 File Offset: 0x000FFE14
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

	// Token: 0x04002883 RID: 10371
	public StudentScript Student;

	// Token: 0x04002884 RID: 10372
	public Renderer TeacherMesh;

	// Token: 0x04002885 RID: 10373
	public Renderer MyMesh;
}
