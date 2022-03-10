using System;
using UnityEngine;

// Token: 0x02000359 RID: 857
public class LowPolyStudentScript : MonoBehaviour
{
	// Token: 0x0600197E RID: 6526 RVA: 0x00102BD3 File Offset: 0x00100DD3
	private void Start()
	{
		if (this.Student.StudentManager == null)
		{
			base.enabled = false;
		}
	}

	// Token: 0x0600197F RID: 6527 RVA: 0x00102BF0 File Offset: 0x00100DF0
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

	// Token: 0x040028B2 RID: 10418
	public StudentScript Student;

	// Token: 0x040028B3 RID: 10419
	public Renderer TeacherMesh;

	// Token: 0x040028B4 RID: 10420
	public Renderer MyMesh;
}
