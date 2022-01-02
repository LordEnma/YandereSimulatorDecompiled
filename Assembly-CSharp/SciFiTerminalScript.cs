using System;
using UnityEngine;

// Token: 0x02000412 RID: 1042
public class SciFiTerminalScript : MonoBehaviour
{
	// Token: 0x06001C48 RID: 7240 RVA: 0x00148E66 File Offset: 0x00147066
	private void Start()
	{
		if (this.Student.StudentID != 65)
		{
			base.enabled = false;
			return;
		}
		this.RobotArms = this.Student.StudentManager.RobotArms;
	}

	// Token: 0x06001C49 RID: 7241 RVA: 0x00148E98 File Offset: 0x00147098
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

	// Token: 0x04003234 RID: 12852
	public StudentScript Student;

	// Token: 0x04003235 RID: 12853
	public RobotArmScript RobotArms;

	// Token: 0x04003236 RID: 12854
	public Transform OtherFinger;

	// Token: 0x04003237 RID: 12855
	public bool Updated;
}
