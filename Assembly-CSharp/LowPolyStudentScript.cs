using System;
using UnityEngine;

// Token: 0x02000355 RID: 853
public class LowPolyStudentScript : MonoBehaviour
{
	// Token: 0x0600195E RID: 6494 RVA: 0x00100817 File Offset: 0x000FEA17
	private void Start()
	{
		if (this.Student.StudentManager == null)
		{
			base.enabled = false;
		}
	}

	// Token: 0x0600195F RID: 6495 RVA: 0x00100834 File Offset: 0x000FEA34
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
				this.Student.MyRenderer.enabled = true;
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

	// Token: 0x0400284D RID: 10317
	public StudentScript Student;

	// Token: 0x0400284E RID: 10318
	public Renderer TeacherMesh;

	// Token: 0x0400284F RID: 10319
	public Renderer MyMesh;
}
