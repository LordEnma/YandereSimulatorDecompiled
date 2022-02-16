using System;
using UnityEngine;

// Token: 0x02000358 RID: 856
public class LowPolyStudentScript : MonoBehaviour
{
	// Token: 0x06001975 RID: 6517 RVA: 0x00101F63 File Offset: 0x00100163
	private void Start()
	{
		if (this.Student.StudentManager == null)
		{
			base.enabled = false;
		}
	}

	// Token: 0x06001976 RID: 6518 RVA: 0x00101F80 File Offset: 0x00100180
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

	// Token: 0x0400288D RID: 10381
	public StudentScript Student;

	// Token: 0x0400288E RID: 10382
	public Renderer TeacherMesh;

	// Token: 0x0400288F RID: 10383
	public Renderer MyMesh;
}
