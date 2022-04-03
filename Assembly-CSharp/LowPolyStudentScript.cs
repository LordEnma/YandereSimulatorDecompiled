using System;
using UnityEngine;

// Token: 0x0200035A RID: 858
public class LowPolyStudentScript : MonoBehaviour
{
	// Token: 0x0600198C RID: 6540 RVA: 0x00103BF7 File Offset: 0x00101DF7
	private void Start()
	{
		if (this.Student.StudentManager == null)
		{
			base.enabled = false;
		}
	}

	// Token: 0x0600198D RID: 6541 RVA: 0x00103C14 File Offset: 0x00101E14
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

	// Token: 0x040028E7 RID: 10471
	public StudentScript Student;

	// Token: 0x040028E8 RID: 10472
	public Renderer TeacherMesh;

	// Token: 0x040028E9 RID: 10473
	public Renderer MyMesh;
}
