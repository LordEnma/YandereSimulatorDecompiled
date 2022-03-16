using System;
using UnityEngine;

// Token: 0x02000359 RID: 857
public class LowPolyStudentScript : MonoBehaviour
{
	// Token: 0x06001986 RID: 6534 RVA: 0x0010354B File Offset: 0x0010174B
	private void Start()
	{
		if (this.Student.StudentManager == null)
		{
			base.enabled = false;
		}
	}

	// Token: 0x06001987 RID: 6535 RVA: 0x00103568 File Offset: 0x00101768
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

	// Token: 0x040028D4 RID: 10452
	public StudentScript Student;

	// Token: 0x040028D5 RID: 10453
	public Renderer TeacherMesh;

	// Token: 0x040028D6 RID: 10454
	public Renderer MyMesh;
}
