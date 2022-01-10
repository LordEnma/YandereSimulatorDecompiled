using System;
using UnityEngine;

// Token: 0x02000414 RID: 1044
public class SciFiTerminalScript : MonoBehaviour
{
	// Token: 0x06001C4F RID: 7247 RVA: 0x001491DA File Offset: 0x001473DA
	private void Start()
	{
		if (this.Student.StudentID != 65)
		{
			base.enabled = false;
			return;
		}
		this.RobotArms = this.Student.StudentManager.RobotArms;
	}

	// Token: 0x06001C50 RID: 7248 RVA: 0x0014920C File Offset: 0x0014740C
	private void Update()
	{
		if (this.RobotArms != null)
		{
			if ((double)Vector3.Distance(this.RobotArms.TerminalTarget.position, base.transform.position) < 0.3 || (double)Vector3.Distance(this.RobotArms.TerminalTarget.position, this.OtherFinger.position) < 0.3)
			{
				if (!this.Updated)
				{
					this.Updated = true;
					if (!this.RobotArms.On[0])
					{
						this.RobotArms.ActivateArms();
						return;
					}
					this.RobotArms.ToggleWork();
					return;
				}
			}
			else
			{
				this.Updated = false;
			}
		}
	}

	// Token: 0x0400323A RID: 12858
	public StudentScript Student;

	// Token: 0x0400323B RID: 12859
	public RobotArmScript RobotArms;

	// Token: 0x0400323C RID: 12860
	public Transform OtherFinger;

	// Token: 0x0400323D RID: 12861
	public bool Updated;
}
