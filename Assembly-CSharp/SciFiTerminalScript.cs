using System;
using UnityEngine;

// Token: 0x02000415 RID: 1045
public class SciFiTerminalScript : MonoBehaviour
{
	// Token: 0x06001C51 RID: 7249 RVA: 0x0014A8E2 File Offset: 0x00148AE2
	private void Start()
	{
		if (this.Student.StudentID != 65)
		{
			base.enabled = false;
			return;
		}
		this.RobotArms = this.Student.StudentManager.RobotArms;
	}

	// Token: 0x06001C52 RID: 7250 RVA: 0x0014A914 File Offset: 0x00148B14
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

	// Token: 0x0400323F RID: 12863
	public StudentScript Student;

	// Token: 0x04003240 RID: 12864
	public RobotArmScript RobotArms;

	// Token: 0x04003241 RID: 12865
	public Transform OtherFinger;

	// Token: 0x04003242 RID: 12866
	public bool Updated;
}
