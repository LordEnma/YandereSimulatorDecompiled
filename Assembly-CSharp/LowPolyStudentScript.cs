using System;
using UnityEngine;

// Token: 0x0200035B RID: 859
public class LowPolyStudentScript : MonoBehaviour
{
	// Token: 0x06001992 RID: 6546 RVA: 0x00103CF7 File Offset: 0x00101EF7
	private void Start()
	{
		if (this.Student.StudentManager == null)
		{
			base.enabled = false;
		}
	}

	// Token: 0x06001993 RID: 6547 RVA: 0x00103D14 File Offset: 0x00101F14
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

	// Token: 0x040028EA RID: 10474
	public StudentScript Student;

	// Token: 0x040028EB RID: 10475
	public Renderer TeacherMesh;

	// Token: 0x040028EC RID: 10476
	public Renderer MyMesh;
}
