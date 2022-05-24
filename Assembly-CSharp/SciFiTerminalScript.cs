using System;
using UnityEngine;

// Token: 0x0200041E RID: 1054
public class SciFiTerminalScript : MonoBehaviour
{
	// Token: 0x06001C95 RID: 7317 RVA: 0x0014FA9A File Offset: 0x0014DC9A
	private void Start()
	{
		if (this.Student.StudentID != 65)
		{
			base.enabled = false;
			return;
		}
		this.RobotArms = this.Student.StudentManager.RobotArms;
	}

	// Token: 0x06001C96 RID: 7318 RVA: 0x0014FACC File Offset: 0x0014DCCC
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

	// Token: 0x040032FF RID: 13055
	public StudentScript Student;

	// Token: 0x04003300 RID: 13056
	public RobotArmScript RobotArms;

	// Token: 0x04003301 RID: 13057
	public Transform OtherFinger;

	// Token: 0x04003302 RID: 13058
	public bool Updated;
}
